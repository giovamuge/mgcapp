using System;
using FFImageLoading.Helpers;

namespace Mugelli.Software.It.Mgc.iOS.Providers
{
    public class CustomLogger : IMiniLogger
    {
        public void Debug(string message)
        {
            Console.WriteLine(message);
        }

        public void Error(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }

        public void Error(string errorMessage, Exception ex)
        {
            Error(errorMessage + Environment.NewLine + ex);
        }
    }
}