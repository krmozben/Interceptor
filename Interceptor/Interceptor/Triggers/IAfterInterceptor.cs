using Interceptor.Interceptor.Attributes.Base;

namespace Interceptor.Interceptor.Triggers
{
    public interface IAfterInterceptor : IInterceptor
    {
        object OnAfter(object value);
    }
}
