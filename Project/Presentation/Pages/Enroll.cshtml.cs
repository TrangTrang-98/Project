using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ApplicationCore.Entities.PatientAggregate;

namespace Presentation.Pages
{
    

    public class EnrollModel : PageModel
    {
        public Patient Patient{get; set;}
        public void OnGet()
        {
            
        }
    }
}
