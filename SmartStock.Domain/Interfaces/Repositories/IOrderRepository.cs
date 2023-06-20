using SmartStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task<IEnumerable<OrderDetail>> GetDetailsByIdAsync(int id);
        string NewOrder(Order order);
        string UpdateOrder(Order order);
        string DeleteOrderById(int id);
        Company GetCompanyById(int companyId);
    }
}
