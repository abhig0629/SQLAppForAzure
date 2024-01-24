using SQLAppForAzure.Models;
using System.Data.SqlClient;

namespace SQLAppForAzure.Services
{
    public class ProductService
    {
        private static string db_source = "abhiappdbserver001.database.windows.net";
        private static string db_database = "AbhiAppDB001";
        private static string db_user = "sqladmin";
        private static string db_passwd = "Abhi1234!@#$";

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_passwd;
            _builder.InitialCatalog = db_database;

            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Product> GetProducts() 
        { 
            SqlConnection con = GetConnection();

            List<Product> _product_list = new List<Product>();

            string sqlQuery = "SELECT ProductID,ProductName,Quantity from Products";

            con.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, con);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read()) 
                {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };

                    _product_list.Add(product);
                }
            }
            con.Close();
            return _product_list;
        }
    }
}
