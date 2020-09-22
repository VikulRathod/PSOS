using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScoopenAPIModals.Account


namespace RegistrationAndLogin.Controllers
{
    public class UserRegisterController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ModelUserClass user)
        {
            if (ModelState.IsValid)
            { }
            return View();
        }

    }
}