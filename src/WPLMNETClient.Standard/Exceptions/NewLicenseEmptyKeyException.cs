using System;
using System.Runtime.Serialization;

namespace WordPressLicenseManagerNETClient
{
    [Serializable]
    internal class NewLicenseEmptyKeyException : Exception
    {
        public NewLicenseEmptyKeyException()
        {
        }

        public NewLicenseEmptyKeyException(string message) : base(message)
        {
        }

        public NewLicenseEmptyKeyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NewLicenseEmptyKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}