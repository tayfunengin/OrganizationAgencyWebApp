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
    public class ModelController : Controller
    {

        private readonly IRepository<Model> _modelRepository;
        private readonly ApplicationDbContext _context;
        private readonly IRepository<Organization> _orgRepository;

        public ModelController(IRepository<Model> modelRepository, ApplicationDbContext context, IRepository<Organization> orgRepository)
        {
            _modelRepository = modelRepository;
            _context = context;
            _orgRepository = orgRepository;
        }
        // GET: ModelController
        public ActionResult Index()
        {
            return View(_modelRepository.GetAll());
        }

        // GET: ModelController/Details/5
        public ActionResult Details(int id)
        {
            return View(_modelRepository.GetById(id));
        }

        public IActionResult Reports (int id)
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
                if (reports.Count>0)
                {
                    TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.success, "Report(s) have been created successfully.");
                    return View(reports);
                }
                else
                {
                    TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.warning, "Model has not participated in any organizations yet!");
                    return View(reports);
                }
                
                
            }
            catch (Exception ex)
            {
                TempData["Notification"] = Notification.Message(Domain.Enums.NotificationType.error, ex.Message);
                return RedirectToAction("Index");
            }
           
        }


        // GET: ModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModelController/Create
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

        // GET: ModelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ModelController/Edit/5
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

        // GET: ModelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ModelController/Delete/5
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
