using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Entities.PatientAggregate;
using ApplicationCore;
using ApplicationCore.Entities;
namespace ApplicationCore.DTO
{
    public class PatientsDTO
    {
        //enum Gender { Nam = "Nam", Nu = "Nữ"}
        [Display(Name = "Patient Id")]
        public string Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Patient Name")]
        public string Name { get; set; }

        public Gender Gender{get; set;}

        [DataType(DataType.Date)]
       // [Display(Name = "Birthday")]
        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage = "Employee Address is required")]
        [StringLength(300)]
        //[DisplayFormat(DataFormatString = "{0:1:2:3:4}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public Address Address { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        public string Phone { get; set; }

         [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" +
            "@" +
            @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Email không đúng")]
        [Required]
        public string Email{get; set;}
    }
}