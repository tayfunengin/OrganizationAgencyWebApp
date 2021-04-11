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
    public class ModelAdder
    {
        private readonly IRepository<Organization> _organizationRepository;
        private readonly IRepository<Model> _modelRepository;
        private readonly ApplicationDbContext _context;

        public ModelAdder(IRepository<Organization> organizationRepository, IRepository<Model> modelRepository, ApplicationDbContext context)
        {
            _organizationRepository = organizationRepository;
            _modelRepository = modelRepository;
            _context = context;
        }

        public string AddModel(int modelId, int orgId)
        {
            string message = ""; 
            
            Model model = _modelRepository.GetById(modelId);
            Organization organization = _organizationRepository.GetById(orgId);
            _context.Entry(organization).Collection(o => o.Models).Load();

            if (organization.ModelCountToBeAssigned == 0)
            {
                message = "Organization does not need to be assigned any more model!";
                 return Notification.Message(NotificationType.info, message);
            }
                else
                {
                    bool modelExist = organization.Models.Contains(model);

                    if (modelExist)
                    {
                    message = $"{model.FirstName + " " + model.LastName} has been already assigned to the organization!";
                    return Notification.Message(NotificationType.warning, message);
                    }
                    else
                    {
                        organization.Models.Add(model);


                        organization.AssingedModelsCount += 1;
                        _organizationRepository.SaveChanges();
                      message = $"{model.FirstName + "  " + model.LastName}, has been added to organzitaion : {organization.OrganizationName} ";
                    return Notification.Message(NotificationType.success, message);
                    }

                }
        }
    }
}
