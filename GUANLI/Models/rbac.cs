namespace GUANLI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class rbac : DbContext
    {
        public rbac()
            : base("name=rbac")
        {
        }

        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Module>()
                .HasMany(e => e.Role)
                .WithMany(e => e.Module)
                .Map(m => m.ToTable("RoleModule").MapLeftKey("moduleid").MapRightKey("roleid"));

            modelBuilder.Entity<Role>()
                .HasMany(e => e.User)
                .WithMany(e => e.Role)
                .Map(m => m.ToTable("UserRole").MapLeftKey("Roleid").MapRightKey("Userid"));
        }
    }
}
