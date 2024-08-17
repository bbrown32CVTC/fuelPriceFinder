using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Windows.Forms;
using Nancy.Json;
using Nancy.Responses;
using Newtonsoft.Json;
using RestSharp;

/*
 * Created by: Bruce Brown 
 * Date Created: 8/8/2024
 */

namespace fuelPriceFinder
{
    /// <summary>
    /// A proof of concept C# WinForm application for finding the average gas prices in different states and cities
    /// by using the Gas Prices API from CollectAPI (https://collectapi.com/api/gasPrice/gas-prices-api). The api key
    /// is associated with the Free Trial tier option that only allows 100 calls to the API within 3 days.
    /// </summary>


    public partial class FPFMainForm : Form
    {
        private string[] fuelTypes = { "All", "Regular", "Mid-Grade", "Premium", "Diesel" };
        private string stateInput, cityInput, fuelInput, apiKey = "";
        private bool validString;

        public FPFMainForm()
        {
            InitializeComponent();

            // Hide error message and gas label
            this.errorLabel.Hide();
            this.gasDisplayLabel.Text = string.Empty;
            this.gasDisplayLabel.Hide();

            // Set up State ComboBox and display first item
            setStateCB();
            this.stateCB.SelectedIndex = 0;

            // Set up Fuel ComboBox and display first item
            this.fuelCB.Items.AddRange(fuelTypes);
            this.fuelCB.SelectedIndex = 0;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            // Hide error message if displayed for new search
            if (this.errorLabel.Visible)
            {
                this.errorLabel.Hide();
            }

            // Set the state, city, and fuel selected
            this.stateInput = stateSelect(this.stateCB.SelectedIndex);
            this.cityInput = this.cityTB.Text;
            this.fuelInput = this.fuelCB.Text;

            // Display an error if the city field is left blank
            if (string.IsNullOrEmpty(this.cityInput))
            {
                this.errorLabel.Text = "Error: City cannot be left blank. Please try again.";
                this.errorLabel.Show();
                this.cityTB.Text = string.Empty;
                this.cityTB.Select();
            }

            // Validate the city input is a true string for processing or display an error for being invalid
            validString = validStringInput(this.cityInput);

            if (!validString)
            {
                // Display an error for the invalid string
                this.errorLabel.Text = "Error: City input is not valid. Please try again.";
                this.errorLabel.Show();
                this.cityTB.Text = string.Empty;
                this.cityTB.Select();
            }
            else
            {
                // Display Results if data can be found, otherwise will display an error
                displayGasPrices(this.stateInput, this.cityInput, this.fuelInput);
            }

        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            // Reset the city field and gas information label
            this.cityTB.Text = string.Empty;
            this.gasDisplayLabel.Text = string.Empty;

            // Hide the gas information label
            this.gasDisplayLabel.Hide();

            // Place cursor in the City textbox field
            this.cityTB.Select();
        }

        private void setStateCB()
        {
            // Create state list and set it to the state selection combobox
            string[] states = { "Alabama (AL)", "Alaska (AK)", "Arizona (AZ)", "Arkansas (AR)", "California (CA)", "Colorado (CO)",
                "Connecticut (CT)", "Delaware (DE)", "Florida (FL)", "Georgia (GA)", "Hawaii (HI)", "Idaho (ID)", "Illinois (IL)",
                "Indiana (IN)", "Iowa (IA)", "Kansas (KS)", "Kentucky (KY)", "Louisiana (LA)", "Maine (ME)", "Maryland (MD)",
                "Massachusetts (MA)", "Michigan (MI)", "Minnesota (MN)", "Mississippi (MS)", "Missouri (MO)", "Montana (MT)",
                "Nebraska (NE)", "Nevada (NV)", "New Hampshire (NH)", "New Jersey (NJ)", "New Mexico (NM)", "New York (NY)",
                "North Carolina (NC)", "North Dakota (ND)", "Ohio (OH)", "Oklahoma (OK)", "Oregon (OR)", "Pennsylvania (PA)",
                "Rhode Island (RI)", "South Carolina (SC)", "South Dakota (SD)", "Tennessee (TN)", "Texas (TX)", "Utah (UT)",
                "Vermont (VT)", "Virginia (VA)", "Washington (WA)", "West Virginia (WV)", "Wisconsin (WI)", "Wyoming (WY)"};

            this.stateCB.Items.AddRange(states);
        }

        private string stateSelect(int stateIndex)
        {
            // Create state abbreviation list and return corresponding state from array index
            string[] statesAbbreviation = { "AL", "AK", "AZ", "AR", "CA", "CO","CT", "DE", "FL", "GA", "HI", "ID", "IL",
                "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM",
                "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"};

            return statesAbbreviation[stateIndex];
        }

