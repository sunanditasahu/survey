using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Web.Security;

namespace DuckSurveyProjectDotNet

{
    public partial class Register : System.Web.UI.Page
    {

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(SurveyForm.GetConnectionString());
            SqlCommand cmd = new SqlCommand("sp_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;

            string encryp = FormsAuthentication.HashPasswordForStoringInConfigFile(TextBox2.Text, "SHA1");

            cmd.Parameters.AddWithValue("@Username", TextBox1.Text);
            cmd.Parameters.AddWithValue("@Password", encryp);
            cmd.Parameters.AddWithValue("@Email", TextBox4.Text);

            con.Open();
            int codereturn = (int)cmd.ExecuteScalar();
            if (codereturn == -1)
            {

                lblmsg.Text = "Username already exist!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}