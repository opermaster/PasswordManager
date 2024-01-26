using System;
using Microsoft.EntityFrameworkCore;
using PasswordManagerLogic.Models;

namespace PasswordManagerLogic
{

    public class Logic
    {
        static void Main(string[] args) {
            //Console.WriteLine("Hello, World!");
        }
        public static List<Service> GetServices() {
           using (Context ctx=new Context()) {
               return ctx.Services.ToList();
           };
        }
        public static void AddNewService(string _serviceName) {
            using (Context ctx = new Context()) {
                ctx.Services.Add(new Service() {
                    Name = _serviceName
                });
                ctx.SaveChangesAsync();
            };
        }
        public static void AddNewData(string _firstField,string _passWord,string _serviceName) {
            using (Context ctx = new Context()) {
                Service? _sr=ctx.Services.ToList().Find(service => service.Name == _serviceName);
                ctx.Data.Add(new Data() {
                    FirstField = _firstField,
                    Password= _passWord,
                    Service= _sr,
                });
                ctx.SaveChangesAsync();
            };
        }
        public static void DeleteData(int _Id) {
            using (Context ctx = new Context()) {
                Data? _dt = ctx.Data.ToList().Find(data => data.Id == _Id);
                ctx.Data.Remove(_dt);
                ctx.SaveChangesAsync();
            };
        }
        public static void DeleteService(int _Id) {
            using (Context ctx = new Context()) {
                Service? _sr = ctx.Services.ToList().Find(service => service.Id == _Id);
                ctx.Services.Remove(_sr);
                ctx.SaveChangesAsync();
            };
        }

    }
}
