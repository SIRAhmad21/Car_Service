using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CarServiceBL.Models.ViewModel;
namespace CarServiceUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class RoleController : Controller
    {
        #region Configration
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public RoleController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }
        #endregion
        #region Roles
      //  [Authorize(Roles = "Admin")]
        public IActionResult RoleList()
        {
            return View(_roleManager.Roles);
        }
       // [Authorize(Roles = "Admin")]
        public IActionResult CreateRole()
        {
            return View();
        }
     //   [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = model.RoleName
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                ModelState.AddModelError("", "Not Create Role ");

                return View(model);
            }
            return View(model);
        }
        [HttpGet]
     
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                EditRoleViewModel model = new EditRoleViewModel
                {
                    RoleName = role.Name,
                    RoleId = role.Id
                };
               foreach (var user in _userManager.Users)
               {
                   if (await _userManager.IsInRoleAsync(user, role.Name!))
                   {
                       model.Users.Add(user.Email!);
                   }

                }
                return View(model);
            }
            else { return BadRequest(); }
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {

            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(model.RoleId!);
                role.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(RoleList));
                }
                 foreach (var err in result.Errors)
                 {
                     ModelState.AddModelError(err.Code, err.Description);
                 }
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
     //   [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(id);
            return View(role);


        }
        [HttpPost]
     //   [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRole(string id, IdentityRole r)
        {
            if (id == null) { return NotFound(); }
            var role = await _roleManager.FindByIdAsync(id);
            var result = await _roleManager.DeleteAsync(role!);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(RoleList));
            }
            return View(role);
        }
     //   [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UserRole(string id)
        {
            List<UserRoleViewModel> userRoleViewModels = new List<UserRoleViewModel>();
            if (id == null)
            {
                return NotFound();

            }
            var role = await _roleManager.FindByIdAsync(id);
            foreach (var user in _userManager.Users)
            {
                UserRoleViewModel model = new UserRoleViewModel { UserName = user.UserName, UserId = user.Id };
                if (await _userManager.IsInRoleAsync(user, role.Name!))
                {
                    model.IsSelected = true;
                }
                else
                {
                    model.IsSelected = false;
                }
                userRoleViewModels.Add(model);

            }
            return View(userRoleViewModels);
        }
        [HttpPost]
 //       [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UserRole(string id, List<UserRoleViewModel> models)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            IdentityResult result = null;

            for (int i = 0; i < models.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(models[i].UserId);

                if (models[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);

                }

                else if (!(models[i].IsSelected) && await _userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);

                }
            }
            if (result!.Succeeded)
            {
                return RedirectToAction("EditRole", new { id = id });
            }
            return View(models);
        }
     //   [AllowAnonymous]
      
    }


    #endregion
}

