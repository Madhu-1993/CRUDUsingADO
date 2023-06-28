using System.Data.SqlClient;

namespace CRUDUsingADO.Models
{
    public class StudentCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;

        public StudentCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DbConnection"));
        }
        //list

        public List<Student> GetAllStudents()
        {
            List<Student> list = new List<Student>();
            string qry = "select*from Student";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student student = new Student();
                    student.Rollno = Convert.ToInt32(dr["rollno"]);
                    student.Sname = dr["sname"].ToString();
                    student.Branch = dr["branch"].ToString();
                    student.Fees = Convert.ToInt32(dr["fees"]);
                    list.Add(student);
                }
            }
            con.Close();
            return list;
        }
        //display single value against id
        public Student GetStudentById(int rollno)
        {
            Student student = new Student();
            string qry = "select*from Student where rollno=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", rollno);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    student.Rollno = Convert.ToInt32(dr["rollno"]);
                    student.Sname = dr["sname"].ToString();
                    student.Branch = dr["branch"].ToString();
                    student.Fees = Convert.ToInt32(dr["fees"]);
                }
            }
            con.Close();
            return student;
        }
        //add
        public int AddStudent(Student student)
        {
            int result = 0;
            string qry = "insert into Student values(@sname,@branch,@fees)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@sname", student.Sname);
            cmd.Parameters.AddWithValue("@branch", student.Branch);
            cmd.Parameters.AddWithValue("@fees", student.Fees);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        //edit
        public int EditStudent(Student student)
        {
            int result = 0;
            string qry = "update Student set sname=@sname,branch=@branch,fees=@fees";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@sname", student.Sname);
            cmd.Parameters.AddWithValue("@branch", student.Branch);
            cmd.Parameters.AddWithValue("@fees", student.Fees);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        //delete
        
        public int DeleteStudent(int rollno)
        {
            int result = 0;
            string qry = "delete from Student where rollno=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id",rollno);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        

    }
}
