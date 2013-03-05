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
    using System.Web.Mvc.Razor;
    using System.Web.WebPages.Razor;

    public class MvcWebRazorHostFactory : WebRazorHostFactory {

        public override WebPageRazorHost CreateHost(string virtualPath, string physicalPath) {
            WebPageRazorHost host = base.CreateHost(virtualPath, physicalPath);

            if(!host.IsSpecialPage) {
                return new MvcWebPageRazorHost(virtualPath, physicalPath);
            }

            return host;
        }
    }
}
