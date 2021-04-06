using System;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace WordPressLicenseManagerNETClient.Models
{   /// <summary>
    /// License object
    /// </summary>
    public class License
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public License()
        {
            RegisteredDomain = RegisterDomain();
        }
        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Company name
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Transaction ID.
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        /// Maximum number of allowed domains
        /// </summary>
        public int MaximumDomainAllowed { get; set; }
        /// <summary>
        /// License key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Product reference
        /// </summary>
        public string ProductReference { get;  set; }
        /// <summary>
        /// Expiry date
        /// </summary>
        public DateTime DateExpired { get;  set; }
        /// <summary>
        /// Renewal date
        /// </summary>
        public DateTime DateRenewed { get;  set; }
        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime DateCreated { get;  set; }
        /// <summary>
        /// Subscriber ID
        /// </summary>
        public string SubscriberID { get;  set; }


        /// <summary>
        /// Registered domain
        /// </summary>
        public readonly string RegisteredDomain;


        /// <summary>
        /// Registers the current domain. Default implementation returns a string in the following format: "MachineNode: MACHINENAME - [{CPU_BIOS_SERIAL_NUMBER}]"
        /// </summary>
        /// <remarks>
        /// You can override this method to provide alternative domain of uniquely identifying how a license is activated on a machine.
        /// </remarks>
        public virtual string RegisterDomain()
        {
            string serialNumber = string.Empty;

            ManagementObjectSearcher MOS = new ManagementObjectSearcher(" Select * From Win32_BIOS ");
            foreach (ManagementObject getserial in MOS.Get())
            {
                serialNumber = getserial["SerialNumber"].ToString().GetHashCode().ToString();
            }
            serialNumber = $"MachineNode: {Environment.MachineName} - [{serialNumber}]";

            return serialNumber;
        }
    }
}
