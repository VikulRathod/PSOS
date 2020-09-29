using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ScoopenAPIModals.Account;
using ScoopenAPIBLL.Utility;
using ScoopenAPIModals.Notifications;
using ScoopenAPIBLL;
using ScoopenNotifications;
using ScoopenAPIDAL;

namespace ScoopenAPI.Admin
{
    public class AdminRegisterApiController : ApiController
    {
        //    UserRegisterDbEntities db = new UserRegisterDbEntities();
        //    public IHttpActionResult PostRegisterApi(AdminRegisterModels Admin)
        //    {
        //        if (Admin != null)
        //        {
        //            User admin = new User()
        //            {
        //                FirstName = Admin.FirstName,
        //                LastName = Admin.LastName,
        //                Email = Admin.Email,
        //                Password = Admin.Password.ToString(),
        //                PhoneNumber=Admin.PhoneNumber,
        //                Address=Admin.Address,
        //                ZipCode=Admin.zipCode
        //            };
        //            db.Admins.Add(admin);
        //            db.SaveChanges();
        //            return Ok();
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        EmailNotifications emailNotification = new EmailNotifications();

        AccountControllerBLL bll = new AccountControllerBLL(new AccountControllerDAL());
        [HttpPost]
        public HttpResponseMessage RegisterAdmin([FromBody] AdminRegisterModels AdminInfo)
        {
            try
            {
                if (AdminInfo != null)
                {
                    string otp = new LoginHelper().GenerateRandomOtp();

                    int result = bll.RegisterAdmin(AdminInfo.FirstName, AdminInfo.LastName, AdminInfo.Email,AdminInfo.Password,AdminInfo.PhoneNumber,AdminInfo.Address,AdminInfo.zipCode);

                    OtpRequest request = new OtpRequest() { Mobile = AdminInfo.PhoneNumber, Email = AdminInfo.Email, Otp = otp };

                    // Uncomment below line if you want to send sms with otp
                    //OtpResponse response = notification.SendOTP(request);
                    OtpResponse emailresponse = emailNotification.SendOTP(request);

                    bll.SaveOtpInDatabase(AdminInfo.PhoneNumber, AdminInfo.Email, otp);

                    return Request.CreateResponse(HttpStatusCode.OK, emailresponse);
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest, "");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
    //C:\Users\Priyanka\Source\Repos\Registration_Admin\Server\ScoopenAPI\Admin\AdminRegisterApiController.cs


}
