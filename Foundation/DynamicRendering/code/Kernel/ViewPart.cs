using System;
using Sitecore.Data.Items;

namespace HelixHub.Foundation.DynamicRendering.Kernel
{
    public class ViewPart
    {
        private readonly Item _item;

        public ViewPart(Item item)
        {
            CssClass = item["class"];
            TagWrapper = item["wrapper"];
            Style = item["style"];
            Id = item["id"];
            _item = item;
        }

        public string CssClass { get; }

        public string Style { get; }

        public string TagWrapper { get; }

        public string Id { get; }

        public string this[string name] => _item[name];

        public Item GetItem()
        {
            return _item;
        }
    }
}