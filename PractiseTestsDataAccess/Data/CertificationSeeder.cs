using PractiseTests.Data.Entities;
using PractiseTests.Data;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace PractiseTests.Data
{
    public class CertificationSeeder
    {
        private readonly CertificationDbContext _context;
        private readonly IWebHostEnvironment _env;
        public CertificationSeeder(CertificationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();
            if (!_context.Certifications.Any())
            {
                var filepath = Path.Combine(_env.ContentRootPath, "Data/testpapers.json");
                var jsonfile = File.ReadAllText(filepath);
                var testpapers = JsonSerializer.Deserialize<IEnumerable<Certifications>>(jsonfile);
                _context.Certifications.AddRange(testpapers);


                var certificatesTest = new Certifications()
                {
                    CertificationName = "DevOps Leader",
                    CertificationDescription = "DevOps Advanced Level",
                    Price = 20,
                    NoTestPapers = 3,
                    Questions = 30,
                    FileName = "DevopsLeader"
                    //TestPapers = new List<TestPaper>() { new TestPaper() { Testpaper} }
                };

                _context.SaveChanges();

                //var
            }
        }
    }
}
