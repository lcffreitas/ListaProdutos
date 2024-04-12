using ListaProdutos.Domain.DTO;
using ListaProdutos.Domain.Interfaces;
using ListaProdutos.Domain.Model;
using ListaProdutos.Infra.Data;
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

        public async Task<bool> Create(ProductDTO product)
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

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDTO>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ProductDTO product)
        {
            throw new NotImplementedException();
        }
    }
}
