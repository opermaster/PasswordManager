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
namespace PasswordManagerU
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string? test;
        public MainWindow() {
            InitializeComponent();
            
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e) {
            main_list.Items.Clear();
            List <Service> i = Logic.global_context.Services.ToList();
            List<Data> d = Logic.global_context.Data.ToList();
            foreach (var test in i) {
                main_list.Items.Add(Logic.InfoString(test));
                foreach (var data in test.Data) {
                    main_list.Items.Add("\t"+Logic.InfoString(data));
                }
            }
            MessageBox.Show(test);
            
        }

        private void Add_Button2_Click(object sender, RoutedEventArgs e) {
            Logic.AddNewService("TestService#1");
            Logic.AddNewService("TestService#2");
            Logic.AddNewService("TestService#3");
            Logic.AddNewData("TestData#1.1", "TestData#1.2", "TestService#1", ref test);
            Logic.AddNewData("TestData#2.1", "TestData#2.2", "TestService#2", ref test);
            Logic.AddNewData("TestData#2.1", "TestData#2.2", "TestService#1", ref test);
            Logic.AddNewData("TestData#3.1", "TestData#3.2", "TestService#3", ref test);
            Logic.AddNewService("TestService#4");
            Logic.AddNewData("TestData#4.1", "TestData#4.2", "TestService#4", ref test);

        }
    }
}