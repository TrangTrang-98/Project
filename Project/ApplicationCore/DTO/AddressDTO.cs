using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using ApplicationCore.Entities.PatientAggregate;
namespace ApplicationCore.DTO
{
    public class AddressDTO
    {
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Country should not be longer than 20 characters.")]
        public string Country { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "City  should not be longer than 20 characters.")]
        public string City { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Address  should not be longer than 50 characters.")]
        [Display(Name = "Num House")]     
        public string NumHouse { get; set; }

        public string Street { get; set; } 

        public string District { get; set; } 
    }
}