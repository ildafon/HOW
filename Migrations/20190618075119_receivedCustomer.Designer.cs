﻿// <auto-generated />
using System;
using HoustonOnWire.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HoustonOnWire.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190618075119_receivedCustomer")]
    partial class receivedCustomer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HoustonOnWire.Models.Avatar", b =>
                {
                    b.Property<long>("AvatarId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Url");

                    b.HasKey("AvatarId");

                    b.ToTable("Avatars");

                    b.HasData(
                        new { AvatarId = 1L, Url = "/assets/av-1.png" },
                        new { AvatarId = 2L, Url = "/assets/av-2.png" },
                        new { AvatarId = 3L, Url = "/assets/av-3.png" },
                        new { AvatarId = 4L, Url = "/assets/av-4.png" },
                        new { AvatarId = 5L, Url = "/assets/av-5.png" },
                        new { AvatarId = 6L, Url = "/assets/av-6.png" },
                        new { AvatarId = 7L, Url = "/assets/av-7.png" },
                        new { AvatarId = 8L, Url = "/assets/av-8.png" }
                    );
                });

            modelBuilder.Entity("HoustonOnWire.Models.Channel", b =>
                {
                    b.Property<long>("ChannelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<DateTime>("Received");

                    b.HasKey("ChannelId");

                    b.ToTable("Channels");

                    b.HasData(
                        new { ChannelId = 1L, Name = "Test1", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 2L, Name = "Test2", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                    );
                });

            modelBuilder.Entity("HoustonOnWire.Models.ChannelCustomer", b =>
                {
                    b.Property<long>("ChannelId");

                    b.Property<long>("CustomerId");

                    b.Property<DateTime>("Received");

                    b.HasKey("ChannelId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("ChannelCustomers");

                    b.HasData(
                        new { ChannelId = 1L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 1L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 2L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 2L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                    );
                });

            modelBuilder.Entity("HoustonOnWire.Models.Chat", b =>
                {
                    b.Property<long>("ChatId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CustomerFirstResponse");

                    b.Property<long?>("CustomerId");

                    b.Property<bool>("IsActive");

                    b.Property<long?>("LastMessageId");

                    b.Property<int>("Score");

                    b.Property<long>("VisitorId");

                    b.HasKey("ChatId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("VisitorId")
                        .IsUnique();

                    b.ToTable("Chats");

                    b.HasData(
                        new { ChatId = 1L, CustomerFirstResponse = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), CustomerId = 1L, IsActive = true, LastMessageId = 2L, Score = 10, VisitorId = 1L },
                        new { ChatId = 2L, CustomerFirstResponse = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), CustomerId = 1L, IsActive = true, LastMessageId = 4L, Score = 5, VisitorId = 2L }
                    );
                });

            modelBuilder.Entity("HoustonOnWire.Models.Customer", b =>
                {
                    b.Property<long>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AvatarId");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Received");

                    b.HasKey("CustomerId");

                    b.HasIndex("AvatarId")
                        .IsUnique()
                        .HasFilter("[AvatarId] IS NOT NULL");

                    b.ToTable("Customers");

                    b.HasData(
                        new { CustomerId = 1L, AvatarId = 1L, Email = "operator1@example.com", Name = "Operator1", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { CustomerId = 2L, AvatarId = 2L, Email = "operator2@example.com", Name = "Operator2", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { CustomerId = 3L, AvatarId = 5L, Email = "operator3@example.com", Name = "Operator3", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { CustomerId = 4L, AvatarId = 6L, Email = "operator4@example.com", Name = "Operator4", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                    );
                });

            modelBuilder.Entity("HoustonOnWire.Models.Message", b =>
                {
                    b.Property<long>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ChatId");

                    b.Property<string>("Content");

                    b.Property<bool>("FromVisitor");

                    b.Property<DateTime>("Received")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("GetDate()");

                    b.HasKey("MessageId");

                    b.HasIndex("ChatId");

                    b.ToTable("Messages");

                    b.HasData(
                        new { MessageId = 1L, ChatId = 1L, Content = "Hello", FromVisitor = true, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { MessageId = 2L, ChatId = 1L, Content = "Hello", FromVisitor = false, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { MessageId = 3L, ChatId = 2L, Content = "Hello", FromVisitor = true, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { MessageId = 4L, ChatId = 2L, Content = "Hello", FromVisitor = false, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                    );
                });

            modelBuilder.Entity("HoustonOnWire.Models.Visitor", b =>
                {
                    b.Property<long>("VisitorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AvatarId");

                    b.Property<string>("Comment");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.HasKey("VisitorId");

                    b.HasIndex("AvatarId")
                        .IsUnique()
                        .HasFilter("[AvatarId] IS NOT NULL");

                    b.ToTable("Visitors");

                    b.HasData(
                        new { VisitorId = 1L, AvatarId = 3L, Comment = "Comment1", Email = "visitor1@example.com", Name = "Visitor1", Phone = "+79190000001" },
                        new { VisitorId = 2L, AvatarId = 4L, Comment = "Comment2", Email = "visitor2@example.com", Name = "Visitor2", Phone = "+79190000002" }
                    );
                });

            modelBuilder.Entity("HoustonOnWire.Models.ChannelCustomer", b =>
                {
                    b.HasOne("HoustonOnWire.Models.Channel", "Channel")
                        .WithMany("ChannelCustomers")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HoustonOnWire.Models.Customer", "Customer")
                        .WithMany("ChannelCustomers")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HoustonOnWire.Models.Chat", b =>
                {
                    b.HasOne("HoustonOnWire.Models.Customer", "Customer")
                        .WithMany("Chats")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HoustonOnWire.Models.Visitor", "Visitor")
                        .WithOne("Chat")
                        .HasForeignKey("HoustonOnWire.Models.Chat", "VisitorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HoustonOnWire.Models.Customer", b =>
                {
                    b.HasOne("HoustonOnWire.Models.Avatar", "Avatar")
                        .WithOne("Customer")
                        .HasForeignKey("HoustonOnWire.Models.Customer", "AvatarId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("HoustonOnWire.Models.Message", b =>
                {
                    b.HasOne("HoustonOnWire.Models.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HoustonOnWire.Models.Visitor", b =>
                {
                    b.HasOne("HoustonOnWire.Models.Avatar", "Avatar")
                        .WithOne("Visitor")
                        .HasForeignKey("HoustonOnWire.Models.Visitor", "AvatarId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
