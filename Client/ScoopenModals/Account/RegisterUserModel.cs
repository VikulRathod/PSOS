using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoopenAPIModals.Account
{
    class RegisterUserModel
    {
        [Required(ErrorMessage = "First name is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "UserName is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mobile Number is Required")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmed Password is Required")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmedPassword { get; set; }
    }
}
