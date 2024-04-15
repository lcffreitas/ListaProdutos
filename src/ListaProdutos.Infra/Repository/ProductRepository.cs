using ListaProdutos.Domain.DTO;
using ListaProdutos.Domain.Interfaces;
using ListaProdutos.Domain.Model;
using ListaProdutos.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaProdutos.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(ProductDTO product)
        {
            var productEntity = new Product
            {
                Id = Guid.NewGuid(),
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                ExpirationDate = product.ExpirationDate,
                Category = product.Category
            };

            _context.Products.Add(productEntity);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ProductDTO>> Get()
        {
            var products = _context.Products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                ExpirationDate = p.ExpirationDate,
                Category = p.Category
            });

            return await products.ToListAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            var productToDelete = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (productToDelete != null)
            {
                _context.Products.Remove(productToDelete);
                await _context.SaveChangesAsync();
                return true; 
            }
            else
            {
                return false; 
            }
        }

        public async Task<ProductDTO> GetById(Guid id)
        {
            var product = await _context.Products
                                .Where(p => p.Id == id)
                                .Select(p => new ProductDTO
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    Price = p.Price,
                                    Stock = p.Stock,
                                    ExpirationDate = p.ExpirationDate,
                                    Category = p.Category
                                })
                                .FirstOrDefaultAsync();

            return product;
        }

        public async Task<bool> Update(ProductDTO product)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Stock = product.Stock;
                existingProduct.ExpirationDate = product.ExpirationDate;
                existingProduct.Category = product.Category;

                await _context.SaveChangesAsync();

                return true; 
            }
            else
            {
                return false; 
            }
        }
    }
}
