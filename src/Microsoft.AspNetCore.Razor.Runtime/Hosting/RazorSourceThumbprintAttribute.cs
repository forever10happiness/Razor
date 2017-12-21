// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Microsoft.AspNetCore.Razor.Hosting
{
    /// <summary>
    /// Specifies the hash thumprint of a source file that contributed to a compiled item.
    /// </summary>
    /// <remarks>
    /// <para>
    /// These attributes are added by the Razor infrastructure when generating code to assist runtime
    /// implementations to determine the integrity of compiled items.
    /// </para>
    /// <para>
    /// Runtime implementations should access the thumbprint metadata for an item using
    /// <see cref="RazorCompiledItemExtensions.GetThumprintMetadata(RazorCompiledItem)"/>.
    /// </para>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class RazorSourceThumbprintAttribute : Attribute, IRazorSourceThumprintMetadata
    {
        /// <summary>
        /// Creates a new <see cref="RazorSourceThumbprintAttribute"/>.
        /// </summary>
        /// <param name="hashAlgorithm">The hash algorithm used to create this thumbprint.</param>
        /// <param name="thumbprint">The thumbprint as a string.</param>
        /// <param name="kind">The kind of the source file associated with this thumbprint.</param>
        /// <param name="identifier">The identifier associated with this thumbprint. May be <c>null</c>.</param>
        public RazorSourceThumbprintAttribute(string hashAlgorithm, string thumbprint, string kind, string identifier)
        {
            if (hashAlgorithm == null)
            {
                throw new ArgumentNullException(nameof(hashAlgorithm));
            }

            if (thumbprint == null)
            {
                throw new ArgumentNullException(nameof(thumbprint));
            }

            if (kind == null)
            {
                throw new ArgumentNullException(nameof(kind));
            }

            HashAlgorithm = hashAlgorithm;
            Thumbprint = thumbprint;
            Kind = kind;
            Identifier = identifier;
        }

        /// <summary>
        /// Gets the hash algorithm used to create this thumbprint.
        /// </summary>
        public string HashAlgorithm { get; }
        
        /// <summary>
        /// Gets the identifier of the source file associated with this thumbprint. May be <c>null</c>.
        /// </summary>
        public string Identifier { get; }

        /// <summary>
        /// Gets the kind of the source file associated with this thumbprint.
        /// </summary>
        public string Kind { get; }

        /// <summary>
        /// Gets the thumbprint as string.
        /// </summary>
        public string Thumbprint { get; }
    }
}
