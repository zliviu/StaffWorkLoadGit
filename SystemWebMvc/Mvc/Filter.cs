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
    using System.Diagnostics.CodeAnalysis;

    public class Filter {
        public const int DefaultOrder = -1;

        public Filter(object instance, FilterScope scope, int? order) {
            if (instance == null) {
                throw new ArgumentNullException("instance");
            }

            if (order == null) {
                IMvcFilter mvcFilter = instance as IMvcFilter;
                if (mvcFilter != null) {
                    order = mvcFilter.Order;
                }
            }

            Instance = instance;
            Order = order ?? DefaultOrder;
            Scope = scope;
        }

        public object Instance {
            get;
            protected set;
        }

        public int Order {
            get;
            protected set;
        }

        public FilterScope Scope {
            get;
            protected set;
        }
    }
}
