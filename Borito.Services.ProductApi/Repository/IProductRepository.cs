using Borito.Services.ProductApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Borito.Services.ProductApi.Repository
{
    public interface IProductRepository
    {
        public Task<IEnumerable<ProductDto>> GetProducts();
        public Task<ProductDto> GetProductById(int productId);
        public Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
        public Task<bool> DeleteProduct(int productId);


    }
}
