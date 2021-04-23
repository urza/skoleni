using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WPFCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IEnumerable<FileInfo> _files;
        public MainWindow()
        {
            InitializeComponent();

            LoadFiles();
        }

        private void LoadFiles()
        {
            string dir = @"C:\PROJECTS\IctPro\CNET2-STUDENTI-GIT\3-BigFiles\data";
            DirectoryInfo di = new DirectoryInfo(dir);
            _files = di.EnumerateFiles("*.txt");

        }

        private async void btnLoadFiles_Click(object sender, RoutedEventArgs e)
        {
            txbResultsInfo.Text = "";

            Stopwatch w = new Stopwatch();
            w.Start();

            foreach (var file in _files)
            {
                var lines = await File.ReadAllLinesAsync(file.FullName);

                txbResultsInfo.Text += file.Name + "  " + lines.Count();
            }

            w.Stop();
            txbResultsInfo.Text += "elapsed ms: " + w.ElapsedMilliseconds;
        }

        private void btnWordStats_Click(object sender, RoutedEventArgs e)
        {
            /*
	            10 nejcastejsich slov v kazdem souboru
	        */
            txbResultsInfo.Text = "";
            Stopwatch w = new Stopwatch();
            w.Start();

            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

            foreach (var file in _files)
            {
                Dictionary<string, int> stats = new Dictionary<string, int>();

                foreach (var word in File.ReadAllLines(file.FullName))
                {
                    if (stats.ContainsKey(word))
                        stats[word]++;
                    else
                        stats.Add(word, 1);
                }

                txbResultsInfo.Text += file.Name + Environment.NewLine;
                //txbResultsInfo.Text += Environment.NewLine;
                txbResultsInfo.Text += string.Join(Environment.NewLine, stats.OrderByDescending(x => x.Value).Take(10)
                                            .Select(x => x.Key + ": " + x.Value));

                txbResultsInfo.Text += Environment.NewLine + Environment.NewLine;

            }

            Mouse.OverrideCursor = null;

            w.Stop();
            txbResultsInfo.Text += "elapsed ms: " + w.ElapsedMilliseconds;
        }

        private void btnWordStatsGlobal_Click(object sender, RoutedEventArgs e)
        {
            /*
               10 nejcastejsich slov celkem ve všech souborech
           */
            txbResultsInfo.Text = "";
            Stopwatch w = new Stopwatch();
            w.Start();

            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

            Dictionary<string, int> stats = new Dictionary<string, int>();

            foreach (var file in _files)
            {
                foreach (var word in File.ReadAllLines(file.FullName))
                {
                    if (stats.ContainsKey(word))
                        stats[word]++;
                    else
                        stats.Add(word, 1);
                }
            }

            txbResultsInfo.Text += string.Join(Environment.NewLine, stats.OrderByDescending(x => x.Value).Take(10)
                                        .Select(x => x.Key + ": " + x.Value));

            txbResultsInfo.Text += Environment.NewLine;

            Mouse.OverrideCursor = null;

            w.Stop();
            txbResultsInfo.Text += "elapsed ms: " + w.ElapsedMilliseconds;


        }

        private void btnWordStatsParallel_Click(object sender, RoutedEventArgs e)
        {
            /*
	            10 nejcastejsich slov v kazdem souboru - paralelně
	        */
            txbResultsInfo.Text = "";
            Stopwatch w = new Stopwatch();
            w.Start();

            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

            Parallel.ForEach(_files, (file) =>
            {
                Dictionary<string, int> stats = new Dictionary<string, int>();

                foreach (var word in File.ReadAllLines(file.FullName))
                {
                    if (stats.ContainsKey(word))
                        stats[word]++;
                    else
                        stats.Add(word, 1);
                }


                Dispatcher.BeginInvoke(new Action(() =>
                {
                    txbResultsInfo.Text += file.Name + Environment.NewLine;
                    //txbResultsInfo.Text += Environment.NewLine;
                    txbResultsInfo.Text += string.Join(Environment.NewLine, stats.OrderByDescending(x => x.Value).Take(10)
                                                .Select(x => x.Key + ": " + x.Value));

                    txbResultsInfo.Text += Environment.NewLine + Environment.NewLine;
                }), priority: System.Windows.Threading.DispatcherPriority.Send);

            });

            Mouse.OverrideCursor = null;

            w.Stop();
            txbResultsInfo.Text += "Elapsed ms: " + w.ElapsedMilliseconds;
            //Dispatcher.BeginInvoke(new Action(() => txbResultsInfo.Text += "Elapsed ms: " + w.ElapsedMilliseconds));
        }

        private void btnWordStatsParallelInTaskContinueWith_Click(object sender, RoutedEventArgs e)
        {
            /*
	            10 nejcastejsich slov v kazdem souboru - paralelně
	        */
            txbResultsInfo.Text = "";
            Stopwatch w = new Stopwatch();
            w.Start();

            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

            Task.Run(() => Parallel.ForEach(_files, (file) =>
            {
                Dictionary<string, int> stats = new Dictionary<string, int>();

                foreach (var word in File.ReadAllLines(file.FullName))
                {
                    if (stats.ContainsKey(word))
                        stats[word]++;
                    else
                        stats.Add(word, 1);
                }


                Dispatcher.Invoke(new Action(() =>
                {
                    txbResultsInfo.Text += file.Name + Environment.NewLine;
                    //txbResultsInfo.Text += Environment.NewLine;
                    txbResultsInfo.Text += string.Join(Environment.NewLine, stats.OrderByDescending(x => x.Value).Take(10)
                                                .Select(x => x.Key + ": " + x.Value));

                    txbResultsInfo.Text += Environment.NewLine + Environment.NewLine;

                }), priority: System.Windows.Threading.DispatcherPriority.Send);

            }))
                .ContinueWith((task) =>
                {
                    w.Stop();
                    txbResultsInfo.Text += "Elapsed ms: " + w.ElapsedMilliseconds;
                }, TaskScheduler.FromCurrentSynchronizationContext());


            Mouse.OverrideCursor = null;


            //Dispatcher.BeginInvoke(new Action(() => txbResultsInfo.Text += "Elapsed ms: " + w.ElapsedMilliseconds));

        }

        private async void btnWordStatsParallelInTask_Click(object sender, RoutedEventArgs e)
        {
            /*
	            10 nejcastejsich slov v kazdem souboru - paralelně
	        */
            txbResultsInfo.Text = "";
            Stopwatch w = new Stopwatch();
            w.Start();

            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

            await Task.Run(() => Parallel.ForEach(_files, (file) =>
            {
                Dictionary<string, int> stats = new Dictionary<string, int>();

                foreach (var word in File.ReadAllLines(file.FullName))
                {
                    if (stats.ContainsKey(word))
                        stats[word]++;
                    else
                        stats.Add(word, 1);
                }


                Dispatcher.Invoke(new Action(() =>
                {
                    txbResultsInfo.Text += file.Name + Environment.NewLine;
                    txbResultsInfo.Text += string.Join(Environment.NewLine, stats.OrderByDescending(x => x.Value).Take(10)
                                                .Select(x => x.Key + ": " + x.Value));
                    txbResultsInfo.Text += Environment.NewLine + Environment.NewLine;

                }), priority: System.Windows.Threading.DispatcherPriority.Send);

            }));

            w.Stop();
            txbResultsInfo.Text += "Elapsed ms: " + w.ElapsedMilliseconds;

            Mouse.OverrideCursor = null;


            //Dispatcher.BeginInvoke(new Action(() => txbResultsInfo.Text += "Elapsed ms: " + w.ElapsedMilliseconds));

        }

        private async void btnWordStatsParallelInTaskWithProgress_Click(object sender, RoutedEventArgs e)
        {
            /*
	            10 nejcastejsich slov v kazdem souboru - paralelně, s ProgressReportem
	        */
            txbResultsInfo.Text = "";
            Stopwatch w = new Stopwatch();
            w.Start();

            IProgress<string> progress = new Progress<string>(message =>
            {
                txbResultsInfo.Text += message;
            });


            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

            await Task.Run(() => Parallel.ForEach(_files, (file) =>
            {
                Dictionary<string, int> stats = new Dictionary<string, int>();

                foreach (var word in File.ReadAllLines(file.FullName))
                {
                    if (stats.ContainsKey(word))
                        stats[word]++;
                    else
                        stats.Add(word, 1);
                }

                progress.Report(file.Name + Environment.NewLine +
                                string.Join(Environment.NewLine, stats.OrderByDescending(x => x.Value).Take(10)
                                                .Select(x => x.Key + ": " + x.Value))
                                + Environment.NewLine + Environment.NewLine);

            }));


            w.Stop();
            txbResultsInfo.Text += "Elapsed ms: " + w.ElapsedMilliseconds;

            Mouse.OverrideCursor = null;


            //Dispatcher.BeginInvoke(new Action(() => txbResultsInfo.Text += "Elapsed ms: " + w.ElapsedMilliseconds));

        }

        private void btnWordStatsGlobalParallel_Click(object sender, RoutedEventArgs e)
        {
            /*
              10 nejcastejsich slov celkem ve všech souborech paralelně
            */

            txbResultsInfo.Text = "";
            Stopwatch w = new Stopwatch();
            w.Start();

            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

            ConcurrentDictionary<string, int> stats = new ConcurrentDictionary<string, int>();

            Parallel.ForEach(_files, (file) =>
            {
                foreach (var word in File.ReadAllLines(file.FullName))
                {
                    stats.AddOrUpdate(word, 1, (key, oldValue) => oldValue + 1);
                }
            });


            txbResultsInfo.Text += string.Join(Environment.NewLine, stats.OrderByDescending(x => x.Value).Take(10)
                                        .Select(x => x.Key + ": " + x.Value));

            txbResultsInfo.Text += Environment.NewLine;

            Mouse.OverrideCursor = null;

            w.Stop();
            txbResultsInfo.Text += "elapsed ms: " + w.ElapsedMilliseconds;

        }

        CancellationTokenSource tokenSource2 = new CancellationTokenSource();
        private void btnStartTask_Click(object sender, RoutedEventArgs e)
        {
            tokenSource2 = new CancellationTokenSource();
            CancellationToken ct = tokenSource2.Token;

            var task = Task.Run(() => FileLoader.LoadAllFiles(ct), tokenSource2.Token); // Pass same token to Task.Run.

            task.ContinueWith(x => App.Current.Dispatcher.Invoke(() => txbResultsInfo.Text = task.Result.Count().ToString()));

        }

        private void btnStartTaskWithProgress_Click(object sender, RoutedEventArgs e)
        {
            IProgress<string> progress = new Progress<string>(message =>
            {
                txbResultsInfo.Text = message;
            });

            tokenSource2 = new CancellationTokenSource();
            CancellationToken ct = tokenSource2.Token;

            var task = Task.Run(() => FileLoader.LoadAllFilesWithProgress(ct, progress), tokenSource2.Token); // Pass same token to Task.Run.

            task.ContinueWith(task => App.Current.Dispatcher.Invoke(() => txbResultsInfo.Text = (tokenSource2.IsCancellationRequested ? "Canceled " : "") +  task.Result.Count().ToString()));

        }

        private void btnCancelTask_Click(object sender, RoutedEventArgs e)
        {
            tokenSource2.Cancel();
        }
    }
}
