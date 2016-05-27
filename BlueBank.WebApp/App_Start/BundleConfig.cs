using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BlueBank.WebApp.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/Scripts/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/Scripts/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/Scripts/Bootstrap").Include(
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/Scripts/bluebank").Include(
                        "~/Scripts/bluebank.js"));

            // Jquery responsável pelas formatações e uma pequena validação nos números
            // Uma ótima biblioteca, já que pode alterar o separador de . (ponto) para , (vírgula) e vice-versa
            bundles.Add(new ScriptBundle("~/Scripts/JqueryNumeric").Include(
                        "~/Scripts/jquery.numeric.js"));

            bundles.Add(new StyleBundle("~/Content/Css").Include(
                "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/Bootstrap").Include(
                "~/Content/bootstrap.css"));
        }
    }
}