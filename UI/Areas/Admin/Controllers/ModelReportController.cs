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
    public class ModelReportController : Controller
    {

        private readonly IRepository<Model> _modelRepository;
        private readonly ApplicationDbContext _context;
        private readonly IRepository<Organization> _orgRepository;

        public ModelReportController(IRepository<Model> modelRepository, ApplicationDbContext context, IRepository<Organization> orgRepository)
        {
            _modelRepository = modelRepository;
            _context = context;
            _orgRepository = orgRepository;
        }
        // GET: ModelReportController
        public ActionResult Index()
        {
            return View(_modelRepository.GetAll());
       
        }
        public IActionResult Reports(int id)
        {
            try
            {
                Model model = _modelRepository.GetById(id);
                _context.Entry(model).Collection(m => m.Organizations).Load();

                ReportGenerator reportGenerator = new ReportGenerator(_orgRepository, _context);

                List<Report> reports = new List<Report>();

                foreach (var org in model.Organizations)
                {
                    reports.Add(reportGenerator.GenerateReport(org.ID));
                }
                TempData["model"] = model;
                TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.success, "Report(s) have been created successfully.");
                return View(reports);
            }
            catch (Exception ex)
            {
                TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.error, ex.Message);
                return RedirectToAction("Index");
            }

        }

        // GET: ModelReportController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ModelReportController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModelReportController/Create
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

        // GET: ModelReportController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ModelReportController/Edit/5
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

        // GET: ModelReportController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ModelReportController/Delete/5
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
