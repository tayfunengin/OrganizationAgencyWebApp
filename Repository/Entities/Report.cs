using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class Report : BaseEntity
    {
       

        public Location Location { get; set; }
        public decimal Accommodation { get; set; }

        public decimal Food { get; set; }

        public decimal Wage1 { get; set; }
        public decimal Wage1Total 
        { 
            get
            {
                return Wage1 * Organization.NumberOfDays;
            }
        
        }
        public decimal Wage2 { get; set; }
        public decimal Wage2Total
        {
            get
            {
                return Wage2 * Organization.NumberOfDays;
            }
          }
        public decimal Wage3 { get; set; }
        public decimal TotalWage { get; set; }
        public decimal Expense { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal TotalExpenseAndWage
        { 
            get { return TotalExpense + TotalWage; }
                
          }

        public decimal Budget { get; set; }
        public decimal Revenue 
        {
            get
            {
                return Budget - TotalExpenseAndWage;
            }
        }
       
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }

    }
}
