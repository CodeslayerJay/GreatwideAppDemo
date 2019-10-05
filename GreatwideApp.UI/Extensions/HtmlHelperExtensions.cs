using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GreatwideApp.UI.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static HtmlString ReviewStars(this IHtmlHelper helper, int rating)
        {
            string markup = "<span class=\"text-warning\">";
            
            // Filled Star -> &#9733;
            // Empty Star -> &#9734;

            for (var i = 0; i < rating; i++)
            {
                markup += "&#9733; ";
            }

            for (var i = 0; i < (5 - rating); i++)
            {
                markup += "&#9734; ";
            }

            markup += "</span>";
            
            return new HtmlString(markup);
        }
    }
}
