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

namespace PasswordManagerU.EdittingWindows
{
    /// <summary>
    /// SRAddWindow.xaml(ServiceAddWindow)
    /// Logic for Dialog Window that could add new Service by providing to it a name of service
    /// </summary>
    public partial class SRAddWindow : Window
    {
        public SRAddWindow() {
            InitializeComponent();
            Name_Box.Focus();
        }
        /// <summary>
        /// Handler for accept button
        /// </summary>
        private void Accept_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = true;
        }
        /// <summary>
        /// returned data
        /// </summary>
        public string ServiceName{
            get { return Name_Box.Text; }
        }
    }
}
