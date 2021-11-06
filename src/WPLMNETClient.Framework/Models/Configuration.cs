using System;
using System.Collections.Generic;
using System.Text;

namespace WordPressLicenseManagerNETClient.Models
{
    /// <summary>
    /// <see cref="ILicenseManager"/>'s configuration
    /// </summary>
    public class Configuration :IDisposable
    {
        /// <summary>
        /// Creates a new instance of the configuration class.
        /// </summary>
        public Configuration()
        {

        }
        /// <summary>
        /// Base URL
        /// </summary>
        public string PostURL { get; set; }
        /// <summary>
        /// Activation/Deactivation key
        /// </summary>
        public string ActivationKey { get; set; }
        /// <summary>
        /// Secret key
        /// </summary>
        public string SecretKey { get; set; }

        // To detect redundant calls
        private bool _disposed = false;

        /// <summary>
        /// Public implementation of Dispose pattern callable by consumers.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///Protected implementation of Dispose pattern.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // TODO: dispose managed state (managed objects).
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.

            _disposed = true;
        }
    }
}
