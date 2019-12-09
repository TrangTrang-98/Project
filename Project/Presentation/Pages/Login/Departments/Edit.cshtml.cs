using Presentation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using ApplicationCore;
namespace Presentation.Pages.Login.Departments
{
    public class EditModel : PageModel
    {
       
         [BindProperty(SupportsGet = true)]
        public string DoctorHead { get; set; }
        private readonly IDepartmentService _service;

        public EditModel(IDepartmentService servie)
        {
            _service = servie;
        }

        [BindProperty]
        public Department Department { get; set; }
        public SelectList Names{get; set;}
        public IActionResult OnGet(string id)
        {
            // if (id == null)
            // {
            //     return NotFound();
            // }
            var names = _service.GetDoctorNames();
           
            Names = new SelectList(names.Distinct().ToList());

            Department = _service.GetDepartment(id ?? default(string));

            if (Department == null)
            {
                return NotFound();
            }
            return Page();
        }

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
            try
            {
                _service.UpdateDepartment(Department);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeptExists(Department.DeptId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DeptExists(string id)
        {
            return _service.GetDepartment(id) != null;
        }
    }
}
