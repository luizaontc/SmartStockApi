using AutoMapper;
using SmartStock.Data.Repository.Interface;
using SmartStock.Domain.DTO;
using SmartStock.Domain.Entities;
using SmartStock.Domain.Models;
using SmartStock.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
       
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            try
            {
                var products = await _productRepository.GetAllAsync();

                return products;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro: " + ex);
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);

                return product;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro: " + ex);
            }

        }

        public async Task<string> DeleteProductById(int id)
        {
            try
            {
                var user = _productRepository.DeleteProductById(id);

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro: " + ex);
            }

        }

        public async Task<string> NewProduct(Product product)
        {
            try
            {
                var response = _productRepository.NewProduct(product);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro: " + ex);
            }
        }

        public async Task<string> UpdateProduct(Product product)
        {
            try
            {
                product.ModifiedDate = DateTime.Now;
                product.UserModifiedId = 1;
                var response = _productRepository.UpdateProduct(product);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro: " + ex);
            }
        }
    }
}
