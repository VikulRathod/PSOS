using ScoopenAPIModals.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoopenAPIDAL
{
    public interface IAccountControllerDAL
    {
        int RegisterUser(string firstName, string lastName, string mobile, string email, string otp);

        int RegisterAdmin(string FirstName, string LastName, string Email, string Password, string PhoneNumber, string Address, int ZipCode);

        int ActivateRegisteredUser(string mobile, string password, string email, string otp);

        void SaveOtpInDatabase(string mobile, string email, string otp);

        string GetOtpFromDatabase(string mobile, string email);

        User1 Authenticate(string username, string password);

        int ChangePasswordOnFirstLogin(string userName, string currentPassword, string newPassword);
    }
}
