using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CarRents.Models
{
    public class CarRent
    {
        public int CarRentID { get; set; }

        [Display(Name = "Renter")]
        public int RenterID { get; set; }

        [Display(Name = "Car")]
        public int CarID { get; set; }

        [Display(Name = "Company")]
        public int CompanyID { get; set; }

        [Display(Name = "Number of rental days")]
        [Range(0, 31, ErrorMessage = "Incorrect data!")]
        public int RentalDays { get; set; }

        [Display(Name = "Model")]
        public virtual Car Car { get; set; }

        [Display(Name = "Renter")]
        public virtual Renter Renter { get; set; }

        [Display(Name = "Company")]
        public virtual Company Company { get; set; }
    }
}
