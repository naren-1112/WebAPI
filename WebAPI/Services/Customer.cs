using System.Data;
using System.Data.SqlClient;
using WebAPI.Models;
using Microsoft.Extensions.Configuration;

namespace WebAPI.Services
{
    public class Customer : ICustomer
    {
        SqlDataAdapter adapter = null;
        private readonly IConfiguration _configuration;
        public Customer(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        public DataTable AllData()
        {
            string connection = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            SqlConnection con = new SqlConnection(connection);
            var query = "SELECT * FROM BOOKS";
            con.Open();
            DataSet ds = new DataSet();
            adapter = new SqlDataAdapter(query, con);
            //adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(ds);

            Console.WriteLine($"SyncData :sync is going on...");
            return ds.Tables[0];
        }


        public  void AddBooks(Books book)
        {
            try
            {
                string connection = _configuration.GetValue<string>("connectionstrings:defaultconnection");
                var query = "INSERT INTO BOOKS(BookID,Name,Author) VALUES(@BookID,@Name,@Author)";
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("BookID", book.BookID);
                    cmd.Parameters.AddWithValue("Name", book.Name);
                    cmd.Parameters.AddWithValue("Author", book.Author);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
            }
            Console.WriteLine($"updateddatabase :updating the database is in process...");
        }

        public List<Books> GetBooks()
        {
            DataTable books = AllData();
            return (from DataRow dr in books.Rows
                    select new Books()
                    {
                        BookID = Convert.ToInt32(dr["BookID"]),
                        Name = dr["Name"].ToString(),
                        Author = dr["Author"].ToString()

                    }).ToList();
        }

        public bool Delete(int ID)
        {
            int p;
            try
            {
                string connection = _configuration.GetValue<string>("connectionstrings:defaultconnection");
            
                SqlConnection con = new SqlConnection(connection);
                con.Open();
               
               
            
                using (SqlCommand cmd = new SqlCommand($"DELETE FROM BOOKS WHERE BookID={ID}", con))
                {
                    p = cmd.ExecuteNonQuery();

                }
                if (p == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception)
            {
                return false;
            }
            Console.WriteLine($"UpdatedDatabase :Updating the database is in process...");
        }
    }
    }
