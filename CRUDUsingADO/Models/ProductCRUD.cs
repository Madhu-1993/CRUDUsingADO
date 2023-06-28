using System.Data.SqlClient;

namespace CRUDUsingADO.Models
{
    public class ProductCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public ProductCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DbConnection"));
        }
        // list
        public List<prod> GetProducts()
        {
            List<prod> list = new List<prod>();
            string qry = "select * from prod";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    prod product = new prod();
                    product.p_id = Convert.ToInt32(dr["p_id"]);
                    product.p_name = dr["p_name"].ToString();
                    product.company = dr["company"].ToString();
                    product.price = Convert.ToInt32(dr["price"]);

                    list.Add(product);
                }
            }
            con.Close();
            return list;
        }
        // display single value against id
        public prod GetProductById(int id)
        {
            prod product = new prod();
            string qry = "select * from prod where p_id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    product.p_id = Convert.ToInt32(dr["p_id"]);
                    product.p_name = dr["p_name"].ToString();
                    product.company = dr["company"].ToString();
                    product.price = Convert.ToInt32(dr["price"]);
                }
            }
            con.Close();
            return product;
        }
        // add
        public int AddProduct(prod product)
        {
            int result = 0;
            string qry = "insert into prod values(@name,@company,@price)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", product.p_name);
            cmd.Parameters.AddWithValue("@company", product.company);
            cmd.Parameters.AddWithValue("@price", product.price);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        // edit
        public int EditProduct(prod product)
        {
            int result = 0;
            string qry = "update prod set p_name=@name,company=@company,price=@price where p_id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", product.p_name);
            cmd.Parameters.AddWithValue("@company", product.company);
            cmd.Parameters.AddWithValue("@price", product.price);
            cmd.Parameters.AddWithValue("@id", product.p_id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        // delete
        public int DeleteProduct(int id)
        {
            int result = 0;
            string qry = "delete from prod where p_id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
       
    }
}
