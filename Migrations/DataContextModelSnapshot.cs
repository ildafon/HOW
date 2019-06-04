﻿// <auto-generated />
using System;
using HoustonOnWire.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HoustonOnWire.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        new { ChannelId = 2L, Name = "Test2", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 3L, Name = "Test3", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 4L, Name = "Test4", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 5L, Name = "Test5", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 6L, Name = "Test6", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 7L, Name = "Test7", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 8L, Name = "Test8", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 9L, Name = "Test9", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 10L, Name = "Test10", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 11L, Name = "Test11", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 12L, Name = "Test12", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 13L, Name = "Test13", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 14L, Name = "Test14", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 15L, Name = "Test15", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 16L, Name = "Test16", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 17L, Name = "Test17", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 18L, Name = "Test18", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 19L, Name = "Test19", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 20L, Name = "Test20", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 21L, Name = "Test21", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 22L, Name = "Test22", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 23L, Name = "Test23", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 24L, Name = "Test24", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 25L, Name = "Test25", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 26L, Name = "Test26", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 27L, Name = "Test27", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 28L, Name = "Test28", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 29L, Name = "Test29", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 30L, Name = "Test30", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 31L, Name = "Test31", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 32L, Name = "Test32", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 33L, Name = "Test33", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 34L, Name = "Test34", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 35L, Name = "Test35", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 36L, Name = "Test36", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 37L, Name = "Test37", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 38L, Name = "Test38", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 39L, Name = "Test39", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 40L, Name = "Test40", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 41L, Name = "Test41", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 42L, Name = "Test42", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 43L, Name = "Test43", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 44L, Name = "Test44", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 45L, Name = "Test45", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 46L, Name = "Test46", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 47L, Name = "Test47", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 48L, Name = "Test48", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 49L, Name = "Test49", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 50L, Name = "Test50", Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
                        new { ChannelId = 2L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 3L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 3L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 4L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 4L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 5L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 5L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 6L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 6L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 7L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 7L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 8L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 8L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 9L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 9L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 10L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 10L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 11L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 11L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 12L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 12L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 13L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 13L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 14L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 14L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 15L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 15L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 16L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 16L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 17L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 17L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 18L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 18L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 19L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 19L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 20L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 20L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 21L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 21L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 22L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 22L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 23L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 23L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 24L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 24L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 25L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 25L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 26L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 26L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 27L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 27L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 28L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 28L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 29L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 29L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 30L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 30L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 31L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 31L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 32L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 32L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 33L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 33L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 34L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 34L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 35L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 35L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 36L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 36L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 37L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 37L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 38L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 38L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 39L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 39L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 40L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 40L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 41L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 41L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 42L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 42L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 43L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 43L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 44L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 44L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 45L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 45L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 46L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 46L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 47L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 47L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 48L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 48L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 49L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 49L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 50L, CustomerId = 1L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ChannelId = 50L, CustomerId = 2L, Received = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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

                    b.HasKey("CustomerId");

                    b.HasIndex("AvatarId")
                        .IsUnique()
                        .HasFilter("[AvatarId] IS NOT NULL");

                    b.ToTable("Customers");

                    b.HasData(
                        new { CustomerId = 1L, AvatarId = 1L, Email = "operator1@example.com", Name = "Operator1" },
                        new { CustomerId = 2L, AvatarId = 2L, Email = "operator2@example.com", Name = "Operator2" },
                        new { CustomerId = 3L, AvatarId = 5L, Email = "operator3@example.com", Name = "Operator3" },
                        new { CustomerId = 4L, AvatarId = 6L, Email = "operator4@example.com", Name = "Operator4" }
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
