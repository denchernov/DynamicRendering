using System.Web;
using HelixHub.Foundation.DynamicRendering.Extensions;
using HelixHub.Foundation.DynamicRendering.Settings;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Mvc.Helpers;

namespace HelixHub.Foundation.DynamicRendering.Kernel
{
    public class RenderingEngine
    {
        private readonly SitecoreHelper _scHelper;

        public RenderingEngine(SitecoreHelper scHelper)
        {
            _scHelper = scHelper;
        }
        public HtmlString RenderDynamicView(Item contextItem, Item viewItem)
        {
            if (viewItem.TemplateID == Ids.DynamicViewTemplateId || viewItem.TemplateID == Ids.ViewParts.ContainerTemplateId)
            {
                var viewParts = viewItem.GetChildren();

                var result = string.Empty;

                foreach (Item viewPart in viewParts)
                {
                    result += RenderViewPart(contextItem, viewPart).ToString();
                }

                return new HtmlString(result);
            }

            return new HtmlString(string.Empty);
        }

        private HtmlString RenderViewPart(Item contextItem, Item viewPartItem)
        {
            // let's check type of view part
            if (viewPartItem.TemplateID == Ids.ViewParts.FielIdTemplateId)
            {
                return RenderField(contextItem, new ViewPart(viewPartItem));
            }

            if (viewPartItem.TemplateID == Ids.ViewParts.PlaceholderTemplateId)
            {
                return RenderPlaceholder(contextItem, new ViewPart(viewPartItem));
            }

            if (viewPartItem.TemplateID == Ids.ViewParts.ContainerTemplateId)
            {
                return RenderContainer(contextItem, new ViewPart(viewPartItem));
            }

            return new HtmlString(string.Empty);
        }

        private HtmlString RenderField(Item contextItem, ViewPart viewPart)
        {
            var fieldName = viewPart["Name"];

            if (!string.IsNullOrEmpty(fieldName))
            {

                var fieldHtml = string.IsNullOrEmpty(viewPart.CssClass) && string.IsNullOrEmpty(viewPart.Style)
                    ? _scHelper.Field(fieldName, contextItem)
                    : _scHelper.Field(fieldName, contextItem, new { @class = viewPart.CssClass, style = viewPart.Style });

                if (!string.IsNullOrEmpty(viewPart.TagWrapper))
                    fieldHtml = fieldHtml.WrapWithTag(viewPart.TagWrapper);

                return fieldHtml;
            }

            return new HtmlString(string.Empty);
        }

        private HtmlString RenderContainer(Item contextItem, ViewPart viewPart)
        {
            var containerTag = viewPart["element"];

            if (!string.IsNullOrEmpty(containerTag))
            {
                var attributes = string.Empty;
                if (!string.IsNullOrEmpty(viewPart.CssClass))
                {
                    attributes += $" class=\"{viewPart.CssClass}\"";
                }

                if (!string.IsNullOrEmpty(viewPart.Style))
                {
                    attributes += $" style=\"{viewPart.Style}\"";
                }

                var tagAddition = containerTag == "button" ? "  type=\"button\"" : string.Empty;
                return new HtmlString($"<{containerTag}{tagAddition}{attributes}>{RenderDynamicView(contextItem, viewPart.GetItem())}</{containerTag}>");
            }

            return new HtmlString(string.Empty);
        }

        private HtmlString RenderPlaceholder(Item contextItem, ViewPart viewPart)
        {
            var phdName = viewPart["Name"];

            if (!string.IsNullOrEmpty(phdName))
            {
                var phHtml = _scHelper.Placeholder(phdName);

                if (!string.IsNullOrEmpty(viewPart.TagWrapper))
                    phHtml = phHtml.WrapWithTag(viewPart.TagWrapper);

                return phHtml;
            }

            return new HtmlString(string.Empty);
        }

    }
}