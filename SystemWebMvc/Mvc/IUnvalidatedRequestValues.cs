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
    using System.Web;

    // Used for mocking the UnvalidatedRequestValues type in System.Web.WebPages

    internal interface IUnvalidatedRequestValues {
        NameValueCollection Form { get; }
        NameValueCollection QueryString { get; }
        string this[string key] { get; }
    }
}
