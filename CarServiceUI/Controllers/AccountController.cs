using CarServiceBL.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        #region Configration
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }
        #endregion

        #region Users
        [HttpGet]
         [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
         [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError(string.Empty, "Email is already registered.");
                    return View(model);
                }
                IdentityUser user = new IdentityUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                    PhoneNumber = model.Mobile
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
                return View(model);
            }
            return View(model);
        }
         [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
         [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)

        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                    ModelState.AddModelError("", "Invailed uaernamwe or password");            
                ModelState.AddModelError("", "Invailed uaernamwe or password");
                return View(model);
            }
            return View(model);
        }
      
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult ChangePasswprd()
        {
            return View();
        }

        [HttpPost]
       
        public async Task<IActionResult> ChangePasswprd(ChangePasswprdViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name); 
                if (user != null)
                {
                    var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

                    if (changePasswordResult.Succeeded)
                    {
                       
                        return RedirectToAction("Index", "Home"); 
                    }

                    foreach (var error in changePasswordResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User not found.");
                }
            }

            return View(model);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
        #endregion

      
        
    }



}


