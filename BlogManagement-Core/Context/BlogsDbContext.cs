using BlogManagement_Core.Entites;
using BlogManagement_Core.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement_Core.Context
{
    public class BlogsDbContext : DbContext
    {
        public BlogsDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BlogEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LoginEntityTypeConfiguration());

            modelBuilder.Entity<Subscribtion>().HasKey(x => x.Id);
            modelBuilder.Entity<Subscribtion>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<Subscribtion>().Property(x => x.IsActive).HasDefaultValue(true);
            modelBuilder.Entity<UserSubscription>().HasKey(x => x.Id);
            modelBuilder.Entity<UserSubscription>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<PaymentMethod>().HasKey(x => x.Id);
            modelBuilder.Entity<PaymentMethod>().Property(x => x.Id).UseIdentityColumn();
        }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Subscribtion> Subscribtions    { get; set; }
        public virtual DbSet<UserSubscription> UserSubscriptions { get; set; }
    }
}
