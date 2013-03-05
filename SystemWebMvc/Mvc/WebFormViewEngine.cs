/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. All rights reserved.
 *
 * This software is subject to the Microsoft Public License (Ms-PL). 
 * A copy of the license can be found in the license.htm file included 
 * in this distribution.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * ***************************************************************************/

namespace System.Web.Mvc {
    public class WebFormViewEngine : BuildManagerViewEngine {

        public WebFormViewEngine()
            : this(null) {
        }

        public WebFormViewEngine(IViewPageActivator viewPageActivator)
            :base(viewPageActivator){
            MasterLocationFormats = new[] {
                "~/Views/{1}/{0}.master",
                "~/Views/Shared/{0}.master"
            };

            AreaMasterLocationFormats = new[] {
                "~/Areas/{2}/Views/{1}/{0}.master",
                "~/Areas/{2}/Views/Shared/{0}.master",
            };

            ViewLocationFormats = new[] {
                "~/Views/{1}/{0}.aspx",
                "~/Views/{1}/{0}.ascx",
                "~/Views/Shared/{0}.aspx",
                "~/Views/Shared/{0}.ascx"
            };

            AreaViewLocationFormats = new[] {
                "~/Areas/{2}/Views/{1}/{0}.aspx",
                "~/Areas/{2}/Views/{1}/{0}.ascx",
                "~/Areas/{2}/Views/Shared/{0}.aspx",
                "~/Areas/{2}/Views/Shared/{0}.ascx",
            };

            PartialViewLocationFormats = ViewLocationFormats;
            AreaPartialViewLocationFormats = AreaViewLocationFormats;

            FileExtensions = new[] {
                "aspx",
                "ascx",
                "master",
            };
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath) {
            return new WebFormView(controllerContext, partialPath, null, ViewPageActivator);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath) {
            return new WebFormView(controllerContext, viewPath, masterPath, ViewPageActivator);
        }
    }
}
