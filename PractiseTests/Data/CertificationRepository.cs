using PractiseTests.Data;
using PractiseTests.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace PractiseTests.Data
{

    public class CertificationRepository : ICertificationRepository
    {
        private readonly CertificationDbContext _context;
        

        public CertificationRepository(CertificationDbContext context)
        {
            _context = context;
            
        }

        public IEnumerable<Certifications> GetAll()
        {
            return _context.Certifications.ToList();
            // Install MVC newton json and services.AddNewtonJson(cfg => cfg.serializersettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            //return _context.Certifications.Include(o=> o.Items).thenInclude(p=> p.Product).ToList(); 
        }
        public Certifications GetCertificationTestById(int Id)
        {
            return _context.Certifications
                .Where(o=> o.CertificationTestId == Id)
                .FirstOrDefault();
            
            // Install MVC newton json and services.AddNewtonJson(cfg => cfg.serializersettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            //return _context.Certifications.Include(o=> o.Items).thenInclude(p=> p.Product).ToList(); 
        }

        public IEnumerable<Certifications> GetCertificationByName()
        {
            return _context.Certifications
                .Where(p => p.CertificationName == "DevOps")
                .ToList();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;

        }
    }
}
