using PasswordManagerLogic;
using PasswordManagerLogic.Models;
using System.Windows;

namespace PasswordManagerU.EdittingWindows
{
    /// <summary>
    /// DTAddWindow.xaml(DataAddWindow)
    /// Logic for Dialog Window that could add new Data by providing to it a first field, password, Service name
    /// If service name is empty, that window gives user a possibility, for making and adding new Service, and adds it to Combobox and to Db
    /// And then user can select new Service that he made
    /// </summary>
    public partial class DTAddWindow : Window
    {
        public DTAddWindow(List<Service> services) {
            InitializeComponent();
            Services_List.ItemsSource = services;
        }
        /// <summary>
        /// Handler for accept button
        /// </summary>
        private void Accept_Click(object sender, RoutedEventArgs e) {
            if (!(Services_List.SelectedItem is Service service)) {
                SRAddWindow service_window = new SRAddWindow();
                if (service_window.ShowDialog() == true) {
                    string final_service_name = service_window.ServiceName == "" ? "Undefined service" : service_window.ServiceName;
                    Logic.AddNewService(final_service_name);
                    Services_List.ItemsSource = Logic.global_context.Services.ToList();
                    Services_List.SelectedIndex = Services_List.Items.Count-1;
                }
            }
            else this.DialogResult = true;
        }
        /// <summary>
        /// returned data
        /// </summary>
        public string[] NewData {
            get {
                string ffb = First_field_Box.Text;
                string psb = Password_Box.Text;
                if (Services_List.SelectedItem is Service service) {
                    return [ffb, psb, service.ToString()];
                } 
                else {
                    return [" ", " ", " "];
                }
            }
        }
    }
}
