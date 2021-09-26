using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

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
        [Required(ErrorMessage = "This field is required.")]
        [Range(1940, 2021, ErrorMessage = "Incorrect data!")]
        public string CarYear { get; set; }

        [Display(Name = "Body")]
        [Required(ErrorMessage = "This field is required.")]
        public string Body { get; set; }

        [Display(Name = "Model")]
        [Required(ErrorMessage = "This field is required.")]
        public string Model { get; set; }

        [Display(Name = "Color")]
        [Required(ErrorMessage = "This field is required.")]
        public string Color { get; set; }

        [Display(Name = "Price per day")]
        [Range(0, 1000000, ErrorMessage = "Incorrect data!")]
        public double Price { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        [NotMapped]
        [Display(Name = "Upload file")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "Brand")]
        public virtual Brand Brand { get; set; }

        public virtual ICollection<CarRent> CarRents { get; set; }
    }
}
