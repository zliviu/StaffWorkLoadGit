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
    using System.ComponentModel;
    using System.Web.WebPages.Scope;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class PreApplicationStartCode {
        private static bool _startWasCalled;

        public static void Start() {
            // Guard against multiple calls. All Start calls are made on same thread, so no lock needed here
            if (_startWasCalled) {
                return;
            }
            _startWasCalled = true;

            System.Web.WebPages.Razor.PreApplicationStartCode.Start();
            System.Web.WebPages.PreApplicationStartCode.Start();

            ViewContext.GlobalScopeThunk = () => ScopeStorage.CurrentScope;
        }
    }
}
