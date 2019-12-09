using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Presentation.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
                LoginModel.userN = HttpContext.User.Identity.Name;
                if(HttpContext.User.IsInRole("admin"))
                {
                    LoginModel.userNRole = "admin";
                }
                else if(HttpContext.User.IsInRole("doctor"))
                {
                    LoginModel.userNRole = "doctor";
                }
                else
                {
                    LoginModel.userNRole = "Bệnh nhân";
                }
                if(!HttpContext.User.Identity.IsAuthenticated)
                {
                    
                    return RedirectToPage("Login");
                }   
                return Page();      
                
        }
    }
}
