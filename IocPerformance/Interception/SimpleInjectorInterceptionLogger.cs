﻿using System.Diagnostics;
using System.Linq;
using SimpleInjector.Extensions.Interception;

namespace IocPerformance.Interception
{
    public class SimpleInjectorInterceptionLogger : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            // Perform logging here, e.g.:
            // TODO: Get values of parameters
            var args = string.Join(", ", invocation.Arguments.Select(x => (x ?? string.Empty).ToString()));
            Trace.WriteLine(string.Format("SimpleInjector: {0}({1})", invocation.GetConcreteMethod().Name, args));

            invocation.Proceed();
        }
    }
}
