﻿// <auto-generated />
using System;
using HRProject_BackEnd.Presistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HRProject_BackEnd.Migrations
{
    [DbContext(typeof(CommitteeDBContext))]
    [Migration("20220323094149_tryingMeetingFix3")]
    partial class tryingMeetingFix3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CommitteeUserInfo", b =>
                {
                    b.Property<int>("CommitteesCommitteeID")
                        .HasColumnType("int");

                    b.Property<int>("UserInfoesUserID")
                        .HasColumnType("int");

                    b.HasKey("CommitteesCommitteeID", "UserInfoesUserID");

                    b.HasIndex("UserInfoesUserID");

                    b.ToTable("CommitteeUserInfo");
                });

            modelBuilder.Entity("HRProject_BackEnd.Models.Committee", b =>
                {
                    b.Property<int>("CommitteeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChairmanID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CommitteeEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CommitteeStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CommitteeTitle")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("SecretaryID")
                        .HasColumnType("int");

                    b.HasKey("CommitteeID");

                    b.ToTable("Committees");
                });

            modelBuilder.Entity("HRProject_BackEnd.Models.Meeting", b =>
                {
                    b.Property<int>("MeetingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CommitteeID")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MeetingEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MeetingStartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("MeetingTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MeetingID");

                    b.HasIndex("CommitteeID");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("HRProject_BackEnd.Models.UserInfo", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsEmployee")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UserID");

                    b.ToTable("UserInfoes");
                });

            modelBuilder.Entity("CommitteeUserInfo", b =>
                {
                    b.HasOne("HRProject_BackEnd.Models.Committee", null)
                        .WithMany()
                        .HasForeignKey("CommitteesCommitteeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRProject_BackEnd.Models.UserInfo", null)
                        .WithMany()
                        .HasForeignKey("UserInfoesUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HRProject_BackEnd.Models.Meeting", b =>
                {
                    b.HasOne("HRProject_BackEnd.Models.Committee", "Committee")
                        .WithMany("Meetings")
                        .HasForeignKey("CommitteeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Committee");
                });

            modelBuilder.Entity("HRProject_BackEnd.Models.Committee", b =>
                {
                    b.Navigation("Meetings");
                });
#pragma warning restore 612, 618
        }
    }
}
