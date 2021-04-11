using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Entities
{
    public class Organization : BaseEntity
    {
        public Organization()
        {
            OrgStatus = OrganizationStatus.Pending;
            Models = new List<Model>();

        }
  
        [Required(ErrorMessage ="is Required!")]
        public string OrganizationName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte NumberOfDays
        {
            get
            {
                int days = (EndDate.Date - StartDate.Date).Days;
                days += 1;
                return Convert.ToByte(days);          
            }
         
        }
        public string City { get; set; }

        public byte CountOfModels { get; set; }

        public byte AssingedModelsCount { get; set; }
        public byte ModelCountToBeAssigned { get { return Convert.ToByte(CountOfModels - AssingedModelsCount); } }
        public OrganizationStatus OrgStatus { get; set; }

        [Required(ErrorMessage = "is Required!")]
        public decimal Budget { get; set; }

        public virtual List<Model> Models { get; set; }

      
        public virtual Report Report { get; set; }
    }
}
