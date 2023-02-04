using Interceptor.Interceptor.Attributes.Base;
using Interceptor.Interceptor.Triggers;

namespace Interceptor.Interceptor.Attributes
{
    public class ExceptionAttribute : InterceptorBase, IOnExceptionInterceptor
    {
        public void OnException(Exception ex)
        {
            // log yazma işlemleri
        }
    }
}
