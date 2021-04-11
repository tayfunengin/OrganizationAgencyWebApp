using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Repository;
using Repository.Context;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Tools;



namespace UI.Areas.Organizing.Controllers
{
    [Area("Organizing")]
    [Authorize(Roles = "Organization")]
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

            foreach (var org in _organizationRepository.GetAll())
            {
                if (DateTime.Now >= org.StartDate  &&  DateTime.Now <= org.EndDate )
                {
                    org.OrgStatus = OrganizationStatus.Active;
                }
                else if (DateTime.Now > org.EndDate )
                {
                    org.OrgStatus = OrganizationStatus.Completed;
                }

            }
            _context.SaveChanges();


            return View(_organizationRepository.GetAll());
        }

        // GET: OrganizationController/Details/5
        public ActionResult Details(int id)
        {
            Organization org = _organizationRepository.GetById(id);
            _context.Entry(org).Collection(o => o.Models).Load();

            return View(org);
            
        }

        // GET: OrganizationController/Create
        public ActionResult Create()
        {           
            return View();
        }

        // POST: OrganizationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Organization organization)
        {
            if (ModelState.IsValid)
            {
                
                if (organization.StartDate>=DateTime.Now.Date)
                {
                    try
                    {
                        TempData["Notification"] = Notification.Message(NotificationType.success, _organizationRepository.Insert(organization));
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        return View(ex.Message);
                    }

                }
                else
                {
                    TempData["Notification"] = Notification.Message(NotificationType.error, "Start date can not be earlier than today!");
                    return View();
                }

                //}

            }
            else
            {
                return View();
            }

        }

        // GET: OrganizationController/Edit/5
        public ActionResult Edit(int id)
        {         
            Organization org = _organizationRepository.GetById(id);
            _context.Entry(org).Collection(o => o.Models).Load();

            if (org.Models.Count>0)
            {
                TempData["Notification"] = Notification.Message(NotificationType.warning, " Please remove assigned models to organization before updating!");
                return RedirectToAction("Index");
            }

            return View(_organizationRepository.GetById(id));
        }

        // POST: OrganizationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Organization organization)
        {           
                try
                {
                    //TempData["info"] = _organizationRepository.Update(organization.ID,organization);
                    TempData["Notification"] = Notification.Message(NotificationType.success, _organizationRepository.Update(organization.ID, organization));

                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    TempData["Notification"] = Notification.Message(NotificationType.error, ex.Message);
                    return View();
                }            
          
        }

        // GET: OrganizationController/Delete/5
        public ActionResult Delete(int id)
        {
            var deleted = _organizationRepository.GetById(id);         
            return View(deleted);
        }

        // POST: OrganizationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Organization organization)
        {
            try
            {
                Organization deleteOrg = _organizationRepository.GetById(organization.ID);
                _context.Entry(deleteOrg).Collection(o => o.Models).Load();
                deleteOrg.Models.Clear();           

                TempData["Notification"] = Notification.Message(NotificationType.success, _organizationRepository.Delete(deleteOrg));
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["Notification"] = Notification.Message(NotificationType.error, ex.Message);
                return RedirectToAction("Index");
            }
        }

     
        public IActionResult AssignModel(int id)
        {
            Organization assingOrg = _organizationRepository.GetById(id);
            ViewData["org"] = assingOrg;

            AvailableModelFinder modelFinder = new AvailableModelFinder(_organizationRepository, _modelRepository, _context);            
            return View(modelFinder.GetModels(id));
        }

        public IActionResult DetailsModel(int id, int orgId)
        {
            //ViewData["org"] = _organizationRepository.GetAll().FirstOrDefault(x => x.OrganizationName == orgName);
            ViewData["org"] = _organizationRepository.GetAll().FirstOrDefault(x => x.ID == orgId);
            Model model = _modelRepository.GetById(id);
            _context.Entry(model).Collection(m => m.Organizations).Load();
            return View(model);
        }

        public IActionResult AssignModelToOrg (int id, int orgId)
        {
            ModelAdder addModelToOrg = new ModelAdder(_organizationRepository,_modelRepository,_context);

            TempData["Notification"] = addModelToOrg.AddModel(id, orgId);
            return RedirectToAction("AssignModel",new {id= orgId });
        }

        public IActionResult RemoveModelFromOrg (int id, int orgId)
        {
            ModelRemover modelRemover = new ModelRemover(_organizationRepository, _modelRepository, _context);

            TempData["Notification"] = modelRemover.RemoveModel(id, orgId);

            return RedirectToAction("Details", "Organization", new { id = orgId});
        }

    }
}
