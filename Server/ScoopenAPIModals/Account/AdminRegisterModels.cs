using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ScoopenAPIModals.Account
{
   public class AdminRegisterModels
    {
        [Required(ErrorMessage = "First name is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmed Password is Required")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmedPassword { get; set; }


        [Required(ErrorMessage = "Mobile Number is Required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address Number is Required")]
        public string Address { get; set; }


        [Required(ErrorMessage = "ZipCode is Required")]
        public int zipCode { get; set; }
    }
}
