using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WebClientTestperson.Models;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Testdaten> tests = new ObservableCollection<Testdaten>();
        private Testdaten testdaten = null;

        public MainWindow()
        {
            InitializeComponent();
            grid.ItemsSource = tests;
        }

        private async void btnShow_Click(object sender, RoutedEventArgs e)
        {
            tests.Clear();
            Mouse.OverrideCursor = Cursors.Wait;
            string input = txtPLZ.Text;
            int plz = 0;
            if (input != "")
            {
                plz = Convert.ToInt32(input);
            }
            string temptests = await getRequestAsync("/api/Testdaten");
            List<Testdaten> list = System.Text.Json.JsonSerializer.Deserialize<List<Testdaten>>(temptests);
            foreach (Testdaten t in list)
            {
                if (t.TestzeitSoll.Value.Day == DateTime.Now.Day)
                {
                    if (plz != 0)
                    {
                        if (t.PLZ >= plz - 200 && t.PLZ <= plz + 200)
                        {
                            tests.Add(t);
                        }
                    }
                    else
                    {
                        tests.Add(t);
                    }
                }
            }
            Mouse.OverrideCursor = null;
        }

        //Asynchroner Request
        private async Task<string> getRequestAsync(string url)
        {
            HttpClient client = new HttpClient();
            Uri baseUri = new Uri("https://localhost:7331/");
            client.BaseAddress = baseUri;
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var task = await client.SendAsync(requestMessage);
            HttpResponseMessage msg = task.EnsureSuccessStatusCode();
            string responesBody = await task.Content.ReadAsStringAsync();
            return responesBody;
        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblMessage.Visibility = Visibility.Hidden;
            txtCode.Visibility = Visibility.Visible;
            lblCode.Visibility = Visibility.Visible;
            btnDoTest.Visibility = Visibility.Visible;
            testdaten = (Testdaten)((DataGrid)sender).SelectedItem;
        }

        private async void btnDoTest_Click(object sender, RoutedEventArgs e)
        {
            string code = txtCode.Text;
            if (code == testdaten.Code) 
            {
                txtCode.Visibility = Visibility.Hidden;
                lblCode.Visibility = Visibility.Hidden;
                btnDoTest.Visibility = Visibility.Hidden;

                try
                {
                    using HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("https://localhost:7331/");

                    var json = JsonConvert.SerializeObject(testdaten);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"api/Testdaten/{testdaten.Id}", content);
                    response.EnsureSuccessStatusCode();

                    lblMessage.Visibility = Visibility.Visible;
                    lblMessage.Content = "Übermittlung des Tests erfolgreich!";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fehler beim Senden: " + ex.Message);
                }
            }
            else
            {
                txtCode.Visibility = Visibility.Hidden;
                lblCode.Visibility = Visibility.Hidden;
                btnDoTest.Visibility = Visibility.Hidden;
                lblMessage.Visibility = Visibility.Visible;
                lblMessage.Content = "ERROR: Es wurde ein falscher Code eingegeben!";
            }
        }
    }
}