        private bool validStringInput(string input)
        {
            // Verify the string input is valid
            foreach (char c in input)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }

            return true;
        }

        private void displayGasPrices(string stateAbb, string city, string fuelType)
        {
            string regular = "", midGrade = "", premium = "", diesel = "";
            bool cityFound = false;
            Key key = new Key();
            this.apiKey = key.apiKey;

            RestClient client = new RestClient($"https://api.collectapi.com/gasPrice/stateUsaPrice?state={stateAbb}"); // Sets API address
            RestRequest request = new RestRequest()  // Create GET request
            {
                Method = Method.Get
            };
            request.AddHeader("authorization", this.apiKey);
            request.AddHeader("content-type", "application/json");
            RestResponse response = client.Execute(request);  // Submit Get request

            // Display any error response received
            if (!response.IsSuccessful)
            {
                // Display an error for the invalid string
                this.errorLabel.Text = $"Error: {response.ErrorException?.Message}";
                this.errorLabel.Show();
                this.cityTB.Text = string.Empty;
                this.cityTB.Select();
                return;
            }

            Root gasData = JsonConvert.DeserializeObject<Root>(response.Content);
            foreach (City c in gasData.result.cities)
            {
                if (c.lowerName == city.ToLower())
                {
                    cityFound = true;
                    regular = c.gasoline;
                    midGrade = c.midGrade;
                    premium = c.premium;
                    diesel = c.diesel;
                }
            }

            // Display an error if the city was not found, otherwise display the results
            if (cityFound)
            {

                // Set up and Display Results
                switch (fuelType)
                {
                    case "All":
                        this.gasDisplayLabel.Text = $"{city}, {stateAbb} - Average Fuel Prices\n \nRegular Unleaded: ${regular} \nMid-Grade Unleaded: ${midGrade}" +
                            $"\nPremium Unleaded: ${premium} \nDiesel: ${diesel}";
                        break;

                    case "Regular":
                        this.gasDisplayLabel.Text = $"{city}, {stateAbb} - Average Gas Price\n \nRegular Unleaded: ${regular}";
                        break;

                    case "Mid-Grade":
                        this.gasDisplayLabel.Text = $"{city}, {stateAbb} - Average Gas Price\n \nMid-Grade Unleaded: ${midGrade}";
                        break;

                    case "Premium":
                        this.gasDisplayLabel.Text = $"{city}, {stateAbb} - Average Gas Price\n \nPremium Unleaded: ${premium}";
                        break;

                    case "Diesel":
                        this.gasDisplayLabel.Text = $"{city}, {stateAbb} - Average Diesel Price\n \nDiesel: ${diesel}";
                        break;
                }

                this.gasDisplayLabel.Show();

            }
            else
            {
                // Reset and hide gas information label if it is visible
                if (this.gasDisplayLabel.Visible)
                {
                    this.gasDisplayLabel.Text = string.Empty;
                    this.gasDisplayLabel.Hide();
                }

                // Display an error for the invalid string and move cursor to City textbox field
                this.errorLabel.Text = $"Error: {city}, {stateAbb} not found. Please try again.";
                this.errorLabel.Show();
                this.cityTB.Text = string.Empty;
                this.cityTB.Select();
            }

        }

        private void helpMenuItem_Click(object sender, EventArgs e)
        {
            // Display support contact information
            MessageBox.Show("ProSync CS LLC \n\n1212 Sugar Blvd \nEau Claire, WI 54703 \n\n715-555-5525", "Contact Support");
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Fuel Price Finder application uses the state you select from the dropdown list and city you input to call on an API to get the average " +
                "gas prices in that city. You are able to see the average regular, mid-grade, premium, dielsel prices after a successful API call. An error message will be " +
                "displayed if there is an issue with the request or the city you input is not able to be found. The user can hit enter after selecting the state and inputting " +
                "the city to search for the average gas prices in that area. The Clear/Reset button will reset the City textbox field and the fuel information. The dropdowns " +
                "allow you to search by hitting the letter of the item you would like to select when that dropdown is selected. There is a print option in the menu that will allow " +
                "the user to print the current fuel information displayed.", "About Fuel Price Finder");
        }

        private void printMenuItem_Click(object sender, EventArgs e)
        {
            if (this.gasDisplayLabel.Visible && this.gasDisplayLabel.Text.Length > 0)
            {
                MessageBox.Show(this.gasDisplayLabel.Text, "Printed!");
            }
            else
            {
                this.errorLabel.Text = "Error: There is nothing to print.";
                this.errorLabel.Show();
            }
        }

        private void stateCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset and hide gas information label
            this.gasDisplayLabel.Text = string.Empty;
            this.gasDisplayLabel.Hide();

            // Reset City textbox field
            this.cityTB.Text= string.Empty;
        }

    }
}
