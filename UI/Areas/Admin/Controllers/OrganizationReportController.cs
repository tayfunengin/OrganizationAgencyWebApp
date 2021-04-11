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

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrganizationReportController : Controller
    {

        private readonly IRepository<Organization> _organizationRepository;
        private readonly IRepository<Model> _modelRepository;
        private readonly ApplicationDbContext _context;

        public OrganizationReportController(IRepository<Organization> organizationRepository, IRepository<Model> modelRepository, ApplicationDbContext context)
        {
            _organizationRepository = organizationRepository;
            _modelRepository = modelRepository;
            _context = context;
        }
        // GET: OrganizationReportController
        public ActionResult Index()
        {

            return View(_organizationRepository.GetAll());
          
        }

        // GET: OrganizationReportController/Details/5
        public ActionResult Details(int id)
        {
            ReportGenerator reportGenerator = new ReportGenerator(_organizationRepository, _context);
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

        // GET: OrganizationReportController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrganizationReportController/Create
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

        // GET: OrganizationReportController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrganizationReportController/Edit/5
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

        // GET: OrganizationReportController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrganizationReportController/Delete/5
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
