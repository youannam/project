using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.Context;
using project.ViewModel;
using System.Security.Claims;

namespace project.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper _mapper;

        public UserController(ApplicationDbContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Details()
        {
            var userName = User.Identity?.Name; // Retrieves the name claim (if available)
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value; // Retrieves the email claim

            if (userEmail != null)
            {
                var user = db.Users.FirstOrDefault(e => e.Email == userEmail);

                if (user != null)
                {
                    var userVm = _mapper.Map<UserDetailsVM>(user);
                    return View(userVm);
                }
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            if (userEmail is not null)
            {
                var user = db.Users.FirstOrDefault(e => e.Id == id && e.Email == userEmail);

                if (user != null)
                {
                    var userVm = _mapper.Map<UserDetailsVM>(user);
                    return View(userVm);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(UserDetailsVM userVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid Data");
                return View(userVM);
            }

            var user = db.Users.FirstOrDefault(e => e.UserName == userVM.UserName);
            if (user != null)
            {
                user.FirstName = userVM.FirstName;
                user.LastName = userVM.LastName;
                user.Email = userVM.Email;

                db.Users.Update(user);
                db.SaveChanges();

                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Login", "Account");
            }
            return RedirectToAction("Index", "Home");
        }


        public IActionResult EmailUniqueCheck(string email, int? Id)
        {
            bool isUnique;

            if (Id.HasValue)
            {
                // Edit scenario: Check if the name is unique except for the current User
                isUnique = !db.Users
                               .Any(c => c.Email == email && c.Id != Id.Value);
            }
            else
            {
                // Create scenario: Check if the name is unique
                isUnique = !db.Users
                               .Any(c => c.Email == email);
            }

            return Json(isUnique);
        }

    }
}
