using Microsoft.EntityFrameworkCore;
using SmartStock.Domain.Entities;
using SmartStock.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;

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
                //order.CreationDate = DateTime.Now;
                //order.Deleted = false;
                //order.UserCreationId = 1;
                order.TotalPrice = order.OrderDetails.Select(x => x.Price * x.Quantity).Sum();

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
                var ordersList = await _db.Orders
                    .Where(x => x.Deleted == false)
                    .Include(x => x.Company)
                    .Include(x => x.OrderDetails)
                    .ToListAsync();

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
                var order = _db.Orders.Where(x => x.Id == id && x.Deleted == false)
                                       .Include(x=>x.OrderDetails) 
                                        .FirstOrDefault();

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

        public Company GetCompanyById(int companyId)
        {
            try
            {
                var company = _db.Companies.Where(x => x.Id == companyId).FirstOrDefault();

                if (company == null)
                {
                    throw new Exception();
                }
                return company;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
