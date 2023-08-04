using PractiseTests.Data.Entities;

namespace PractiseTests.Data
{
    public interface IPractiseTestListRepository
    {
        IEnumerable<TestPaper> GetAll();

        List<String> GetPractiseTestList(int CertificateTestId, bool TestType);
        IEnumerable<TestPaper> GetTestPaper(int CertificateTestId, bool TestType, string TestPaper);
        bool SaveAll();
    }
}