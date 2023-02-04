using Interceptor.Interceptor.Attributes.Base;

namespace Interceptor.Interceptor.Triggers
{
    public interface IBeforeVoidInterceptor : IInterceptor
    {
        void OnBefore();
    }
}
