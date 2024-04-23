﻿// <auto-generated />
using System;
using System.Collections.Generic;
using DotNetTemplate.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DotNetTemplate.Migrations
{
    [DbContext(typeof(DotNetTemplateDbContext))]
    [Migration("20240420091116_awudid2t2")]
    partial class awudid2t2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DotNetTemplate.Core.Entities.AuditedEntity<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uuid");

                    b.Property<string>("MutatedEntity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("MutationById")
                        .HasColumnType("uuid");

                    b.Property<string>("MutationByName")
                        .HasColumnType("text");

                    b.Property<DateTime>("MutationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MutationType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OriginalEntity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Auditions");
                });

            modelBuilder.Entity("DotNetTemplate.Core.Entities.Todo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Todos", (string)null);
                });

            modelBuilder.Entity("DotNetTemplate.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("Permissions")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
