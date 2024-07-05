using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Store.Business.Exceptions
{
    public static class ArgumentNullExceptionService
    {
        public static void ThrowIfNull<T>(this T argument, string paramName, ILogger logger, string message)
        {
            if (argument is not null)
            {
                return;
            }

            var exception = new ArgumentNullException(paramName, message);

            logger.LogError(exception, message);

            throw exception;
        }
    }
}
