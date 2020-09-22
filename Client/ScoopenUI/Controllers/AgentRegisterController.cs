
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

using ScoopenAPIModals.AgentRegistration1;
using ScoopenAPI;
using ScoopenAPIDAL;
using ScoopenAPIModals;


//using ScoopenAPIModals.AgentRegistration;

namespace RegistrationAndLogin.Controllers
{
   
    public class AgentRegisterController : Controller
    {
        // GET: AgentRegister
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddAgent1()
        {
            return View();
        }
        [HttpPost]

        public ActionResult AddAgent1(Agent agent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string passhash = HashPassword(agent.AgentPassword);
                    string cpasshash = HashPassword(agent.AgentConfirmPassword);
                    agent.AgentPassword = passhash;
                    agent.AgentConfirmPassword = cpasshash;
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:2017/api/agentRegistration");

                        var PostTask = client.PostAsJsonAsync("AgentRegistration", agent);
                        PostTask.Wait();

                        var result = PostTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            ViewBag.SuccessMessage = " <script> alert('Registration is Successfull')</script>";

                            ModelState.Clear();

                            return View();
                            //return RedirectToRoute(new { action = "AddAgent", controller = "Registration", area = "" });
                        }
                    }
                }
                ModelState.AddModelError(string.Empty, "Server Error");
                return View(agent);

            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, "Server Error");
                return View(agent);
            }
        }

        public static string HashPassword(string password, string algorithm = "sha256")
        {
            return Hash(Encoding.UTF8.GetBytes(password), algorithm);
        }

        private static string Hash(byte[] input, string algorithm = "sha256")
        {
            using (var hashAlgorithm = HashAlgorithm.Create(algorithm))
            {
                return Convert.ToBase64String(hashAlgorithm.ComputeHash(input));
            }
        }

    }
}