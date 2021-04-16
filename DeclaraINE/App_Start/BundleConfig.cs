using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace DeclaraINE
{
    public class BundleConfig
    {
        // For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "~/Scripts/WebForms/WebForms.js",
                            "~/Scripts/WebForms/WebUIValidation.js",
                            "~/Scripts/WebForms/MenuStandards.js",
                            "~/Scripts/WebForms/Focus.js",
                            "~/Scripts/WebForms/GridView.js",
                            "~/Scripts/WebForms/DetailsView.js",
                            "~/Scripts/WebForms/TreeView.js",
                            "~/Scripts/WebForms/WebParts.js"));

            // Order is very important for these files to work, they have explicit dependencies
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

           

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));

            ScriptManager.ScriptResourceMapping.AddDefinition(
            "MsWebFormsControlsResources",
            new ScriptResourceDefinition
            {
                Path = "~/Scripts/AlanWebControls.js",
                DebugPath = "~/Scripts/AlanWebControls.js",
            });

            ScriptManager.ScriptResourceMapping.AddDefinition(
             "MsWebFormsSiteResorces",
             new ScriptResourceDefinition
             {
                 Path = "~/Scripts/Site.js",
                 DebugPath = "~/Scripts/Site.js",
             });

            ScriptManager.ScriptResourceMapping.AddDefinition(
             "MsWebFormsPoper",
             new ScriptResourceDefinition
             {
                 Path = "~/Scripts/ModalTooltip.js",
                 DebugPath = "~/Scripts/ModalTooltip.js",
             });

            ScriptManager.ScriptResourceMapping.AddDefinition(
             "MsWebFormsValidations",
             new ScriptResourceDefinition
             {
                 Path = "~/Scripts/Login.js",
                 DebugPath = "~/Scripts/Login.js",
             });

            ScriptManager.ScriptResourceMapping.AddDefinition(
                "respond",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/respond.min.js",
                    DebugPath = "~/Scripts/respond.js",
                });

            ScriptManager.ScriptResourceMapping.AddDefinition(
                "respond",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/respond.min.js",
                    DebugPath = "~/Scripts/respond.js",
                });
        }
    }
}