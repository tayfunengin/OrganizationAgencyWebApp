using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Maps
{
    public class OrganizationMap
    {
        public OrganizationMap(EntityTypeBuilder<Organization> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(x => x.ID);
            entityTypeBuilder.HasOne(x => x.Report).WithOne(x => x.Organization).HasForeignKey<Report>(x => x.OrganizationId);
            entityTypeBuilder.Property(x => x.OrganizationName).HasMaxLength(255).IsRequired();
            entityTypeBuilder.Property(x => x.City).HasMaxLength(55).IsRequired();
            entityTypeBuilder.Property(x => x.CountOfModels).IsRequired();
            entityTypeBuilder.Property(x => x.StartDate).IsRequired();

        }

    }
}
