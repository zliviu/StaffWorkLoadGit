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

    // ConstantExpression fingerprint class
    //
    // A ConstantExpression might represent a captured local variable, so we can't compile
    // the value directly into the cached function. Instead, a placeholder is generated
    // and the value is hoisted into a local variables array. This placeholder can then
    // be compiled and cached, and the array lookup happens at runtime.

    [SuppressMessage("Microsoft.Usage", "CA2218:OverrideGetHashCodeOnOverridingEquals", Justification = "Overrides AddToHashCodeCombiner() instead.")]
    internal sealed class ConstantExpressionFingerprint : ExpressionFingerprint {

        public ConstantExpressionFingerprint(ExpressionType nodeType, Type type)
            : base(nodeType, type) {

            // There are no properties on ConstantExpression that are worth including in
            // the fingerprint.
        }

        public override bool Equals(object obj) {
            ConstantExpressionFingerprint other = obj as ConstantExpressionFingerprint;
            return (other != null)
                && this.Equals(other);
        }

    }
}
