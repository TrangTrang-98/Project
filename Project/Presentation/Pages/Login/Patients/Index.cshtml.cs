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
namespace Presentation.Pages.Login.Patients
{
    public class IndexModel : PageModel
    {
        //private int pageSize = 5;
        private readonly IPatientService _service;
        public IndexModel(IPatientService service)
        {
            _service = service;
        } 
        

         public PatientPageVM PatientPageVM { get; set; }


        public void OnGet(int pageIndex = 1)
        {
            PatientPageVM = _service.GetPatientPageViewModel(pageIndex);
        }

    }
          
}

