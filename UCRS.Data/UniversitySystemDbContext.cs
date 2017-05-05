﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

using UCRS.Common.Contracts;
using UCRS.Data.Models;

namespace UCRS.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class UniversitySystemDbContext : IdentityDbContext<ApplicationUser>, IUniversitySystemDbContext
    {
        public UniversitySystemDbContext()
            : base("UniversitySystemDBConnectionString", throwIfV1Schema: false)
        {
        }

        public static UniversitySystemDbContext Create()
        {
            return new UniversitySystemDbContext();
        }

        public IDbSet<IStudent> Students { get; set; }

        public IDbSet<ICourse> Courses { get; set; }
    }
}