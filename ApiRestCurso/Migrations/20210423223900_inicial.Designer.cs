﻿// <auto-generated />
using System;
using ApiRestCurso.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiRestCurso.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210423223900_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiRestCurso.Modelo.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImagemUrl");

                    b.Property<string>("Nome");

                    b.HasKey("CategoriaId");

                    b.ToTable("tb_categoria");
                });

            modelBuilder.Entity("ApiRestCurso.Modelo.Produtos", b =>
                {
                    b.Property<int>("ProdId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId");

                    b.Property<string>("Descricao");

                    b.Property<DateTime>("DtCadastro");

                    b.Property<int>("Estoque");

                    b.Property<string>("ImagemUrl");

                    b.Property<string>("Nome");

                    b.Property<string>("Preco");

                    b.HasKey("ProdId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("tb_produtos");
                });

            modelBuilder.Entity("ApiRestCurso.Modelo.Produtos", b =>
                {
                    b.HasOne("ApiRestCurso.Modelo.Categoria", "categoria")
                        .WithMany("produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}