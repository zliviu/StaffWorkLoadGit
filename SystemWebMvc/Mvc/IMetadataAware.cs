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
    // This interface is implemented by attributes which wish to contribute to the
    // ModelMetadata creation process without needing to write a custom metadata
    // provider. It is consumed by AssociatedMetadataProvider, so this behavior is
    // automatically inherited by all classes which derive from it (notably, the
    // DataAnnotationsModelMetadataProvider).
    public interface IMetadataAware {
        void OnMetadataCreated(ModelMetadata metadata);
    }
}
