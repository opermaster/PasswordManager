using Microsoft.EntityFrameworkCore;
using PasswordManagerLogic.Models;
using System.Security.Cryptography;

namespace PasswordManagerLogic
{
    /// <summary>
    /// Main static class that is used for connecting with Db
    /// </summary>
    public class Logic
    {
        /// <summary>
        /// Gloabal context that connects to Db
        /// </summary>
        public static Context global_context=new Context();

        static void Main() { }
        /// <summary>
        /// This method adds new service in Db by name
        /// </summary>
        /// <param name="_serviceName"></param>
        public static void AddNewService(string _serviceName) {
            global_context.Services.Add(new Service() {
                Name = _serviceName == "" ? "Undefined service" : _serviceName //Cheking if input string is empty string, if it is return "Undefined service"
            });
            global_context.SaveChanges();

        }
        /// <summary>
        /// This method adds new data ,to Db, by providing it first field, password, service name
        /// </summary>
        /// <param name="_firstField"></param>
        /// <param name="_passWord"></param>
        /// <param name="_serviceName"></param>
        public static void AddNewData(string _firstField, string _passWord, string _serviceName) {
            Service? _sr = global_context.Services.ToList().Find(service => service.Name == _serviceName);
            global_context.Data.Add(new Data() {
                FirstField = _firstField,
                Password = _passWord,
                Service = _sr,
            });
            global_context.SaveChanges();

        }
        /// <summary>
        /// This method deletes Data from Db by providing Id of tha Data
        /// </summary>
        /// <param name="_Id"></param>
        public static bool DeleteData(int _Id) {
            Data? _dt = global_context.Data.ToList().Find(data => data.Id == _Id);
            if (_dt is not null) {
                global_context.Data.Remove(_dt);
                global_context.SaveChanges();
                return true;
            }
            else return false;
        }
        /// <summary>
        /// This method deletes Service from Db by providing Id of tha Service
        /// </summary>
        /// <param name="_Id"></param>
        public static bool DeleteService(int _Id) {
            Service? _sr = global_context.Services.ToList().Find(service => service.Id == _Id);
            if (_sr is not null) {
                global_context.Services.Remove(_sr);
                global_context.SaveChanges();
                return true;
            }
            else return false;

        }
        /// <summary>
        /// Method for objects that have realesation of IPrintInfoString interface, used for getting string from object.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>String</returns>
        public static string InfoString(IPrintInfoString item) {
            return item.PrintInfo();
        }
        /// <summary>
        /// Method that finds all occurrences in names of all services. And returns them if there are mathes
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        public static List<Service> FindServiceByName(string _name) {
            List<Service> _sr = global_context.Services.Where(service => EF.Functions.Like(service.Name, $"%{_name}%")).ToList();
            return _sr;
        }
    }
}
