using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CarRents.Models
{
    public class Renter
    {
        public Renter()
        {
            CarRents = new HashSet<CarRent>();
        }

        public int RenterID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "The field cannot be empty!")]
        public string RenterName { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "The field cannot be empty!")]
        public string City { get; set; }

        [Display(Name = "Birth year")]
        [Range(1900, 2021, ErrorMessage = "Incorrect data!")]
        public int BirthYear { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "The field cannot be empty")]
        [RegularExpression(@"([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Incorrect data!")]
        public string Email { get; set; }

        public virtual ICollection<CarRent> CarRents { get; set; }
    }
}
