


# WordPressLicenseManagerNETClient
A .NET client for  software License Manager (https://wordpress.org/plugins/software-license-manager/). 

A better fork of the software license manager wordpress plugin with woocommerce integration can be found [here](https://github.com/Arsenal21/software-license-manager) (https://github.com/Arsenal21/software-license-manager)

# Are your binaires signed?
 Starting version 1.0.6, WPLMNETClient.Framework.dll and WPLMNETClient.Standard.dll and their dependencies are signed.

# NuGet

.NET Standard 2.0 ![NuGet](https://img.shields.io/nuget/v/WPLMNETClient.svg) 

``` Install-Package WPLMNETClient ```

.NET Framework 4.7.2 ![NuGet](https://img.shields.io/nuget/v/WPLMNETClient.Framework.svg) 

``` Install-Package WPLMNETClient.Framework ```

 
# Examples

## Actions 
Four actions are available. You can create a new license, activate/deactivate a license or check the metadata of an existing license.

## Configuration class

The configuration class is where you stored the credentials required. The ``` secret key ``` is only required to create a new license. The ``` activation key ``` is required to complete the other actions.

## Sample

This sample shows how to activate a pending license. Deactivation and creation of license is very similar to this example.

 ```csharp 
 
        Configuration configuration = default(Configuration);
        ILicenseManager licenseManager = default(ILicenseManager);
        License license = default(License);
        public void Main()
        {
            // create configuration object
            configuration = new Configuration();
            configuration.PostURL = "http://chucknorris.co";
            configuration.ActivationKey = "abc";
            configuration.SecretKey = "123";
            // create license manager
            licenseManager = LicenseManagerFactory.New(configuration);
            // create license object 
            license = new License();
            license.Email = "charles@chucknorris.co";
            license.Key = "password123";
            license.FirstName = "Chuck";
            license.LastName = "Norris";
            license.CompanyName = "Chuck Norris Unlimited Liability Co";
            license.MaximumDomainAllowed = 1;
            // you must call RegisterDomain before you perform an action
            license.RegisterDomain();



        
            ActivateLicenseKey();
        }


        
        public void ActivateLicenseKey()
        {
            var licenseResponse = licenseManager.PerformAction(WordPressLicenseManagerNETClient.Consts.Action.Activate, license);
            if (licenseResponse.Success == false)
                throw new Exception(licenseResponse.Message);
            else
                Assert.IsTrue(licenseResponse.Success);
        }
 ```
 
 # Acknowledgement

Thanks to https://github.com/xavave for his contributions.

