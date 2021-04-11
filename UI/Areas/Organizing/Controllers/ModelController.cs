using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Entities;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using System.Threading;
using UI.Tools;
using Domain.Enums;
using Repository.Context;
using Microsoft.AspNetCore.Authorization;

namespace UI.Areas.Organizing.Controllers
{
    [Area("Organizing")]
    [Authorize(Roles = "Organization")]
    public class ModelController : Controller
    {
        private readonly IRepository<Model> _modelRepository;       
        private readonly IWebHostEnvironment _env;
        private readonly ApplicationDbContext _context;
      

        public ModelController(IRepository<Model> modelRepository, IWebHostEnvironment env, ApplicationDbContext context)
        {
            _modelRepository = modelRepository;
            _env = env;
            _context = context;
        
        }

        // GET: ModelController
        public ActionResult Index()
        {
            return View(_modelRepository.GetAll());
        }

        // GET: ModelController/Details/5
        public ActionResult Details(int id)
        {
            Model model = _modelRepository.GetById(id);
            _context.Entry(model).Collection(m => m.Organizations).Load();
            return View(model);
        }

        // GET: ModelController/Create
        public ActionResult Create()
        {

            TempData["gender"] = Enum.GetValues(typeof(Domain.Enums.Gender));
            TempData["eyeColor"] = Enum.GetValues(typeof(Domain.Enums.EyeColor));
            TempData["hairColor"] = Enum.GetValues(typeof(Domain.Enums.HairColor));
            TempData["foreignLang"] = Enum.GetValues(typeof(Domain.Enums.ForeignLanguage));
            TempData["modelCategory"] = Enum.GetValues(typeof(Domain.Enums.ModelCategory));

            TempData.Keep();
        
            return View();
        }

        // POST: ModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Model model, IFormFile formFile)
        {
            string webRoot = _env.WebRootPath;
            if (formFile == null)
            {
                TempData["Notification"] = Notification.Message(NotificationType.error, "Profile photo can not be empty!");
                return RedirectToAction("Index");
            }
            else
            {
                if (ModelState.IsValid)
                {
                   Model emailExist = _modelRepository.GetAll().FirstOrDefault(x => x.Email == model.Email);
                    if (emailExist!=null)
                    {
                        TempData["Notification"] = Notification.Message(NotificationType.error, $"There is already a model using {model.Email}!");
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        try
                        {
                            if (ProfilePhotoUploader.UploadImage(model, formFile, webRoot))
                            {
                                TempData["Notification"] = Notification.Message(NotificationType.success, _modelRepository.Insert(model));
                                return RedirectToAction(nameof(Index));
                            }
                            else
                            {
                                TempData["Notification"] = Notification.Message(NotificationType.error, "Wrong format has been chosen for profile photo!");
                                return RedirectToAction(nameof(Index));
                            }
                        }
                        catch (Exception ex)
                        {
                            TempData["Notification"] = Notification.Message(NotificationType.error, ex.Message);
                            return RedirectToAction("Index");
                        }
                    }
                  
                }
                else
                {
                    TempData["Notification"] = Notification.Message(NotificationType.error, "Please fill whole form!");
                    return RedirectToAction("Index");
                }
              
            }    
        }

        // GET: ModelController/Edit/5
        public ActionResult Edit(int id)
        {
            TempData["gender"] = Enum.GetValues(typeof(Domain.Enums.Gender));
            TempData["eyeColor"] = Enum.GetValues(typeof(Domain.Enums.EyeColor));
            TempData["hairColor"] = Enum.GetValues(typeof(Domain.Enums.HairColor));
            TempData["foreignLang"] = Enum.GetValues(typeof(Domain.Enums.ForeignLanguage));
            TempData["modelCategory"] = Enum.GetValues(typeof(Domain.Enums.ModelCategory));

            return View(_modelRepository.GetById(id));
        }

