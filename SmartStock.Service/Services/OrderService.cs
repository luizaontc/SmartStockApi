using SmartStock.Data.Repository.Interface;
using SmartStock.Domain.Entities;
using SmartStock.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            try
            {
                var orders = await _orderRepository.GetAllAsync();

                return orders;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro: " + ex);
            }

        }

        public async Task<Order> GetOrderById(int id)
        {
            try
            {
                var order = await _orderRepository.GetByIdAsync(id);

                return order;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro: " + ex);
            }

        }

        public async Task<string> DeleteOrderById(int id)
        {
            try
            {
                var order = _orderRepository.DeleteOrderById(id);

                return order;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro: " + ex);
            }

        }

        public async Task<string> NewOrder(Order order)
        {
            try
            {
                var response = _orderRepository.NewOrder(order);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro: " + ex);
            }
        }

        public async Task<string> UpdateOrder(Order order)
        {
            try
            {
                order.ModifiedDate = DateTime.Now;
                order.UserModifiedId = 1;
                var response = _orderRepository.UpdateOrder(order);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro: " + ex);
            }
        }
    }
}
