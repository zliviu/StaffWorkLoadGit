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
    using System.Collections.Specialized;
    using System.Web.Helpers;

    // Concrete implementation for the IUnvalidatedRequestValues helper interface

    internal sealed class UnvalidatedRequestValuesWrapper : IUnvalidatedRequestValues {

        private readonly UnvalidatedRequestValues _unvalidatedValues;

        public UnvalidatedRequestValuesWrapper(UnvalidatedRequestValues unvalidatedValues) {
            _unvalidatedValues = unvalidatedValues;
        }

        public NameValueCollection Form {
            get { return _unvalidatedValues.Form; }
        }

        public NameValueCollection QueryString {
            get { return _unvalidatedValues.QueryString; }
        }

        public string this[string key] {
            get { return _unvalidatedValues[key]; }
        }

    }
}
