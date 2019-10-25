using System;
using System.Runtime.Serialization;

namespace WordPressLicenseManagerNETClient
{
    [Serializable]
    internal class UndefinedActionException : Exception
    {
        public UndefinedActionException()
        {
        }

        public UndefinedActionException(string message) : base(message)
        {
        }

        public UndefinedActionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UndefinedActionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}