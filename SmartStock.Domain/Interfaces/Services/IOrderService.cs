using SmartStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetOrderById(int id);
        Task<string> DeleteOrderById(int id);
        Task<string> NewOrder(Order order);
        Task<string> UpdateOrder(Order order);
    }
}
