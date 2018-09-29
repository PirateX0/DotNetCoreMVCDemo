using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserSys.Services.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("T_Users");
            builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(50);
            builder.Property(u => u.PhoneNum).IsRequired().HasMaxLength(50);
            builder.HasQueryFilter(u => u.IsDeleted == false);
        }
    }
}
