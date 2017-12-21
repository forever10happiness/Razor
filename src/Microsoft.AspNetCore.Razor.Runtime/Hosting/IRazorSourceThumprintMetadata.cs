// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNetCore.Razor.Hosting
{
    public interface IRazorSourceThumprintMetadata
    {
        string HashAlgorithm { get; }

        string Identifier { get; }

        string Kind { get; }
        
        string Thumbprint { get; }
    }
}
