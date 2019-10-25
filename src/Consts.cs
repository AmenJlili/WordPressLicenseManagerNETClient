using System.ComponentModel;

namespace WordPressLicenseManagerNETClient.Consts
{
    /// <summary>
    /// Actions
    /// </summary>
    public enum Action
    {
        /// <summary>
        /// Default value
        /// </summary>
        [Description("slm_undefined")]
        Unknown,
        /// <summary>
        /// Create a new license
        /// </summary>
        [Description("slm_create_new")]
        Create,
        /// <summary>
        /// Activate an existing license
        /// </summary>
        [Description("slm_activate")]
        Activate,
        /// <summary>
        /// Deactivate an existing license
        /// </summary>
        [Description("slm_deactivate")]
        Deactivate,
        /// <summary>
        /// Check an existing license
        /// </summary>
        [Description("slm_check")]
        Check,

    }
}
