// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
// 

namespace System.Reflection.Emit
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Runtime.Versioning;

    // This is a package private class. This class hold all of the managed
    // data member for ModuleBuilder. Note that what ever data members added to
    // this class cannot be accessed from the EE.
    [Serializable]
    internal class ModuleBuilderData
    {
        internal ModuleBuilderData(ModuleBuilder module, String strModuleName, String strFileName, int tkFile)
        {
            m_globalTypeBuilder = new TypeBuilder(module);
            m_module = module;
            m_tkFile = tkFile;

            InitNames(strModuleName, strFileName);
        }

        // Initialize module and file names.
        private void InitNames(String strModuleName, String strFileName)
        {
            m_strModuleName = strModuleName;
            if (strFileName == null)
            {
                // fake a transient module file name
                m_strFileName = strModuleName;
            }
            else
            {
                String strExtension = Path.GetExtension(strFileName);
                if (strExtension == null || strExtension == String.Empty)
                {
                    // This is required by our loader. It cannot load module file that does not have file extension.
                    throw new ArgumentException(Environment.GetResourceString("Argument_NoModuleFileExtension", strFileName));
                }
                m_strFileName = strFileName;
            }
        }

        internal String        m_strModuleName;     // scope name (can be different from file name)
        internal String        m_strFileName;
        internal bool          m_fGlobalBeenCreated;
        internal bool          m_fHasGlobal;   
        [NonSerialized]
        internal TypeBuilder   m_globalTypeBuilder;
        [NonSerialized]
        internal ModuleBuilder m_module;

        private int            m_tkFile;
        internal bool          m_isSaved;
        internal const String MULTI_BYTE_VALUE_CLASS = "$ArrayType$";
        internal String        m_strResourceFileName;
        internal byte[]        m_resourceBytes;
    } // class ModuleBuilderData
}
