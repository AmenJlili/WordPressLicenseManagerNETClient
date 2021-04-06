using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressLicenseManagerNETClient;
using WordPressLicenseManagerNETClient.Models;

namespace WPLMNETClient.NetFramework.Tests
{
    [TestClass]
    public class Tests
    {

        Configuration configuration = default(Configuration);
        ILicenseManager licenseManager = default(ILicenseManager);
        License license = default(License);
        [TestInitialize]
        public void OnStartUp()
        {

            configuration = new Configuration();
            configuration.PostURL = "yourtestURL";
            configuration.ActivationKey = "youractivationkey";
            configuration.SecretKey = "yoursecretkey";

            licenseManager = LicenseManagerFactory.New(configuration);


            license = new License();
            license.Email = "yourclientemail";
            license.Key = "yourlicensekey";
            license.FirstName = "firstname";
            license.LastName = "lastname";
            license.CompanyName = "company name";
            license.MaximumDomainAllowed = 1;
        }


        [TestMethod]
        public void ActivateLicenseKey()
        {
            var licenseResponse = licenseManager.PerformAction(WordPressLicenseManagerNETClient.Consts.Action.Activate, new License());
            if (licenseResponse.Success == false)
                throw new Exception(licenseResponse.Message);
            else
                Assert.IsTrue(licenseResponse.Success);
        }
        [TestMethod]
        public void DeactivateLicenseKey()
        {
            var licenseResponse = licenseManager.PerformAction(WordPressLicenseManagerNETClient.Consts.Action.Deactivate, license);
            if (licenseResponse.Success == false)
                throw new Exception(licenseResponse.Message);
            else
                Assert.IsTrue(licenseResponse.Success);
        }
        [TestMethod]
        public void CheckLicenseKey()
        {
            var licenseResponse = licenseManager.PerformAction(WordPressLicenseManagerNETClient.Consts.Action.Check, license);
            if (licenseResponse.Success == false)
                throw new Exception(licenseResponse.Message);
            else
                Assert.IsTrue(licenseResponse.Success, $"Key {licenseResponse.Key}: Domains: {string.Join(", ", licenseResponse.RegisteredDomains.Select(x=> x.Value).ToArray())}");
        }

        [TestMethod]
        public void CreateLicenseKey()
        {
            var licenseResponse = licenseManager.PerformAction(WordPressLicenseManagerNETClient.Consts.Action.Create, license);
            if (licenseResponse.Success == false)
                throw new Exception(licenseResponse.Message);
            else
                Assert.IsTrue(licenseResponse.Success);
        }
    }
}
