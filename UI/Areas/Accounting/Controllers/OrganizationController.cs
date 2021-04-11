using Domain.Enums;
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
using UI.Tools;

namespace UI.Areas.Accounting.Controllers
{
    [Area("Accounting")]
    [Authorize(Roles = "Report")]
    public class OrganizationController : Controller
    {
        private readonly IRepository<Organization> _organizationRepository;
        private readonly IRepository<Model> _modelRepository;
        private readonly ApplicationDbContext _context;

        public OrganizationController(IRepository<Organization> organizationRepository, IRepository<Model> modelRepository, ApplicationDbContext context)
        {
            _organizationRepository = organizationRepository;
            _modelRepository = modelRepository;
            _context = context;
        }
        // GET: OrganizationController
        public ActionResult Index()
        {
           
            return View(_organizationRepository.GetAll());
        }

        // GET: OrganizationController/Details/5
        public ActionResult Details(int id)
        {
            ReportGenerator reportGenerator = new ReportGenerator(_organizationRepository,_context);
            try
            {
                Report rbo = reportGenerator.GenerateReport(id);
                TempData["Notification"] = Notification.Message(NotificationType.success, "Report has been generated succesfully");
                return View(rbo);
            }
            catch (Exception ex)
            {
                TempData["Notification"] = Notification.Message(NotificationType.error, ex.Message);
                return RedirectToAction("Index");            
            }
            
        }

        // GET: OrganizationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrganizationController/Create
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

        // GET: OrganizationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrganizationController/Edit/5
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

        // GET: OrganizationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrganizationController/Delete/5
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
