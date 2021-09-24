using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CarRents.Models
{
    public class Car
    {
        public Car()
        {
            CarRents = new HashSet<CarRent>();
        }

        public int CarID { get; set; }

        [Display(Name = "Brand")]
        public int BrandID { get; set; }

        [Display(Name = "Release year")]
        [Required(ErrorMessage = "The field cannot be empty!")]
        [Range(1940, 2021, ErrorMessage = "Incorrect data!")]
        public string CarYear { get; set; }

        [Display(Name = "Body")]
        [Required(ErrorMessage = "The field cannot be empty!")]
        public string Body { get; set; }

        [Display(Name = "Model")]
        [Required(ErrorMessage = "The field cannot be empty!")]
        public string Model { get; set; }

        [Display(Name = "Color")]
        [Required(ErrorMessage = "The field cannot be empty!")]
        public string Color { get; set; }

        [Display(Name = "Price per day")]
        [Range(0, 1000000, ErrorMessage = "Incorrect data!")]
        public double Price { get; set; }

        [Display(Name = "Brand")]
        public virtual Brand Brand { get; set; }

        public virtual ICollection<CarRent> CarRents { get; set; }
    }
}
