using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleTest.Attributes
{
    public class PositiveNumberAttribute : ValidationAttribute
    {
        //Call the base ValidationAttribute constructor and pass in a custom error message
        public PositiveNumberAttribute() : base("Numbers cannot be negative")
        {

        }

        public override bool IsValid(object value)
        {
            //Return true if the value parameter is a positive number

            try
            {
                int intValue = Convert.ToInt32(value);
                return intValue >= 0;
            }
            catch (Exception)
            {
               
                return false;
            }
            
        }
    }
}