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
        public ILicenseResponse PerformAction(Consts.Action action, License license, RestSharp.Method httpMethod = RestSharp.Method.GET)
        {
            if (license == null)
                throw new ArgumentNullException("license");


            if (action == Consts.Action.Unknown)
                throw new ArgumentNullException("action");

            if (Configuration == null)
                throw new NullReferenceException("Configuration property is null.");

            if (string.IsNullOrWhiteSpace(Configuration.PostURL))
                throw new NullReferenceException("The PostURL of the specified configuration object is white space or null.");

            if (action == Consts.Action.Create)
                if (string.IsNullOrWhiteSpace(Configuration.SecretKey))
                    throw new NullReferenceException("The SecretKey of the specified configuration object is an empty string or null.");

            if (action != Consts.Action.Create)
                if (string.IsNullOrWhiteSpace(Configuration.ActivationKey))
                    throw new NullReferenceException("the ActivationKey of the specified configuration object is white space or null.");


            var restClient = new RestSharp.RestClient(Configuration.PostURL);
            var restRequest = new RestSharp.RestRequest();
            restRequest.Method = httpMethod;
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
                    if (string.IsNullOrWhiteSpace(license.FirstName) == false)
                        restRequest.AddParameter("first_name", license.FirstName);
                    // add domain 
                    restRequest.AddParameter("registered_domain", license.RegisteredDomain);
                    // add first name
                    if (string.IsNullOrWhiteSpace(license.FirstName) == false)
                        restRequest.AddParameter("first_name", license.FirstName);
                    // add last name 
                    if (string.IsNullOrWhiteSpace(license.LastName) == false)
                        restRequest.AddParameter("last_name", license.LastName);
                    // add company name 
                    if (string.IsNullOrWhiteSpace(license.CompanyName) == false)
                        restRequest.AddParameter("company_name", license.CompanyName);
                    // add email
                    if (string.IsNullOrWhiteSpace(license.Email) == false)
                        restRequest.AddParameter("email", license.Email);

                    if (string.IsNullOrWhiteSpace(license.Key) == false)
                        restRequest.AddParameter("license_key", license.Key);


                    break;
                case WordPressLicenseManagerNETClient.Consts.Action.Deactivate:

                    restRequest.AddParameter("secret_key", Configuration.ActivationKey);

                    // add first name
                    if (string.IsNullOrWhiteSpace(license.FirstName) == false)
                        restRequest.AddParameter("first_name", license.FirstName);
                    // add domain 
                    restRequest.AddParameter("registered_domain", license.RegisteredDomain);
                    // add first name
                    if (string.IsNullOrWhiteSpace(license.FirstName) == false)
                        restRequest.AddParameter("first_name", license.FirstName);
                    // add last name 
                    if (string.IsNullOrWhiteSpace(license.LastName) == false)
                        restRequest.AddParameter("last_name", license.LastName);
                    // add company name 
                    if (string.IsNullOrWhiteSpace(license.CompanyName) == false)
                        restRequest.AddParameter("company_name", license.CompanyName);
                    // add email
                    if (string.IsNullOrWhiteSpace(license.Email) == false)
                        restRequest.AddParameter("email", license.Email);

                    if (string.IsNullOrWhiteSpace(license.Key) == false)
                        restRequest.AddParameter("license_key", license.Key);

                    break;


                case WordPressLicenseManagerNETClient.Consts.Action.Check:
                    restRequest.AddParameter("secret_key", Configuration.ActivationKey);

                    // add first name
                    if (string.IsNullOrWhiteSpace(license.FirstName) == false)
                        restRequest.AddParameter("first_name", license.FirstName);
                    // add last name 
                    if (string.IsNullOrWhiteSpace(license.LastName) == false)
                        restRequest.AddParameter("last_name", license.LastName);
                    // add company name 
                    if (string.IsNullOrWhiteSpace(license.CompanyName) == false)
                        restRequest.AddParameter("company_name", license.CompanyName);
                    // add email
                    if (string.IsNullOrWhiteSpace(license.Email) == false)
                        restRequest.AddParameter("email", license.Email);

                    if (string.IsNullOrWhiteSpace(license.Key) == false)
                        restRequest.AddParameter("license_key", license.Key);
                    break;
                case WordPressLicenseManagerNETClient.Consts.Action.Create:
                    restRequest.AddParameter("secret_key", Configuration.SecretKey);


                    restRequest.AddParameter("date_created", license.DateCreated.ToString("yyyy-MM-dd"));
                    restRequest.AddParameter("date_renewed", license.DateRenewed.ToString("yyyy-MM-dd"));
                    restRequest.AddParameter("date_expiry", license.DateExpired.ToString("yyyy-MM-dd"));

                    // add product name
                    if (string.IsNullOrWhiteSpace(license.ProductReference) == false)
                        restRequest.AddParameter("product_reference", license.ProductReference);

                    // add subscriber id 
                    if (string.IsNullOrWhiteSpace(license.SubscribedID) == false)
                        restRequest.AddParameter("subscriber_id", license.RegisteredDomain);

                    // add first name
                    if (string.IsNullOrWhiteSpace(license.FirstName) == false)
                        restRequest.AddParameter("first_name", license.FirstName);
                    // add last name 
                    if (string.IsNullOrWhiteSpace(license.LastName) == false)
                        restRequest.AddParameter("last_name", license.LastName);
                    // add company name 
                    if (string.IsNullOrWhiteSpace(license.CompanyName) == false)
                        restRequest.AddParameter("company_name", license.CompanyName);
                    // add email
                    if (string.IsNullOrWhiteSpace(license.Email) == false)
                        restRequest.AddParameter("email", license.Email);
                    // add maximum number of domains allowed
                    if (license.MaximumDomainAllowed >= 0)
                        restRequest.AddParameter("maximum_domained_allowed", license.MaximumDomainAllowed);
                    // add license key
                    if (string.IsNullOrWhiteSpace(license.Key) == false)
                        restRequest.AddParameter("license_key", license.Key);
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

                var ret = JsonConvert.DeserializeObject(content, typeof(ILicenseResponse), settings) as ILicenseResponse;

                // update key property when checking license 

                var concreteInstance = ret as LicenseResponse;
                concreteInstance.Raise();
                return concreteInstance as ILicenseResponse;

            };

            return null;

        }

        public Task<ILicenseResponse> PerformActionAsync(Consts.Action action, License License, RestSharp.Method httpMethod = RestSharp.Method.GET)
        {
            return Task.Run(() =>
            {
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
        /// <param name="httpMethod">Http Method</param>
        /// <returns><seealso cref="ILicenseResponse"/></returns>
        ILicenseResponse PerformAction(Consts.Action action, License License, RestSharp.Method httpMethod = RestSharp.Method.GET);
        /// <summary>
        /// Performs an action asynchronously. Check <see cref="Consts.Action"></see> for actions.
        /// </summary>
        /// <param name="action">Action</param>
        /// <param name="License">License</param>
        /// <param name="httpMethod">Http Method</param>
        /// <returns><seealso cref="ILicenseResponse"/></returns>
        Task<ILicenseResponse> PerformActionAsync(Consts.Action action, License License, RestSharp.Method httpMethod = RestSharp.Method.GET);
    }






}