        // POST: ModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Model model, IFormFile formFile)
        {
            Model modelUpdate = _modelRepository.GetById(model.ID);

            if (modelUpdate.Email != model.Email)
            {
                foreach (var item in _modelRepository.GetAll())
                {
                    if (item.Email == model.Email)
                    {
                        TempData["Notification"] = Notification.Message(NotificationType.error, $"There is already a model using {model.Email}!");
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
           
            string webRoot = _env.WebRootPath;
            try
            {          
                if (formFile != null)
                {
                    if (ProfilePhotoUploader.UploadImage(model, formFile, webRoot))
                    {
                        TempData["Notification"] = Notification.Message(NotificationType.success, _modelRepository.Update(model.ID, model));
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["Notification"] = Notification.Message(NotificationType.error, "Wrong format has been chosen for profile photo!");
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    model.ProfilePhotoPath = _modelRepository.GetById(model.ID).ProfilePhotoPath;                   
                    TempData["Notification"] = Notification.Message(NotificationType.success, _modelRepository.Update(model.ID, model));
                    return RedirectToAction(nameof(Index));
                }                           
            }

            catch
            {
                return View();
            }
        }

        // GET: ModelController/Delete/5
        public ActionResult Delete(int id)
        {
            Model deleteModel = _modelRepository.GetById(id);
            _context.Entry(deleteModel).Collection(m => m.Organizations).Load();
            int orgNumber = 0;
            string names = "";

            foreach (var org in deleteModel.Organizations)
            {
                if (org.OrgStatus== OrganizationStatus.Pending || org.OrgStatus == OrganizationStatus.Active)
                {
                    orgNumber++;
                    names += $"  {org.OrganizationName}";
                }
            }
            if (orgNumber > 0)
            {
                TempData["Notification"] = Notification.Message(NotificationType.error, $"Before deleting, you need to remove the model from assigned pending/active {orgNumber} organization(s):{names}");
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Notification"] = Notification.Message(NotificationType.success, _modelRepository.Delete(deleteModel));
                return RedirectToAction("Index");
            }
           
        }

        // POST: ModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Model model)
        {
            try
            {         
                TempData["Notification"] = Notification.Message(NotificationType.success, _modelRepository.Delete(model));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public IActionResult Gallery(int id)
        {
            Model model = _modelRepository.GetById(id);
            _context.Entry(model).Collection(m => m.PhotoGraphies).Load();

            return View(model);
        }

        public IActionResult AddPhoto(int modelId)
        {
            Model model = _modelRepository.GetById(modelId);
            TempData["modelForPhoto"] = model;
            return View();
        }

        [HttpPost]
        public IActionResult AddPhoto(PhotoGraphy photo, IFormFile formFile, int id)
        {
            //Model model = TempData["modelForPhoto"] as Model;
            string webRoot = _env.WebRootPath;
            Model model = _modelRepository.GetById(id);

            try
            {     

                if (formFile != null)
                {
                    GalleryImageAdder galleryImageAdder = new GalleryImageAdder(_modelRepository);

                    if (galleryImageAdder.UploadImage(photo, formFile, id, webRoot))
                    {
                        TempData["Notification"] = Notification.Message(NotificationType.success, "Photo has been added successfully");
                        return RedirectToAction("Gallery", model);
                    }
                    else
                    {
                        TempData["Notification"] = Notification.Message(NotificationType.error, "Wrong format!");
                        return RedirectToAction("Gallery", model);
                    }
                }
                else
                {
                    TempData["Notification"] = Notification.Message(NotificationType.error, "No photo was chosen!");
                    return RedirectToAction("Gallery", model);
                }
            }
            catch (Exception ex)
            {
                TempData["Notification"] = Notification.Message(NotificationType.error, ex.Message);
                return View();
            }

        }

        public IActionResult DeletePhoto(int id, int modelId)
        {

            try
            {
                Model model = _modelRepository.GetById(modelId);
                _context.Entry(model).Collection(m => m.PhotoGraphies).Load();
                PhotoGraphy removePhoto = _context.PhotoGraphies.Find(id);
                if (model != null && removePhoto !=null)
                {
                    model.PhotoGraphies.Remove(removePhoto);                    
                    _modelRepository.SaveChanges();
                    TempData["Notification"] = Notification.Message(NotificationType.success, "Photo has been removed successfully");
                    return RedirectToAction("Gallery", new {id = model.ID });
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                Notification.Message(NotificationType.error, ex.Message);
                return View();
            }
           
        }




    }
}
