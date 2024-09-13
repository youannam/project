using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.Context;
using project.Models;
using project.ViewModel;
using System.Security.Claims;

namespace project.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AccountController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            //Prevent User From Accessing Register Page if he is already logged in
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegister userRegister)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                return View(userRegister);
            }

            var user = _mapper.Map<User>(userRegister);

            var UserWithHashedPassword = HashPassword(user, userRegister.Password);

            _context.Add(UserWithHashedPassword);
            _context.SaveChanges();

            AutheticateUser(UserWithHashedPassword);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            //Prevent User From Accessing Login Page if he is already logged in
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLogin logindata)
        {
            var user = _context.Users.Where(e => e.Email == logindata.Email || e.UserName == logindata.Email).FirstOrDefault();

            if (user is null)
            {
                ModelState.AddModelError("", "Invalid Email Or Password");
                return View(logindata);
            }

            bool CheckUserPassword = VerifyPassword(logindata.Password, user.Password);

            if (!CheckUserPassword)
            {
                ModelState.AddModelError("", "Invalid Email Or Password");
                return View();
            }

            AutheticateUser(user);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        public IActionResult EmailUniqueCheck(string email)
        {
            var emailExists = _context.Users.Any(u => u.Email == email);

            if (emailExists)
                return Json(false);

            return Json(true);
        }

        public IActionResult UserNameUniqueCheck(string userName)
        {
            var userNameExists = _context.Users.Any(u => u.UserName == userName);

            if (userNameExists)
                return Json(false);

            return Json(true);
        }

        public void AutheticateUser(User user)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
                };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true // Keep the user logged in
            };

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
               new ClaimsPrincipal(claimsIdentity), authProperties);
        }

        public User HashPassword(User user, string plainPassword)
        {
            // Hash the password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword);

            user.Password = hashedPassword;

            return user;
        }

        public bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHashedPassword);
        }


    }
}
