using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace LogiQ
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Scripts").Include(
                  "~/Scripts/jquery-1.9.1.js",
                  "~/Scripts/gumby.js",
                  "~/Scripts/plugins.js",
                  "~/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-2.6.2.js"));
        }
    }
}