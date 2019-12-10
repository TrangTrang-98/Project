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
       public Account Account{get;set;}
       public RegisterAccount Register{get; set;}
    public string ConfirmPassword{get; set;}
        private readonly IAccountService _service;
         public RegisterModel(IAccountService service)
        {
            _service = service;
        }

        public IActionResult OnPost(string returnUrl )
        {
           
            if (ModelState.IsValid)
            {
                Account  = new Account();
                Account.Username = Register.UserName;
                Account.Password = Register.Password;
                Account.Roles = "Bệnh Nhân,Bác Sĩ,Admin";
               
                ConfirmPassword = Account.Password;
                _service.CreateAccount(Account);

                ViewData["message"] = "User created successfully!";
            }
           return RedirectToPage("Login");
        }
    }
}