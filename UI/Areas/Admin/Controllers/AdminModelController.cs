using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Context;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminModelController : Controller
    {
        private readonly IRepository<Model> _modelRepository;
        private readonly ApplicationDbContext _context;

        public AdminModelController(IRepository<Model> modelRepository, ApplicationDbContext context)
        {
            _modelRepository = modelRepository;
            _context = context;
        }
        // GET: AdminModelController
        public ActionResult Index()
        {
            return View(_modelRepository.GetAll());
        }

        // GET: AdminModelController/Details/5
        public ActionResult Details(int id)
        {
            Model model = _modelRepository.GetById(id);
            _context.Entry(model).Collection(m => m.Organizations).Load();
            return View(model);
        }

        public IActionResult Gallery(int id)
        {
            Model model = _modelRepository.GetById(id);
            _context.Entry(model).Collection(m => m.PhotoGraphies).Load();

            return View(model);
        }


        // GET: AdminModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminModelController/Create
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

        // GET: AdminModelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: AdminModelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminModelController/Delete/5
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
