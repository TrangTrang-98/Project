using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ApplicationCore.Entities.PatientAggregate;
using ApplicationCore.Entities;
using Presentation.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Pages
{
    

    public class EnrollModel : PageModel
    {
        public Patient Patient{get; set;}
        public Department dept { get; set; }

       
        public SelectList DeptNames { get; set; }
        
        private readonly IPatientService _patService;
        private readonly IDoctorService _docService;
        private readonly IAccountService _accService;
        private readonly IDepartmentService _deptService;
        private readonly IEnrollmentService _enrollService;

        public EnrollModel(IPatientService patService,IDoctorService docService, IAccountService accservie,
        IDepartmentService deptService, IEnrollmentService enrollService) 
        {
               
                 this._patService = patService;
                 this._docService = docService;
                 this._accService = accservie;
                 this._deptService = deptService;
                 this._enrollService = enrollService;
        }

        public void OnGet()
        {
            var deptNames = _deptService.GetNameDepartments();

            DeptNames = new SelectList(deptNames.Distinct().ToList());

            Patient = _patService.GetPatientByAccountID(LoginModel.userN);


        }

        public IActionResult OnPost()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var en = new Enrollment();
            
            en.PatientId = _patService.GetPatientByAccountID(LoginModel.userN).Id;
            en.DeptName = deptName;
            en.EnrollmentDate = date;

            string dpID = _deptService.GetdeptByName(deptName).DeptId;
            en.DoctorId = _docService.getRandDoctorID(dpID).Id;

            _enrollService.CreateEnrollment(en);
            return RedirectToPage("Login/Departments/Index");
        }

       

        [Required]
        [BindProperty]
        public DateTime date { get; set; }

        [BindProperty(SupportsGet = true)]
        public string deptName { get; set; }

    }
}
