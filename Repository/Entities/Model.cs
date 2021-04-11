using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Entities
{
    public class Model : BaseEntity
    {
        public Model()
        {
            ModelStatus = ModelStatus.available;
            Organizations = new List<Organization>();
            PhotoGraphies = new List<PhotoGraphy>();
        }

      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
        public string Tel { get; set; }

        public Gender Gender { get; set; }

        public DateTime Birthdate { get; set; }
        public byte ShoeNumber { get; set; }
        public byte BodySize { get; set; }
        public byte Weight { get; set; }
        public byte Height { get; set; }
        public string ProfilePhotoPath { get; set; }
        public EyeColor EyeColor { get; set; }
        public HairColor HairColor { get; set; }   
        public bool HasDriverLicence { get; set; }
        public ForeignLanguage ForeignLanguage { get; set; }
        public string Note { get; set; }

        public ModelCategory Category { get; set; }

        public ModelStatus ModelStatus { get; set; }
      
        public virtual List<Organization> Organizations { get; set; }

        public List<PhotoGraphy> PhotoGraphies { get; set; }

    }
}
