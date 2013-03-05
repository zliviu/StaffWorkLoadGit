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

    // LambdaExpression fingerprint class
    // Represents a lambda expression (root element in Expression<T>)

    [SuppressMessage("Microsoft.Usage", "CA2218:OverrideGetHashCodeOnOverridingEquals", Justification = "Overrides AddToHashCodeCombiner() instead.")]
    internal sealed class LambdaExpressionFingerprint : ExpressionFingerprint {

        public LambdaExpressionFingerprint(ExpressionType nodeType, Type type)
            : base(nodeType, type) {

            // There are no properties on LambdaExpression that are worth including in
            // the fingerprint.
        }

        public override bool Equals(object obj) {
            LambdaExpressionFingerprint other = obj as LambdaExpressionFingerprint;
            return (other != null)
                && this.Equals(other);
        }

    }
}
