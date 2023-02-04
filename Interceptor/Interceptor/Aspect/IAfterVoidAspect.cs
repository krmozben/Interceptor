using Interceptor.Interceptor.Attributes.Base;

namespace Interceptor.Interceptor.Triggers
{
    public interface IAfterVoidAspect : IInterceptor
    {
        void OnAfter(object value);
    }
}
