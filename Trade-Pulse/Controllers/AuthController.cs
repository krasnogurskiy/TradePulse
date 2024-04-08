using BLL.DTOs;
using BLL.Services.Interfaces;
using DAL.Tools;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Trade_Pulse.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly SignInManager<User> _signInManager;
        public AuthController(IAuthService authService, SignInManager<User> signInManager)
        {
            _authService = authService;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View("Login");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            if (!ModelState.IsValid) return View(signUpDto);
            var result = await _authService.SignUpAsync(signUpDto);
            if (result.IsFailure)
            {
                TempData["Error"] = result.Error!.Message;
                return View(signUpDto);
            }
            return RedirectToAction("Index", "Auth");
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid) return View(loginDto);

            var result = await _authService.LoginAsync(loginDto);
            if (result.IsFailure || result.Value == null)
            {
                TempData["Error"] = result.Error!.Message;
                return View(loginDto);
            }
            var user = result.Value;

            await _signInManager.SignInAsync(user, true);
            return RedirectToAction("Index", "Category");
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
