using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfClientApp.Model;

namespace WpfClientApp
{
    /// <summary>
    /// Interaction logic for ClientDetailsWindow.xaml
    /// </summary>
    public partial class ClientDetailsWindow : Window
    {
        private Client _client;
        public ClientDetailsWindow(Client client)
        {
            InitializeComponent();

            _client = client;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txbUser.Text = _client.FullName();
            
            dgTransactionHistory.ItemsSource = _client.Transactions;
        }

        private async void btnTx_Click(object sender, RoutedEventArgs e)
        {
            Transaction tx = new Transaction();
            tx.Value = double.Parse(txtTxInput.Text);
            tx.Type = tx.Value > 0 ? TransactionType.DEPOSIT : TransactionType.WITHDRAW;
            tx.Date = DateTime.Now;
            var email = _client.Email;

            var json = JsonConvert.SerializeObject(tx);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient c = new HttpClient();
            var response = c.PostAsync($"https://localhost:44386/api/Transaction/add/{email}/", data).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                HttpClient c2 = new HttpClient();
                var response2 = await c2.GetAsync($"https://localhost:44386/api/client/get/{email}/");
                if (response2.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var client_updated = Newtonsoft.Json.JsonConvert.DeserializeObject<Client>
                                    (response2.Content.ReadAsStringAsync().Result);

                    dgTransactionHistory.ItemsSource = client_updated.Transactions;
                }

            }
        }
    }
}
