using EntityFrameworkCode._Models;
using EntityFrameworkCode.FluentApi;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCode
{
    public class ApplicationDBContext_Old : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlServer("Data Source=DESKTOP-0SRN5KR;Initial Catalog=EFCore;Integrated Security=True");



        // Fluent Api (three ways)
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditEntry>();
            modelBuilder.Ignore<Post>();
        }
        */

        // Fluent Api (two ways)
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ده واحد يمشى
            new EntityBlogsConfig().Configure(modelBuilder.Entity<Blog>());
            // و ده طريقه تانيه نفس النتيجه
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityBlogsConfig).Assembly);
        }
        */

        // Fluent Api (one ways)
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .Property(m => m.Url).IsRequired();
        }
        */

        // Create table in Database one Ways 
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .ToTable("Blogs", m => m.ExcludeFromMigrations());
        }

        */












        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
      modelBuilder.Entity<AuditEntry>();
      new EntityBlogsConfig().Configure(modelBuilder.Entity<Blog>());
      */

            // Create table , Schema name in database
            /*
            // modelBuilder.Entity<Post>()
            // .ToTable("Posts");

            // Create table , Schema name in database
            modelBuilder.Entity<Post>()
            .ToTable("Posts",schema:"blogging");

            // Return view Desgin In www
            modelBuilder.Entity<Post>()
           .ToView("SelectPosts", schema: "blogging");

            // Create Schema name in database ,
            // and any Table take your Schema Where Create Table
            modelBuilder.HasDefaultSchema("blogging");
            */

            // ف الحاله دى لو عاوز اشيل حاجه معينه من الكلاس 
            /*
            modelBuilder.Entity<Blog>()
                .Ignore(b => b.AddOn);
           */

            // Change ColumnName in DataBase
            /*
            modelBuilder.Entity<Blog>()
                .Property(b => b.Url)
                .HasColumnName("Blogurl");
            */

            // Change Column DataType in DataBase
            /*
            modelBuilder.Entity<Blog>(eb =>{
                eb.Property(b => b.Url).HasColumnType("varchar(200)");
                eb.Property(b => b.Rating).HasColumnType("decimal(5,2)");
            });
            */

            // Change Max Length in DataBase
            /*
            modelBuilder.Entity<Blog>(eb => {
                eb.Property(b => b.Url).HasMaxLength(200);

            });
            */

            // Create Comment 
            /*
            modelBuilder.Entity<Blog>(eb => {
                eb.Property(b => b.Url).HasComment("The Url of the Blog");

            });
            */

            // Composite Key (this don`t use in data Annotaion) 
            /*
            modelBuilder.Entity<Book>()
                .HasKey(b => new { b.Name, b.Author });
            */

            // Default Value 
            /*
            modelBuilder.Entity<Blog>().Property
                (b => b.Rti).HasDefaultValue(2);

            modelBuilder.Entity<Blog>().Property
            (b => b.AddOn).HasDefaultValueSql("GETDATE()");
            */

            //ComputedColumn
            /*
            modelBuilder.Entity<Author>()
                .Property(b => b.DisplayName)
                .HasComputedColumnSql("[LastName] + '. ' + [FirstName]");
            */

            // Default Value (primaryKEY)
            /*
            modelBuilder.Entity<Category>()
                .Property(c => c.Id).ValueGeneratedOnAdd();
            */


            // RelationShip 

            // one to one 
            /*
            modelBuilder.Entity<Relation>()
                .HasOne(b => b.retaionImage)
                .WithOne(i => i.relation)
                .HasForeignKey<RetaionImage>(b => b.RelationForeign);
            */

            // one to Many
            /*
            modelBuilder.Entity<Relation>()
           .HasMany(b => b.RetaionImages)
           .WithOne();

            modelBuilder.Entity<RetaionImage>()
           .HasOne(b => b.relation)
           .WithMany(b=>b.RetaionImages);
            */
            /*
            modelBuilder.Entity<RetaionImage>()
                .HasOne<Relation>()
                .WithMany()
                .HasForeignKey(b => b.RelationId);
            */
            /*
            modelBuilder.Entity<RecordOfSale>()
                .HasOne(s => s.car)
                .WithMany(c => c.SaleHistory)
                .HasForeignKey(s => s.CarLicensaplate)
                .HasPrincipalKey(c=>c.Licensaplate);


            modelBuilder.Entity<RecordOfSale>()
            .HasOne(s => s.car)
            .WithMany(c => c.SaleHistory)
            .HasForeignKey(s =>new { s.CarLicensaplate ,s.CarState})
            .HasPrincipalKey(c =>new { c.Licensaplate,c.State });
            */

            // Many to Many
            /*
            modelBuilder.Entity<Many>()
                .HasMany(p => p.ManytoManies)
                .WithMany(p => p.Manies)
                .UsingEntity(j => j.ToTable("CollectTable"));
            */
            // Create Table In Many to Many 11111
            /*
            modelBuilder.Entity<Many>()
            .HasMany(p => p.TagsMany)
            .WithMany(p => p.PostMany)
            .UsingEntity<CollectTable>(
                j=>j
                .HasOne(pt=>pt.TagsMany)
                .WithMany(t=>t.PT_Maines)
                .HasForeignKey(pt=>pt.TagsManyId),
                  j => j
                  .HasOne(pp => pp.PostMany).
                  WithMany(p => p.PT_Maines).
                  HasForeignKey(pp => pp.PostManyId),
                 j =>
                 {
                     j.Property(pt => pt.DateNow).HasDefaultValueSql("GETDATE()");
                     j.HasKey(t => new { t.ManyToManyId, t.ManyId });
                 }

                );
               */
            // Create Table In Many to Many 22222**
            /*
            modelBuilder.Entity<CollectTable>()
                .HasKey(t => new { t.TagsManyId, t.PostManyId });
            modelBuilder.Entity<CollectTable>()
            .HasOne(p => p.PostMany)
            .WithMany(p => p.PT_Maines)
            .HasForeignKey(p => p.PostManyId);
            modelBuilder.Entity<CollectTable>()
            .HasOne(p => p.TagsMany)
            .WithMany(p => p.PT_Maines)
            .HasForeignKey(p => p.TagsManyId);
            */

            // How to create Index 
            /*
            modelBuilder.Entity<Blog>()
                .HasIndex(e => e.Url);
            */
            // How to create  Composite Index 
            /*
            modelBuilder.Entity<Person>()
                .HasIndex(e =>new { e.FirstName , e.LastName });
            */
            // How to create  Index  Uniqueness
            /*
             modelBuilder.Entity<Blog>()
            .HasIndex(e => e.Url).IsUnique();
            */
            // How to create  Index  Name
            /*
            modelBuilder.Entity<Blog>()
           .HasIndex(e => e.Url)
           .HasDatabaseName("Url_Name");
            */
            // How to create  Index  Filter
            /*
            modelBuilder.Entity<Blog>()
            .HasIndex(e => e.Url)
            .IsUnique()
            .HasFilter(null);
            */


            // Sequences
            /*
            modelBuilder.HasSequence<int>("OrderNumber", schema: "shared")
                .StartsAt(1000)
                .IncrementsBy(5);

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderNo)
                .HasDefaultValueSql("NEXT VALUE FOR shared.OrderNumber ");


            modelBuilder.Entity<OrderTest>()
                .Property(o => o.OrderNo)
                .HasDefaultValueSql("NEXT VALUE FOR shared.OrderNumber ");
            */

            // Data seeding
            /*
            modelBuilder.Entity<Blog>()
                .HasData(new Blog { BlogId = 1 , Url = "www.google.com" });
            modelBuilder.Entity<Post>()
                .HasData(new Post { BlogId = 1, Id = 1 ,Title = "Post1" , Content = "Test1" },
                new Post { BlogId = 1, Id = 2, Title = "Post2", Content = "Test2" });
            */


        }

        // Create table in Database two Ways
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }






        /*
        // public DbSet<Category> categories { get; set; }
        // public DbSet<Order> Orders { get; set; }
        // public DbSet<OrderTest> OrdersTest { get; set; }
        // public DbSet<Person> people { get; set; }
        // public DbSet<ManytoMany> ManyToMany { get; set; }
        // public DbSet<Many> Manies { get; set; }
        // public DbSet<Car> Cars { get; set; }
        // public DbSet<Relation> Relations { get; set; }
        // public DbSet<RetaionImage> Relationimages { get; set; }
        */

    }

    // [Index(nameof(Url),Name ="Index Url",IsUnique =true)]
    public class Blog
    {
        public int BlogId { get; set; }


        //[Required]            //DataAnnotaions 
        // [Column("BlogUrl")] //DataAnnotaions
        // [Column(TypeName ="varchar(200)")] //DataAnnotaions
        // [MaxLength(100)] //DataAnnotaions 
        // [Comment("The Url of the Blog")]

        public string Url { get; set; }


        // [Column(TypeName = "decimal(5,2)")]  //Column DataType
        // public decimal Rating { get; set; }
        // public int Rti { get; set; }

        //[NotMapped] //DataAnnotaions
        // public DateTime AddOn { get; set; }


        // [NotMapped] //DataAnnotaions
        public List<Post> Posts { get; set; }
    }
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

    }

}
