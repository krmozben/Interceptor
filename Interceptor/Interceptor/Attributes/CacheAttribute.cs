using Interceptor.Interceptor.Attributes.Base;
using Interceptor.Interceptor.Context;
using Interceptor.Interceptor.Triggers;
using Interceptor.Services;
using System.Text.Json;

namespace Interceptor.Interceptor.Attributes
{
    public class CacheAttribute : InterceptorBase, IBeforeAspect, IAfterVoidAspect
    {
        public int DurationInMinute { get; set; }

        public object OnBefore()
        {
            string cacheKey = string.Format("{0}_{1}", InterceptorContext.Instance.MethodName, string.Join("_", InterceptorContext.Instance.Arguments));

            if (true)
            {
                // gerekli cache key ile kontrol ederek varsa cache'de çağırım öncesi metot'u execute
                // etmeden cache üzerinden ilgili veriyi geri dön.

                Console.WriteLine("{0} isimli cache key ile cache üzerinden geliyorum!", cacheKey);
                //return JsonSerializer.Deserialize<object>(JsonSerializer.Serialize(new Product { Name = "test" }));
                return true;
            }
        }

        public void OnAfter(object value)
        {
            string cacheKey = string.Format("{0}_{1}", InterceptorContext.Instance.MethodName, string.Join("_", InterceptorContext.Instance.Arguments));

            // cache key ile ilgili veriyi DurationInMinute kullanarak Cache'e ekle veya güncelle.
        }
    }
}
