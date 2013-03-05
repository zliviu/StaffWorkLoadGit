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

    // This attribute can be applied to a model property to specify that the particular property to
    // which it is applied should not go through request validation.

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class AllowHtmlAttribute : Attribute, IMetadataAware {

        public void OnMetadataCreated(ModelMetadata metadata) {
            if (metadata == null) {
                throw new ArgumentNullException("metadata");
            }

            metadata.RequestValidationEnabled = false;
        }

    }
}
