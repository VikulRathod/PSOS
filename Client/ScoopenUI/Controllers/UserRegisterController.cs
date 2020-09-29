using ScoopenAPIModals.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;


namespace RegistrationAndLogin.Controllers
{
    public class UserRegisterController : Controller
    {
       
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegisterModel user)
        {
            if(ModelState.IsValid)
            {                
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:2017/api/userRegisterApi");
                var InserRecord = client.PostAsJsonAsync("UserRegisterApi", user);
                InserRecord.Wait();
                var SaveRecord = InserRecord.Result;
                if(SaveRecord.IsSuccessStatusCode)
                {
                    ModelState.Clear();
                    ViewBag.Message = "<script>alert('successfully Register')</script>";
                }
            }
            return View();
        }
    }
}