using GlobalProcess.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalProcess.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<BusinessProcess> BusinessProcesses { get; set; }
        public DbSet<BusinessProcessInstance> BusinessProcessInstances { get; set; }
        public DbSet<Workflow> Workflows { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<ActionItem> ActionItems { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<DynamicForm> DynamicForms { get; set; }
        public DbSet<DynamicField> DynamicFields { get; set; }
        public DbSet<FieldValue> FieldValues { get; set; }
        public DbSet<FieldPermissions> FieldPermissions { get; set; }
        public DbSet<UserGroupPermission> UserGroupPermissions { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<StepType> StepTypes { get; set; }



        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserGroupPermission>()
                 .HasOne(ugp => ugp.UserGroup)
                 .WithMany(ug => ug.UserGroupPermissions)
                 .HasForeignKey(ugp => ugp.UserGroupId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DynamicField>()
                .HasOne(df => df.Form)
                .WithMany(f => f.Fields)
                .HasForeignKey(df => df.FormId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Step>()
           .Property(s => s.StepType)
           .HasConversion<string>();
            // Additional configurations if needed
        }
    }
}
