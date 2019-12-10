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
namespace Presentation.Pages.Login.Departments
{
    public class IndexModel : PageModel
    {
        //private int pageSize = 5;
        private readonly IDepartmentService _service;
        public IndexModel(IDepartmentService service)
        {
            _service = service;
        } 
        

         public DepartmentPageVM DepartmentPageVM { get; set; }


        public void OnGet(int pageIndex = 1)
        {
            DepartmentPageVM = _service.GetDepartmentPageViewModel(pageIndex);
        }

        
    }
}
