﻿using System;
using Microsoft.EntityFrameworkCore;
using PasswordManagerLogic.Models;

namespace PasswordManagerLogic
{

    public class Logic
    {
        public static Context global_context = new Context();
        static void Main() {

        }
        public static List<Service> GetServices() {
           
               return global_context.Services.ToList();
           
        }
        public static void AddNewService(string _serviceName) {

            global_context.Services.Add(new Service() {
                    Name = _serviceName
                });
            global_context.SaveChangesAsync();
            
        }
        public static void AddNewData(string _firstField,string _passWord,string _serviceName,ref string test) {
            
                Service _sr= global_context.Services.ToList().Find(service => service.Name == _serviceName);
            global_context.Data.Add(new Data() {
                    FirstField = _firstField,
                    Password= _passWord,
                    Service= _sr,
                });
                test +=_sr.Name+" "+_sr.Id+" ,";
            global_context.SaveChangesAsync();
            
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
        public static List<Data> GetData() {
            using (Context ctx = new Context()) {
                return ctx.Data.ToList();
            };
        }
        public static string InfoString(IPrintInfoString item) {
            return item.PrintInfo();
        }
    }
}
