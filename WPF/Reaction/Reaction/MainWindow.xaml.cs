using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reaction
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

        DateTime start;
        List<double> reactions = new List<double>();

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                //start
                rectangle.Fill = Brushes.Gray;
                txtInfo.Visibility = Visibility.Hidden;
                txtLetter.Text = GetRandomLetter();
                txtLetter.Visibility = Visibility.Visible;
                start = DateTime.Now;
            }
            else if(e.Key == Key.Escape)
            {
                string result = "";

                result += "Count: " + reactions.Count + Environment.NewLine;
                result += "Avg: " + reactions.Average() + Environment.NewLine;
                result += "Max: " + reactions.Max() + Environment.NewLine;
                result += "Min: " + reactions.Min();

                ResutlsWindow rw = new ResutlsWindow(result);
                rw.Show();
            }
            else
            {
                if (txtLetter.Text == e.Key.ToString())
                {
                    var now = DateTime.Now;
                    var elapsed = now - start;
                    reactions.Add(elapsed.TotalMilliseconds);
                    txtElapsed.Text = ((int)elapsed.TotalMilliseconds).ToString() 
                                       + " ms";

                    rectangle.Fill = Brushes.GreenYellow;
                    
                    txtLetter.Text = GetRandomLetter();
                    start = DateTime.Now;

                }
                else
                    rectangle.Fill = Brushes.DarkSalmon;
            }

            
        }

        private string GetRandomLetter()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            Random random = new Random();
            var index = random.Next(chars.Length - 1);

            var letter = chars[index];

            return letter.ToString();
        }
    }
}
