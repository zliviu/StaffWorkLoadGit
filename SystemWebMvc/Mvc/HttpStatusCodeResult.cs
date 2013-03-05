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

    public class HttpStatusCodeResult : ActionResult {
        public HttpStatusCodeResult(int statusCode)
            : this(statusCode, null) {
        }

        public HttpStatusCodeResult(int statusCode, string statusDescription) {
            StatusCode = statusCode;
            StatusDescription = statusDescription;
        }

        public int StatusCode {
            get;
            private set;
        }

        public string StatusDescription {
            get;
            private set;
        }

        public override void ExecuteResult(ControllerContext context) {
            if (context == null) {
                throw new ArgumentNullException("context");
            }

            context.HttpContext.Response.StatusCode = StatusCode;
            if (StatusDescription != null) {
                context.HttpContext.Response.StatusDescription = StatusDescription;
            }
        }
    }
}
