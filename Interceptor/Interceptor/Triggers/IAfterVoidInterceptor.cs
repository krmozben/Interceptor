using Interceptor.Interceptor.Attributes.Base;

namespace Interceptor.Interceptor.Triggers
{
    public interface IAfterVoidInterceptor : IInterceptor
    {
        void OnAfter(object value);
    }
}
