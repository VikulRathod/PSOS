using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScoopenAPIModals.Account;
using System.Net.Http;
using RegistrationAndLogin.Service_References.Account;

namespace RegistrationAndLogin.Controllers
{
    public class AdminRegisterController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Route("api/register")]
        public HttpResponseMessage RegisterAdmin(AdminRegisterModel AdminInfo)
        {
            var registerHttpClient = new RegisterHttpClient();

            var response = registerHttpClient.RegisterAdmin(AdminInfo);
            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            return null;
        }

        [HttpPost]
        public ActionResult Register(AdminRegisterModel Admin)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:2017/api/AdminRegisterApi");//this one
                var InserRecord = client.PostAsJsonAsync("AdminRegisterApi", Admin);//this one
                InserRecord.Wait();
                var SaveRecord = InserRecord.Result;
                if (SaveRecord.IsSuccessStatusCode)
                {
                    ModelState.Clear();
                    ViewBag.Message = "<script>alert('successfully Register')</script>";
                }
            }
            return View();
        }
    }
}