using Interceptor.Interceptor.Attributes.Base;

namespace Interceptor.Interceptor.Triggers
{
    public interface IOnExceptionInterceptor : IInterceptor
    {
        void OnException(Exception ex);
    }
}
