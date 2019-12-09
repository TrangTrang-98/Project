using ApplicationCore.Entities;
using Presentation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Presentation.Pages.Login.Departments
{
    public class DetailsModel : PageModel
    {
        private readonly IDepartmentService _service;

        public DetailsModel(IDepartmentService servie)
        {
            _service = servie;
        }

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
    }
}
