using ApplicationCore.Entities;
using Presentation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApplicationCore.Entities.PatientAggregate;
namespace Presentation.Pages.Login.Patients
{
    public class DetailsModel : PageModel
    {
        private readonly IMedicalRecordService _service;

        public DetailsModel(IMedicalRecordService servie)
        {
            _service = servie;
        }

        public MedicalRecord MedicalRecord { get; set; }

        public IActionResult OnGet(string medicalrecordid)
        {
            if (medicalrecordid == null)
            {
                return NotFound();
            }

            MedicalRecord = _service.GetMedicalRecord(medicalrecordid ?? default(string));

            if (MedicalRecord == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}