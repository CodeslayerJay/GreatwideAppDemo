using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreatwideApp.UI.Utilities
{
    /// <summary>
    /// Placeholder class to use instead of magic strings. If language specific is required then
    /// best to place strings into a resource file for culture translations.
    /// </summary>
    public static class AppStrings
    {
        public const int NotSet = 0;
        public const string GenericErrorMsg = "An error occurred. Please try again.";
        public const string ProductEditSuccessMessage = "Product saved successfully.";
        public const string ProductNotFoundMessage = "Product not found.";
    }
}
