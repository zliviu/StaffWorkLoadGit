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

    public sealed class ChildActionValueProvider : DictionaryValueProvider<object> {

        public ChildActionValueProvider(ControllerContext controllerContext)
            : base(controllerContext.RouteData.Values, CultureInfo.InvariantCulture) {
        }

        private static string _childActionValuesKey = Guid.NewGuid().ToString();

        internal static string ChildActionValuesKey {
            get {
                return _childActionValuesKey;
            }
        }

        public override ValueProviderResult GetValue(string key) {
            if (key == null) {
                throw new ArgumentNullException("key");
            }

            ValueProviderResult explicitValues = base.GetValue(ChildActionValuesKey);
            if (explicitValues != null) {
                DictionaryValueProvider<object> rawExplicitValues = explicitValues.RawValue as DictionaryValueProvider<object>;
                if (rawExplicitValues != null) {
                    return rawExplicitValues.GetValue(key);
                }
            }

            return null;
        }
    }
}
