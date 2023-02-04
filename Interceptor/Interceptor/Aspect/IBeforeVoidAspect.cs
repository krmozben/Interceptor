using Interceptor.Interceptor.Attributes.Base;

namespace Interceptor.Interceptor.Triggers
{
    public interface IBeforeVoidAspect : IInterceptor
    {
        void OnBefore();
    }
}
