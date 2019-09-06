namespace HelixHub.Foundation.DynamicRendering.HtmlHelpers
{
    using System.Web;

    using HelixHub.Foundation.DynamicRendering.Kernel;

    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Helpers;
    using Sitecore.Mvc.Presentation;

    public static class SitecoreHelperExtensions
    {
        public static HtmlString RenderDynamicView(this SitecoreHelper helper, Item item)
        {
            var renderingParameters = RenderingContext.Current.Rendering.Parameters;
            var viewIdString = renderingParameters["Dynamic View"];

            if (!ID.TryParse(viewIdString, out var viewId))
            {
                return new HtmlString("Dynamic View is not set.");
            }

            var viewItem = Sitecore.Context.Database.GetItem(viewId);
            if (viewItem == null)
            {
                return new HtmlString("Dynamic View is null.");
            }

            return new RenderingEngine(helper).RenderDynamicView(item, viewItem);
        }
    }
}