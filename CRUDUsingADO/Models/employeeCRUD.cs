using System.Data.SqlClient;

namespace CRUDUsingADO.Models
{
    public class employeeCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public readonly IConfiguration configuration;
        public employeeCRUD( IConfiguration configuration )
        {
            this.configuration= configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DbConnection"));
        }

        //list
        public List<employee> GetEmployees()
        {
            List<employee> list = new List<employee>();
            string qry = "select*from employee";
            cmd=new SqlCommand(qry, con);
            con.Open();
            dr=cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while(dr.Read())
                {
                    employee emp=new employee();
                    emp.Eid = Convert.ToInt32(dr["eid"]);
                    emp.Ename = dr["ename"].ToString();
                    emp.Dept = dr["dept"].ToString();
                    emp.Salary = Convert.ToInt32(dr["salary"]);

                    list.Add(emp);
                }
            }
            con.Close();
            return list;
        }
        //displaye single value against id
        public employee GetEmployeeById(int eid)
        {
            employee emp = new employee();
            string qry = "select*from employee where eid=@id";
            cmd=new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", eid);
            con.Open();
            dr=cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while(dr.Read())
                {
                    emp.Eid = Convert.ToInt32(dr["eid"]);
                    emp.Ename = dr["ename"].ToString();
                    emp.Dept = dr["dept"].ToString();
                    emp.Salary = Convert.ToInt32(dr["salary"]);
                }
            }
            con.Close();
            return emp;
        }

        //add
        public int AddEmployee(employee emp)
        {
            int result = 0;
            string qry = "insert into Product values(@ename,@dept,@salary)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@ename", emp.Ename);
            cmd.Parameters.AddWithValue("@dept", emp.Dept);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            con.Open();
            result = cmd.ExecuteNonQuery();
            return result;
        }
        //edit
        public int EditEmployee(employee emp)
        {
            int result = 0;
            string qry = "Update Product set ename=@ename,dept=@dept,salaey=@salary";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@ename", emp.Ename);
            cmd.Parameters.AddWithValue("@dept", emp.Dept);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            cmd.Parameters.AddWithValue("@eid", emp.Eid);

            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        //delete
        public int DeleteEmployee(int eid)
        {
            int result = 0;
            string qry = "delete from employee eid=@eid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@eid", eid);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
