﻿using Interceptor.Interceptor.Attributes.Base;

namespace Interceptor.Interceptor.Triggers
{
    public interface IBeforeInterceptor : IInterceptor
    {
        object OnBefore();
    }
}
