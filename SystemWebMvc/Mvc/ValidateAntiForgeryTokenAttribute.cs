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
    using System.Diagnostics;
    using System.Web;
    using System.Web.Helpers;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class ValidateAntiForgeryTokenAttribute : FilterAttribute, IAuthorizationFilter {

        private string _salt;

        public string Salt {
            get {
                return _salt ?? String.Empty;
            }
            set {
                _salt = value;
            }
        }

        internal Action<HttpContextBase, string> ValidateAction {
            get;
            private set;
        }

        public ValidateAntiForgeryTokenAttribute()
            : this(AntiForgery.Validate) {
        }

        internal ValidateAntiForgeryTokenAttribute(Action<HttpContextBase,string> validateAction) {
            Debug.Assert(validateAction != null);
            ValidateAction = validateAction;
        }

        public void OnAuthorization(AuthorizationContext filterContext) {
            if (filterContext == null) {
                throw new ArgumentNullException("filterContext");
            }

            ValidateAction(filterContext.HttpContext, Salt);
        }
    }
}
