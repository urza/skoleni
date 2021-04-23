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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfClientApp.Model;

namespace WpfClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Client client;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Jakub.Novotny.1972@example.com
            //https://localhost:44386/
            var email = txtEmail.Text;


            HttpClient c = new HttpClient();
            var response = await c.GetAsync($"https://localhost:44386/api/client/get/{email}/");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                client = Newtonsoft.Json.JsonConvert.DeserializeObject<Client>
                                (response.Content.ReadAsStringAsync().Result);

                ClientDetailsWindow cdw = new ClientDetailsWindow(client);
                cdw.Show();
            }

        }
    }
}
