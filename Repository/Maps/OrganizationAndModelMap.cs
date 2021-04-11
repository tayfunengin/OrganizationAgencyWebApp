using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Maps
{
    public class OrganizationAndModelMap
    {

        public OrganizationAndModelMap(EntityTypeBuilder<OrganizationAndModel> entityTypeBuilder)
        {
            entityTypeBuilder.Ignore(x => x.ID);
            entityTypeBuilder.HasKey(x => new { x.ModelId, x.OrganizationId });

        }


    }
}
