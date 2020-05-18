﻿// <auto-generated />
using IllyriadAssist.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IllyriadAssist.Migrations
{
    [DbContext(typeof(IllyContext))]
    partial class IllyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("IllyriadAssist.Models.APISettings", b =>
                {
                    b.Property<int>("APIid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("API_ID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("APIKey")
                        .IsRequired()
                        .HasColumnName("API_KEY")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("APIType")
                        .IsRequired()
                        .HasColumnName("API_TYPE")
                        .HasColumnType("TEXT")
                        .HasMaxLength(4);

                    b.HasKey("APIid");

                    b.ToTable("MD_API_SETTINGS");
                });

            modelBuilder.Entity("IllyriadAssist.Models.RareMinerals", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ITEM_ID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IllyCode")
                        .IsRequired()
                        .HasColumnName("ILLY_CODE")
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnName("IMAGE_NAME")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000);

                    b.Property<string>("ItemDescription")
                        .IsRequired()
                        .HasColumnName("ITEM_DESCRIPTION")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000000);

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnName("ITEM_NAME")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.HasKey("ItemID");

                    b.ToTable("MD_RARE_MINERALS");
                });
#pragma warning restore 612, 618
        }
    }
}
