using ListaProdutos.Domain.DTO;
using ListaProdutos.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaProdutos.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> Get();
        Task<ProductDTO> GetById(Guid id); 
        Task<bool> Add(ProductDTO product);
        Task<bool> Update(ProductDTO product);
        Task<bool> Delete(Guid id);
    }
}
