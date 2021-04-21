using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace WpfAppAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DoWork(IEnumerable<string> files, 
                    ConcurrentDictionary<string, int> dict)
        {
            foreach (var file in files)
            {
                var cntwords = File.ReadAllLines(file).Length;

                dict[file] = cntwords;
            }
        }
        private async void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch s = new Stopwatch();
            s.Start();

            var folder = @"C:\PROJECTS\IctPro\netcore\LINQPad\BigFiles";

            var files = Directory.EnumerateFiles(folder, "*.txt");

            //txtResult.Text = string.Join(Environment.NewLine, files);

            ConcurrentDictionary<string, int> dict
                = new ConcurrentDictionary<string, int>();

            //Parallel.ForEach(files, (file) =>
            //{
            //    var cntwords = File.ReadAllLines(file).Length;

            //    dict[file] = cntwords;
            //});

           await Task.Run(() => DoWork(files,dict));

            foreach (var kv in dict)
            {
                txtResult.Text += kv.Key + ": "
                   + kv.Value.ToString()
                   + Environment.NewLine;
            }

            s.Stop();
            txtResult.Text += Environment.NewLine + s.ElapsedMilliseconds;
        }

        private void btnStats_Click(object sender, RoutedEventArgs e)
        {
            var folder = @"C:\PROJECTS\IctPro\netcore\LINQPad\BigFiles";
            var files = Directory.EnumerateFiles(folder, "*.txt");
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (var file in files)
            {
                var words = File.ReadAllLines(file);

                //count how many times each word is in file
                foreach (var word in words)
                {
                    if (dict.ContainsKey(word))
                        dict[word]++;
                    else
                        dict.Add(word, 1);
                }
            }
            //take top 10 words by count
            var top = dict.OrderByDescending(x => x.Value).Take(10);

            //print results to our txtResult element
            txtResult.Text = "";
            foreach(var item in top)
            {
                txtResult.Text += item.Key + ": " 
                    + item.Value.ToString() 
                    + Environment.NewLine;
            }

            //var p = Process.Start("program.exe");
            
        }

        private async void LoadAPI_Click(object sender, RoutedEventArgs e)
        {
            string url1 = "http://demo.vakutech.cz/api/values";
            string url2 = "http://demo.vakutech.cz/api2/values";
            
            Task<string> task1 =  LoadFromAPI(url1);
            Task<string> task2 = LoadFromAPI(url2);
            Task<string> task3 = LoadFromAPI(url2);

            var firstGroup = Task.WhenAny(task1, task2);

            var r = Task.WhenAll(firstGroup, task3);

            Task.WaitAll(task1, task2, task3);
            Task.WaitAny(firstGroup, task3);


        }

        private async Task<string> LoadFromAPI(string url)
        {
            HttpClient c = new HttpClient();
            //string url = "http://demo.vakutech.cz/api/values";

            var response = await c.GetAsync(url);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
