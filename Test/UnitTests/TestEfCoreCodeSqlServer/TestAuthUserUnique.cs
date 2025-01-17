﻿// Copyright (c) 2023 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using AuthPermissions.BaseCode.CommonCode;
using AuthPermissions.BaseCode.DataLayer.EfCode;
using EntityFramework.Exceptions.SqlServer;
using Test.TestHelpers;
using TestSupport.EfHelpers;
using Xunit;
using Xunit.Extensions.AssertExtensions;

namespace Test.UnitTests.TestEfCoreCodeSqlServer
{
    public class TestAuthUserUnique
    {
        [Fact]
        public void TestAddAuthUserNullEmail()
        {
            //SETUP
            var options = this.CreateUniqueClassOptions<AuthPermissionsDbContext>(builder =>
                builder.UseExceptionProcessor());
            using var context = new AuthPermissionsDbContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //ATTEMPT
            context.Add(AuthPSetupHelpers.CreateTestAuthUserOk("123", null, "userName"));
            var status = context.SaveChangesWithChecks("en".SetupAuthPLoggingLocalizer().DefaultLocalizer);

            //VERIFY
            status.IsValid.ShouldBeTrue(status.GetAllErrors());
        }

        [Fact]
        public void TestAddAuthUserNullUserName()
        {
            //SETUP
            var options = this.CreateUniqueClassOptions<AuthPermissionsDbContext>(builder =>
                builder.UseExceptionProcessor());
            using var context = new AuthPermissionsDbContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Add(AuthPSetupHelpers.CreateTestAuthUserOk("123", "j@gmail.com", "userName"));
            var status = context.SaveChangesWithChecks("en".SetupAuthPLoggingLocalizer().DefaultLocalizer);

            //VERIFY
            status.IsValid.ShouldBeTrue(status.GetAllErrors());
        }

        [Fact]
        public void TestAddAuthUserNullEmailAndUserName()
        {
            //SETUP
            var options = this.CreateUniqueClassOptions<AuthPermissionsDbContext>(builder =>
                builder.UseExceptionProcessor());
            using var context = new AuthPermissionsDbContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //ATTEMPT
            var ex = Assert.Throws<AuthPermissionsBadDataException>(() =>
                AuthPSetupHelpers.CreateTestAuthUserOk("123", null, null));

            //VERIFY
            ex.Message.ShouldEqual("The Email and UserName can't both be null.");
        }
    }
}