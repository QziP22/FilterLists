﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilterLists.Directory.Infrastructure.Persistence.Queries.Entities
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public class Syntax
    {
        public string Name { get; private set; } = null!;
        public string? Description { get; private set; }
        public Uri? Url { get; private set; }
        public IReadOnlyCollection<FilterListSyntax> FilterListSyntaxes { get; private set; } = new HashSet<FilterListSyntax>();
        public IReadOnlyCollection<SoftwareSyntax> SoftwareSyntaxes { get; private set; } = new HashSet<SoftwareSyntax>();
    }

    internal class SyntaxTypeConfiguration : IEntityTypeConfiguration<Syntax>
    {
        public virtual void Configure(EntityTypeBuilder<Syntax> builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            const string syntaxId = "Id";
            builder.Property<int>(syntaxId);
            builder.HasKey(syntaxId);
        }
    }
}