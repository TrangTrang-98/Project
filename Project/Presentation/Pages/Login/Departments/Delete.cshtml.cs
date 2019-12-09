using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation.Services;
namespace Presentation.Pages.Login.Departments
{
    
    public class DeleteModel : PageModel
    {
        private readonly IDepartmentService _service;

        public DeleteModel(IDepartmentService servie)
        {
            _service = servie;
        }

        [BindProperty]
        public Department Department { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = _service.GetDepartment(id ?? default(string));

            if (Department == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = _service.GetDepartment(id ?? default(string));

            if (Department != null)
            {
                _service.DeleteDepartment(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
