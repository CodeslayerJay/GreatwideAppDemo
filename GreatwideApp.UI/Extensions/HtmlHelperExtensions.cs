using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GreatwideApp.UI.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string ReviewStars(this IHtmlHelper helper, int rating)
        {
            string markup = "<span class=\"text-warning\">";
            
            // HTML Template:
            // <span class="text-warning">&#9733; &#9733; &#9733; &#9733; &#9734;</span>
            // <span>4.0 stars</span>

            for(var i = 0; i <= rating; i++)
            {
                markup = markup + "&#9733; ";
            }

            for(var i = 0; i <= (5 - rating); i++)
            {
                markup = markup + "&#9734; ";
            }

            markup = markup + "</span>";

            return markup;
        }
    }
}
