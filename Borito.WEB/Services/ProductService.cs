using Borito.WEB.Models;
using Borito.WEB.Models.DTO;
using Borito.WEB.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Borito.WEB.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto, string token)
        {
            
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.POST,
                Url = SD.ProductAPIBase + "/api/products",
                AccessToken = token,
                Data = productDto
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.DELETE,
                Url = SD.ProductAPIBase + "/api/products/" + id,
                AccessToken = token,
            });
        }

        public async Task<T> GetAllProductsAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/products",
                AccessToken = token,
                
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/products/" + id ,
                AccessToken = token,
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto,string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.PUT,
                Url = SD.ProductAPIBase + "/api/products/",
                AccessToken = token,
                Data = productDto
            });
        }
    }
}
