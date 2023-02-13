﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TelegramBot.Persistence.DbContexts;

#nullable disable

namespace TelegramBot.Persistence.Migrations
{
    [DbContext(typeof(TelegramBotDbContext))]
    [Migration("20230211021144_updentitiess")]
    partial class updentitiess
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TelegramBot.Persistence.Entities.UserEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("DepartureAddress")
                        .HasColumnType("text");

                    b.Property<string>("DestinationAddress")
                        .HasColumnType("text");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<string>("MessageValidationType")
                        .HasColumnType("text");

                    b.Property<string>("Numder")
                        .HasColumnType("text");

                    b.Property<string>("Sms")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
