using SmartStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Domain.DTO
{
    public class OrderDTO
    {
        public long RecipientPhoneNumber { get; set; } 
        //public double? TotalPrice { get; set; } 
        public int Status{ get; set; }
        public int CompanyId{ get; set; }
        public string RecipientComplement { get; set; }
        public string RecipientEmail{ get; set; }
        public string RemetentAddress{ get; set; }
        public string RecipientAddress { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; }

    }
}
