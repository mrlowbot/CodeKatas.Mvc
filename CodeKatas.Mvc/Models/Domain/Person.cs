using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CodeKatas.Mvc.Models.Domain
{
    public class Person
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        public string? PhoneNumber { get; set; }
    }
}
