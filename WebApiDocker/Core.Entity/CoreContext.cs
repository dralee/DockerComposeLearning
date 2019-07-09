using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Entity
{
    public class CoreContext : DbContext
    {
        public CoreContext() { }

        public CoreContext(DbContextOptions<CoreContext> options) : base(options)
        {            
        }

        public virtual DbSet<Post> Post { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                    .AddJsonFile("appsettings.Development.json", optional: false)
                    .Build();

                optionsBuilder.UseSqlServer(config["ConnectionString"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            #region Seeds

            string[] titles = new[] {
                "本教程由Siegrain提供",
                "感谢贡献~~",
                "博客地址为http://dralee.com",
                "教程内容就是docker的windows下简单使用"
            };

            for(var i = 0; i < titles.Length; ++i)
            {
                modelBuilder.Entity<Post>().HasData(new Post
                {
                    Id = i + 1,
                    Title = titles[i],
                    Content = Guid.NewGuid().ToString()
                });
            }

            #endregion
        }
    }
}
