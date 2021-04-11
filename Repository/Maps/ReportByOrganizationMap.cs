using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Maps
{
    public class ReportByOrganizationMap
    {
        public ReportByOrganizationMap(EntityTypeBuilder<Report> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.ID);
            //entityTypeBuilder.HasOne(x => x.Organization).WithOne(x => x.ReportByOrganization).HasForeignKey<Organization>(x => x.ReportByOrganizationId);
            //entityTypeBuilder.Property(x => x.OrganizationName).HasMaxLength(255).IsRequired();
            //entityTypeBuilder.Property(x => x.ModelName).HasMaxLength(55).IsRequired();
            //entityTypeBuilder.Property(x => x.ModelSurname).HasMaxLength(255).IsRequired();

        }

    }
}
