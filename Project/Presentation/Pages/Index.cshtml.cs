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
                if(HttpContext.User.IsInRole("Admin"))
                {
                    LoginModel.userNRole = "Admin";
                }
               
                else
                {
                    LoginModel.userNRole = "Bệnh Nhân";
                }
                if(!HttpContext.User.Identity.IsAuthenticated)
                {
                    
                    return RedirectToPage("Login");
                }   
                return Page();      
                
        }
    }
}
