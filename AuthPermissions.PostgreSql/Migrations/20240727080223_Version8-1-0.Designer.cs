﻿// <auto-generated />
using System;
using AuthPermissions.BaseCode.DataLayer.EfCode;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AuthPermissions.PostgreSql.Migrations
{
    [DbContext(typeof(AuthPermissionsDbContext))]
    [Migration("20240727080223_Version8-1-0")]
    partial class Version810
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("authp")
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AuthPermissions.BaseCode.DataLayer.Classes.AuthUser", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("boolean");

                    b.Property<int?>("TenantId")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<uint>("xmin")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("TenantId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("AuthUsers", "authp");
                });

            modelBuilder.Entity("AuthPermissions.BaseCode.DataLayer.Classes.RefreshToken", b =>
                {
                    b.Property<string>("TokenValue")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("AddedDateUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsInvalid")
                        .HasColumnType("boolean");

                    b.Property<string>("JwtId")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<uint>("xmin")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.HasKey("TokenValue");

                    b.HasIndex("AddedDateUtc")
                        .IsUnique();

                    b.ToTable("RefreshTokens", "authp");
                });

            modelBuilder.Entity("AuthPermissions.BaseCode.DataLayer.Classes.RoleToPermissions", b =>
                {
                    b.Property<string>("RoleName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("PackedPermissionsInRole")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("RoleType")
                        .HasColumnType("smallint");

                    b.Property<uint>("xmin")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.HasKey("RoleName");

                    b.HasIndex("RoleType");

                    b.ToTable("RoleToPermissions", "authp");
                });

            modelBuilder.Entity("AuthPermissions.BaseCode.DataLayer.Classes.ShardingEntry", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(400)
                        .HasColumnType("character varying(400)");

                    b.Property<string>("ConnectionName")
                        .HasColumnType("text");

                    b.Property<string>("DatabaseName")
                        .HasColumnType("text");

                    b.Property<string>("DatabaseType")
                        .HasColumnType("text");

                    b.Property<uint>("xmin")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.HasKey("Name");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ShardingEntryBackup", "authp");
                });

            modelBuilder.Entity("AuthPermissions.BaseCode.DataLayer.Classes.Tenant", b =>
                {
                    b.Property<int>("TenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TenantId"));

                    b.Property<string>("DatabaseInfoName")
                        .HasColumnType("text");

                    b.Property<bool>("HasOwnDb")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsHierarchical")
                        .HasColumnType("boolean");

                    b.Property<string>("ParentDataKey")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("character varying(250)");

                    b.Property<int?>("ParentTenantId")
                        .HasColumnType("integer");

                    b.Property<string>("TenantFullName")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("character varying(400)");

                    b.Property<uint>("xmin")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.HasKey("TenantId");

                    b.HasIndex("ParentDataKey");

                    b.HasIndex("ParentTenantId");

                    b.HasIndex("TenantFullName")
                        .IsUnique();

                    b.ToTable("Tenants", "authp");
                });

            modelBuilder.Entity("AuthPermissions.BaseCode.DataLayer.Classes.UserToRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("RoleName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<uint>("xmin")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.HasKey("UserId", "RoleName");

                    b.HasIndex("RoleName");

                    b.ToTable("UserToRoles", "authp");
                });

            modelBuilder.Entity("RoleToPermissionsTenant", b =>
                {
                    b.Property<string>("TenantRolesRoleName")
                        .HasColumnType("character varying(100)");

                    b.Property<int>("TenantsTenantId")
                        .HasColumnType("integer");

                    b.Property<uint>("xmin")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.HasKey("TenantRolesRoleName", "TenantsTenantId");

                    b.HasIndex("TenantsTenantId");

                    b.ToTable("RoleToPermissionsTenant", "authp");
                });

            modelBuilder.Entity("AuthPermissions.BaseCode.DataLayer.Classes.AuthUser", b =>
                {
                    b.HasOne("AuthPermissions.BaseCode.DataLayer.Classes.Tenant", "UserTenant")
                        .WithMany()
                        .HasForeignKey("TenantId");

                    b.Navigation("UserTenant");
                });

            modelBuilder.Entity("AuthPermissions.BaseCode.DataLayer.Classes.Tenant", b =>
                {
                    b.HasOne("AuthPermissions.BaseCode.DataLayer.Classes.Tenant", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentTenantId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("AuthPermissions.BaseCode.DataLayer.Classes.UserToRole", b =>
                {
                    b.HasOne("AuthPermissions.BaseCode.DataLayer.Classes.RoleToPermissions", "Role")
                        .WithMany()
                        .HasForeignKey("RoleName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthPermissions.BaseCode.DataLayer.Classes.AuthUser", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("RoleToPermissionsTenant", b =>
                {
                    b.HasOne("AuthPermissions.BaseCode.DataLayer.Classes.RoleToPermissions", null)
                        .WithMany()
                        .HasForeignKey("TenantRolesRoleName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthPermissions.BaseCode.DataLayer.Classes.Tenant", null)
                        .WithMany()
                        .HasForeignKey("TenantsTenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuthPermissions.BaseCode.DataLayer.Classes.AuthUser", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("AuthPermissions.BaseCode.DataLayer.Classes.Tenant", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}