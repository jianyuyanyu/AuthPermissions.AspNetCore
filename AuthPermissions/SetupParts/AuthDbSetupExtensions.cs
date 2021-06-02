﻿// Copyright (c) 2021 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Threading.Tasks;
using AuthPermissions.DataLayer.EfCode;
using AuthPermissions.SetupParts.Internal;
using StatusGeneric;

namespace AuthPermissions.SetupParts
{
    public static class AuthDbSetupExtensions
    {
        public static void IfErrorsTurnToException(this IStatusGeneric status)
        {
            if (status.HasErrors)
                throw new InvalidOperationException(status.Errors.Count() == 1
                    ? status.Errors.Single().ToString()
                    : $"There were {status.Errors.Count()}:{Environment.NewLine}{status.GetAllErrors()}");
        }
    }
}