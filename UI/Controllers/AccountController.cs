using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Authentication;
using Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Tools;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public object Session { get; private set; }

        public async Task<IActionResult> Login()
        {
            AppUser user = await _userManager.GetUserAsync(User);

            if (user != null)
            {               
                var role = await _userManager.GetRolesAsync(user);
                if (role[0].ToString() == "Admin")
                    return RedirectToAction("Index", "User", new { area = "Admin" });
                else if (role[0].ToString() == "Organization")
                    return RedirectToAction("Index", "Organization", new { area = "Organizing" });
                else if (role[0].ToString() == "Report")
                    return RedirectToAction("Index", "Organization", new { area = "Accounting" });
                else if (role[0].ToString() == "Model")
                    return RedirectToAction("Index", "Home", new { area = "OrgModel", id = user.Id });
                else if (role[0].ToString() == "Member")
                    return RedirectToAction("Index", "Home");        
            }
            else
            {
                return View();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {

            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByNameAsync(loginVM.UserName);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {

                         TempData["login"] = user.FirstName;
                        
                        if (await _userManager.IsInRoleAsync(user, "Admin"))
                        {
                            TempData["role"] = "Admin";
                            return RedirectToAction("Index", "User", new { area = "Admin" });
                        }
                        else if (await _userManager.IsInRoleAsync(user, "Organization"))
                        {
                            TempData["role"] = "Organization";
                            return RedirectToAction("Index", "Organization", new { area = "Organizing" });
                        }
                        else if ( await _userManager.IsInRoleAsync(user, "Report"))
                        {
                            TempData["role"] = "Report";
                            return RedirectToAction("Index", "Organization", new { area = "Accounting" });
                        }
                        else if(await _userManager.IsInRoleAsync(user, "Model"))
                        {
                            TempData["role"] = "Model";
                            return RedirectToAction("Index", "Home", new { area = "OrgModel", id=user.Id });
                        }
                        else if ( await _userManager.IsInRoleAsync(user, "Member"))
                        {
                            TempData["role"] = "Member";
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return View();
                        }

                    }
                    else
                    {
                        TempData["Notification"] = Notification.Message(NotificationType.error, "Username and password does not match!");
                        return View();
                    }
                }
                else
                {
                    TempData["Notification"] = Notification.Message(NotificationType.error, $"There is no user with {loginVM.UserName} username!");
                    return View();
                }
            }
            else
            {
                return View();
            }

        }
      
        public async Task<IActionResult> LogOut()
        {
            AppUser user = await _userManager.GetUserAsync(User);

            await _signInManager.SignOutAsync();

            TempData["Notification"] = Notification.Message(NotificationType.success, "You have logged out successfully");

            return RedirectToAction("Index", "Home", new { area = "" });
        }


        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterVM userRegisterVM)
        {

            if (ModelState.IsValid)
            {
                AppUser userExist = await _userManager.FindByEmailAsync(userRegisterVM.Email);

                if (userExist == null)
                {
                    AppUser newUser = new AppUser();
                    newUser.UserName = userRegisterVM.UserName;
                    newUser.Email = userRegisterVM.Email;
                    newUser.FirstName = userRegisterVM.FirstName;
                    newUser.LastName = userRegisterVM.LastName;


                    var result = await _userManager.CreateAsync(newUser, userRegisterVM.Password);
                    await _userManager.AddToRoleAsync(newUser, "Member");

                    if (result.Succeeded)
                    {
                        TempData["Notification"] = Notification.Message(NotificationType.success, "Register has been completed succesfully. You can login now!");
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var error in result.Errors.ToList())
                        {
                            ModelState.AddModelError(error.Code, error.Description);
                        }
                    }
                }
                else
                {
                    TempData["Notification"] = Notification.Message(NotificationType.error, $"E-mail: {userRegisterVM.Email} has already an account!");
                    return View();
                }

               
            }
            return View(userRegisterVM);

        }


    }
}
