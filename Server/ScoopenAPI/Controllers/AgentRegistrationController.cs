using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ScoopenAPIBLL;
using ScoopenAPIModals.Account;
using ScoopenAPIModals.Notifications;
using ScoopenAPIBLL.Utility;
using ScoopenNotifications;
using System.Web.Helpers;
using ScoopenAPIDAL;

using ScoopenAPIModals.AgentRegistration1;

namespace ScoopenAPI.Controllers
{
    public class AgentRegistrationController : ApiController
    {
        AccountControllerBLL bll = new AccountControllerBLL(new AccountControllerDAL());
        [HttpPost]
        public HttpResponseMessage PostRegister(ScoopenAPIModals.AgentRegistration1.Agent agent)
        {
            try
            {
                if (agent != null)
                {
                    bll.AgentRegister(agent);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }

                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "");
                }

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
