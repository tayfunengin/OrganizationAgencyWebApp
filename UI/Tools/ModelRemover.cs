using Domain.Enums;
using Repository;
using Repository.Context;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Tools
{
    public class ModelRemover
    {
        private readonly IRepository<Organization> _organizationRepository;
        private readonly IRepository<Model> _modelRepository;
        private readonly ApplicationDbContext _context;

        public ModelRemover(IRepository<Organization> organizationRepository, IRepository<Model> modelRepository, ApplicationDbContext context)
        {
            _organizationRepository = organizationRepository;
            _modelRepository = modelRepository;
            _context = context;
        }

        public string RemoveModel(int id, int orgId)
        {
            string message = "";

            Model model = _modelRepository.GetById(id);
            Organization organization = _organizationRepository.GetById(orgId);
            _context.Entry(organization).Collection(o => o.Models).Load();

            //bool modelExist = organization.Models.Contains(model);
       
                organization.Models.Remove(model);
                message = $"{model.FirstName + " " + model.LastName} has been removed from {organization.OrganizationName}";
                organization.AssingedModelsCount -= 1;
                _organizationRepository.SaveChanges();

                return  Notification.Message(NotificationType.success, message);
           
        }
    }
}
