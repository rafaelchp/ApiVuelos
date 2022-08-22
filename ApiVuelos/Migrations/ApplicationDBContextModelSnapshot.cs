﻿// <auto-generated />
using System;
using ApiVuelos.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiVuelos.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiVuelos.Entidades.Aerolinea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreAerolinea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("aerolinea");
                });

            modelBuilder.Entity("ApiVuelos.Entidades.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ciudades");
                });

            modelBuilder.Entity("ApiVuelos.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("ApiVuelos.Entidades.Vuelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EstadoVuelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaVuelo")
                        .HasColumnType("datetime2");

                    b.Property<string>("HoraLlegada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoraSalida")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumVuelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("vuelos");
                });

            modelBuilder.Entity("ApiVuelos.Entidades.VuelosAerolinea", b =>
                {
                    b.Property<int>("VueloId")
                        .HasColumnType("int");

                    b.Property<int>("AerolineaId")
                        .HasColumnType("int");

                    b.HasKey("VueloId", "AerolineaId");

                    b.HasIndex("AerolineaId");

                    b.ToTable("vuelosAerolinea");
                });

            modelBuilder.Entity("ApiVuelos.Entidades.VuelosCiudades", b =>
                {
                    b.Property<int>("VueloId")
                        .HasColumnType("int");

                    b.Property<int>("CiudadId")
                        .HasColumnType("int");

                    b.HasKey("VueloId", "CiudadId");

                    b.HasIndex("CiudadId");

                    b.ToTable("vuelosCiudades");
                });

            modelBuilder.Entity("ApiVuelos.Entidades.VuelosAerolinea", b =>
                {
                    b.HasOne("ApiVuelos.Entidades.Aerolinea", "aerolinea")
                        .WithMany("vuelosAerolinea")
                        .HasForeignKey("AerolineaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiVuelos.Entidades.Vuelo", "vuelo")
                        .WithMany("vuelosAerolinea")
                        .HasForeignKey("VueloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("aerolinea");

                    b.Navigation("vuelo");
                });

            modelBuilder.Entity("ApiVuelos.Entidades.VuelosCiudades", b =>
                {
                    b.HasOne("ApiVuelos.Entidades.Ciudad", "ciudad")
                        .WithMany("vuelosCiudades")
                        .HasForeignKey("CiudadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiVuelos.Entidades.Vuelo", "vuelo")
                        .WithMany("vuelosCiudades")
                        .HasForeignKey("VueloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ciudad");

                    b.Navigation("vuelo");
                });

            modelBuilder.Entity("ApiVuelos.Entidades.Aerolinea", b =>
                {
                    b.Navigation("vuelosAerolinea");
                });

            modelBuilder.Entity("ApiVuelos.Entidades.Ciudad", b =>
                {
                    b.Navigation("vuelosCiudades");
                });

            modelBuilder.Entity("ApiVuelos.Entidades.Vuelo", b =>
                {
                    b.Navigation("vuelosAerolinea");

                    b.Navigation("vuelosCiudades");
                });
#pragma warning restore 612, 618
        }
    }
}
