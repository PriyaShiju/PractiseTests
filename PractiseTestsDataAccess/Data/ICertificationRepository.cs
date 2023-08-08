using PractiseTests.Data.Entities;

namespace PractiseTests.Data
{
    public interface ICertificationRepository
    {
        IEnumerable<Certifications> GetAll();
        IEnumerable<Certifications> GetCertificationByName();
        Certifications GetCertificationTestById(int id);
    }
}