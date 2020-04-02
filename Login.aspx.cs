using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;


namespace DuckSurveyProjectDotNet
{
    
    public partial class Login : System.Web.UI.Page
    {

        public static string userName= "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LoginId"] = null;
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            Login.userName = TextBox1.Text;
            if (authenticate(TextBox1.Text, TextBox2.Text))
            {
                Session["LoginId"] = TextBox1.Text;
                Response.Redirect("~/SurveyForm.aspx");
                //Login.userName = TextBox1.Text;
            }
            else
            {
                Label1.Text = "Invalid Username and Password";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
        private bool authenticate(string Username, string Passsword)
        {

            SqlConnection con = new SqlConnection(SurveyForm.GetConnectionString());
            SqlCommand cmd = new SqlCommand("sp_select", con);
            cmd.CommandType = CommandType.StoredProcedure;

            string encryp = FormsAuthentication.HashPasswordForStoringInConfigFile(TextBox2.Text, "SHA1");

            cmd.Parameters.AddWithValue("@Username", TextBox1.Text);
            cmd.Parameters.AddWithValue("@Password", encryp);
            con.Open();
            int codereturn = (int)cmd.ExecuteScalar();
            return codereturn == 1;

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }

}