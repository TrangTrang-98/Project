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
namespace Presentation.Pages.Login.Departments
{
    public class IndexModel : PageModel
    {
        private int pageSize = 5;
        private readonly IDepartmentService _service;
        public IndexModel(IDepartmentService service)
        {
            _service = service;
        } 

        // [BindProperty(SupportsGet = true)]
        // public string DoctorPhone { get; set; }

        public SelectList Names { get; set; }

        public PaginatedList<DepartmentsDTO> ListDept { get; set; }

        public void OnGet(string searchString, int pageIndex = 1)
        {
            ViewData["searchString"] = searchString;

            var names = _service.GetNameDepartments();
            int count;
            var depts = _service.GetDepartments(pageIndex , pageSize , out count);

            if (!string.IsNullOrEmpty(searchString))
            {
                depts = depts.Where(m => m.DeptName.Contains(searchString));
            }
            // if (!string.IsNullOrEmpty(DoctorPhone))
            // {
            //     doctors = doctors.Where(m => m.Phone == DoctorPhone);
            // }

            
            Names = new SelectList(names.Distinct().ToList());
            ListDept = new PaginatedList<DepartmentsDTO>(depts, pageIndex, pageSize, count);
        }
       
        
    }
}
