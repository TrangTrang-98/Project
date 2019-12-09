using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApplicationCore.Entities.PatientAggregate;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using ApplicationCore.Entities.DoctorAggregate;
using Presentation.Services;
using ApplicationCore.DTO;
using ApplicationCore.Interfaces;
using ApplicationCore;
using Presentation.ViewModel;
namespace Presentation.Pages.Login.Doctors
{
    public class IndexModel : PageModel
    {
        //private int pageSize = 5;
        private readonly IDoctorService _service;
        public IndexModel(IDoctorService service)
        {
            _service = service;
        } 

        // [BindProperty(SupportsGet = true)]
        // public string DoctorPhone { get; set; }

        // public SelectList Names { get; set; }

        // public PaginatedList<Doctor> ListDoctor { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }


          public DoctorPageVM DoctorPageVM { get; set; }

        // public async Task OnGetAsync(string searchString, int pageIndex = 1)
        // {
        //     ViewData["searchString"] = searchString;
        //     //int count;

        //     IQueryable<Doctor> doctors = _service.GetAllDoctors();

        //      var names = _service.GetNames();
        //     // int count;
        //     // var doctors = _service.GetDoctors(pageIndex , pageSize , out count);

        //     if (!string.IsNullOrEmpty(searchString))
        //     {
        //         doctors = doctors.Where(m => m.DoctorName.Contains(searchString));
        //     }

            
        //      Names = new SelectList(names.Distinct().ToList());
        //     // ListDoctor = new PaginatedList<DoctorsDTO>(doctors, pageIndex, pageSize, count);

        //     ListDoctor = await PaginatedList<Doctor>.CreateAsync(doctors, pageIndex, pageSize);
        // }
       
       public void OnGet(int pageIndex = 1)
        {
            DoctorPageVM = _service.GetDoctorPageViewModel(SearchString, pageIndex);
        }

        
    }
}

