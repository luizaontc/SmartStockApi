using SmartStock.Domain.Entities;
using SmartStock.Domain.Interfaces.Repositories;
using SmartStock.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using SmartStock.Domain.DTO;
using AutoMapper;

namespace SmartStock.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository,IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
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

        public async Task<IEnumerable<Order>> GetOrdersByDate(DateTime initialDate, DateTime endDate)
        {
            try
            {
                var orders = await _orderRepository.GetOrderByDateAsync(initialDate,endDate);

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

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsById(int id)
        {
            try
            {
                var order = await _orderRepository.GetDetailsByIdAsync(id);

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

        public async Task<string> NewOrder(OrderDTO orderDto)
        {
            try
            {
                var order = _mapper.Map<Order>(orderDto);
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
