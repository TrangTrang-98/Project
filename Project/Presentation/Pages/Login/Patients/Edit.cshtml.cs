using Presentation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities.PatientAggregate;
using ApplicationCore.Entities;
using System.Threading.Tasks;
namespace Presentation.Pages.Login.Patients
{
    public class EditModel : PageModel
    {
        private readonly IPatientService _service;
       // public Address Address{get; set;}

        public EditModel(IPatientService servie)
        {
            _service = servie;
        }

        [BindProperty]
        public Patient Patient { get; set; }
       
        [BindProperty]
         public string numhouse { get; set; }

        [BindProperty]

        public string street { get; set; }

        [BindProperty]

        public string district { get; set; }

        [BindProperty]

        public string city { get; set; }

        [BindProperty]

        public string country { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Patient = _service.GetPatient(id ?? default(string));
            numhouse = Patient.Address.NumHouse;
            street = Patient.Address.Street;
            district = Patient.Address.District;
            city = Patient.Address.City;
            country = Patient.Address.Country;
          
           // Address = Patient.Address;

            if (Patient == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public  IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Patient.Address = new Address(numhouse,street,district,city,country);
           
            try
            {
                _service.UpdatePatient(Patient);
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(Patient.Id))
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

        private bool PatientExists(string id)
        {
            return _service.GetPatient(id) != null;
        }
    }
}
