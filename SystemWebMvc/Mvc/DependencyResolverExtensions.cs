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
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    public static class DependencyResolverExtensions {
        public static TService GetService<TService>(this IDependencyResolver resolver) {
            return (TService)resolver.GetService(typeof(TService));
        }

        public static IEnumerable<TService> GetServices<TService>(this IDependencyResolver resolver) {
            return resolver.GetServices(typeof(TService)).Cast<TService>();
        }
    }
}
