using DoctorBooking.Models;
using DoctorBooking.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorBooking.Controllers
{
    public class AuthenticationController : Controller
    {
        UserRepository userRepo = new UserRepository();
        [HttpGet]
        public ActionResult Login(int id=0)
        {
            User userModel = new User();
            return View(userModel);
        }
        [HttpGet]
        public ActionResult Main()
        {
            return View();
        }
        

        [HttpPost]
        public ActionResult Login(User userModel)
        {
            return View("Register");
            //try
            //{
            //   if(userRepo.checkLogin(userModel))
            //   {
            //        MessageBox.Show("yes");
            //        return View("Main"); 
            //   }
            //    MessageBox.Show("no");
            //    ViewBag.DuplicateMessage = "Username Not Found";
            //   return View("Register");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ex");
            //    return View("Index");
            //}
        }

        [HttpGet]
        public ActionResult Register(int id=0)
        {
            User userModel = new User();

            return View(userModel);
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
                if (userRepo.FindName(user.Name))
                {
                ViewBag.DuplicateMessage = "Username already exist.";
                return View("Login");
                }
               userRepo.Add(user);
               return View("Main");
            }
            catch (Exception ex)
            {
                return HttpNotFound();
            }
            
        }
      
    }
}