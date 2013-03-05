﻿/* ****************************************************************************
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
    using System.Web.Helpers;

    public sealed class FormValueProviderFactory : ValueProviderFactory {

        private readonly UnvalidatedRequestValuesAccessor _unvalidatedValuesAccessor;

        public FormValueProviderFactory()
            : this(null) {
        }

        // For unit testing
        internal FormValueProviderFactory(UnvalidatedRequestValuesAccessor unvalidatedValuesAccessor) {
            _unvalidatedValuesAccessor = unvalidatedValuesAccessor ?? (cc => new UnvalidatedRequestValuesWrapper(cc.HttpContext.Request.Unvalidated()));
        }

        public override IValueProvider GetValueProvider(ControllerContext controllerContext) {
            if (controllerContext == null) {
                throw new ArgumentNullException("controllerContext");
            }

            return new FormValueProvider(controllerContext, _unvalidatedValuesAccessor(controllerContext));
        }

    }
}
