// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Razor.Parser.SyntaxTree;
using Microsoft.Extensions.Internal;

namespace Microsoft.AspNetCore.Razor.Chunks.Generators
{
    /// <summary>
    /// A <see cref="SpanChunkGenerator"/> responsible for generating <see cref="RemoveTagHelperChunk"/>s.
    /// </summary>
    public class RemoveTagHelperChunkGenerator : SpanChunkGenerator
    {
        private readonly string _lookupText;

        /// <summary>
        /// Initializes a new instance of <see cref="RemoveTagHelperChunkGenerator"/>.
        /// </summary>
        /// <param name="lookupText">
        /// Text used to look up <see cref="Compilation.TagHelpers.TagHelperDescriptor"/>s that should be removed.
        /// </param>
        public RemoveTagHelperChunkGenerator(string lookupText)
        {
            _lookupText = lookupText;
        }

        /// <summary>
        /// Generates <see cref="RemoveTagHelperChunk"/>s.
        /// </summary>
        /// <param name="target">
        /// The <see cref="Span"/> responsible for this <see cref="RemoveTagHelperChunkGenerator"/>.
        /// </param>
        /// <param name="context">A <see cref="ChunkGeneratorContext"/> instance that contains information about
        /// the current chunk generation process.</param>
        public override void GenerateChunk(Span target, ChunkGeneratorContext context)
        {
            context.ChunkTreeBuilder.AddRemoveTagHelperChunk(_lookupText, target);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            var other = obj as RemoveTagHelperChunkGenerator;
            return base.Equals(other) &&
                string.Equals(_lookupText, other._lookupText, StringComparison.Ordinal);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            var combiner = HashCodeCombiner.Start();
            combiner.Add(base.GetHashCode());
            combiner.Add(_lookupText, StringComparer.Ordinal);

            return combiner.CombinedHash;
        }
    }
}