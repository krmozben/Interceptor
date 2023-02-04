using Interceptor.Proxy;
using Interceptor.Services;
using Interceptor.Services.Interfaces;


// TODO : DI yapılandırılması için bir servis hazırlanabilir.
var proxy = DispactProxyProvider<IProductService, ProductService>.Create(new ProductService());

var product = proxy.GetProduct(1);

Console.WriteLine("Id: {0}, Name: {1}, Price: {2}", product.Id, product.Name, product.Price);
Console.ReadLine();