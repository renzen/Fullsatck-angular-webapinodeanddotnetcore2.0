﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using contact_app.Models;

namespace contactapp.Migrations
{
    [DbContext(typeof(ContactAppContext))]
    partial class ContactAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("contact_app.Models.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Street");

                    b.Property<string>("Suite");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<long>("UserDetailsId");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("UserDetailsId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("contact_app.Models.GeoLoc", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AddressId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Lat");

                    b.Property<string>("Lng");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("GeoLoc");
                });

            modelBuilder.Entity("contact_app.Models.UserDetails", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birth");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<long>("UsersId");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.HasIndex("UsersId")
                        .IsUnique();

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("contact_app.Models.Users", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Active");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Password");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("contact_app.Models.Address", b =>
                {
                    b.HasOne("contact_app.Models.UserDetails", "UserDetails")
                        .WithOne("Address")
                        .HasForeignKey("contact_app.Models.Address", "UserDetailsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("contact_app.Models.GeoLoc", b =>
                {
                    b.HasOne("contact_app.Models.Address", "Address")
                        .WithOne("GeoLoc")
                        .HasForeignKey("contact_app.Models.GeoLoc", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("contact_app.Models.UserDetails", b =>
                {
                    b.HasOne("contact_app.Models.Users", "Users")
                        .WithOne("UserDetails")
                        .HasForeignKey("contact_app.Models.UserDetails", "UsersId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
