using Interceptor.Interceptor.Attributes;
using Interceptor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interceptor.Services
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
    public class ProductService : IProductService
    {
        private Dictionary<int, Product> _InMemDb = new Dictionary<int, Product>();

        public ProductService()
        {
            _InMemDb.Add(1, new Product() { Id = 1, Name = "MacBook Air", Price = 3000 });
            _InMemDb.Add(2, new Product() { Id = 2, Name = "Sony Xperia Z Ultra", Price = 1400 });
        }

        [Cache(DurationInMinute = 10)]
        [Loging]
        [Exception]
        public Product GetProduct(int productId)
        {

            //throw new Exception();
            return _InMemDb[productId];
        }
    }
}
