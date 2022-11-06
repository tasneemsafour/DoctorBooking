using DoctorBooking.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DoctorBooking.Server
{
    static public class DataAccess
    {
        static SqlConnection conn;
        public static void connection()
        {
           // Server = localhost; Database = SQLShackDemo
            conn = new SqlConnection(@"Server=DESKTOP-KCTKMBJ\SQLEXPRESS;Database=HospitalData;Trusted_Connection=True;");
            conn.Open();
        }

        public static bool addUser(User user)
        {

            //conn.Open();
            SqlCommand insert = new SqlCommand("insert into [HospitalData].[dbo].[Users](Name,Email,Password) values (@Name, @Password ,@Password)", conn);
            insert.Parameters.AddWithValue("@Name", user.Name);
            insert.Parameters.AddWithValue("@Password", user.Password);
            insert.Parameters.AddWithValue("@Email", user.Email);
            try
            {
                
                insert.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                //LMsg.Text = "Error when saving on database";
                conn.Close();
                return false;
            }
        }

        public static List<User> GetUser()
        {

           
                using (SqlCommand cmd = new SqlCommand("SELECT Name , Password ,Email  FROM [HospitalData].[dbo].[Users]", conn))
                {
                
                    List<User> customers = new List<User>();
                    cmd.CommandType = CommandType.Text;
                   
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(new User
                            {
                                Name = sdr["Name"].ToString(),
                                Password = sdr["Password"].ToString(),
                                Email = sdr["Email"].ToString()
                            });
                        }
                    }
               
                return customers;
                }
            }
    }
}