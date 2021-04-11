using Repository;
using Repository.Context;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Tools
{
    public class ReportGenerator
    {
        private readonly IRepository<Organization> _organizationRepository;
        private readonly ApplicationDbContext _context;

        public ReportGenerator(IRepository<Organization> organizationRepository, ApplicationDbContext context)
        {
            _organizationRepository = organizationRepository;
            _context = context;
        }

        public Report GenerateReport(int id)
        {            
                Organization org = _organizationRepository.GetById(id);
                _context.Entry(org).Collection(o => o.Models).Load();

                Report report = new Report();
                 report.Organization = org;
                 report.Budget = org.Budget;

                if (org.City.ToLower() == "istanbul")
                {
                     report.Location = Domain.Enums.Location.InCity;
                }
                else
                {
                    report.Location = Domain.Enums.Location.OutOfCity;
                }

                if (report.Location == Domain.Enums.Location.InCity)
                {
                     report.Accommodation = 0;
                     report.Food = 40;
                }
                else
                {
                      report.Accommodation = 150;
                      report.Food = 80;
                }
                    report.Expense = (report.Food + report.Accommodation) * report.Organization.NumberOfDays;
                int countOfCat3 = 0;
                foreach (var model in report.Organization.Models)
                {
                    if (model.Category == Domain.Enums.ModelCategory.Three)
                    {
                        countOfCat3 += 1;
                    }
                    else if (model.Category == Domain.Enums.ModelCategory.Two)
                    {
                         report.Wage2 = 400;
                    }
                    else if (model.Category == Domain.Enums.ModelCategory.One)
                    {
                      report.Wage1 = 200;
                    }
                }

                if (countOfCat3 != 0)
                {
                       report.Wage3 = (report.Budget * 0.2m) / countOfCat3;
                }
                else
                {
                     report.Wage3 = 0;
                }

                  report.TotalWage = report.Wage1Total + report.Wage2Total + (report.Wage3 * countOfCat3);
                  report.TotalExpense = report.Expense * report.Organization.AssingedModelsCount;

                return report;
            
        }

    }
}
