using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NavTech.Models;
using System.Collections;


namespace NavTech.Services
{
    public class UserService
    {


        OrderContext db = new OrderContext();

        public User ValidateUser(string username,string password)
        {

            
            var user = db.Users.FirstOrDefault(a => a.Name == username && a.Password == password);
            return user;
    
        }

     

    }
}