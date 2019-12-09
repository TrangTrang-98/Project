using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
//using Presentation.Helpers;

namespace Presentation.Pages
{
    public class InforModel : PageModel
    {
        
        private readonly ILogger<InforModel> _logger;

        
        public InforModel(ILogger<InforModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        
        
    }
}
