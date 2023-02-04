using Interceptor.Interceptor.Attributes.Base;

namespace Interceptor.Interceptor.Triggers
{
    public interface IOnExceptionAspect : IInterceptor
    {
        void OnException(Exception ex);
    }
}
