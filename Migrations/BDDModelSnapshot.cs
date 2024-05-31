﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace delivri.Migrations
{
    [DbContext(typeof(BDD))]
    partial class BDDModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Cardapio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Item")
                        .HasColumnType("int");

                    b.Property<string>("ItemNome")
                        .HasColumnType("longtext");

                    b.Property<float>("Preco")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Cardapio");
                });

            modelBuilder.Entity("Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CEP")
                        .HasColumnType("int");

                    b.Property<string>("Complemento")
                        .HasColumnType("longtext");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Loja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Entrega")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<float>("Nota")
                        .HasColumnType("float");

                    b.Property<float>("Taxa")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Loja");
                });

            modelBuilder.Entity("LojaCardapio", b =>
                {
                    b.Property<int>("LojaId")
                        .HasColumnType("int");

                    b.Property<int>("CardapioId")
                        .HasColumnType("int");

                    b.HasKey("LojaId", "CardapioId");

                    b.HasIndex("CardapioId");

                    b.ToTable("LojaCardapio", (string)null);
                });

            modelBuilder.Entity("Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Detalhes")
                        .HasColumnType("longtext");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NomeUser")
                        .HasColumnType("longtext");

                    b.Property<float>("UserAvalicao")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("UsuarioEndereco", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "EnderecoId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("UsuarioEndereco", (string)null);
                });

            modelBuilder.Entity("LojaCardapio", b =>
                {
                    b.HasOne("Cardapio", null)
                        .WithMany()
                        .HasForeignKey("CardapioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Loja", null)
                        .WithMany()
                        .HasForeignKey("LojaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UsuarioEndereco", b =>
                {
                    b.HasOne("Endereco", null)
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Usuario", null)
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
