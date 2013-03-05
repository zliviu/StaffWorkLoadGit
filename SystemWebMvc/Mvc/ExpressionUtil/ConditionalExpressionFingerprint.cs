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

    // ConditionalExpression fingerprint class
    // Expression of form (test) ? ifTrue : ifFalse

    [SuppressMessage("Microsoft.Usage", "CA2218:OverrideGetHashCodeOnOverridingEquals", Justification = "Overrides AddToHashCodeCombiner() instead.")]
    internal sealed class ConditionalExpressionFingerprint : ExpressionFingerprint {

        public ConditionalExpressionFingerprint(ExpressionType nodeType, Type type)
            : base(nodeType, type) {

            // There are no properties on ConditionalExpression that are worth including in
            // the fingerprint.
        }

        public override bool Equals(object obj) {
            ConditionalExpressionFingerprint other = obj as ConditionalExpressionFingerprint;
            return (other != null)
                && this.Equals(other);
        }

    }
}
