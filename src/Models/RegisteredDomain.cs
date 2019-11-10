using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPLMNETClient.Models
{
    public class RegisteredDomain
    {

      
        [JsonProperty("id")]
        public int ID { get; set; }
        
        [JsonProperty("lic_key_id")]
        public string LicenseID { get; set; }

        [JsonProperty("lic_key")]
        public string LicenseKey { get; set; }

        [JsonProperty("registered_domain")]
        public string Value { get; set; }

        [JsonProperty("item_reference")]
        public string ItemReference { get; set; }

    }
}
