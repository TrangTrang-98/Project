using ApplicationCore.Entities.PatientAggregate;
using ApplicationCore.Entities.DoctorAggregate;
using ApplicationCore.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApplicationCore.DTO
{
    public class EnrollmentsDTO
    {
        [Required]
       [Display(Name = "Patient Id")]

        public string PatientId{get; set;}

        [Required]
       [Display(Name = "Doctor Id")]

        public string DoctorId{get; set;}

        public Patient Patient{get; set;}

        public Doctor Doctor{get; set;}

         [Display(Name = "Enrollment Date")]

        public System.DateTime EnrollmentDate{get; set;}
    }
    
}