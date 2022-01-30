using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Share
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = ("Input Name"))]
        public string VisitorName { get; set; }
        [Required(ErrorMessage = ("Input Email"))]
        public string VisitorEmail { get; set; }
        [Required(ErrorMessage = ("Input Phone"))]
        public string VisitoPhone { get; set; }
        [Required(ErrorMessage = ("Input  Password"))]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = ("Input Confirm Password"))]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = ("Password not Match"))]
        [NotMapped]
        public string ConfirmPassword { get; set; }
        public string VisitorAddress { get; set; }
        public string Occupation { get; set; }
    }
}
