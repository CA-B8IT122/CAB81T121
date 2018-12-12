using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.Helpers;

namespace CA_B8IT121.Models
{
    
    public class DAO
    {
       
        SqlConnection con = new SqlConnection();
        public string message = "";

        public DAO()
        {
            con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        }


        public int InsertCustomer(Customer cust)
        {
            int count = 0;
            string message = "";
            string password;
            SqlCommand cmd = new SqlCommand("usp_Insert_Customer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Email", cust.Email);
            cmd.Parameters.AddWithValue("@Name", cust.Name);
            cmd.Parameters.AddWithValue("@StreetAddress", cust.StreetAddress);
            cmd.Parameters.AddWithValue("@City", cust.City);
            password = Crypto.HashPassword(cust.Password);
            cmd.Parameters.AddWithValue("@Password", cust.Password);
            cmd.Parameters.AddWithValue("@Phone", cust.Phone);
            cmd.Parameters.AddWithValue("@Gender", cust.Gender);
            cmd.Parameters.AddWithValue("@MailList", cust.MailList);
           cmd.Parameters.AddWithValue("@CustType", cust.UserType);

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
            string password, name = null;
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("usp_VerifyLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
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
                        name =  reader["Name"].ToString();
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

            return name;
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
                    cust.Name = reader[1].ToString();
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

    }
    
}