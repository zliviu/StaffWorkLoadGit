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
    using System.Globalization;
    using System.Web.Helpers;

    public sealed class FormValueProvider : NameValueCollectionValueProvider {

        public FormValueProvider(ControllerContext controllerContext)
            : this(controllerContext, new UnvalidatedRequestValuesWrapper(controllerContext.HttpContext.Request.Unvalidated())) {
        }

        // For unit testing
        internal FormValueProvider(ControllerContext controllerContext, IUnvalidatedRequestValues unvalidatedValues)
            : base(controllerContext.HttpContext.Request.Form, unvalidatedValues.Form, CultureInfo.CurrentCulture) {
        }

    }
}
