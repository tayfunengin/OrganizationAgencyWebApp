using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Authentication;
using Repository.Context;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UI.Tools;

namespace UI.Areas.OrgModel.Controllers
{
    [Area("OrgModel")]
    [Authorize(Roles ="Model")]
    public class HomeController : Controller
    {
        private readonly IRepository<Model> _modelRepository;
        private readonly IWebHostEnvironment _env;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppUserRole> _roleManager;

        public HomeController(IRepository<Model> modelRepository, IWebHostEnvironment env, ApplicationDbContext context, UserManager<AppUser> userManager, RoleManager<AppUserRole> roleManager)
        {
            _modelRepository = modelRepository;
            _env = env;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        // GET: HomeController
        public async Task<ActionResult> Index(int id)
        {
            AppUser user =  await _userManager.FindByIdAsync(id.ToString());
            int userId = user.Id;
            TempData["userId"] = userId;
            Model model = _modelRepository.GetDefault(m => m.Email == user.Email).FirstOrDefault();
            if (model!=null)
            {
                return View(model);
            }
            else
            {
                TempData["Notification"] = Notification.Message(NotificationType.info, $"There is no model registered with email: {user.Email}");
                return RedirectToAction("Index", "home", new { area = "" });
            }
            
        }

        // GET: HomeController/Details/5
        public IActionResult Details(int id)
        {

            Model model = _modelRepository.GetById(id);
            
            return View(model);
          
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            TempData["gender"] = Enum.GetValues(typeof(Domain.Enums.Gender));
            TempData["eyeColor"] = Enum.GetValues(typeof(Domain.Enums.EyeColor));
            TempData["hairColor"] = Enum.GetValues(typeof(Domain.Enums.HairColor));
            TempData["foreignLang"] = Enum.GetValues(typeof(Domain.Enums.ForeignLanguage));

            return View(_modelRepository.GetById(id));

        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Model model, int userId)
        {
            int Id = userId;            
         
            try
            {
               
                model.ProfilePhotoPath = _modelRepository.GetById(model.ID).ProfilePhotoPath;
                model.Email = _modelRepository.GetById(model.ID).Email;
                TempData["Notification"] = Notification.Message(NotificationType.success, _modelRepository.Update(model.ID, model));
                return RedirectToAction(nameof(Index), new { id = Id });
            }

            catch(Exception ex)
            {
                TempData["Notification"] = Notification.Message(NotificationType.error, ex.Message);
                return View();
            }       

        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
