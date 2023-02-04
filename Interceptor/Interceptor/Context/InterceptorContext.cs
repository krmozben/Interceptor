namespace Interceptor.Interceptor.Context
{
    public class InterceptorContext
    {
        private readonly static Lazy<InterceptorContext> _Instance = new Lazy<InterceptorContext>(() => new InterceptorContext());

        public static InterceptorContext Instance
        {
            get
            {
                return _Instance.Value;
            }
        }

        public string? MethodName { get; set; }
        public object[]? Arguments { get; set; }
    }
}
