using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// SRDelWindow.xaml (ServiceDeleteWindow)
    /// /// Logic for dialog window that is used for getting the Id of service that user want to delete
    /// </summary>
    public partial class SRDelWindow : Window
    {
        private static readonly Regex _regex = new Regex("[^0-9]"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text) {
            return !_regex.IsMatch(text);
        }
        public SRDelWindow() {
            InitializeComponent();
            Service_Id_Box.Focus();
        }
        private void Accept_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = true;
        }
        public string ServiceId {
            get { return Service_Id_Box.Text; }
        }
        /// <summary>
        /// cheking for numbers int text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_Id_Box_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            e.Handled = !IsTextAllowed(e.Text);
        }
    }
}
