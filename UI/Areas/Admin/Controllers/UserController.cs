using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;
using Repository.Authentication;
using Repository.Context;
using Repository.Entities;
using Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Tools;


namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class UserController : Controller
    {

        private readonly RoleManager<AppUserRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IRepository<Model> _modelRepository;

        public UserController(RoleManager<AppUserRole> roleManager, UserManager<AppUser> userManager, IRepository<Model> modelRepository)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _modelRepository = modelRepository;
        }
        // GET: UserController
        public ActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }

        // GET: UserController/Details/5
        public  ActionResult Details(int id)
        {
          
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            

            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Create( RegisterVM registerVM )
        {

            AppUser userExist = await _userManager.FindByEmailAsync(registerVM.Email);
            AppUser userExist2 = await _userManager.FindByNameAsync(registerVM.UserName);


            if (userExist == null && userExist2 == null )
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        AppUser user = new AppUser
                        {
                            FirstName = registerVM.FirstName,
                            LastName = registerVM.LastName,
                            UserName = registerVM.UserName,
                            Email = registerVM.Email
                        };

                        bool roleExist = await _roleManager.RoleExistsAsync(registerVM.Role);

                        if (roleExist)
                        {
                            if (registerVM.Role.ToUpper() =="MODEL")
                            {
                                bool modelExist = false;
                                foreach (var model in _modelRepository.GetAll())
                                {
                                    if (model.Email == registerVM.Email)
                                    {
                                        user.FirstName = model.FirstName;
                                        user.LastName = model.LastName;
                                        modelExist = true;
                                    }                                  
                                }
                                if (!modelExist)
                                {
                                    TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.error, $"There is no model using the provided e-mail: {registerVM.Email}!");
                                    return View();
                                }
                            }
                            
                            var result = await _userManager.CreateAsync(user, registerVM.Password);
                            await _userManager.AddToRoleAsync(user, registerVM.Role);

                            if (result.Succeeded)
                            {
                                TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.success, "User has been created");
                                return RedirectToAction(nameof(Index));
                            }
                            else
                            {
                                TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.error, "There is an error!");
                                return RedirectToAction(nameof(Index));
                            }

                        }
                        else
                        {
                            TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.error, $"Role: {registerVM.Role} does not exist!");
                            return View();
                        }

                    }
                    catch (Exception ex)
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
            else
            {
                if (userExist !=null)
                {
                    TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.error, "Email address has already a role!");
                    return View();
                }
                else
                {
                    TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.error, "Username has already a role!");
                    return View();
                }
            }
         
        }

        // GET: UserController/Edit/5
        public async Task< ActionResult> Edit(string id)
        {

         
            TempData["userRole"] = "";
            UpdateVM update = new UpdateVM();
            AppUser user = await _userManager.FindByIdAsync(id);

            List<AppUserRole> roles =  _roleManager.Roles.ToList();
            foreach (var role in roles)
            {
                if (role != null)
                {                    
                        if (user != null && await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        TempData["userRole"] = role.Name;
                        update.Id = user.Id;
                        update.UserName = user.UserName;
                         update.FirstName = user.FirstName;
                        update.LastName = user.LastName;
                        update.Email = user.Email;
                         update.Role = role.Name;
                    }                    
                }
            }

            return View(update);

        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateVM updateVM)
        {

            try
            {
                var updated = await _userManager.FindByIdAsync(updateVM.Id.ToString());
                AppUser emailExist = await _userManager.FindByEmailAsync(updateVM.Email);
                AppUser userNameExist = await _userManager.FindByNameAsync(updateVM.UserName);

                if (

                    (emailExist == null && userNameExist == null) || 
                    (emailExist == null && updateVM.UserName == updated.UserName) || 
                    (emailExist!= null && updateVM.Email == updated.Email) 
                    
                    )
                {

                    updated.UserName = updateVM.UserName;
                    updated.Email = updateVM.Email;
                    updated.FirstName = updateVM.FirstName;
                    updated.LastName = updateVM.LastName;

                    bool roleExist = await _roleManager.RoleExistsAsync(updateVM.Role);

                    if (roleExist)
                    {
                        var result = await _userManager.UpdateAsync(updated);
                        await _userManager.RemoveFromRoleAsync(updated, TempData["userRole"] as string);
                        await _userManager.AddToRoleAsync(updated, updateVM.Role);
                        if (result.Succeeded)
                        {
                            TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.success, "User has been updated");
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.error, "Username has been already taken!");
                            return View();
                        }
                    }
                    else
                    {
                        TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.error, $"Role: {updateVM.Role} does not exist!");
                        return View();
                    }
                }
                else
                {
                    if (emailExist!=null)
                    {
                        TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.error, "Email has been already taken!");
                          return View();
                    }
                    else
                    {
                        TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.error, "Username has been already taken!");
                        return View();
                    }
                }          
            }

            catch (Exception ex)
            {
                TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.error, ex.Message);
                return View();
            }
        }

        // GET: UserController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            return View();
           
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(AppUser user)
        {

            if (user.Id.ToString() != null)
            {
                try
                {
                    AppUser deleted = await _userManager.FindByIdAsync(user.Id.ToString());
                    var result = await _userManager.DeleteAsync(deleted);
                    if (result.Succeeded)
                    {
                        TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.success, "User has been deleted");
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.error, "There is a problem!");
                        return View();
                    }
                }
                catch (Exception ex)
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

