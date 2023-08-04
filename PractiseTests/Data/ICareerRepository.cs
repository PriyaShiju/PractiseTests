namespace PractiseTests.Data
{
    public interface ICareerRepository
    {
        string DocUpload { get; set; }
        string EmailAddress { get; set; }
        string Name { get; set; }
        string ResumeUpload { get; set; }


        //void FileUpload();
    }
}