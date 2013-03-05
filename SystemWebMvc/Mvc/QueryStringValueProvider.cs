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
    using System;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.Web.Helpers;

    public sealed class QueryStringValueProvider : NameValueCollectionValueProvider {

        // QueryString should use the invariant culture since it's part of the URL, and the URL should be
        // interpreted in a uniform fashion regardless of the origin of a particular request.
        public QueryStringValueProvider(ControllerContext controllerContext)
            : this(controllerContext, new UnvalidatedRequestValuesWrapper(controllerContext.HttpContext.Request.Unvalidated())) {
        }

        // For unit testing
        internal QueryStringValueProvider(ControllerContext controllerContext, IUnvalidatedRequestValues unvalidatedValues)
            : base(controllerContext.HttpContext.Request.QueryString, unvalidatedValues.QueryString, CultureInfo.InvariantCulture) {
        }

    }
}
