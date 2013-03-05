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
    public class ModelMetadataProviders {
        private ModelMetadataProvider _currentProvider;
        private static ModelMetadataProviders _instance = new ModelMetadataProviders();
        private IResolver<ModelMetadataProvider> _resolver;

        internal ModelMetadataProviders(IResolver<ModelMetadataProvider> resolver = null) {
            _resolver = resolver ?? new SingleServiceResolver<ModelMetadataProvider>(
                () => _currentProvider,
                new DataAnnotationsModelMetadataProvider(),
                "ModelMetadataProviders.Current"
            );
        }

        public static ModelMetadataProvider Current {
            get {
                return _instance.CurrentInternal;
            }
            set {
                _instance.CurrentInternal = value;
            }
        }

        internal ModelMetadataProvider CurrentInternal {
            get {
                return _resolver.Current;
            }
            set {
                _currentProvider = value ?? new EmptyModelMetadataProvider();
            }
        }
    }
}