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

            var viewItem = Sitecore.Context.Database.GetItem(new ID(viewIdString));

            return new RenderingEngine(helper).RenderDynamicView(item, viewItem);
        }
    }
}