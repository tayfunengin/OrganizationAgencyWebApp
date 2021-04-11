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
    public class AvailableModelFinder
    {
        private readonly IRepository<Organization> _organizationRepository;
        private readonly IRepository<Model> _modelRepository;
        private readonly ApplicationDbContext _context;
        public AvailableModelFinder(IRepository<Organization> organizationRepository, IRepository<Model> modelRepository, ApplicationDbContext context)
        {
            _organizationRepository = organizationRepository;
            _modelRepository = modelRepository;
            _context = context;

        }

        public IEnumerable<Model> GetModels(int id)
        {
            Organization assingOrg = _organizationRepository.GetById(id);
            IEnumerable<Model> models = _modelRepository.GetAll();

            foreach (var model in models)
            {
                model.ModelStatus = ModelStatus.available;
            }

            foreach (var model in models)
            {
                _context.Entry(model).Collection(m => m.Organizations).Load();


                foreach (var org in model.Organizations)
                {
                    if (assingOrg.StartDate >= org.StartDate && assingOrg.StartDate <= org.EndDate || assingOrg.EndDate >= org.StartDate && assingOrg.EndDate <= org.EndDate)
                    {
                        model.ModelStatus = ModelStatus.passive;

                    }

                }

            }
            _context.SaveChanges();

            return _modelRepository.GetDefault(x => x.ModelStatus == ModelStatus.available);


        }

    }
}
