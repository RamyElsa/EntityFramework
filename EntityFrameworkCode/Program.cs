using EntityFrameworkCode._Models;
using EntityFrameworkCode.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Diagnostics;

namespace EntityFrameworkCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _Context = new ApplicationDBContext();


            // Select All Data
            /*
            var stacks = _Context.Stacks.ToList();
            foreach(var stack in stacks)
                Console.WriteLine(stack.Name);
            */
            // Select One Item Data
            /*
            var stacks = _Context.Stacks.Find(990); // ID Number In Database
            Console.WriteLine($"ID: {stacks.Id} : {stacks.Name}");
            */
            // Select One Item Data Single
            /*
            var stacks = _Context.Stacks.Single(m=>m.Id==100);
            Console.WriteLine($"ID: {stacks.Id} : {stacks.Name}");

            var stack = _Context.Stacks.SingleOrDefault(m => m.Id == 100);
            Console.WriteLine(stack==null ? "No Item Found!!!" : $"ID: {stack.Id} : {stack.Name}");
            */
            // Select One Item Data First
            /*
            var stacks = _Context.Stacks.First();
            Console.WriteLine($"ID: {stacks.Id} : {stacks.Name}");

            var stac = _Context.Stacks.First(f=>f.Id>500);
            Console.WriteLine($"ID: {stac.Id} : {stac.Name}");

            var stack = _Context.Stacks.FirstOrDefault(m => m.Id == 100);
            Console.WriteLine(stack == null ? "No Item Found!!!" : $"ID: {stack.Id} : {stack.Name}");
            */
            // Select One Item Data Last
            /*
            var stacks = _Context.Stacks.OrderBy(m=>m.Id).Last();
            Console.WriteLine($"ID: {stacks.Id} : {stacks.Name}");

            var stac = _Context.Stacks.OrderBy(m => m.Name).Last(m=>m.Id>10);
            Console.WriteLine($"ID: {stac.Id} : {stac.Name}");

            var stack = _Context.Stacks.OrderBy(m => m.Name).LastOrDefault(m => m.Id == 100);
            Console.WriteLine(stack == null ? "No Item Found!!!" : $"ID: {stack.Id} : {stack.Name}");
            */
            // Filtering data using Where
            /*
            var stacks = _Context.Stacks.Where(m=>m.Id>500).ToList();
            foreach (var stack in stacks) { Console.WriteLine(stack.Name); }
               
            var stac = _Context.Stacks.Where(m=>m.Name.StartsWith("Z")).ToList();
            foreach (var stack in stacks) { Console.WriteLine(stack == null ? "No Item Found!!!" : $"ID: {stack.Id} : {stack.Name}"); }
             */
            //  Any Vs All Data
            /*
            var stacks = _Context.Stacks.Any();
            Console.WriteLine(stacks);
            var stack = _Context.Stacks.Any(m=>m.Id > 234);
            Console.WriteLine(stack);
            
            var stacks = _Context.Stacks.All(m=>m.Id>0);
            Console.WriteLine(stacks);
            var stack = _Context.Stacks.All(m => m.Id < 234);
            Console.WriteLine(stack);
            */
            //Append Vs Prepend 
            //(Addpend Add item in last List)
            //(Prepend Add item in First List)
            /*
            var stacks = _Context.Stacks.Where(m => m.Id > 900).ToList().Append(new Stack {Id = 1001 ,Name = "Test"});
            foreach (var stack in stacks) { Console.WriteLine($"ID: {stack.Id} : {stack.Name}"); }

            var stac = _Context.Stacks.Where(m => m.Id > 900).ToList().Prepend(new Stack { Id = 1001, Name = "Test" });
            foreach (var stack in stac) { Console.WriteLine($"ID: {stack.Id} : {stack.Name}"); }
            */
            // Average -- Count -- Sum
            /*
            var stacks = _Context.Stacks.Average(m => m.Balance);
            var stack = _Context.Stacks.Where(m=>m.Id>600).Average(m => m.Balance);
            Console.WriteLine(stacks);
            Console.WriteLine(stack);

            var stacks = _Context.Stacks.Count();
            var stack = _Context.Stacks.LongCount(m => m.Id>500);
            Console.WriteLine(stacks);
            Console.WriteLine(stack);

            var stacks = _Context.Stacks.Sum(m => m.Balance);
            var stack = _Context.Stacks.Where(m => m.Id > 600).Sum(m => m.Balance);
            Console.WriteLine(stacks);
            Console.WriteLine(stack);
            */
            //  Max Vs Min 
            /*
            var stacks = _Context.Stacks.Max(m => m.Balance);
            var stack = _Context.Stacks.Where(m => m.Id > 600).Max(m => m.Balance);
            Console.WriteLine(stacks);
            Console.WriteLine(stack);

            var stacks = _Context.Stacks.Min(m => m.Balance);
            var stack = _Context.Stacks.Where(m => m.Id > 600).Min(m => m.Balance);
            Console.WriteLine(stacks);
            Console.WriteLine(stack);

            */
            //  Sorting  using OrderBy (form min to max number)
            /*
            var stacks = _Context.Stacks.OrderBy(m => m.Balance).ToList();
            foreach (var stack in stacks) {
                Console.WriteLine(stack == null ? "No Item Found!!!" : $"ID: {stack.Id} : {stack.Name} -Balance:{stack.Balance}");
            }
            */
            //  Sorting  using OrderBy (form max to min number)
            /*
            var stacks = _Context.Stacks.OrderByDescending(m => m.Balance).ToList();
            foreach (var stack in stacks)
            {
                Console.WriteLine(stack == null ? "No Item Found!!!" : $"ID: {stack.Id} : {stack.Name} -Balance:{stack.Balance}");
            }
            var stac = _Context.Stacks.OrderByDescending(m => m.Industry).ThenBy(b=>b.Balance).ToList();
            foreach (var stack in stacks)
            {
                Console.WriteLine( $" {stack.Industry} -Balance:{stack.Balance}");
            }
            */
            // ** Projection Using Select
            /*
            var stacks = _Context.Stacks.Select(m => new Blog{BlogId = m.Id ,Url = m.Name }).ToList();
            foreach (var stack in stacks)
            {
                Console.WriteLine( $"ID: {stack.BlogId} : {stack.Url} ");
            }
            var stac = _Context.Stacks.Select(m => new  { stackId = m.Id, stackName = m.Name }).ToList();
            foreach (var stack in stac)
            {
                Console.WriteLine($"ID: {stack.stackId} : {stack.stackName} ");
            }
            */
            // Select Unique Values Using .Distinct
            /*
            var blog = _Context.Blogs.Distinct().ToList();
            foreach (var stack in blog)
            {
                Console.WriteLine($"ID: {stack.BlogId} : {stack.Url} ");
            }
            var blogs = _Context.Blogs.Select(m=> new { m.Url , m.AddOn }).Distinct().ToList();
            foreach (var stack in blogs)
            {
                Console.WriteLine($"Name : {stack.Url} ");
            }
            var stacks = _Context.Stacks.Select(m => new { m.Industry}).Distinct().ToList();
            foreach (var stack in stacks)
            {
                Console.WriteLine($"Name : {stack.Industry} ");
            }
            */
            //*** Take Vs Skip 
            /*
            var stacks = _Context.Stacks.Skip(0).Take(100).ToList();
            foreach (var stack in stacks)
            {
                Console.WriteLine($" {stack.Id} ");
            }
            */
            /*
            var stacks = GetDate(1, 20);
            foreach (var stack in stacks)
            {
                Console.WriteLine($" {stack.Id} ");
            }
            */
            // Group By
            /*
            var stacks = _Context.Stacks
                .GroupBy(s => s.Industry)
                .Select(m => new { Industry = m.Key, Count = m.Count() })
                .OrderByDescending(m => m.Count);
                
                foreach(var stack in stacks ) 
                {
                    Console.WriteLine($"{stack.Industry} - {stack.Count}");
                }
              */
            /*
            var Industries = _Context.Stacks
                .GroupBy(s => s.Industry)
                .Select(m => new { Name = m.Key, StackCount = m.Count() , BalanceSum = m.Sum(m=>m.Balance) , BalanceAverage = m.Average(m=>m.Balance) })
                .OrderByDescending(m => m.StackCount);

            foreach (var Industry in Industries)
            {
                Console.WriteLine($"{Industry.Name} - {Industry.StackCount} - {Industry.BalanceSum} - {Industry.BalanceAverage}");
            }
            */
            // inner Join --- Using Jion
            /*
            var books = _Context.Books
                .Join(
                _Context.Authors,
                book => book.Id,
                author => author.Id,
                (book, author) => new
                {
                    BookId = book.Id,
                    BookName = book.BookName,
                    AuthorName = author.AuthorName,
                    AuthorNationalyID=author.Id
                }
                )
                .Join(
                _Context.Nationalities,
                book=>book.AuthorNationalyID,
                nationailty=>nationailty.Id,
                 (book, nationailty) => new
                 {
                      book.BookId,
                      book.BookName,
                      book.AuthorName,
                     AuthorNationaly = nationailty.Name
                 }
                );
            foreach(var book in books) { Console.WriteLine($"{book.BookId} - {book.BookName} - {book.AuthorName} - {book.AuthorNationaly}"); }
                */
            // Left Join 
            /*
            var books = _Context.Books
                .Join(
                _Context.Authors,
                book => book.Id,
                author => author.Id,
                (book, author) => new
                {
                    BookId = book.Id,
                    BookName = book.BookName,
                    AuthorName = author.AuthorName,
                    AuthorNationalyID = author.Id
                }
                )
                .GroupJoin(
                _Context.Nationalities,
                book => book.AuthorNationalyID,
                nationailty => nationailty.Id,
                 (book, nationailty) => new
                 {
                     Book = book,
                     Nationality = nationailty
                 }
                )
                .SelectMany(
                b=>b.Nationality.DefaultIfEmpty(),
                (b, n) => new {b.Book,Nationality=n}
                );
            foreach (var book in books) { Console.WriteLine($"{book.Book.BookId} - {book.Book.BookName} - {book.Book.AuthorName} - {book.Nationality.Name}"); }
            */
            // Tracking --- no Tracking
            /*
            var Book = _Context.Books.SingleOrDefault(b => b.Id == 1);
            Book.Price = 105;
            _Context.SaveChanges();
            */
            /*
            var Book = _Context.Books.AsNoTracking().SingleOrDefault(b=>b.Id == 1);
            Book.Price = 111;
            _Context.SaveChanges();
            */
            /*
            _Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var Book = _Context.Books.AsNoTracking().SingleOrDefault(b => b.Id == 1);
            Book.Price = 111;
            _Context.SaveChanges();
            */
            /*
            var Book = _Context.Books.AsNoTracking().SingleOrDefault(b => b.Id == 1);
            Book.Price = 112;
            var trackers = _Context.ChangeTracker.Entries();
            foreach(var tracker in trackers) { Console.WriteLine($"{tracker.Entity.ToString()} - {tracker.State}"); }
            */
            //Eager Loading
            /*
            var Book = _Context.Books
                .Include(b => b.Aouthors)
                .ThenInclude(a=>a.Nationality)
                .SingleOrDefault(b => b.Id == 2);
            Console.WriteLine(Book.Aouthors.Nationality.Name);
            */
            //Explicit Loading
            /*
            var Book = _Context.Books.SingleOrDefault(b => b.Id == 2);
            _Context.Entry(Book).Reference(b => b.Aouthors).Load();
            Console.WriteLine(Book.Aouthors.AuthorName);
            */
            /*
            var Blog = _Context.Blogs.SingleOrDefault(b => b.BlogId == 5);
            _Context.Entry(Blog)
            .Collection(b => b.Posts)
            .Load();
           foreach (var post in Blog.Posts)
            { 
                Console.WriteLine(post.Title); 
            }
            */
            /*
            var Blog = _Context.Blogs.SingleOrDefault(b => b.BlogId == 5);
            _Context.Entry(Blog)
            .Collection(b => b.Posts)
            .Query()
            .Where(p=>p.Id > 2)
            .ToList();
            
            foreach (var post in Blog.Posts)
            {
                Console.WriteLine(post.Title);
            }
            */
            /*
            var Blog = _Context.Blogs.SingleOrDefault(b => b.BlogId == 5);
            _Context.Entry(Blog)
            .Collection(b => b.Posts)
            .Query()
            .Count();

            foreach (var post in Blog.Posts)
            {
                Console.WriteLine(post.Title);
            }
            */
            //Lazy Loading
            /*
            var Book = _Context.Books
               .Single(b => b.Id == 2);
            Console.WriteLine(Book.Aouthors.AuthorName);
            */
            //Split Queries
            /*
            //var Book = _Context.Books.Include(b => b.Aouthors).AsSplitQuery().ToList();
           // var Book = _Context.Books.Include(b => b.Aouthors).AsSingleQuery().ToList();
            */
            //Join Using LINQ
            /*
            var books = (from b in _Context.Books
                         join a in _Context.Authors
                         on b.Id equals a.Id
                         join n in _Context.Nationalities
                         on a.NationalityId equals n.Id into 
                         authorNationality from an in authorNationality
                         .DefaultIfEmpty()
                         select new
                         {
                             BookId = b.Id,
                             BookName = b.BookName,
                             AuthorName = a.AuthorName
                         }).Count();
            Console.WriteLine(books);
            */
            //Select Data Using SQL Statement or Stored Procedure
            /*
            var books = _Context.Books.FromSqlRaw
                ("SELECT * FROM Books").ToList();
            foreach(var book in books) 
            {
                Console.WriteLine(book.BookName);
            }
            */
            /*
            var books = _Context.Books.FromSqlRaw
                ("prc_GetAllBooks").ToList();
            foreach(var book in books) 
            {
                Console.WriteLine(book.BookName);
            }
            */
            /*
             var bookId =1;
            var books = _Context.Books.FromSqlRaw
                ("prc_GetAllBookById {bookId} ").ToList();
            foreach(var book in books) 
            {
                Console.WriteLine(book.BookName);
            }
            */
            /*
            var bookId = new SqlParameter("Id",1);
            var books = _Context.Books.FromSqlRaw
                ("prc_GetAllBookById",bookId).ToList();
            foreach (var book in books)
            {
                Console.WriteLine(book.BookName);
            }
            */
            /*
            var books = _Context.BooksDtos.FromSqlRaw
                ("prc_GetAllBooksWithAuthors").ToList();
            foreach (var book in books)
            {
                Console.WriteLine(book.BookName);
            }
            */
            //Global Query Filters
            /*
            var posts = _Context.Posts.ToList();
                foreach(var post in posts)
            {
                Console.WriteLine(post.Title);
            }
            */
            /*
            var blogs = _Context.Blogs.IgnoreQueryFilters().ToList();
            foreach (var blog in blogs)
            {
                Console.WriteLine(blog.BlogId);
            }
            */

            // ----------- Save ADD Update Delete Data in  Database----------
            // Add one item 
            /*
            var Nat = new Nationality
            {
                Name = "Nataaaa 1"
            };
            _Context.Nationalities.Add(Nat);
            */
            // Add More Items
            /*
            var nationality = new List<Nationality>
            {
              new Nationality  { Name = "New Nationality2" },
              new Nationality  { Name = "New Nationality3" },
              new Nationality  { Name = "New Nationality4" },
              new Nationality  { Name = "New Nationality5" }
            };
            _Context.Nationalities.AddRange(nationality);
            */
            /*
            var athor = new Authors
            { 
                AuthorName = "New Author",
                Nationality = new Nationality {Name ="New Nationality 6" }
            };
            _Context.Authors.Add(athor);
            */
            /*
            var blogs = new Blog
            {
                Url ="www.google.com",
                Posts= new List<Post> 
                {
                     new Post {Content="Content1", Title="Title1"},
                     new Post {Content="Content2", Title="Title2"},
                     new Post {Content="Content3", Title="Title3"},
                     new Post {Content="Content4", Title="Title4"},
                     new Post {Content="Content5", Title="Title5"},
                }
            };
            _Context.Blogs.Add(blogs);
            */

            // Update data in database 
            /*
            var nationality = new Nationality 
            {
                Id= 11,Name="Alex"
            };
            _Context.Update(nationality);
            */
            /*
            var currentNationality = _Context.Nationalities.Find(10);
            var nationality = new Nationality
            {
                Id = 10,
                Name = "Cairo"
            };
            _Context.Entry(currentNationality).CurrentValues.SetValues(nationality);
            */
            /*
            var post = new Post
            {
                Id = 3,
                BlogId = 3,
                Content="Update Content",
            };
            _Context.Update(post);
            _Context.Entry(post).Property(e => e.BlogId).IsModified= false;
            _Context.Entry(post).Property(e => e.Title).IsModified = false;
            */
            /*
            var posts = _Context.Posts.Where(p => !p.IsDeleted).ToList();
            foreach(var post in posts) { post.IsDeleted = true; }
            _Context.UpdateRange(posts);
            
            */

            // Remove data in database 
            /*
            var nationality = _Context.Nationalities.Find(9);
            _Context.Nationalities.Remove(nationality);
            */
            /*
            var nationalitys = _Context.Nationalities
                .Where(p=>p.Id>= 6 && p.Id<=8).ToList();
            _Context.Nationalities.RemoveRange(nationalitys);
            */


            //Transactions
            /*
           using var transaction = _Context.Database.BeginTransaction();
            
            try
            {
                _Context.Blogs.Add(new Blog { Url = "www.google.com" });
                _Context.SaveChanges();

                transaction.CreateSavepoint("AddFirstBlog");

                _Context.Blogs.Add(new Blog { Url = "www.google.com" });
                _Context.SaveChanges();

                transaction.Commit();
            }
            catch(System.Exception )
            {
                transaction.RollbackToSavepoint("AddFirstBlog");
                transaction.Commit();
            }
            */


            //Save Data with Sql Statment and Stored Procedures ExecuteSqlRaw
            //_Context.Database.ExecuteSqlRaw("INSERT INTO Nationalities VALUES ('Test')");
            //_Context.Database.ExecuteSqlRaw("prc_AddNationality @Name='Test2'");
            var name = "Test3";
            _Context.Database.ExecuteSqlRaw($"prc_AddNationality @Name='{name}'");




            // _Context.SaveChanges();



            // Code Test One 
            /*
            //var DB_Context = new ApplicationDBContext();
            //var order = new OrderTest
            //{ 
            //    Amount= 100,
            //};
            */
            /*
            //var author = DB_Context.Authors.Find(1);
            //author.LastName = "Panda";
            //var author = new Author
            //{
            //    FirstName = "Ramy",
            //    LastName = "Elsayed"
            //};
            //DB_Context.OrdersTest.Add(order);
            // DB_Context.SaveChanges();
            */
            // Test Employee Class (Add)
            /*
            var employee = new Employee
            {
                Name = "Employee 1"
            };

            DB_Context.Employees.Add(employee);
            DB_Context.SaveChanges();

            */

        }
        /*
        public static List<Stack> GetDate(int pageNumber, int pageSize)
        {
            var _Context = new ApplicationDBContext();
            return _Context.Stacks.Skip((pageNumber-1)*pageSize).Take(pageSize).ToList();
        }
        */

        // SeedData
        /*
        public static void SeedData()
        {
            using(var Context = new ApplicationDBContext())
            {
                Context.Database.EnsureCreated();
                var blog = Context.Blogs.FirstOrDefault(b=>b.Url=="www.google.com");
                if(blog == null)
                {
                    Context.Blogs.Add(new Blog { Url = "www.google.com" });
                }
                Context.SaveChanges();
            }
        }
        */


    }
}