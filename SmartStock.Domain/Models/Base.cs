using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Domain.Models
{
    public class Base 
    {
        public bool Deleted { get; set; } = false;

        public DateTime? DeletedDate { get; set; }

        public int? UserDeletedId { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public int UserCreationId { get; set; } = 1;

        public DateTime? ModifiedDate { get; set; }

        public int? UserModifiedId { get; set; }

        public virtual void SetCreationDate()
        {
            CreationDate = DateTime.Now;
            UserCreationId = 1;
        }
    }
}
