using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Q3_Exam_2018.Models
{
    public class DAO
    {
        SqlConnection con;
        public string message ="";
        public DAO()
        {
            con = new SqlConnection(WebConfigurationManager.ConnectionStrings["constring"].ConnectionString);
        }


        public int InsertMember(Member member)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("usp_Insert_Member", con);
            cmd.CommandType = CommandType.StoredProcedure;
            

            cmd.Parameters.AddWithValue("@Name", member.Name);
            cmd.Parameters.AddWithValue("@Email", member.Email);
            cmd.Parameters.AddWithValue("@Address", member.Address);
            cmd.Parameters.AddWithValue("@Password", member.Password);

            try
            {
                con.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                message = "DAO" +ex.Message;
            }
            finally
            {
                con.Close();
            }
            return count;
        }

        public List<Member> ShowAllMembers()

        {
            SqlDataReader reader;
            List<Member> mem_list = new List<Member>();

            SqlCommand sql = new SqlCommand("usp_ShowALL", con);

            sql.CommandType = CommandType.StoredProcedure;

            try
            {
              
                con.Open();
                reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    Member mem = new Member();


                    mem.Email = reader[0].ToString();
                    mem.Name = reader[1].ToString();
                    mem.Address = reader[2].ToString();
                    mem.Password = reader[3].ToString();
                    
                    mem_list.Add(mem);
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
           
            return mem_list;

            
        }

    }


}
