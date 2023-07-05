﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinimalChatApplication;

#nullable disable

namespace MinimalChatApplication.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230704114136_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MinimalChatApplication.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserRegistrationUserId")
                        .HasColumnType("int");

                    b.HasKey("MessageId");

                    b.HasIndex("UserRegistrationUserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MinimalChatApplication.Models.SendMessageRequest", b =>
                {
                    b.Property<int>("ReceiverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ReceiverId");

                    b.ToTable("SendMessageRequests");
                });

            modelBuilder.Entity("MinimalChatApplication.Models.UserLogin", b =>
                {
                    b.Property<int>("LoginID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginID");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("MinimalChatApplication.Models.UserRegistration", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RegistrationDate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("UserRegistrations");
                });

            modelBuilder.Entity("MinimalChatApplication.Models.Message", b =>
                {
                    b.HasOne("MinimalChatApplication.Models.UserRegistration", null)
                        .WithMany("Messages")
                        .HasForeignKey("UserRegistrationUserId");
                });

            modelBuilder.Entity("MinimalChatApplication.Models.UserLogin", b =>
                {
                    b.HasOne("MinimalChatApplication.Models.UserRegistration", "User")
                        .WithMany("UserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MinimalChatApplication.Models.UserRegistration", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("UserLogins");
                });
#pragma warning restore 612, 618
        }
    }
}
