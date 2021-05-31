﻿// Copyright (c) 2021 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AuthPermissions.SetupParts;

namespace AuthPermissions
{
    public class AuthPermissionsOptions : IAuthPermissionsOptions
    {
        public enum DatabaseTypes { NotSet, InMemory, SqlServer }

        //-------------------------------------------------
        //internal set properties/handles

        public Type EnumPermissionsType { get; internal set; }

        /// <summary>
        /// This contains the type of database used
        /// </summary>
        public DatabaseTypes DatabaseType { get; internal set; }

        /// <summary>
        /// This holds the a string containing the definition of the tenants
        /// See the <see cref="SetupExtensions.AddTenantsIfEmpty"/> method for the format of the lines
        /// </summary>
        public string UserTenantSetupText { get; internal set; }

        /// <summary>
        /// This holds the a string containing the definition of the RolesToPermission database class
        /// See the <see cref="SetupExtensions.AddRolesPermissionsIfEmpty"/> method for the format of the lines
        /// </summary>
        public string RolesPermissionsSetupText { get; internal set; }

        /// <summary>
        /// This holds the definition for a user, with its various parts
        /// See the <see cref="DefineUserWithRolesTenant"/> class for information you need to provide
        /// </summary>
        public List<DefineUserWithRolesTenant> UserRolesSetupData { get; internal set; }
    }
}