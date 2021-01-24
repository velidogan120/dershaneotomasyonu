﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dershane.data.Concrete.EfCore;

namespace dershane.data.Migrations
{
    [DbContext(typeof(DershaneContext))]
    [Migration("20210117042830_AddColumnOgrenciIsHome")]
    partial class AddColumnOgrenciIsHome
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("dershane.entity.Bolum", b =>
                {
                    b.Property<int>("BolumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("BolumId");

                    b.ToTable("Bolumler");
                });

            modelBuilder.Entity("dershane.entity.Ogrenci", b =>
                {
                    b.Property<int>("OgrenciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsHome")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Sınıf")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("OgrenciId");

                    b.ToTable("Ogrenciler");
                });

            modelBuilder.Entity("dershane.entity.OgrenciBolum", b =>
                {
                    b.Property<int>("BolumId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OgrenciId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BolumId", "OgrenciId");

                    b.HasIndex("OgrenciId");

                    b.ToTable("OgrenciBolum");
                });

            modelBuilder.Entity("dershane.entity.OgrenciBolum", b =>
                {
                    b.HasOne("dershane.entity.Bolum", "Bolum")
                        .WithMany("OgrenciBolumler")
                        .HasForeignKey("BolumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dershane.entity.Ogrenci", "Ogrenci")
                        .WithMany("OgrenciBolumler")
                        .HasForeignKey("OgrenciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bolum");

                    b.Navigation("Ogrenci");
                });

            modelBuilder.Entity("dershane.entity.Bolum", b =>
                {
                    b.Navigation("OgrenciBolumler");
                });

            modelBuilder.Entity("dershane.entity.Ogrenci", b =>
                {
                    b.Navigation("OgrenciBolumler");
                });
#pragma warning restore 612, 618
        }
    }
}
