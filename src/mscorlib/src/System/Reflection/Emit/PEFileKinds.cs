// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Reflection.Emit {
    
    using System;
    // This Enum matchs the CorFieldAttr defined in CorHdr.h
    [Serializable]
    public enum PEFileKinds
    {
        Dll                = 0x0001,
        ConsoleApplication = 0x0002,
        WindowApplication = 0x0003,
    }
}
