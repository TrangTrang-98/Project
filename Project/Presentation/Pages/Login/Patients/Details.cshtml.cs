using ApplicationCore.Entities;
using Presentation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApplicationCore.Entities.PatientAggregate;
namespace Presentation.Pages.Login.Patients
{
    public class DetailsModel : PageModel
    {
        private readonly IPatientService _service;

        public DetailsModel(IPatientService servie)
        {
            _service = servie;
        }

        public Patient Patient{get; set;}
        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = _service.GetMedicalRecord(id ?? default(string));

            if (Patient == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
