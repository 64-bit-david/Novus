using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAdo
{
    public partial class Person : System.Web.UI.Page
    {
        /// <summary>
        ///     Load the page
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fetch_Persons_Data();
            }
        }
        /// <summary>
        /// Fetches person data from the database and binds it to gridview
        /// </summary>
        private void Fetch_Persons_Data()
        {
            string s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection con = new SqlConnection(s);

            //only try to fetch the data if the table exists
            if(PersonsTableExists(con))
            {
                string sqlString = "SELECT * FROM Persons";
                SqlCommand cmd = new SqlCommand(sqlString, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
                dr.Close();
                con.Close();

            }
        }

        /// <summary>
        ///     Checks if the Persons table exists in the db
        /// </summary>
        /// <param name="connection">SqlConnectoin obj</param>
        /// <returns>true if exists, false if not</returns>
        private bool PersonsTableExists(SqlConnection connection)
        {
            string sqlString = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Persons'";
            SqlCommand cmd = new SqlCommand(sqlString, connection);
            connection.Open();
            int count = (int)cmd.ExecuteScalar();
            connection.Close();

            return count > 0;
        }

        /// <summary>
        ///     Event handler for the PostPersonButton click event
        ///     Inserts new person to Persons table
        /// </summary>
        protected void PostPersonButton_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    if (!PersonsTableExists(connection))
                    {
                        string createTableQuery = "CREATE TABLE Persons(Id INT PRIMARY KEY IDENTITY(1,1), FirstName VARCHAR(50), LastName VARCHAR(50), Email VARCHAR(50), Phone VARCHAR(50))";
                        SqlCommand createTable = new SqlCommand(createTableQuery, connection);
                        connection.Open();
                        createTable.ExecuteNonQuery();
                        connection.Close();
                    }

                    string insertQuery = "INSERT INTO Persons (FirstName, LastName, Email, Phone) VALUES (@FirstName, @LastName, @Email, @Phone)";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
                    insertCmd.Parameters.AddWithValue("@FirstName", TextBox1.Text);
                    insertCmd.Parameters.AddWithValue("@LastName", TextBox2.Text);
                    insertCmd.Parameters.AddWithValue("@Email", TextBox3.Text);
                    insertCmd.Parameters.AddWithValue("@Phone", TextBox4.Text);
                    connection.Open();
                    insertCmd.ExecuteNonQuery();
                    connection.Close();

                    // Clear the input forms
                    TextBox1.Text = string.Empty;
                    TextBox2.Text = string.Empty;
                    TextBox3.Text = string.Empty;
                    TextBox4.Text = string.Empty;

                    // Render the GridView to display the updated data
                    Fetch_Persons_Data();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        ///     deletes a person from the database with the provided id
        /// </summary>
        /// <param name="id">Id of the row to delete</param>
        public void DeletePerson(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string deleteQuery = "DELETE FROM Persons WHERE Id = @Id";
                SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection);
                deleteCmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                deleteCmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        /// <summary>
        /// Event handler for the gridview delete event
        /// </summary>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            //Extract corresponding Id from the row where the button was clicked
            int id = Convert.ToInt32(row.Cells[0].Text);
            DeletePerson(id);

            Fetch_Persons_Data();
        }

    }
}