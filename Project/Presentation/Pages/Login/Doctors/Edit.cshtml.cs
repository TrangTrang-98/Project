using Presentation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities.DoctorAggregate;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
namespace Presentation.Pages.Login.Doctors
{
    public class EditModel : PageModel
    {
        private readonly IDoctorService _service;

        public EditModel(IDoctorService servie)
        {
            _service = servie;
        }
       
        [BindProperty]
        public Doctor Doctor { get; set; }

        [BindProperty]
        public Department Department { get; set; }
        public SelectList AllDept{get; set;}

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var allDept = _service.GetAllDept();

            AllDept = new SelectList(allDept.Distinct().ToList());
            

            Doctor = _service.GetDoctor(id ?? default(string));

            if (Doctor == null)
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
                _service.UpdateDoctor(Doctor);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(Doctor.Id))
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

        private bool DoctorExists(string id)
        {
            return _service.GetDoctor(id) != null;
        }
    }
}
