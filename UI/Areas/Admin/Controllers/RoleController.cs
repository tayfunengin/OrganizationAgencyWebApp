using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Tools;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppUserRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppUserRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        // GET: RoleController
        public ActionResult Index()
        {

            return View(_roleManager.Roles.ToList());
        }

        // GET: RoleController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            List<AppUser> users = new List<AppUser>();
            AppUserRole role = await _roleManager.FindByIdAsync(id);
            
            if (role != null)
            {
                foreach (var user in _userManager.Users)
                {
                    if (user != null && await _userManager.IsInRoleAsync(user, role.Name))
                        users.Add(user);
                }
            }
            TempData["users"] = users;
            
            return View(role);
        }

        // GET: RoleController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppUserRole appUserRole)
        {
            if (ModelState.IsValid)
            {
                
                try
                {
                    var result = await _roleManager.CreateAsync(appUserRole);
                    if (result.Succeeded)
                    {
                        TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.success, "Role has been created successfully.");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }
                    
                }
                catch(Exception ex)
                {
                    TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.error, ex.Message);
                    return View();
                }

            }
            else
            {
                return View();
            }
            
        }

        // GET: RoleController/Edit/5
        public async Task< ActionResult> Edit(string id)
        {
            AppUserRole appUserRole = await _roleManager.FindByIdAsync(id);

            return View(appUserRole);
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AppUserRole appUserRole)
        {
            try
            {
                var updated = await _roleManager.FindByIdAsync(appUserRole.Id.ToString());
                updated.Name = appUserRole.Name;
                updated.Description = appUserRole.Description;

                var result = await _roleManager.UpdateAsync(updated);
                if (result.Succeeded)
                {
                    TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.success, "Role has been updated successfully.");
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
                
            }
            catch(Exception ex)
            {
                TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.error, ex.Message);
                return View();
            }
        }

        // GET: RoleController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            AppUserRole userRole = await _roleManager.FindByIdAsync(id);
            if (userRole!=null)
            {
                return View(userRole);
            }
            return View();
        }

        // POST: RoleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(AppUserRole userRole)
        {
            if (userRole.Id.ToString() != null)
            {
         
              try
                {
                    AppUserRole deleted = await _roleManager.FindByIdAsync(userRole.Id.ToString());
                    var result = await _roleManager.DeleteAsync(deleted);
                    if (result.Succeeded)
                    {
                        TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.success, "Role has been deleted");
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.error, "There is a problem!");
                        return View();
                    }
                }
              catch(Exception ex)
                  {
                    TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.error, ex.Message);
                    return View();
                }

            }
            else
            {
                return View();
            }
        }
    }
}
