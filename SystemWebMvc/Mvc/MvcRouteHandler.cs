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
    using System.Web.Routing;
    using System.Web.SessionState;

    public class MvcRouteHandler : IRouteHandler {
        private IControllerFactory _controllerFactory;

        public MvcRouteHandler() {
        }

        public MvcRouteHandler(IControllerFactory controllerFactory) {
            _controllerFactory = controllerFactory;
        }

        protected virtual IHttpHandler GetHttpHandler(RequestContext requestContext) {
            requestContext.HttpContext.SetSessionStateBehavior(GetSessionStateBehavior(requestContext));
            return new MvcHandler(requestContext);
        }

        protected virtual SessionStateBehavior GetSessionStateBehavior(RequestContext requestContext) {
            string controllerName = (string)requestContext.RouteData.Values["controller"];
            IControllerFactory controllerFactory = _controllerFactory ?? ControllerBuilder.Current.GetControllerFactory();
            return controllerFactory.GetControllerSessionBehavior(requestContext, controllerName);
        }

        #region IRouteHandler Members
        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext) {
            return GetHttpHandler(requestContext);
        }
        #endregion
    }
}
