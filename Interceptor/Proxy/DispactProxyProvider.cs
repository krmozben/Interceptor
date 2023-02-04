using Interceptor.Interceptor.Attributes.Base;
using Interceptor.Interceptor.Context;
using Interceptor.Interceptor.Triggers;
using System.Reflection;

namespace Interceptor.Proxy
{
    public class DispactProxyProvider<TI, T> : DispatchProxy where T : TI, new()
    {
        public static TI Create(T decorated) => Create<TI, DispactProxyProvider<TI, T>>();

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            object returnMessage = default(object)!;
            object exceptionInterceptor = default(object)!;

            try
            {
                var realType = typeof(T);
                var mInfo = realType.GetMethod(targetMethod.Name);
                var Interceptors = mInfo?.GetCustomAttributes(typeof(IInterceptor), true);
                exceptionInterceptor = Interceptors?.Where(x => x.GetType().GetInterface(nameof(IOnExceptionInterceptor)) == typeof(IOnExceptionInterceptor)).FirstOrDefault(default(object))!;

                FillAspectContext(targetMethod, args);

                object response;

                CheckBeforeInterceptor(Interceptors!, out response);

                object result;

                if (response == null)
                    returnMessage = response;
                else
                    returnMessage = targetMethod.Invoke(new T(), args)!;


                CheckAfterInterceptor(Interceptors!, out result);
            }
            catch (Exception ex)
            {
                if (exceptionInterceptor != default(object))
                    ((IOnExceptionInterceptor)exceptionInterceptor).OnException(ex);
            }
     
            // TODO : burada return edilen nesnenin tip güvenli hale getirilmesi gerekli(ÖRN : Metod product nesnesi beklerken true gönderilmektedir.). Konu AOP yapısı olduğu için çözüm için bir yol aranmamıştır

            return returnMessage;
        }

        private void FillAspectContext(MethodInfo targetMethod, object[] args)
        {
            InterceptorContext.Instance.MethodName = targetMethod.Name;
            InterceptorContext.Instance.Arguments = args;
        }

        private void CheckBeforeInterceptor(object[] Interceptors, out object response)
        {
            response = default(object)!;

            foreach (IInterceptor loopAttribute in Interceptors)
            {
                if (loopAttribute is IBeforeVoidInterceptor)
                {
                    ((IBeforeVoidInterceptor)loopAttribute).OnBefore();
                }
                else if (loopAttribute is IBeforeInterceptor)
                {
                    response = ((IBeforeInterceptor)loopAttribute).OnBefore();
                }
            }
        }

        private void CheckAfterInterceptor(object[] Interceptors, out object result)
        {
            result = default(object)!;
            foreach (IInterceptor loopAttribute in Interceptors)
            {
                if (loopAttribute is IAfterVoidInterceptor)
                {
                    ((IAfterVoidInterceptor)loopAttribute).OnAfter(result);
                }
            }
        }
    }
}
