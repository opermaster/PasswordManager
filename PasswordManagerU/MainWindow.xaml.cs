using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PasswordManagerLogic;
using PasswordManagerLogic.Models;
using PasswordManagerU.EdittingWindows;
namespace PasswordManagerU
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow() {
            InitializeComponent();
        }
        /// <summary>
        /// Function that updates a main list of Services and Data
        /// </summary>
        private void UpdateList() {
            main_list.Items.Clear();
            List<Service> i = Logic.global_context.Services.ToList();
            foreach (var test in i) {
                main_list.Items.Add(Logic.InfoString(test) + ":");
                foreach (var data in test.Data) {
                    main_list.Items.Add("\t" + Logic.InfoString(data));
                }
            }
        }
        /// <summary>
        /// Temp handler for refreshing a main list of Services and Data
        /// </summary>
        private void Refresh_Button_Click(object sender, RoutedEventArgs e) {
            UpdateList();
        }
        /// <summary>
        /// Temp handler for adding hardcoded data into Db and main list of Services and Data
        /// </summary>
        private void Add_Button2_Click(object sender, RoutedEventArgs e) {
            Logic.AddNewService("TestService#1");
            Logic.AddNewService("TestService#2");
            Logic.AddNewService("TestService#3");
            Logic.AddNewData("TestData#1.1", "TestData#1.2", "TestService#1");
            Logic.AddNewData("TestData#2.1", "TestData#2.2", "TestService#2");
            Logic.AddNewData("TestData#2.1", "TestData#2.2", "TestService#1");
            Logic.AddNewData("TestData#3.1", "TestData#3.2", "TestService#3");
            Logic.AddNewService("TestService#4");
            Logic.AddNewData("TestData#4.1", "TestData#4.2", "TestService#4");

        }
        /// <summary>
        /// Handler for button that adds new service into Db and main list.
        /// Was used new DialogWindow for getting service name 
        /// </summary>
        /// <returns>New service</returns>
        private void Add_Service_Button_Click(object sender, RoutedEventArgs e) {
            SRAddWindow service_window = new SRAddWindow();
            if (service_window.ShowDialog() == true) {
                Logic.AddNewService(service_window.ServiceName);
                UpdateList();
            }
        }
        /// <summary>
        /// Handler for button that adds new data into Db and main list.
        /// Was used new DialogWindow for getting service name 
        /// </summary>
        /// <returns>New data or new data and service</returns>
        private void Add_Data_Button_Click(object sender, RoutedEventArgs e) {
            DTAddWindow data_window = new DTAddWindow(Logic.global_context.Services.ToList());
            if (data_window.ShowDialog() == true) {
                Logic.AddNewData(data_window.NewData[0], data_window.NewData[1], data_window.NewData[2]);
                UpdateList();
            }
        }
    }
}