using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Services
{

    public class ProductService : IProductService
    {
        private readonly DBContextMicroservice _dBContext;
        public ProductService(DBContextMicroservice dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<Products> AddProduct(Products pro)
        {
            try
            {
                var p = new Products()
                {
                    ProductId=pro.ProductId,
                    ProductName=pro.ProductName,
                    ProductDesc=pro.ProductDesc,
                    ProductPrice=pro.ProductPrice
                };
             var pr=   await _dBContext.Product.AddAsync(p);
                await _dBContext.SaveChangesAsync();
                return await _dBContext.Product.FindAsync(p.ProductId); // Auto ID from DB


            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<bool> DeleteProduct(int ProductId)
        {
            var pro = await _dBContext.Product.Where(x => x.ProductId == ProductId).FirstOrDefaultAsync();
            var result = _dBContext.Product.Remove(pro);

            await _dBContext.SaveChangesAsync();
            return result != null ? true : false;
        }

        public async Task<Products> GetproductById(int ProductId)
        {
            var pro = await _dBContext.Product.Where(x => x.ProductId == ProductId).FirstOrDefaultAsync();
            return pro;
        }

        public async  Task<List<Products>> GetProductList()
        {
            return await _dBContext.Product.ToListAsync();
        }

        public async Task<Products> UpdateProduct(Products products)
        {
            _dBContext.Entry(products).State = EntityState.Modified;
             await _dBContext.SaveChangesAsync();
            return products;
        }
    }
}
