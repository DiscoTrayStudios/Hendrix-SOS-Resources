﻿// <auto-generated />
using System;
using HendrixSOSResources.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HendrixSOSResources.Migrations
{
    [DbContext(typeof(SOSContext))]
    [Migration("20241030202909_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("ResourceResourceRequest", b =>
                {
                    b.Property<int>("ResourceRequestsID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ResourcesID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ResourceRequestsID", "ResourcesID");

                    b.HasIndex("ResourcesID");

                    b.ToTable("ResourceResourceRequest");
                });

            modelBuilder.Entity("SOSResources.Models.Copy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CheckedOut")
                        .HasColumnType("INTEGER");

                    b.Property<int>("textbookID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("textbookID");

                    b.ToTable("Copy");
                });

            modelBuilder.Entity("SOSResources.Models.Participant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Participant");
                });

            modelBuilder.Entity("SOSResources.Models.Resource", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Resource");
                });

            modelBuilder.Entity("SOSResources.Models.ResourceRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParticipantID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ParticipantID");

                    b.ToTable("ResourceRequest");
                });

            modelBuilder.Entity("SOSResources.Models.Textbook", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Edition")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Textbook");
                });

            modelBuilder.Entity("SOSResources.Models.TextbookRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("RequesterID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("copyID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("RequesterID");

                    b.HasIndex("copyID");

                    b.ToTable("TextbookRequest");
                });

            modelBuilder.Entity("ResourceResourceRequest", b =>
                {
                    b.HasOne("SOSResources.Models.ResourceRequest", null)
                        .WithMany()
                        .HasForeignKey("ResourceRequestsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SOSResources.Models.Resource", null)
                        .WithMany()
                        .HasForeignKey("ResourcesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SOSResources.Models.Copy", b =>
                {
                    b.HasOne("SOSResources.Models.Textbook", "textbook")
                        .WithMany("Copies")
                        .HasForeignKey("textbookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("textbook");
                });

            modelBuilder.Entity("SOSResources.Models.ResourceRequest", b =>
                {
                    b.HasOne("SOSResources.Models.Participant", "Participant")
                        .WithMany("ResourceRequests")
                        .HasForeignKey("ParticipantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("SOSResources.Models.TextbookRequest", b =>
                {
                    b.HasOne("SOSResources.Models.Participant", "Requester")
                        .WithMany("TextbookRequests")
                        .HasForeignKey("RequesterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SOSResources.Models.Copy", "copy")
                        .WithMany("textbookRequests")
                        .HasForeignKey("copyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Requester");

                    b.Navigation("copy");
                });

            modelBuilder.Entity("SOSResources.Models.Copy", b =>
                {
                    b.Navigation("textbookRequests");
                });

            modelBuilder.Entity("SOSResources.Models.Participant", b =>
                {
                    b.Navigation("ResourceRequests");

                    b.Navigation("TextbookRequests");
                });

            modelBuilder.Entity("SOSResources.Models.Textbook", b =>
                {
                    b.Navigation("Copies");
                });
#pragma warning restore 612, 618
        }
    }
}