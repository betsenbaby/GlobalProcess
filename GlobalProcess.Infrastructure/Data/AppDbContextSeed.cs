using GlobalProcess.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GlobalProcess.Infrastructure.Data
{
    public static class AppDbContextSeed
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.UserGroups.Any())
            {
                context.UserGroups.AddRange(
                    new UserGroup { Name = "Admin" },
                    new UserGroup { Name = "Manager" },
                    new UserGroup { Name = "User" }
                );

                context.SaveChanges();
            }
        }
    }
}
