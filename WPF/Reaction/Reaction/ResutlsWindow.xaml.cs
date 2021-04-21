using System;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Reaction
{
    /// <summary>
    /// Interaction logic for ResutlsWindow.xaml
    /// </summary>
    public partial class ResutlsWindow : Window
    {
        public ResutlsWindow()
        {
            InitializeComponent();
        }

        public ResutlsWindow(string results)
        {
            InitializeComponent();

            txtResults.Text = results;
        }
    }
}
