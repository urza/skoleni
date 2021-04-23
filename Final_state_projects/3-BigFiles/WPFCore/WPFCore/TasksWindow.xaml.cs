using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
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

namespace WPFCore
{
    /// <summary>
    /// Interaction logic for TasksWindow.xaml
    /// </summary>
    public partial class TasksWindow : Window
    {
        
        public TasksWindow()
        {
            InitializeComponent();

            this.DataContext = new WebSearchViewModel();
        }

        private async void btnWebLoad_Click(object sender, RoutedEventArgs e)
        {
            dgResults.Visibility = Visibility.Visible;
            dgResultsBinding.Visibility = Visibility.Hidden;

            Stopwatch s = new Stopwatch();
            s.Start();

            string search = txtSearch.Text;
            
            var results = await Task.Run(() => WebLoader.SearchUrls(search) );

            dgResults.ItemsSource = results;

            s.Stop();
            txbInfo.Text = "elapsed ms: " + s.ElapsedMilliseconds.ToString();
        }

        private async void btnApiFirst_Click(object sender, RoutedEventArgs e)
        {
            var result = await APILoader.LoadAPIResults();

            txbInfo.Text = $"Suma {result.Sum} z URL: {result.Url}";
        }

        private async void btnSearchBinding_Click(object sender, RoutedEventArgs e)
        {
            dgResults.Visibility = Visibility.Hidden;
            dgResultsBinding.Visibility = Visibility.Visible;

            string search = txtSearch.Text;
            var dc = (this.DataContext as WebSearchViewModel);
            IProgress<SearchResult> progress = new Progress<SearchResult>(p =>
            {
                dc.WebSearchResults.Add(p);
            });

            await Task.Run(() => WebLoader.SearchUrlsWithProgress(search, progress));

        }
    }
}
