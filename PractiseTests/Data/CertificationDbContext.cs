using PractiseTests.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Emit;
using System.Text.Json;

namespace PractiseTests.Data
{
    public class CertificationDbContext : DbContext
    {
        public DbSet<Certifications> Certifications { get; set; }
        public DbSet<TestPaper> TestPaper { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Contact> Contact { get; set; }

        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }


        private readonly IConfiguration _config;
        public CertificationDbContext(IConfiguration config)
        {
            _config = config;

            //this._config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config.GetConnectionString("AppDbContext"));
            optionsBuilder.EnableSensitiveDataLogging();
            //_config.GetConnectionString(["ConnectionString:AppDbContext"]);
            //string strConnection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=CertificateTest;Integrated Security=True;Connect Timeout=30;Multipleactiveresultsets=true;";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Seed(modelBuilder);
        }

        public static void Seed(ModelBuilder modelBuilder)
        {
            var prodcategory = new ProductCategory() { ProdCategoryId = 1, CategoryCode = "C",  CategoryName = "Certification"};
            modelBuilder.Entity<ProductCategory>().HasData(prodcategory);

            var product = new Product() { ProductId = 1, CategoryCode = "C", Name = "DevOps Foundation" , Description= "DevOps Foundation", Price=20};
            var product2 = new Product() { ProductId = 2, CategoryCode = "C", Name = "DevOps Leader", Description = "DevOps Leader", Price = 25};
            var product3 = new Product() { ProductId = 3, CategoryCode = "C", Name = "DevSecOps Foundation", Description = "DevOps Foundation", Price = 20 };
            var product4 = new Product() { ProductId = 4, CategoryCode = "C", Name = "DevSecOps Practioner", Description = "DevOps Leader", Price = 25 };
            modelBuilder.Entity<Product>().HasData(product,product2,product3,product4);

            var orderitem = new OrderItem() { OrderItemId = 1, CategoryCode = "C", ProductId = 1, Quantity = 2,OrderId=1 };
            var orderitem2 = new OrderItem() { OrderItemId = 2, CategoryCode = "C", ProductId = 2, Quantity = 2, OrderId = 1 };

            var order = new Order()
            {
                OrderId = 1,
                OrderNo = "C001",
                OrderDate = Convert.ToDateTime("01/03/2023"),
                //Items = new List<OrderItem>() { orderitem, orderitem2 }

            };

            modelBuilder.Entity<Order>().HasData(order);
            modelBuilder.Entity<OrderItem>().HasData(orderitem, orderitem2);
            //ICollection<OrderItem> orders = new List<OrderItem>() { orderitem,orderitem2 };

           

            //var orderitem = new OrderItem() { CategoryCode = "C", CategoryName = "Certification" };
            //modelBuilder.Entity<ProductCategory>().HasData(prodcategory);


            var Certification2 = new Certifications()
            {
                CertificationTestId = 2,
                CertificationName = "DevOps Foundation",
                CertificationDescription = "DevOps Foundation",
                Price = 20,
                NoTestPapers = 6,
                Questions = 30,
                FileName = "devopsfoundation.png",
                Active=true
            };

            var Certification3 = new Certifications()
            {
                CertificationTestId = 3,
                CertificationName = "DevOps Leader",
                CertificationDescription = "DevOps Leader",
                Price = 25,
                NoTestPapers = 6,
                Questions = 30,
                FileName = "DevOpsLeader.png",
                Active = true
            };

            var Certification4 = new Certifications()
            {
                CertificationTestId = 4,
                CertificationName = "DevSecOps Foundation",
                CertificationDescription = "DevSecOps Foundation",
                Price = 20,
                NoTestPapers = 6,
                Questions = 30,
                FileName = "DevSecOps.png",
                Active = true
            };
            var Certification5 = new Certifications()
            {
                CertificationTestId = 5,
                CertificationName = "DevSecOps Practioner",
                CertificationDescription = "DevSecOps Practioner",
                Price = 25,
                NoTestPapers = 6,
                Questions = 30,
                FileName = "devsecopspract.png",
                Active = true
            };
            modelBuilder.Entity<Certifications>().HasData(Certification2, Certification3, Certification4, Certification5);
            
            var TestPaper1 = new TestPaper()
            {
                TestPaperId = 2,
                TestPaperName = "TestPaper-1",
                CertificationTestId = 2,
                QuestionNo = 1,
                Question = "What is the Three Ways?",
                Answer1 = "A. Methodology for identifying and removing constraints",
                Answer2 = "B. The key principles of DevOps",
                Answer3 = "C. Disciplined, data-driven approach for reducing waste ",
                Answer4 = "D. A methodology for performing continuous improvement ",
                CorrectAnswer = "B",
                 Active = false//false is free practise test
            };
            var TestPaper2 = new TestPaper()
            {
                TestPaperId = 3,
                TestPaperName = "TestPaper-1",
                CertificationTestId = 2,
                QuestionNo = 2,
                Question = "Which statement about Kanban is CORRECT?",
                Answer1 = "A. Pushes work through a process ",
                Answer2 = "B. Requires a workflow management tool ",
                Answer3 = "C. Pulls work through a process ",
                Answer4 = "D. Enables more work in progress ",
                CorrectAnswer = "C",
                Active = false//false is free practise test
            };
            var TestPaper3 = new TestPaper()
            {
                TestPaperId = 4,
                TestPaperName = "TestPaper-2",
                CertificationTestId = 2,
                QuestionNo = 1,
                Question = "Which statement BEST describes change fatigue? ",
                Answer1 = "A. Aggressive resistance",
                Answer2 = "B. Apathy ",
                Answer3 = "C. Finger pointing ",
                Answer4 = "D. Exhaustion ",
                CorrectAnswer = "B",
                Active = false//false is free practise test
            };
            var TestPaper4 = new TestPaper()
            {
                TestPaperId = 5,
                TestPaperName = "TestPaper-1",
                CertificationTestId = 2,
                QuestionNo = 1,
                Question = "Which of the following roles are DevOps stakeholders? ",
                Answer1 = "A. QA testers ",
                Answer2 = "B. Support professionals ",
                Answer3 = "C. Suppliers ",
                Answer4 = "D. All of the above ",
                CorrectAnswer = "D",
                Active=true
            };
            var TestPaper5 = new TestPaper()
            {
                TestPaperId = 6,
                TestPaperName = "TestPaper-1",
                CertificationTestId = 3,
                QuestionNo = 1,
                Question = "Which of the following roles are DevOps stakeholders? ",
                Answer1 = "A. QA testers ",
                Answer2 = "B. Support professionals ",
                Answer3 = "C. Suppliers ",
                Answer4 = "D. All of the above ",
                CorrectAnswer = "D",
                Active = false//false is free practise test
            };
            var TestPaper6 = new TestPaper()
            {
                TestPaperId = 7,
                TestPaperName = "TestPaper-1",
                CertificationTestId = 3,
                QuestionNo = 1,
                Question = "Which of the following roles are DevOps stakeholders? ",
                Answer1 = "A. QA testers ",
                Answer2 = "B. Support professionals ",
                Answer3 = "C. Suppliers ",
                Answer4 = "D. All of the above ",
                CorrectAnswer = "D",
                Active = true
            };
            var TestPaper7 = new TestPaper()
            {
                TestPaperId = 8,
                TestPaperName = "TestPaper-2",
                CertificationTestId = 3,
                QuestionNo = 1,
                Question = "Which of the following roles are DevOps stakeholders? ",
                Answer1 = "A. QA testers ",
                Answer2 = "B. Support professionals ",
                Answer3 = "C. Suppliers ",
                Answer4 = "D. All of the above ",
                CorrectAnswer = "D",
                Active = true
            };
            modelBuilder.Entity<TestPaper>().HasData(TestPaper1, TestPaper2, TestPaper3, TestPaper4,TestPaper5,TestPaper6,TestPaper7);

            /*var filepath = Path.Combine(_env.ContentRootPath, "Data/testpapers.json");
            var jsonfile = File.ReadAllText(filepath);
            var testpapers = JsonSerializer.Deserialize<IEnumerable<Certifications>>(jsonfile);
            _context.Certifications.AddRange(testpapers);*/
        }
    }
}
