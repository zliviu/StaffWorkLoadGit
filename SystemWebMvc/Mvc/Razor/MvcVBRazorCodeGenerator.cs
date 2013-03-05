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

namespace System.Web.Mvc.Razor {
    using System.CodeDom;
    using System.Web.Razor;
    using System.Web.Razor.Generator;
    using System.Web.Razor.Parser.SyntaxTree;

    public class MvcVBRazorCodeGenerator : VBRazorCodeGenerator {
        public MvcVBRazorCodeGenerator(string className, string rootNamespaceName, string sourceFileName, RazorEngineHost host)
            : base(className, rootNamespaceName, sourceFileName, host) {
        }

        protected override bool TryVisitSpecialSpan(Span span) {
            return TryVisit<ModelSpan>(span, VisitModelSpan);
        }

        private void VisitModelSpan(ModelSpan span) {
            string modelName = span.ModelTypeName;
            var baseType = new CodeTypeReference(Host.DefaultBaseClass + "(Of " + modelName + ")");

            GeneratedClass.BaseTypes.Clear();
            GeneratedClass.BaseTypes.Add(baseType);

            if (DesignTimeMode) {
                WriteHelperVariable(span.Content, "__modelHelper");
            }
        }
    }
}
