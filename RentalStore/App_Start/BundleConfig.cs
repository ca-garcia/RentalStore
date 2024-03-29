﻿using System.Web;
using System.Web.Optimization;

namespace mvc2019
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/libs").Include(
                      "~/Scripts/datatables/jquery.datatables.js",
                      "~/Scripts/datatables/datatables.bootstrap.js",
                      "~/Scripts/typeahead.bundle.js",
                      "~/Scripts/toastr.js",
                      "~/Scripts/bootbox.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      //"~/Content/bootstrap-darkly.css",
                      "~/Content/datatables/css/datatables.bootstrap.css",
                      "~/Content/typeahead.css",
                      "~/Content/toastr.css",
                      //"~/Content/404.css",
                      "~/Content/site.css"
                      ));
        }
    }
}
