using Interceptor.Interceptor.Attributes.Base;

namespace Interceptor.Interceptor.Triggers
{
    public interface IAfterAspect : IInterceptor
    {
        object OnAfter(object value);
    }
}
