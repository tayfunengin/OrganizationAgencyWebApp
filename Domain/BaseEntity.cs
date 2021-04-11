using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            AddedDate = DateTime.Now;
        }
        public int ID { get; set; }
        public DateTime? AddedDate { get; set; }

    }
}
