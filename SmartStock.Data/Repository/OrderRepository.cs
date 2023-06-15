using Microsoft.EntityFrameworkCore;
using SmartStock.Data.Repository.Interface;
using SmartStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SmartStockContext _db;

        public OrderRepository(SmartStockContext db)
        {
            _db = db;
        }

        public string NewOrder(Order order)
        {
            try
            {
                order.CreationDate = DateTime.Now;
                order.Deleted = false;
                order.UserCreationId = 1;

                _db.Add(order);
                _db.SaveChanges();

                return "Orçamento criado";
            }
            catch (Exception ex)
            {
                return "Ocorreu um erro: " + ex.Message;
            }

        }

        public string UpdateOrder(Order order)
        {
            try
            {
                _db.Update(order);
                _db.SaveChanges();

                return "Orçamento atualizado!";
            }
            catch (Exception ex)
            {
                return "Ocorreu um erro: " + ex.Message;
            }

        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            try
            {
                var ordersList = await _db.Orders.Where(x => x.Deleted == false).ToListAsync();

                return (IEnumerable<Order>)ordersList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<Order> GetByIdAsync(int id)
        {
            try
            {
                var order = _db.Orders.Where(x => x.Id == id && x.Deleted == false).FirstOrDefault();

                return order;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public string DeleteOrderById(int id)
        {
            try
            {
                var order = _db.Orders.Where(x => x.Id == id).FirstOrDefault();

                if (order != null)
                {
                    order.DeletedDate = DateTime.Now;
                    order.UserDeletedId = 1;
                    order.Deleted = true;
                    _db.Update(order);
                    _db.SaveChanges();

                    return "Orçamento Deletado";

                }
                else
                {
                    throw new Exception("Orçamento não existe!");
                }
            }
            catch (Exception ex)
            {

                return "Ocorreu um erro: " + ex.Message;
            }
        }
    }
}
