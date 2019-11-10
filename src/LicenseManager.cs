using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WordPressLicenseManagerNETClient.Models;

namespace WordPressLicenseManagerNETClient
{


    /// <summary>
    /// License Manager Factory. 
    /// </summary>
    public static class LicenseManagerFactory
    {
        
        /// <summary>
        /// Creates a new instance of the <see cref="ILicenseManager"/>.
        /// </summary>
        /// <param name="Configuration">Configuration object</param>
        /// <returns><see cref="ILicenseManager"/></returns>
        public static ILicenseManager New(Configuration Configuration)
        {
            if (Configuration == null)
                throw new ArgumentNullException("Configuration");

            return new LicenseManager(Configuration);
        }
    }



    class LicenseManager : ILicenseManager
    {

        /// <summary>
        /// Configuration object.
        /// </summary>
        public Configuration Configuration { get; private set; }
        public LicenseManager(Configuration configuration)
        {
            Configuration = configuration;
        }
        public ILicenseResponse PerformAction(Consts.Action action, License License)
        {
            if (Configuration == null)
                throw new NullReferenceException("Configuration property is null");

            if (action == Consts.Action.Create)
               if ( string.IsNullOrWhiteSpace(Configuration.SecretKey))
                       throw new NullReferenceException("Configuration's Secret key is an empty string or null.");

            if (string.IsNullOrWhiteSpace(Configuration.PostURL) ||
                string.IsNullOrWhiteSpace(Configuration.ActivationKey))
                throw new NullReferenceException("One of the properties of the Configuration property is null or white space.");


            var restClient = new RestSharp.RestClient(Configuration.PostURL);
            var restRequest = new RestSharp.RestRequest();
            restRequest.Method = RestSharp.Method.POST;
            restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            if (action == Consts.Action.Unknown)
                throw new UndefinedActionException("Undefined action.");

            else
            {
                string description = Helper.DescriptionAttr<Consts.Action>(action);
                restRequest.AddParameter("slm_action", description);
            }


            

            switch (action)
            {
                case WordPressLicenseManagerNETClient.Consts.Action.Unknown:
                    break;
                case WordPressLicenseManagerNETClient.Consts.Action.Activate:
                    
                    restRequest.AddParameter("secret_key", Configuration.ActivationKey);

                    // add first name
                    if (string.IsNullOrWhiteSpace(License.FirstName) == false)
                        restRequest.AddParameter("first_name", License.FirstName);
                    // add domain 
                    restRequest.AddParameter("registered_domain", License.RegisteredDomain);
                    // add first name
                    if (string.IsNullOrWhiteSpace(License.FirstName) == false)
                        restRequest.AddParameter("first_name", License.FirstName);
                    // add last name 
                    if (string.IsNullOrWhiteSpace(License.LastName) == false)
                        restRequest.AddParameter("last_name", License.LastName);
                    // add company name 
                    if (string.IsNullOrWhiteSpace(License.CompanyName) == false)
                        restRequest.AddParameter("company_name", License.CompanyName);
                    // add email
                    if (string.IsNullOrWhiteSpace(License.Email) == false)
                        restRequest.AddParameter("email", License.Email);

                    if (string.IsNullOrWhiteSpace(License.Key) == false)
                        restRequest.AddParameter("license_key", License.Key);


                    break;
                case WordPressLicenseManagerNETClient.Consts.Action.Deactivate:
                    
                    restRequest.AddParameter("secret_key", Configuration.ActivationKey);
                  
                    // add first name
                    if (string.IsNullOrWhiteSpace(License.FirstName) == false)
                        restRequest.AddParameter("first_name", License.FirstName);
                    // add domain 
                    restRequest.AddParameter("registered_domain", License.RegisteredDomain);
                    // add first name
                    if (string.IsNullOrWhiteSpace(License.FirstName) == false)
                        restRequest.AddParameter("first_name", License.FirstName);
                    // add last name 
                    if (string.IsNullOrWhiteSpace(License.LastName) == false)
                        restRequest.AddParameter("last_name", License.LastName);
                    // add company name 
                    if (string.IsNullOrWhiteSpace(License.CompanyName) == false)
                        restRequest.AddParameter("company_name", License.CompanyName);
                    // add email
                    if (string.IsNullOrWhiteSpace(License.Email) == false)
                        restRequest.AddParameter("email", License.Email);

                    if (string.IsNullOrWhiteSpace(License.Key) == false)
                        restRequest.AddParameter("license_key", License.Key);
 
                    break;


                case WordPressLicenseManagerNETClient.Consts.Action.Check:
                    restRequest.AddParameter("secret_key", Configuration.ActivationKey);

                    // add first name
                    if (string.IsNullOrWhiteSpace(License.FirstName) == false)
                        restRequest.AddParameter("first_name", License.FirstName);
                    // add last name 
                    if (string.IsNullOrWhiteSpace(License.LastName) == false)
                        restRequest.AddParameter("last_name", License.LastName);
                    // add company name 
                    if (string.IsNullOrWhiteSpace(License.CompanyName) == false)
                        restRequest.AddParameter("company_name", License.CompanyName);
                    // add email
                    if (string.IsNullOrWhiteSpace(License.Email) == false)
                        restRequest.AddParameter("email", License.Email);

                    if (string.IsNullOrWhiteSpace(License.Key) == false)
                        restRequest.AddParameter("license_key", License.Key);
                    break;
                case WordPressLicenseManagerNETClient.Consts.Action.Create:
                    restRequest.AddParameter("secret_key", Configuration.SecretKey);

                    
                    restRequest.AddParameter("date_created", License.DateCreated);
                    restRequest.AddParameter("date_renewed", License.DateRenewed);
                    restRequest.AddParameter("date_expiry", License.DateExpired);

                    // add product name
                    if (string.IsNullOrWhiteSpace(License.ProductReference) == false)
                        restRequest.AddParameter("product_reference", License.ProductReference);

                    // add subscriber id 
                    if (string.IsNullOrWhiteSpace(License.SubscribedID) == false)
                        restRequest.AddParameter("subscriber_id", License.ProductReference);

                    // add first name
                    if (string.IsNullOrWhiteSpace(License.FirstName) == false)
                        restRequest.AddParameter("first_name", License.FirstName);
                    // add last name 
                    if (string.IsNullOrWhiteSpace(License.LastName) == false)
                        restRequest.AddParameter("last_name", License.LastName);
                    // add company name 
                    if (string.IsNullOrWhiteSpace(License.CompanyName) == false)
                        restRequest.AddParameter("company_name", License.CompanyName);
                    // add email
                    if (string.IsNullOrWhiteSpace(License.Email) == false)
                        restRequest.AddParameter("email", License.Email);
                    // add maximum number of domains allowed
                    if (License.MaximumDomainAllowed >= 0)
                    restRequest.AddParameter("maximum_domained_allowed", License.MaximumDomainAllowed);
                    // add license key
                    if (string.IsNullOrWhiteSpace(License.Key) == false)
                        restRequest.AddParameter("license_key", License.Key);
                    else
                        throw new NewLicenseEmptyKeyException("Cannot create license with empty key.");

                    break;
                default:
                    break;
            }

            var response = restClient.Execute(restRequest);
            var content = response.Content;

            var rootObject = new LicenseResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseRet = response.Content;
                // deserialize response 
                var settings = new JsonSerializerSettings();
                settings.MissingMemberHandling = MissingMemberHandling.Ignore;

                var format = "dd-MM-yyyy";
                var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
                var converters = new List<JsonConverter>();
                converters.Add(new AbstractConverter<LicenseResponse, ILicenseResponse>());
                converters.Add(dateTimeConverter);
                settings.Converters = converters;

                var ret =  JsonConvert.DeserializeObject(content, typeof(ILicenseResponse), settings) as ILicenseResponse;

                // update key property when checking license 
                
                var concreteInstance = ret as LicenseResponse;
                concreteInstance.Raise();
                return concreteInstance as ILicenseResponse;

              };

            return null;
           
        }
    
        public Task<ILicenseResponse> PerformActionAsync(Consts.Action action, License License) 
        {
            return Task.Run(() => {
                return PerformAction(action, License);
            });
        }
          
        

        
    }


    /// <summary>
    /// License Manager
    /// </summary>
    public interface ILicenseManager
    {

        /// <summary>
        /// Performs an action. Check <see cref="Consts.Action"></see> for actions.
        /// </summary>
        /// <param name="action">Action</param>
        /// <param name="License">License</param>
        /// <returns><seealso cref="ILicenseResponse"/></returns>
        ILicenseResponse PerformAction(Consts.Action action, License License);
        /// <summary>
        /// Performs an action asynchronously. Check <see cref="Consts.Action"></see> for actions.
        /// </summary>
        /// <param name="action">Action</param>
        /// <param name="License">License</param>
        /// <returns><seealso cref="ILicenseResponse"/></returns>
        Task<ILicenseResponse> PerformActionAsync(Consts.Action action, License License);
    }


 

 

}

