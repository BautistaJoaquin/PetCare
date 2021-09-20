using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using proyecto_mascotas.Models;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Text;
using System;
using Microsoft.AspNetCore.Http;

namespace proyecto_mascotas.Controllers
{
   public class AccountController : Controller
    {
        private readonly AppDBContext _context;

        public AccountController(AppDBContext context)
        {
            _context = context;
        }
       
        [HttpGet]
        public IActionResult Login()
        {
           return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userdetails = await _context.User.SingleOrDefaultAsync(m => m.Email == model.Email && m.Password ==model.Password);
                if(userdetails == null)
                {
                    ModelState.AddModelError("Password","Inicio de Sesion Invalido.");
                    return View("Login");
                }
                HttpContext.Session.SetString("userId",userdetails.Name);
                TempData["userId"]= userdetails.UserId;
                TempData["userName"]= userdetails.Name;
                Console.WriteLine(userdetails.UserId);
            }
            else
            {
                return View("Login");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                User user = new User
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password
                   
                };

                _context.Add(user);
                await _context.SaveChangesAsync();

                
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error en Registro");
                return View();
            }
            // return RedirectToAction("Index", "Home");
            return View(model);

        }

        
        public  IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }

        // //create a string MD5
        // public static string GetMD5(string str)
        // {
        //     MD5 md5 = new MD5CryptoServiceProvider();
        //     byte[] fromData = Encoding.UTF8.GetBytes(str);
        //     byte[] targetData = md5.ComputeHash(fromData);
        //     string byte2String = null;

        //     for (int i = 0; i < targetData.Length; i++)
        //     {
        //         byte2String += targetData[i].ToString("x2");

        //     }
        //     return byte2String;
        // }

       
    }
}