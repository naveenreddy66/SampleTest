using SampleTest.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleTest.Models
{
    public class Property
    {

        /*
         * Make the Address, isForSale, and Price required 
         * Restrict the Address to a maximum length of 100 characters
         * Using PositiveNumberAttribute, restrict Price to only positive numbers
         * Using the Properties/CheckCityName action, validate the City passes validation
         */

        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Remote("CheckCityName", "Properties", ErrorMessage = "City Name is not valid!")]
        public string City { get; set; }

        public string Country { get; set; }
        [Required]
        public bool isForSale { get; set; }

        public ApplicationUser Owner { get; set; }
        [Required]
        [PositiveNumber]
        public double Price { get; set; }

    }
}