using Interceptor.Interceptor.Attributes.Base;

namespace Interceptor.Interceptor.Triggers
{
    public interface IBeforeAspect : IInterceptor
    {
        object OnBefore();
    }
}
