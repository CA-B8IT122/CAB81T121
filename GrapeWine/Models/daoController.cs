using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.Helpers;
using System.Web.UI.WebControls;
using GrapeWine.Models;

namespace GrapeWine.Controllers
{
    public class DAO : Controller
    {

        SqlConnection con = new SqlConnection();
        public string message = "";

        // GET: dao


        public DAO()
        {
            con = new SqlConnection(WebConfigurationManager.ConnectionStrings["GrapeWineConnection"].ConnectionString);
        }

        public int InsertProduct(Product products)
        {
            int count = 0;
            string message = "";
            SqlCommand cmd = new SqlCommand("usp_InsertProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@ProductID", products.ProductID);
            cmd.Parameters.AddWithValue("@ProductName", products.ProductName);
            cmd.Parameters.AddWithValue("@ProductCountry", products.ProductCountry);
            cmd.Parameters.AddWithValue("@ProductType", products.ProductType);
            cmd.Parameters.AddWithValue("@ProductDescription", products.ProductDescription);
            cmd.Parameters.AddWithValue("@Grape", products.Grape);
            cmd.Parameters.AddWithValue("@IMageSrc", products.ImageSrc);
            cmd.Parameters.AddWithValue("@Price", products.Price);

            try
            {
                con.Open();

                count = cmd.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                message = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return count;
        }

        public List<Product> ShowAllProducts()
        {
            SqlDataReader reader;
            List<Product> products_list = new List<Product>();

            SqlCommand sql = new SqlCommand("usp_ShowAllProducts", con);

            sql.CommandType = CommandType.StoredProcedure;

            try
            {

                con.Open();
                reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    Product products = new Product();


                    products.ProductID = Convert.ToInt32(reader[0].ToString());
                    products.ProductName = reader[1].ToString();
                    products.ProductCountry = reader[2].ToString();
                    products.ProductType = reader[3].ToString();
                    products.ProductDescription = reader[4].ToString();
                    products.Grape = reader[5].ToString();
                    products.ImageSrc = reader[6].ToString();
                    products.Price = Convert.ToInt32(reader[7].ToString());


                    products_list.Add(products);
                }
            }
            catch (SystemException ex)
            {
                message = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return products_list;

        }

        public int InsertCustomer(Customer cust)
        {
            int count = 0;
            string message = "";
            string password;
            SqlCommand cmd = new SqlCommand("usp_Insert_Customer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Email", cust.Email);
            cmd.Parameters.AddWithValue("@Name", cust.CustName);
            cmd.Parameters.AddWithValue("@StreetAddress", cust.StreetAddress);
            cmd.Parameters.AddWithValue("@City", cust.City);
            password = Crypto.HashPassword(cust.Password);
            cmd.Parameters.AddWithValue("@Password", cust.Password);
            cmd.Parameters.AddWithValue("@Phone", cust.Phone);
            cmd.Parameters.AddWithValue("@Gender", cust.Gender);
            cmd.Parameters.AddWithValue("@MailList", cust.MailList);

            try
            {
                con.Open();

                count = cmd.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                message = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return count;
        }

        public string VerifyLogin(Customer cust)

        {
            string password = null;
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("uspVerifyLogin", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Email", cust.Email);
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    password = reader["Password"].ToString();
                    if (Crypto.VerifyHashedPassword(password, cust.Password))
                    {
                        this.message = "Welcome" + reader["Name"].ToString();
                    }
                    else
                    {
                        this.message = "Incorrect password entered";
                    }
                }
            }
            catch (SqlException ex)
            {
                this.message = ex.Message;
            }
            catch (FormatException ex1)
            {
                this.message = ex1.Message;
            }
            finally
            {
                con.Close();
            }

            return this.message;

        }

        public List<Customer> ShowAll()
        {
            SqlDataReader reader;
            List<Customer> cust_list = new List<Customer>();

            SqlCommand sql = new SqlCommand("usp_ShowAll", con);

            sql.CommandType = CommandType.StoredProcedure;

            try
            {

                con.Open();
                reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    Customer cust = new Customer();


                    cust.Email = reader[0].ToString();
                    cust.CustName = reader[1].ToString();
                    cust.StreetAddress = reader[2].ToString();
                    cust.City = reader[3].ToString();
                    cust.Phone = reader[4].ToString();
                    cust.Password = reader[5].ToString();


                    cust_list.Add(cust);
                }
            }
            catch (SystemException ex)
            {
                message = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return cust_list;


        }

        public int InsertOrder(Order order)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("uspInsert_tbl_order", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@order", order.ProductID);
            cmd.Parameters.AddWithValue("@customer", order.CustomerID);
            cmd.Parameters.AddWithValue("@type", order.ProductType);
            cmd.Parameters.AddWithValue("@name", order.ProductName);
            cmd.Parameters.AddWithValue("@county", order.Country);
            cmd.Parameters.AddWithValue("@grape", order.Grape);
            cmd.Parameters.AddWithValue("@price", order.Price);
            cmd.Parameters.AddWithValue("@quantity", order.Quantity);
            try
            {
                con.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                message = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return count;


        }

    }
    
}
