﻿namespace HelixHub.Feature.Navigation.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using HelixHub.Feature.Navigation.Extensions;
    using HelixHub.Feature.Navigation.Models;

    using Sitecore;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Controllers;

    public class NavigationController : SitecoreController
    {
        private readonly ID contentPageTemplateId = new ID("{53B3F315-7E49-4512-8122-A096E3597DAA}");

        public ActionResult Header()
        {
            var model = this.GetHeaderMenu();

            return this.View("~/Views/Navigation/Header.cshtml", model);
        }

        private Header GetHeaderMenu()
        {
            if (Context.Site == null || string.IsNullOrEmpty(Context.Site.StartPath))
            {
                return null;
            }

            var homeItem = Context.Site.Database.GetItem(Context.Site.StartPath);
            if (homeItem == null)
            {
                return null;
            }

            var header = new Header
                             {
                                 HomeItem = new NavigationItem { Title = homeItem.DisplayName, Link = homeItem.Url() },
                                 MenuItems = new List<NavigationItem>()
                             };

            var childList = homeItem.GetChildren();
            foreach (var child in childList)
            {
                var item = child as Item;
                if (item == null)
                {
                    continue;
                }

                // If item is not content page, then skip
                if (item.TemplateID != this.contentPageTemplateId)
                {
                    continue;
                }

                header.MenuItems.Add(
                    new NavigationItem { IsActive = IsActive(item), Title = item.DisplayName, Link = item.Url() });
            }

            return header;
        }

        private static bool IsActive(Item navigationLinkItem)
        {
            if (navigationLinkItem == null)
            {
                return false;
            }

            var currentItem = Context.Item;
            if (currentItem == null)
            {
                return false;
            }

            return currentItem.Paths.ContentPath.StartsWith(
                navigationLinkItem.Paths.ContentPath,
                StringComparison.InvariantCultureIgnoreCase);
        }
    }
}