using Interceptor.Interceptor.Attributes.Base;
using Interceptor.Interceptor.Context;
using Interceptor.Interceptor.Triggers;
using System.Text;

namespace Interceptor.Interceptor.Attributes
{
    public class LogingAttribute : InterceptorBase, IBeforeVoidAspect, IAfterVoidAspect
    {
        public void OnBefore()
        {
            StringBuilder sbLogMessage = new StringBuilder();

            sbLogMessage.AppendLine(string.Format("Method Name: {0}", InterceptorContext.Instance.MethodName));
            sbLogMessage.AppendLine(string.Format("Arguments: {0}", string.Join(",", InterceptorContext.Instance.Arguments)));

            // log işlemini gerçekleştir.
            Console.WriteLine("Loging: {0}", sbLogMessage.ToString());
        }

        public void OnAfter(object value)
        {
            // sonrasında log tutmak istenirse.
        }
    }
}