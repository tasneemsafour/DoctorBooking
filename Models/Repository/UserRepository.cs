using DoctorBooking.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorBooking.Models.Repository
{
    public class UserRepository
    {
        List<User> users;
        public UserRepository()
        {
            users = DataAccess.GetUser();

        }
        public void Add(User entity)
        {
            DataAccess.addUser(entity);
        }

           

        public bool FindName(String Name)
        {
           var p=  users.Where(a => a.Name.Contains(Name)).ToList();
            if (p.Count == 0)
                return false;
            else
                return
                    true;
           // var p = users.Contains(a => a.Name.Equals(Name));
            //if (p == null) //no found
            //    return false;
            //else   //found
            //    return true;
        }

        public IList<User> ListUser()
        {
           return DataAccess.GetUser();
        }

        public bool checkLogin(User term)
        {
            var p = users.Where(a => a.Name.Contains(term.Name)).ToList();
            if (p[0].Password.Equals(term.Password))
                return true;
            return false;
        }

           
        }
    }