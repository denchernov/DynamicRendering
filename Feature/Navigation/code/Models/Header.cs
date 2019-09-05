namespace HelixHub.Feature.Navigation.Models
{
    using System.Collections.Generic;

    public class Header
    {
        public NavigationItem HomeItem { get; set; }

        public List<NavigationItem> MenuItems { get; set; }
    }
}