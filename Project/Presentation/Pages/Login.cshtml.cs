using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Presentation.Services;
namespace Presentation.Pages
{
    public class LoginModel  : PageModel
    {
        private readonly IAccountService _service;
        public const string SessionKeyName = "_Name";

        public static string userN{ get; set; }
        public static string userNRole {get; set; }
        public LoginModel(IAccountService servie) 
        {
               
                 this._service = servie;
        }

        public IActionResult OnGet(string returnUrl)
        {
            if(!HttpContext.User.Identity.IsAuthenticated)
                return Page();
            
            HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            
            userN = null;
            return RedirectToPage("Login");
        }

        //[HttpPost]
        
        public IActionResult Onpost( string returnUrl)
        {
            bool isUservalid = false;

            Account user = _service.GetAccount(username);
            //role = _service.GetAllRole();

            if(user!=null)
            {
                isUservalid = true;
            }

        //Identity
            if(ModelState.IsValid && isUservalid)
            {
                var claims = new List<Claim>();

                claims.Add(new Claim(ClaimTypes.Name, user.Username));
                claims.Add(new Claim(ClaimTypes.Role, user.Roles));
                var identity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.
        AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var props = new AuthenticationProperties();
                props.IsPersistent = RememberMe;

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.
        AuthenticationScheme,
                    principal, props).Wait();
            
                    
                    return RedirectToPage("Index");
            }
        else
            {
                ViewData["message"] = "Tài khoản hoặc mật khẩu không đúng";
            }
            return RedirectToPage("Index");
        }

        


        private bool AccountExists(string id)
        {
            return _service.GetAccount(id) != null; 
        }
        
        [TempData]
         public string msg{get; set;}
         [Required]
         [BindProperty]
         public string username{get; set;}
         [Required]
         [BindProperty]
         public string password{get; set;}

        
         [BindProperty]
         public string role{get; set;}
         
         [BindProperty]
         public bool RememberMe { get; set; }
        
    }
}