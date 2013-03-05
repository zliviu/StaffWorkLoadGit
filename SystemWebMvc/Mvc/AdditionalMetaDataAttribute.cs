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

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Property, AllowMultiple = true)]
    public sealed class AdditionalMetadataAttribute : Attribute, IMetadataAware {
        private object _typeId = new object();

        public AdditionalMetadataAttribute(string name, object value) {
            if (name == null) {
                throw new ArgumentNullException("name");
            }

            Name = name;
            Value = value;
        }

        public override object TypeId {
            get {
                return _typeId;
            }
        }

        public string Name {
            get;
            private set;
        }

        public object Value {
            get;
            private set;
        }

        public void OnMetadataCreated(ModelMetadata metadata) {
            if (metadata == null) {
                throw new ArgumentNullException("metadata");
            }

            metadata.AdditionalValues[Name] = Value;
        }
    }
}
