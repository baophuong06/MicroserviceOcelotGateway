using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Services
{
    public interface IProductService
    {
         public Task<List<Products>> GetProductList();
        public Task<Products> GetproductById(int ProductId);
        Task<Products> AddProduct(Products products);
        Task<Products> UpdateProduct(Products products);
        public Task<bool> DeleteProduct(int ProductId);
    }
}
