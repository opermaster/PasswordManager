using PasswordManagerLogic;
using PasswordManagerLogic.Models;
using PasswordManagerU.EdittingWindows;
using System.Windows;
namespace PasswordManagerU
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<int, int> data_indexes;
        private Dictionary<int, int> service_indexes;
        public MainWindow() {
            InitializeComponent();
            data_indexes = new Dictionary<int, int>();
            service_indexes = new Dictionary<int, int>();
            StartFillList();
        }
        /// <summary>
        /// Function that updates a main list of Services and Data. Also function provides a local id`s for services and data.
        /// That id`s will user use for deleting services and data.
        /// Id`s are saved in hash tables data_indexes,service_indexes
        /// </summary>
        private void UpdateList() {
            main_list.Items.Clear();
            int sr_id = 1;
            int dt_id = 1;
            List<Service> services = Logic.global_context.Services.ToList();
            foreach (var service in services) {
                main_list.Items.Add("Id - "+sr_id + " " + Logic.InfoString(service) + " :");
                service_indexes[sr_id] = service.Id;
                sr_id++;
                foreach (var data in service.Data) {
                    main_list.Items.Add("\t" + "Id - " + dt_id + " " + Logic.InfoString(data));
                    data_indexes[dt_id] = data.Id;
                    dt_id++;
                }
            }
        }
        /// <summary>
        /// Overload of function UpdateList(), for making it display special lists of services
        /// </summary>
        private void UpdateList(List<Service> services) {
            main_list.Items.Clear();
            int sr_id = 1;
            int dt_id = 1;
            foreach (var service in services) {
                main_list.Items.Add("Id - " + sr_id + " " + Logic.InfoString(service) + " :");
                service_indexes[sr_id] = service.Id;
                sr_id++;
                foreach (var data in service.Data) {
                    main_list.Items.Add("\t" + "Id - " + dt_id + " " + Logic.InfoString(data));
                    data_indexes[dt_id] = data.Id;
                    dt_id++;
                }
            }
        }
        /// <summary>
        /// Special function that is used onlu when app starts .It is used for filling main list in first time.
        /// Can`t use UpdateList() function because it doesn`t work correctly.
        /// </summary>
        private void StartFillList() {
            int sr_id = 1;
            int dt_id = 1;
            List<Service> services = Logic.global_context.Services.ToList();
            List<Data> data = Logic.global_context.Data.ToList();
            foreach(Service service in services) {
                main_list.Items.Add("Id - " + sr_id + " " + Logic.InfoString(service) + " :");
                service_indexes[sr_id] = service.Id;
                sr_id++;
                List<Data> data_for_service = data.FindAll(dt=>dt.Service==service);
                foreach(Data dt_f_s in data_for_service) {
                    main_list.Items.Add("\t" + "Id - " + dt_id + " " + Logic.InfoString(dt_f_s));
                    data_indexes[dt_id] = dt_f_s.Id;
                    dt_id++;
                }
            }
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
        /// <summary>
        /// Handler for button that delete data from db by providing to it id of data that you would like to delete.
        /// Method uses new window DTDelWindow(DataDeleteWindow). After getting string from window it checks for invalid input.
        /// If string is invalid the method will notify the user about it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Data_Button_Click(object sender, RoutedEventArgs e) {
            DTDelWindow data_delete_win = new DTDelWindow();
            if (data_delete_win.ShowDialog() == true) {
                string data_id_str = data_delete_win.DataId.Replace(" ", "");
                if (data_id_str != "")
                    if (data_indexes.TryGetValue(Convert.ToInt32(data_id_str), out int value)) {
                        Logic.DeleteData(value);
                        UpdateList();
                    }
                    else MessageBox.Show("Invalid data Id: " + data_id_str);
                else MessageBox.Show("Empty data Id!");
            }
        }
        /// <summary>
        /// Handler for button that delete service from db by providing to it id of service that you would like to delete
        /// Method uses new window SRDelWindow(ServiceDeleteWindow). After getting string from window it checks for invalid input.
        /// If string is invalid the method will notify the user about it.
        /// If it`s not it will delete Service and all Data in it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Service_Button_Click(object sender, RoutedEventArgs e) {
            SRDelWindow service_delete_win = new SRDelWindow();
            if (service_delete_win.ShowDialog() == true) {
                string service_id_str = service_delete_win.ServiceId.Replace(" ", "");
                if (service_id_str != "")
                    if (service_indexes.TryGetValue(Convert.ToInt32(service_id_str), out int value)) {
                        Logic.DeleteService(value);
                        UpdateList();
                    }
                    else MessageBox.Show("Invalid service Id: " + service_id_str);
                else MessageBox.Show("Empty service Id!");

            }
        }
        /// <summary>
        /// Method ,for disconnecting from DB ,that calles when window closes. 
        /// </summary>
        private void Window_Closed(object sender, EventArgs e) {
            Logic.global_context.Dispose();
        }
        /// <summary>
        /// Handler for Find_Service button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Find_Service_Button_Click(object sender, RoutedEventArgs e) {
            UpdateList(Logic.FindServiceByName(Service_Name_Box.Text));
        }
    }
}