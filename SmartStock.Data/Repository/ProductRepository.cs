using Microsoft.EntityFrameworkCore;
using SmartStock.Domain.DTO;
using SmartStock.Domain.Entities;
using SmartStock.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SmartStockContext _db;

        public ProductRepository(SmartStockContext db)
        {
            _db = db;
        }

        public string NewProduct(Product product)
        {
            try
            {
                product.CreationDate = DateTime.Now;
                product.Deleted = false;
                product.UserCreationId = 1;

                _db.Add(product);
                _db.SaveChanges();

                return "Produto adicionado";
            }
            catch (Exception ex)
            {
                return "Ocorreu um erro: " + ex.Message;
            }

        }

        public string UpdateProduct(Product product)
        {
            try
            {
                _db.Update(product);
                _db.SaveChanges();

                return "Produto alterado";
            }
            catch (Exception ex)
            {
                return "Ocorreu um erro: " + ex.Message;
            }

        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                var usersList = await _db.Products
                                        .Where(x => x.Deleted == false)
                                        .ToListAsync();

                return (IEnumerable<Product>)usersList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<Product> GetByIdAsync(int id)
        {
            try
            {
                var product = _db.Products.Where(x => x.Id == id && x.Deleted == false).FirstOrDefault();

                return product;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeleteProductById(int id)
        {
            try
            {
                var product = _db.Products.Where(x => x.Id == id).FirstOrDefault();

                if (product != null)
                {
                    product.DeletedDate = DateTime.Now;
                    product.UserDeletedId = 1;
                    product.Deleted = true;
                    _db.Update(product);
                    _db.SaveChanges();

                    return "Produto Deletado";

                }
                else
                {
                    throw new Exception("Produto não existe!");
                }
            }
            catch (Exception ex)
            {
                return "Ocorreu um erro: " + ex.Message;
            }
        }
    }
}
