using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore;
using ApplicationCore.Entities;
namespace ApplicationCore.DTO
{
    public class DoctorsDTO
    {
       [Required]
       [Display(Name = "Mã Bác Sĩ")]
        public string Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]        
        [Display(Name = "Tên Bác Sĩ")]
        public string Name { get; set; }

        [Required]
         [DataType(DataType.Date)]
        public string BirthDay { get; set; }

        public Gender Gender{get; set;}
        
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Số điện thoại không đúng cú pháp")]
        [Required]
        public string Phone { get; set; }

        

         [Required]
         [Display(Name = "Mã Khoa")]
        public string DeptId{get; set;}


    }
}