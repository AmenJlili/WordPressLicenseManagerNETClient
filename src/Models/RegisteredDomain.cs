using Newtonsoft.Json;

namespace WordPressLicenseManagerNETClient.Models
{
    /// <summary>
    /// Registered domain
    /// </summary>
    public class RegisteredDomain
    {

      
        /// <summary>
        /// ID of the registered domain 
        /// </summary>
        [JsonProperty("id")]
        public int ID { get; set; }
        
        /// <summary>
        /// License ID 
        /// </summary>
        [JsonProperty("lic_key_id")]
        public string LicenseID { get; set; }


        /// <summary>
        /// License key 
        /// </summary>
        [JsonProperty("lic_key")]
        public string LicenseKey { get; set; }


        /// <summary>
        /// Value of the registered domain 
        /// </summary>
        [JsonProperty("registered_domain")]
        public string Value { get; set; }

        /// <summary>
        /// Item reference 
        /// </summary>
        [JsonProperty("item_reference")]
        public string ItemReference { get; set; }

    }
}
