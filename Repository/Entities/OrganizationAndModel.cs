using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class OrganizationAndModel : BaseEntity
    {
        public int OrganizationId { get; set; }
        public int ModelId { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Model Model { get; set; }

    }

}
