using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Linq;
using UserSys.Services.Configs;

namespace UserSys.Services
{
    public class MyDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder =
                new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())//SetBasePath设置配置文件所在路径
                .AddJsonFile("appsettings.json");
            var configRoot = builder.Build();
            var connString =
                configRoot.GetSection("db").GetSection("ConnectionString").Value;
            optionsBuilder.UseSqlServer(connString);
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Assembly asmServices = Assembly.Load(new AssemblyName("UserSys.Services"));
            //modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfigurationsFromAssembly(asmServices);
        }
    }
}
