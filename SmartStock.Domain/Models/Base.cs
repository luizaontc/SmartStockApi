using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Domain.Models
{
    public class Base 
    {
        public bool Deleted { get; set; }

        public DateTime? DeletedDate { get; set; }

        public int? UserDeletedId { get; set; }

        public DateTime CreationDate { get; set; }

        public int UserCreationId { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? UserModifiedId { get; set; }
    }
}
