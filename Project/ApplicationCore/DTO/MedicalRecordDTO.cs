using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Entities.PatientAggregate;
using ApplicationCore;
using ApplicationCore.Entities;
namespace ApplicationCore.DTO
{
    public class MedicalRecordDTO
    {

        [Display(Name = "Mã Bệnh Nhân")]
        public string PersonId{get; set;}

        //public Patient Patient{get; set;}

        // [Display(Name = "Mã Hố Sơ Bệnh Án")]
        // public string MedicalRecordId { get; set; }

         [Required]
        [StringLength(50, MinimumLength = 3)] 
        [Display(Name = "Triệu Chứng")]   
        public string Diagnostic{get;set;}

         [Required]
        [StringLength(50, MinimumLength = 3)]        
        [Display(Name = "Bác Sĩ Chữa Trị")]
        public string AttendingDoctorName { get; set; }

    }
} 
    
