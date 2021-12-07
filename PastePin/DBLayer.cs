using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PastePin
{
    public class DBLayer
    {
        public void InsertQueryString(string query, string message)
        {
            // inserte query, message og datetime.now
            var connectionString = ConfigurationManager.ConnectionStrings["Pastetable2"].ConnectionString;
            SqlParameter param;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT into Pastetable4 (QS, Dato, Message ) VALUES (@QS, @DATO, @Messages ); ", conn);

                cmd.CommandType = CommandType.Text;

                param = new SqlParameter("@Dato", SqlDbType.DateTime);
                param.Value = DateTime.Now;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@QS" , SqlDbType.NVarChar);
                param.Value = query;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Messages", SqlDbType.NVarChar);
                param.Value = message;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                conn.Close();
                //l
            }
        }
        public void GetQSAndmessage(string query)
        {
            // inserte query, message og datetime.now
            var connectionString = ConfigurationManager.ConnectionStrings["Pastetable2"].ConnectionString;
            SqlParameter param;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT FROM Pastetable4 (QS,  Message ) VALUES (@QS, @Messages ); ", conn);

                cmd.CommandType = CommandType.Text;

                param = new SqlParameter("@QS", SqlDbType.NVarChar);
                param.Value = query;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                conn.Close();

            }

        }
        public string GetmessagefromQS(string QS)
        {
            string message = string.Empty;

            var connectionString = ConfigurationManager.ConnectionStrings["Pastetable2"].ConnectionString;
        
            SqlParameter param;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select Message from Pastetable4 WHERE QS = @qs" , conn);

                param = new SqlParameter("@qs", SqlDbType.NVarChar);
                param.Value = QS;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    message = (string)reader["Message"];
                }
                conn.Close();
            }
            return message;
        }

        private static Random random = new Random();

        public static string RandomQS(int length)
        {
            const string chars = "abcdefghijklmnopqstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());



        }




    }
        
    }
