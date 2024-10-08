﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Desafio.Migrations
{
    [DbContext(typeof(AlunoContext))]
    partial class AlunoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Desafio.Model.Aluno", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Idade")
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "idade");

                    b.Property<double>("N1")
                        .HasColumnType("double precision")
                        .HasAnnotation("Relational:JsonPropertyName", "n1");

                    b.Property<double>("N2")
                        .HasColumnType("double precision")
                        .HasAnnotation("Relational:JsonPropertyName", "n2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasAnnotation("Relational:JsonPropertyName", "nome");

                    b.Property<string>("Professor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasAnnotation("Relational:JsonPropertyName", "professor");

                    b.Property<int>("Sala")
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "sala");

                    b.HasKey("Id");

                    b.ToTable("Alunos", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
