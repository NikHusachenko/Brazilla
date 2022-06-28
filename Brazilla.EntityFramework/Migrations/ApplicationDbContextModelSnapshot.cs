﻿// <auto-generated />
using System;
using Brazilla.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Brazilla.EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Brazilla.Database.Entities.BlendTypeEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("Arabica")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(63)
                        .HasColumnType("nvarchar(63)");

                    b.Property<int>("Robusta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Blend types", (string)null);
                });

            modelBuilder.Entity("Brazilla.Database.Entities.CoffeeBlendEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsBuyed")
                        .HasColumnType("bit");

                    b.Property<int>("Left")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(31)
                        .HasColumnType("nvarchar(31)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<long?>("TypeFK")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserFK")
                        .HasColumnType("bigint");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("TypeFK");

                    b.HasIndex("UserFK");

                    b.ToTable("Blends", (string)null);
                });

            modelBuilder.Entity("Brazilla.Database.Entities.UserEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(31)
                        .HasColumnType("nvarchar(31)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Brazilla.Database.Entities.CoffeeBlendEntity", b =>
                {
                    b.HasOne("Brazilla.Database.Entities.BlendTypeEntity", "Type")
                        .WithMany("Blends")
                        .HasForeignKey("TypeFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Brazilla.Database.Entities.UserEntity", "User")
                        .WithMany("Blends")
                        .HasForeignKey("UserFK");

                    b.Navigation("Type");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Brazilla.Database.Entities.BlendTypeEntity", b =>
                {
                    b.Navigation("Blends");
                });

            modelBuilder.Entity("Brazilla.Database.Entities.UserEntity", b =>
                {
                    b.Navigation("Blends");
                });
#pragma warning restore 612, 618
        }
    }
}
