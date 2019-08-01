﻿// <auto-generated />
using Denver.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Denver.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190731095931_StoreModel")]
    partial class StoreModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Denver._Model.Cigarettes", b =>
                {
                    b.Property<int>("IdCigarettes")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand");

                    b.Property<int>("Fillin");

                    b.Property<int>("Quantity");

                    b.HasKey("IdCigarettes");

                    b.ToTable("Cigarettes");
                });

            modelBuilder.Entity("Denver._Model.StoreModel.StoreModel", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("NameStore");

                    b.HasKey("StoreId");

                    b.ToTable("StroeModel");
                });

            modelBuilder.Entity("Denver._Model.UserModel.UserModel", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("IdUser");

                    b.ToTable("UserModel");
                });
#pragma warning restore 612, 618
        }
    }
}
