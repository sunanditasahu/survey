using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;

namespace DuckSurveyProjectDotNet
{

    public partial class SurveyForm : System.Web.UI.Page
    {

        public string GetConnectionString()
        {
            //we will set up the configuration which will call our 
            //web.config file to provide the database details because 
            //in configuration file we have created the <connectionStrings>
            //in the process we draged and droped. It creates automatically.
            //We normally put the database details in web.config file or
            //machine.config file because it is very sensitive information
            //usually there IP address of remote database, passwords and
            //user names are stored.

            return System.Configuration.ConfigurationManager.ConnectionStrings
                ["OnlineDuckSurveyConnectionString"].ConnectionString;
            //in above line "onlineapplicationformConnectionString1" is 
            //our configuration name which is inside the web.config file.
        }

        private void execution(string foodTime, string foodName, string foodLoc, string ducksNumber, string foodType, string foodQty)
        {
            //In above line we declaring different variables same as backend
            SqlConnection conn = new SqlConnection(GetConnectionString());
            //In above line we are calling connection 
            //string function which is defined already on top
            string sql = "INSERT INTO DuckInfo (foodTime, foodName, foodLoc, ducksNumber, foodType, foodQty) VALUES "
            + " (@foodTime, @foodName, @foodLoc, @ducksNumber, @foodType, @foodQty)";
            //In above lines we are just storing the sql commands which 
            //will insert value in DuckInfo named table, 
            //using variable named sql.
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                //In above lines we are opening the connection to work and
                //also storing connection name and sql command in cmd variable
                //which has 'SqlCommand' type.
                SqlParameter[] pram = new SqlParameter[6];
                //In above lines we are defining 6 sql parameters will be use
                //In below lines we will not disscuss about id column
                pram[0] = new SqlParameter("@foodTime", SqlDbType.NVarChar, 50);
                pram[1] = new SqlParameter("@foodName", SqlDbType.NVarChar, 50);
                pram[2] = new SqlParameter("@foodLoc", SqlDbType.NVarChar, 100);
                pram[3] = new SqlParameter("@ducksNumber", SqlDbType.NVarChar, 50);
                pram[4] = new SqlParameter("@foodType", SqlDbType.NVarChar, 50);
                pram[5] = new SqlParameter("@foodQty", SqlDbType.NVarChar, 50);

                //Now we set-uped all fiels in database in above lines
                //Now we will set-up form fields
                pram[0].Value = foodTime;
                pram[1].Value = foodName;
                pram[2].Value = foodLoc;
                pram[3].Value = ducksNumber;
                pram[4].Value = foodType;
                pram[5].Value = foodQty;

                //Now create loop to insert
                for (int i = 0; i < pram.Length; i++)
                {
                    cmd.Parameters.Add(pram[i]);
                }
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException ex_msg)
            {
                //Here will be catch elements
                string msg = "Error occured while inserting data in table.";
                msg += ex_msg.Message;
                throw new Exception(msg);
            }
            finally
            {
                //Here will be fially elements
                conn.Close();
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
        protected void submit_Click(object sender, EventArgs e)
        {
            //Here is the command inside the click event of button
            if (foodTime.Text == "")
            {
                Response.Write("Please complete the form.");
            }
            else
            {
                execution(foodTime.Text, foodName.Text, foodLoc.Text, ducksNumber.Text, foodType.Text, foodQty.Text);
                confirm.Visible = true;
            }
        }

        protected void generateReport_Click(object sender, EventArgs e)
        {
            //Here is the command inside the click event of button
            if (foodTime.Text == "")
            {
                Response.Write("Please complete the form.");
            }
            else
            {
                ExportSQLToCSV();               
                appreciate.Visible = true;
            }
        }
        //private void populateDropdown(System.Web.UI.WebControls.DropDownList dropdown, DateTime startTime, DateTime endTime, TimeSpan interval)
        //{
        //    dropdown.Items.Clear();

        //    DateTime time = startTime;

        //    while (time <= endTime)
        //    {
        //        dropdown.Items.Add(time.ToString("HH:mm tt"));
        //        time = time.Add(interval);
        //    }
        //}


        protected void foodTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = foodTime.SelectedItem.Text;
            string selectedValue = foodTime.SelectedItem.Value;

            //--- Show results in page.
            Response.Write("Selected Text is " + selectedText + " and selected value is :" + selectedValue);
        }
        protected void foodName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = foodName.SelectedItem.Text;
            string selectedValue = foodName.SelectedItem.Value;

