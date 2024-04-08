using BLL.DTOs;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using DAL.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Trade_Pulse.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly SignInManager<User> _signInManager;
        public AuthController(IAuthService authService, SignInManager<User> signInManager, IUserRepository userRepository)
        {
            _authService = authService;
            _signInManager = signInManager;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View("Login");
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Update()
        {
            var userEmail = this.User.Identity!.Name;
            var user = await _userRepository.GetByEmailAsync(userEmail!);
            if (user == null) return NotFound();

            return View("Update", new UpdateUserDto(user));
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

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete()
        {
            string? idStr = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int id = int.Parse(idStr!);

            await _authService.DeleteUserAsync(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserDto updateUserDto)
        {
            if (!ModelState.IsValid) return View(updateUserDto);
            var result = await _authService.UpdateUserAsync(updateUserDto);
            if (result.IsFailure || result.Value == null) TempData["Error"] = result.Error!.Message;
            return View(updateUserDto);
        }
    }
}
