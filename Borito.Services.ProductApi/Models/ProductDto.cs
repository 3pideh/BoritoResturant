using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Borito.Services.ProductApi.Models.DTO
{
    public class ProductDto
    {
        public int Productid { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
