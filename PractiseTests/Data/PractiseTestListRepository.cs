using PractiseTests.Data.Entities;
using System;
using System.Data;

namespace PractiseTests.Data
{
    public class PractiseTestListRepository : IPractiseTestListRepository
    {

        private readonly CertificationDbContext _context;
        private readonly ILogger<PractiseTestListRepository> _logger;

        public PractiseTestListRepository(CertificationDbContext context, ILogger<PractiseTestListRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<TestPaper> GetAll()
        {
            try
            {
                _logger.LogInformation("PractiseTestRepo - GetAll is called");
                return _context.TestPapers.ToList();
            }
            catch(Exception ex) 
            {
                _logger.LogError($"Failed to load the data from PractiseTestRepo - GetAll due to {ex}");
                return null;
            }
        }

        public List<String> GetPractiseTestList(int CertificateTestId, bool TestType)
        {
            var results = _context.TestPapers   //.GroupBy(m => new { m.TestPaperName })
                .Where(p => p.CertificationTestId == CertificateTestId && p.Active == TestType) 
                .ToList();

            //.Select(e => new { e.TestPaperName })  //.DistinctBy(s=> new {s.TestPaperName})
            //DataTable dt = new DataTable();
            //dt.Columns.Add("TestPaperName", typeof(string));

            List<String> TestPapersList = new List<String>();
            foreach (var row in results)
            {
                TestPapersList.Add(row.TestPaperName);
                //dt.Rows.Add(row.TestPaperName);
            }
            TestPapersList.Distinct();
            return TestPapersList; //.DistinctBy(m=>m.TestPaperName).ToList();
        }

        public IEnumerable<TestPaper> GetTestPaper(int CertificateTestId, bool TestType , string TestPaper)
        {
            
             return _context.TestPapers.Where(p => p.CertificationTestId == CertificateTestId && p.Active == TestType && p.TestPaperName==TestPaper)
                .ToList();
    }


        public bool SaveAll()
        {
            // save teh marks to the user profile

            return _context.SaveChanges() > 0;

        }
    }
}
