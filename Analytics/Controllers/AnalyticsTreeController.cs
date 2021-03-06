﻿using System;
using System.Collections.Generic;
using Analytics.Models;
using Lucene.Net.Analysis;
using Umbraco.Core;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;

namespace Analytics.Controllers
{
    [Tree("analytics", "analyticsTree", "Analytics")]
    [PluginController("Analytics")]
    public class AnalyticsTreeController : TreeController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="queryStrings"></param>
        /// <returns></returns>
        protected override Umbraco.Web.Models.Trees.TreeNodeCollection GetTreeNodes(string id, System.Net.Http.Formatting.FormDataCollection queryStrings)
        {
            //check if we're rendering the root node's children
            if (id == Constants.System.Root.ToInvariantString())
            {
                //Nodes that we will return
                var nodes = new TreeNodeCollection();

                //Main Route
                var mainRoute = "/analytics/analyticsTree";

                //Add nodes
                var treeNodes = new List<SectionTreeNode>();
                //treeNodes.Add(new SectionTreeNode() { Id = "real-time", Title = "Real Time", Icon = "icon-connection", Route = string.Format("{0}/view/{1}", mainRoute, "real-time") });
                
                treeNodes.Add(new SectionTreeNode() { Id = "views", Title = "Views", Icon = "icon-activity", Route = string.Format("{0}/view/{1}", mainRoute, "views") });
                treeNodes.Add(new SectionTreeNode() { Id = "keywords", Title = "Keywords", Icon = "icon-tags", Route = string.Format("{0}/view/{1}", mainRoute, "keywords") });
                treeNodes.Add(new SectionTreeNode() { Id = "social", Title = "Social Network", Icon = "icon-chat-active", Route = string.Format("{0}/view/{1}", mainRoute, "social") });
                treeNodes.Add(new SectionTreeNode() { Id = "os", Title = "Operating System", Icon = "icon-windows", Route = string.Format("{0}/view/{1}", mainRoute, "os") });
                treeNodes.Add(new SectionTreeNode() { Id = "screenres", Title = "Screen Resolution", Icon = "icon-display", Route = string.Format("{0}/view/{1}", mainRoute, "screenres") });
                treeNodes.Add(new SectionTreeNode() { Id = "devices", Title = "Devices", Icon = "icon-iphone", Route = string.Format("{0}/view/{1}", mainRoute, "devices") });
                treeNodes.Add(new SectionTreeNode() { Id = "browser", Title = "Browser", Icon = "icon-browser-window", Route = string.Format("{0}/view/{1}", mainRoute, "browser") });
                treeNodes.Add(new SectionTreeNode() { Id = "language", Title = "Language", Icon = "icon-chat-active", Route = string.Format("{0}/view/{1}", mainRoute, "language") });
                treeNodes.Add(new SectionTreeNode() { Id = "country", Title = "Country", Icon = "icon-globe", Route = string.Format("{0}/view/{1}", mainRoute, "country") });
                treeNodes.Add(new SectionTreeNode() { Id = "settings", Title = "Settings", Icon = "icon-settings" , Route = string.Format("{0}/edit/{1}", mainRoute, "settings") });
                

                foreach (var item in treeNodes)
                {
                    //When clicked - /App_Plugins/Diagnostics/backoffice/diagnosticsTree/edit.html
                    //URL in address bar - /developer/diagnosticsTree/General/someID
                    //var route = string.Format("/analytics/analyticsTree/view/{0}", item.Value);
                    var nodeToAdd = CreateTreeNode(item.Id, null, queryStrings, item.Title, item.Icon, false, item.Route);

                    //Add it to the collection
                    nodes.Add(nodeToAdd);
                }

                //Return the nodes
                return nodes;
            }

            //this tree doesn't suport rendering more than 1 level
            throw new NotSupportedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="queryStrings"></param>
        /// <returns></returns>
        protected override Umbraco.Web.Models.Trees.MenuItemCollection GetMenuForNode(string id, System.Net.Http.Formatting.FormDataCollection queryStrings)
        {
            return null;
        }

    }
}
