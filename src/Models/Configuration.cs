using System;
using System.Collections.Generic;
using System.Text;

namespace WordPressLicenseManagerNETClient.Models
{
    /// <summary>
    /// <see cref="ILicenseManager"/>'s configuration
    /// </summary>
    public class Configuration
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
    }
}
