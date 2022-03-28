using System;
using System.IO;
using System.Net;
using System.Text;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Diagnostics;

namespace App1Final
{
    public partial class MainPage : ContentPage
    {
        public string Gl_Confirmed { get; set; }
        public string Gl_Recovered { get; set; }
        public string Gl_Deaths { get; set; }
        public string[] PickerItems { get; set; }
        public int index { get; set; }
        World data;
        public string f = "N0";
        public MainPage()
        {
            // Sets initial data for launch screen
            SetGlobalStats();
            SetSearchList();

            InitializeComponent();
            BindingContext = this;
        }

        // Uses http to fetch from API with a specific criteria
        // When fetched, the json converter manages data with the custom class World
        public World Fetch(string specific = "Global")
        {
            string url = "https://covid-api.mmediagroup.fr/v1/cases?country=" + specific;
            using (WebClient client = new WebClient())
            {
                string response = client.DownloadString(url);

                return JsonConvert.DeserializeObject<World>(response);
            }
        }

        // Launch screen labels are set when fetch is run
        private void SetGlobalStats()
        {
            data = Fetch(specific: "Global");
            Gl_Confirmed = "Confirmed:  " + data.All.Confirmed.ToString(format: f);
            Gl_Recovered = "Recovered:  " + data.All.Recovered.ToString(format: f);
            Gl_Deaths = "Deaths:  " + data.All.Deaths.ToString(format: f);
            OnPropertyChanged("Gl_Confirmed");
            OnPropertyChanged("Gl_Recovered");
            OnPropertyChanged("Gl_Deaths");
        }

        // Navigates to a new page with the search criteria country for a deeper look
        private void Search_Clicked(object sender, EventArgs e)
        {
            OnPropertyChanged("index");
            Navigation.PushAsync(new SearchResult(PickerItems[index], f));
        }

        // List of countries provided for the demo
        // NOTE 1: The API contains most countries
        // NOTE 2: Testing showed that China data is unavailable
        private void SetSearchList()
        {
            PickerItems = new string[5];
            PickerItems[0] = "Denmark";
            PickerItems[1] = "Germany";
            PickerItems[2] = "Sweden";
            PickerItems[3] = "Norway";
            PickerItems[4] = "Japan";
            OnPropertyChanged("PickerItems");
        }
    }
}
