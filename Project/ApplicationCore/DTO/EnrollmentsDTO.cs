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
       [Display(Name = "Mã Bệnh Nhân")]

        public string PatientId{get; set;}

        [Required]
       [Display(Name = "Mã Bác Sĩ")]

        public string DoctorId{get; set;}

        public Patient Patient{get; set;}

        public Doctor Doctor{get; set;}

         [Display(Name = "Ngày Đăng Kí")]

        public System.DateTime EnrollmentDate{get; set;}

        [Required]
       [Display(Name = "Tên Khoa")]

        public string DeptName{get; set;}
    }
    
}