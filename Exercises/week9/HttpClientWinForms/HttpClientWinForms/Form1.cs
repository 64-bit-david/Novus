using System.Net.Http.Json;
using System.Security.Policy;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace HttpClientWinForms
{



    /// <summary>
    /// The main form of the HttpClientWinForms application.
    /// </summary>
    public partial class Form1 : Form
    {

        public double Num1 { get; set; } = 0;
        public double Num2 { get; set; } = 0;

        public string Operation { get; set; }

        static readonly HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
        }


        /// <summary>
        /// Handles the selection change event of the combo box.
        /// Enables the calculation button if an operation is selected.
        /// </summary>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Operation = comboBox1.Text;
            button1.Enabled = !string.IsNullOrEmpty(Operation);
        }

        /// <summary>
        /// Event handler for textchange text box
        /// </summary>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Show a warning if division by zero is attempted
            if (double.TryParse(textBox1.Text, out double result))
            {
                Num1 = result;
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid number.", "Warning");
                textBox1.Clear(); 
            }
        }


        /// Event handler for textchange text box
        /// Parses and sets Num2 if valid; shows a warning if invalid.
        /// Checks for division by zero if the operation is Divide.
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox2.Text, out double result))
            {
                Num2 = result;

                // Show a warning if division by zero is attempted
                if (Operation == "Divide" && Num2 == 0)
                {
                    MessageBox.Show("Cannot divide by zero.", "Warning");
                    textBox2.Clear(); 
                }
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid number.", "Warning");
                textBox2.Clear(); 
            }
        }


        /// <summary>
        /// Handles the click event of the calculation button.
        /// Posts the calculation request, displays the result, and shows a success message.
        /// </summary>
        private async void button1_Click(object sender, EventArgs e)
        {

            try
            {
                double result = await Post_API(Num1, Num2, Operation);
                MessageBox.Show($"Result: {result}\n\nOperation saved successfully.", "Calculation Result and Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }

        }

        /// <summary>
        /// Posts a calculation request to the API and returns the result.
        /// </summary>
        /// <param name="num1">The first number for the calculation.</param>
        /// <param name="num2">The second number for the calculation.</param>
        /// <param name="operation">The operation to perform (e.g., "Add", "Subtract", etc.).</param>
        /// <returns>The calculated result of the operation.</returns>
        private async Task<double> Post_API(double num1, double num2, string operation)
        {
            var requestData = new
            {
                Num1 = num1,
                Num2 = num2,
                Operation = operation
            };

            HttpResponseMessage response = await client.PostAsJsonAsync("http://localhost:5000/api/calculation", requestData);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                CalculationResponse calculationResponse = JsonConvert.DeserializeObject<CalculationResponse>(responseBody);

                return calculationResponse.Result;
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }


        /// <summary>
        /// Gets the calculation history from the API.
        /// </summary>
        /// <returns>A list of CalculationResult objects representing the calculation history.</returns>
        private async Task<List<CalculationResult>> Get_API()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:5000/api/calculation");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                List<CalculationResult> calculations = JsonConvert.DeserializeObject<List<CalculationResult>>(responseBody);

                return calculations;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
                return null;
            }
        }

        /// <summary>
        /// Handles the click event of the history button.
        /// Retrieves and displays the calculation history.
        /// </summary>
        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                List<CalculationResult> calculations = await Get_API();
                if (calculations != null && calculations.Count > 0)
                {
                    CalculationHistory historyForm = new CalculationHistory(calculations);
                    // Show the form as a popup
                    historyForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No calculation history available.", "Information");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
        }
    }
}
