using Presentation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
namespace Presentation.Pages.Login.Enrollments
{
    public class EditModel : PageModel
    {
        private readonly IEnrollmentService _service;

        public EditModel(IEnrollmentService servie)
        {
            _service = servie;
        }
       
        [BindProperty]
        public Enrollment Enrollment { get; set; }

        
        public IActionResult OnGet(string idPatient, string idDoctor)
        {
            if (idPatient  == null && idDoctor == null)
            {
                return NotFound();
            }
            
            Enrollment  = _service.GetEnrollment (idPatient ?? default(string), idDoctor ?? default(string));

            if (Enrollment  == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _service.UpdateEnrollment (Enrollment);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(Enrollment.PatientId, Enrollment.DoctorId))
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

        private bool EnrollmentExists(string idPatient, string idDoctor)
        {
            return _service.GetEnrollment (idPatient, idDoctor) != null;
        }
    }
}