            //--- Show results in page.
            Response.Write("Selected Text is " + selectedText + " and selected value is :" + selectedValue);
        }

        protected void foodLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = foodLoc.SelectedItem.Text;
            string selectedValue = foodLoc.SelectedItem.Value;

            //--- Show results in page.
            Response.Write("Selected Text is " + selectedText + " and selected value is :" + selectedValue);
        }

        protected void ducksNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = ducksNumber.SelectedItem.Text;
            string selectedValue = ducksNumber.SelectedItem.Value;

            //--- Show results in page.
            Response.Write("Selected Text is " + selectedText + " and selected value is :" + selectedValue);
        }
        protected void foodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = foodType.SelectedItem.Text;
            string selectedValue = foodType.SelectedItem.Value;

            //--- Show results in page.
            Response.Write("Selected Text is " + selectedText + " and selected value is :" + selectedValue);
        }
        protected void foodQty_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = foodQty.SelectedItem.Text;
            string selectedValue = foodQty.SelectedItem.Value;

            //--- Show results in page.
            Response.Write("Selected Text is " + selectedText + " and selected value is :" + selectedValue);
        }


        public void ExportSQLToCSV()
        {
            // Database connection variable.
            SqlConnection connect = new SqlConnection(GetConnectionString());

            try
            {

                // Connect to database.
                connect.Open();

            }
            catch (Exception ex)
            {

                // Confirm unsuccessful connection and stop program execution.
                Console.WriteLine("Database connection unsuccessful due to following error: " + ex.ToString());
                System.Environment.Exit(0);

            }
            // Export path and file.
            string exportPath = "C:\\demo\\";
            string exportCsv = "DuckReport.csv";

            // Stream writer for CSV file.
            StreamWriter csvFile = null;

            // Check to see if the file path exists.
            if (Directory.Exists(exportPath))
            {

                try
                {

                    // Query text.
                    string sqlText =
                        "SELECT [id], [foodTime], [foodName], [foodLoc], [ducksNumber], [foodType], [foodQty] FROM [OnlineDuckSurvey].dbo.[DuckInfo]";

                    // Query text incorporated into SQL command.
                    SqlCommand sqlSelect = new SqlCommand(sqlText, connect);

                    // Execute SQL and place data in a reader object.
                    SqlDataReader reader = sqlSelect.ExecuteReader();

                    // Stream writer for CSV file.
                    csvFile = new StreamWriter(@exportPath + exportCsv);

                    // Add the headers to the CSV file.
                    csvFile.WriteLine(String.Format("\"{0}\",\"{1}\",\"{2}\"," +
                        "\"{3}\",\"{4}\"",
                        reader.GetName(0), reader.GetName(1), reader.GetName(2),
                        reader.GetName(3), reader.GetName(4)));

                    // Construct CSV file data rows.
                    while (reader.Read())
                    {

                        // Add line from reader object to new CSV file.
                        csvFile.WriteLine(String.Format("\"{0}\",\"{1}\",\"{2}\"," +
                            "\"{3}\",\"{4}\"",
                            reader[0], reader[1], reader[2], reader[3], reader[4]));

                    }

                    // Message stating export successful.
                    Console.WriteLine("Data export successful.");

                }
                catch (Exception e)
                {

                    // Message stating export unsuccessful.
                    Console.WriteLine("Data export unsuccessful.");
                    System.Environment.Exit(0);

                }
                finally
                {

                    // Close the database connection and CSV file.
                    connect.Close();
                    csvFile.Close();

                }

            }
            else
            {

                // Display a message stating file path does not exist.
                Console.WriteLine("File path does not exist.");

            }
        }

    }
}