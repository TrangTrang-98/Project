using System.Threading.Tasks;
using ApplicationCore.Entities;
using Presentation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
namespace Presentation.Pages.Login.Enrollments
{
    public class CreateModel : PageModel
    {
        private readonly IEnrollmentService _service;

         [BindProperty]
        public Enrollment Enrollment { get; set; }

        public SelectList AllPatientId{get; set;}

         public SelectList AllDoctorId{get; set;}

        // [BindProperty]
        // public Doctor Doct { get; set; }
        public CreateModel(IEnrollmentService servie)
        {
            _service = servie;
        }

        public void OnGet()
        {
            var allPatientId = _service.AllPatientId();

            AllPatientId = new SelectList(allPatientId.Distinct().ToList());

            var allDoctorId = _service.AllDoctorId();

            AllDoctorId = new SelectList(allDoctorId.Distinct().ToList());
        }

       

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

             var e = new Enrollment();
             if (await TryUpdateModelAsync<Enrollment>(
                 e,
                 "Enrollment",   // Prefix for form value.
                 e => e.PatientId, e => e.DoctorId, e => e.EnrollmentDate))
            
            _service.CreateEnrollment(Enrollment);

            return RedirectToPage("./Index");
        }
    }
}
