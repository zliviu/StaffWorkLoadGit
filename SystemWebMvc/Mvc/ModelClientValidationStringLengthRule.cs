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
    public class ModelClientValidationStringLengthRule : ModelClientValidationRule {
        public ModelClientValidationStringLengthRule(string errorMessage, int minimumLength, int maximumLength) {
            ErrorMessage = errorMessage;
            ValidationType = "length";

            if (minimumLength != 0) {
                ValidationParameters["min"] = minimumLength;
            }

            if (maximumLength != Int32.MaxValue) {
                ValidationParameters["max"] = maximumLength;
            }
        }
    }
}
