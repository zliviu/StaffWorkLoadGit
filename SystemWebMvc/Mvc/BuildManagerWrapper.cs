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
    using System.Collections;
    using System.IO;
    using System.Web.Compilation;

    internal sealed class BuildManagerWrapper : IBuildManager {
        bool IBuildManager.FileExists(string virtualPath) {
            return BuildManager.GetObjectFactory(virtualPath, false) != null;
        }

        Type IBuildManager.GetCompiledType(string virtualPath) {
            return BuildManager.GetCompiledType(virtualPath);
        }

        ICollection IBuildManager.GetReferencedAssemblies() {
            return BuildManager.GetReferencedAssemblies();
        }

        Stream IBuildManager.ReadCachedFile(string fileName) {
            return BuildManager.ReadCachedFile(fileName);
        }

        Stream IBuildManager.CreateCachedFile(string fileName) {
            return BuildManager.CreateCachedFile(fileName);
        }
    }
}
