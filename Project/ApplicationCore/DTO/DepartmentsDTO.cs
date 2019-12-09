using ApplicationCore.Entities.DoctorAggregate;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace ApplicationCore.DTO
{
    public class DepartmentsDTO
    {
        [Required]
       [Display(Name = "Department Id")]
        public string DeptId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]        
        [Display(Name = "Department Name")]
        
        public string DeptName { get; set; }
         
        public ICollection<Doctor> Doctors{get; set;}

       // [Required]
        [StringLength(50, MinimumLength = 3)] 
        [Display(Name = "Doctor Head")]       
        public string DoctorHead{get; set;}

        // [Required]
        // public Doctor DoctorH{get; set;} // doctor head

    }
}