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

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminOrgController : Controller
    {
        private readonly IRepository<Organization> _organizationRepository;
        private readonly IRepository<Model> _modelRepository;
        private readonly ApplicationDbContext _context;
        public AdminOrgController(IRepository<Organization> organizationRepository, IRepository<Model> modelRepository, ApplicationDbContext context)
        {
            _organizationRepository = organizationRepository;
            _modelRepository = modelRepository;
            _context = context;
        }

        // GET: AdminOrgController
        public ActionResult Index()
        {
            foreach (var org in _organizationRepository.GetAll())
            {
                if (DateTime.Now >= org.StartDate && DateTime.Now <= org.EndDate)
                {
                    org.OrgStatus = OrganizationStatus.Active;
                }
                else if (DateTime.Now > org.EndDate)
                {
                    org.OrgStatus = OrganizationStatus.Completed;
                }

            }
            _context.SaveChanges();

            return View(_organizationRepository.GetAll());
        }

        // GET: AdminOrgController/Details/5
        public ActionResult Details(int id)
        {
            Organization org = _organizationRepository.GetById(id);
            _context.Entry(org).Collection(o => o.Models).Load();

            return View(org);

        }

        // GET: AdminOrgController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminOrgController/Create
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

        // GET: AdminOrgController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminOrgController/Edit/5
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

        // GET: AdminOrgController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminOrgController/Delete/5
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
