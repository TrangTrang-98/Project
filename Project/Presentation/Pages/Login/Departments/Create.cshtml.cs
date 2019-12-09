using System.Threading.Tasks;
using ApplicationCore.Entities;
using Presentation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering; // SelectList in using
namespace Presentation.Pages.Login.Departments
{
    public class CreateModel : PageModel
    {
        public SelectList Names{get; set;} // List Doctor
        private readonly IDepartmentService _service;
       
         [BindProperty(SupportsGet = true)]
        public string DoctorHead { get; set; }
        
        public CreateModel(IDepartmentService servie)
        {
            _service = servie;
        }

        public void OnGet()
        {
            var names = _service.GetDoctorNames();
           
            Names = new SelectList(names.Distinct().ToList());
            
           
            
        }

        [BindProperty]
        public Department Department { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var depart = new Department();
             if (await TryUpdateModelAsync<Department>(
                 depart,
                 "Department",   // Prefix for form value.
                 d => d.DeptId, d => d.DeptName, d => d.DoctorHead))
                
            _service.CreateDepartment(depart);

            return RedirectToPage("./Index");
        }
    }
}
