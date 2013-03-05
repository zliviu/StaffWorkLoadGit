#pragma warning disable 659 // overrides AddToHashCodeCombiner instead

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

namespace System.Web.Mvc.ExpressionUtil {
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;

    // ParameterExpression fingerprint class
    // Can represent the model parameter or an inner parameter in an open lambda expression

    [SuppressMessage("Microsoft.Usage", "CA2218:OverrideGetHashCodeOnOverridingEquals", Justification = "Overrides AddToHashCodeCombiner() instead.")]
    internal sealed class ParameterExpressionFingerprint : ExpressionFingerprint {

        public ParameterExpressionFingerprint(ExpressionType nodeType, Type type, int parameterIndex)
            : base(nodeType, type) {

            ParameterIndex = parameterIndex;
        }

        // Parameter position within the overall expression, used to maintain alpha equivalence.
        public int ParameterIndex { get; private set; }

        public override bool Equals(object obj) {
            ParameterExpressionFingerprint other = obj as ParameterExpressionFingerprint;
            return (other != null)
                && (this.ParameterIndex == other.ParameterIndex)
                && this.Equals(other);
        }

        internal override void AddToHashCodeCombiner(HashCodeCombiner combiner) {
            combiner.AddInt32(ParameterIndex);
            base.AddToHashCodeCombiner(combiner);
        }

    }
}
