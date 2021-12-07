using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace PastePin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DBLayer dblayer = new DBLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            string QS = Request.QueryString["qs"];
           
            if (QS != null)
            {
                string message = dblayer.GetmessagefromQS(QS);
                Msgarea.Value = message;
            }

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        protected void InsertQueryString(string query, string message)
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

                param = new SqlParameter("@QS", SqlDbType.NVarChar);
                param.Value = query;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Messages", SqlDbType.NVarChar);
                param.Value = message;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                conn.Close();
            }

        }
        protected void ButtonCreateQueryString_Click(object sender, EventArgs e)
        {
            string qs = RandomString(8);
            dblayer.InsertQueryString(qs, Msgarea.Value);
            
            
            
            Response.Redirect("WebForm1.aspx?qs=" + qs);
        }




        



  
        
       





        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


    }
    }






