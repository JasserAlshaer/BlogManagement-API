using BlogManagement_Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement_Core.EntityTypeConfigurations
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).UseIdentityColumn();
            builder.Property(t=>t.IsActive).HasDefaultValue(true);
            builder.Property(t => t.JoinDate).HasDefaultValue(DateTime.Now);
            //Relationships
            builder.HasMany<Blog>().WithOne().HasForeignKey(x => x.UserId);
            builder.HasOne<Login>().WithOne().HasForeignKey<Login>(x => x.UserId);
        }
    }
}
