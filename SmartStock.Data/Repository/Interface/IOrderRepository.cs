using SmartStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Data.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        string NewOrder(Order order);
        string UpdateOrder(Order order);
        string DeleteOrderById(int id);
    }
}
