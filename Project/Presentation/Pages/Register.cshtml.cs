using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Presentation.Services;
using ApplicationCore.Entities;
namespace Presentation.Pages
{
    public class RegisterModel  : PageModel
    {
    //    public Account account{get;set;}
        [BindProperty]
       public RegisterAccount register{get; set;}
       [BindProperty]
    public string ConfirmPassword{get; set;}
     [BindProperty]
    public string role{get; set;}
        private readonly IAccountService _service;
         public RegisterModel(IAccountService service)
        {
            _service = service;
        }

        public IActionResult OnPost(string returnUrl)
        {
           
            if (ModelState.IsValid)
            {
               Account account  = new Account();
                account.Username = register.UserName;
                account.Password = register.Password;
                account.Roles = "Bệnh Nhân";
               
                ConfirmPassword = register.Password;
                _service.CreateAccount(account);

                ViewData["message"] = "Đăng Kí Thành Công!";
            }
           return RedirectToPage("Login");
        }
    }
}