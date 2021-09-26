using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CarRents.Models
{
    public class Company
    {
        public Company()
        {
            Cars = new HashSet<Car>();
        }

        public int CompanyID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "This field is required.")]
        public string CompanyName { get; set; }

        [Display(Name = "Rating")]
        [Range(0, 5, ErrorMessage = "Incorrect data!")]
        public double Rating { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
