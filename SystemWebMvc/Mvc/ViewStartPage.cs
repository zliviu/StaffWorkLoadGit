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
    using System.Web.Mvc.Resources;
    using System.Web.WebPages;

    public abstract class ViewStartPage : StartPage, IViewStartPageChild {
        private IViewStartPageChild _viewStartPageChild;

        public HtmlHelper<object> Html {
            get {
                return ViewStartPageChild.Html;
            }
        }

        public UrlHelper Url {
            get {
                return ViewStartPageChild.Url;
            }
        }

        public ViewContext ViewContext {
            get {
                return ViewStartPageChild.ViewContext;
            }
        }

        internal IViewStartPageChild ViewStartPageChild {
            get {
                if (_viewStartPageChild == null) {
                    IViewStartPageChild child = base.ChildPage as IViewStartPageChild;
                    if (child == null) {
                        throw new InvalidOperationException(MvcResources.ViewStartPage_RequiresMvcRazorView);
                    }
                    _viewStartPageChild = child;
                }

                return _viewStartPageChild;
            }
        }
    }
}
