using System.Web;

namespace HelixHub.Foundation.DynamicRendering.Extensions
{
    public static class HtmlStringExtensions
    {
        public static HtmlString WrapWithTag(this HtmlString htmlString, string tagName)
        {
            return new HtmlString($"<{tagName}>{htmlString}</{tagName}>"); 
        }
    }
}