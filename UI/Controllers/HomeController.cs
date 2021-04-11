using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository;
using Repository.Authentication;
using Repository.Context;
using Repository.Entities;
using Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;
using UI.Tools;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly IRepository<Model> _modelReposiroty;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, IRepository<Model> modelReposiroty, ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _modelReposiroty = modelReposiroty;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            AppUser user = await _userManager.GetUserAsync(User);
            if (user!= null)
            {
                TempData["login"] = user.FirstName;


                var role = await _userManager.GetRolesAsync(user);
                if (role[0].ToString() == "Admin")
                    TempData["role"] = "Admin";
                else if (role[0].ToString() == "Organization")
                    TempData["role"] = "Organization";
                else if (role[0].ToString() == "Report")
                    TempData["role"] = "Report";
                else if (role[0].ToString() == "Model")
                    TempData["role"] = "Model";
                else if (role[0].ToString() == "Member")
                    TempData["role"] = "Member";

                //RoleFinder roleFinder = new RoleFinder(_userManager);
                //TempData["role"] = roleFinder.FindRole(user);
            }
            else
            {
                TempData["login"] = null;
            }
            
            return View();
        }

        public async Task<IActionResult> About()
        {
            AppUser user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                TempData["login"] = user.FirstName;
                var role = await _userManager.GetRolesAsync(user);
                if (role[0].ToString() == "Admin")
                    TempData["role"] = "Admin";
                else if (role[0].ToString() == "Organization")
                    TempData["role"] = "Organization";
                else if (role[0].ToString() == "Report")
                    TempData["role"] = "Report";
                else if (role[0].ToString() == "Model")
                    TempData["role"] = "Model";
                else if (role[0].ToString() == "Member")
                    TempData["role"] = "Member";
            }
            else
            {
                TempData["login"] = null;
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Service()
        {
            AppUser user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                TempData["login"] = user.FirstName;
                var role = await _userManager.GetRolesAsync(user);
                if (role[0].ToString() == "Admin")
                    TempData["role"] = "Admin";
                else if (role[0].ToString() == "Organization")
                    TempData["role"] = "Organization";
                else if (role[0].ToString() == "Report")
                    TempData["role"] = "Report";
                else if (role[0].ToString() == "Model")
                    TempData["role"] = "Model";
                else if (role[0].ToString() == "Member")
                    TempData["role"] = "Member";             
            }
            else
            {
                TempData["login"] = null;
            }
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Model()
        {
            AppUser user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                TempData["login"] = user.FirstName;
                var role = await _userManager.GetRolesAsync(user);
                if (role[0].ToString() == "Admin")
                    TempData["role"] = "Admin";
                else if (role[0].ToString() == "Organization")
                    TempData["role"] = "Organization";
                else if (role[0].ToString() == "Report")
                    TempData["role"] = "Report";
                else if (role[0].ToString() == "Model")
                    TempData["role"] = "Model";
                else if (role[0].ToString() == "Member")
                    TempData["role"] = "Member";               
            }
            else
            {
                TempData["login"] = null;
            }

            IEnumerable<Model> models = _modelReposiroty.GetAll();
            return View(models);
        }

        [Authorize]
        public IActionResult ModelDetails(int id)
        {
            Model model = _modelReposiroty.GetById(id);
            _context.Entry(model).Collection(m => m.PhotoGraphies).Load();

            return View(model);
        }

        public async Task<IActionResult> Contact()
        {
            AppUser user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                TempData["login"] = user.FirstName;
                var role = await _userManager.GetRolesAsync(user);
                if (role[0].ToString() == "Admin")
                    TempData["role"] = "Admin";
                else if (role[0].ToString() == "Organization")
                    TempData["role"] = "Organization";
                else if (role[0].ToString() == "Report")
                    TempData["role"] = "Report";
                else if (role[0].ToString() == "Model")
                    TempData["role"] = "Model";
                else if (role[0].ToString() == "Member")
                    TempData["role"] = "Member";
            }
            else
            {
                TempData["login"] = null;
            }
            return View();
        }
 

    }

}
