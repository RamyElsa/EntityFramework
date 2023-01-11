using System;
using System.Collections.Generic;
using EntityFrameworkCode.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityFrameworkCode.Model
{
    public partial class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Stack> Stacks { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; } 
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Authors> Authors { get; set; }
        
        public  DbSet<BooksDtos> BooksDtos { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               // optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=DESKTOP-0SRN5KR;Initial Catalog=EFCore;Integrated Security=True");
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-0SRN5KR;Initial Catalog=EFCore;Integrated Security=True",
                   o =>o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasSequence<int>("OrderNumber");

            //modelBuilder.HasSequence<int>("OrderNumber", "shared")
            //    .StartsAt(1000)
            //    .IncrementsBy(5);

            // this table not add in database
            modelBuilder.Entity<BooksDtos>(e => { e.HasNoKey().ToView(null); });
            OnModelCreatingPartial(modelBuilder);
            modelBuilder.Entity<Post>().HasQueryFilter(p =>  !p.IsDeleted);
            modelBuilder.Entity<Blog>().HasQueryFilter(p => p.Posts.Count>0);
            //modelBuilder.Entity<Post>().HasQueryFilter(p => p.Title.Contains(""));
             
            
            modelBuilder.Entity<Blog>()
                .HasMany(p => p.Posts)
                .WithOne(p => p.Blog)
                .OnDelete(DeleteBehavior.Restrict);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
