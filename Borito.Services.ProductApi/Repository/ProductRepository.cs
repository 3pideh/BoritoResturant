using AutoMapper;
using Borito.Services.ProductApi.DbContexts;
using Borito.Services.ProductApi.Models;
using Borito.Services.ProductApi.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Borito.Services.ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            if (product.ProductId > 0)
            {
                _db.Products.Update(product);

            }
            else
            { 
                _db.Products.Add(product);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {

            try
            {
                Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
                if (product == null)
                    return false;
                else
                {
                    _db.Remove(product);
                    await _db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }



        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);

        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productlist = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productlist);

        }
    }
}
