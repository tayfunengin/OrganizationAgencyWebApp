using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Maps
{
    public class ModelMap
    {

        public ModelMap(EntityTypeBuilder<Model> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.ID);
            entityTypeBuilder.Property(x => x.FirstName).HasMaxLength(55).IsRequired();
            entityTypeBuilder.Property(x => x.LastName).HasMaxLength(55).IsRequired();
            entityTypeBuilder.Property(x => x.Email).IsRequired();
          
        }


    }
}
