using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CarRents.Models
{
    public class Brand
    {
        public Brand()
        {
            Cars = new HashSet<Car>();
        }

        public int BrandID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "The field cannot be empty!")]
        public string BrandName { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "The field cannot be empty!")]
        public string Country { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
