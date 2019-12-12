using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation.Services;
namespace Presentation.Pages.Login.Enrollments
{
    
    public class DeleteModel : PageModel
    {
        private readonly IEnrollmentService _service;

        public DeleteModel(IEnrollmentService servie)
        {
            _service = servie;
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Enrollment = _service.GetEnrollment(id ?? default(string));

            if (Enrollment == null)
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

            Enrollment = _service.GetEnrollment(id ?? default(string));

            if (Enrollment!= null)
            {
                _service.DeleteEnrollment(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
