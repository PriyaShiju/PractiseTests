using System.ComponentModel.DataAnnotations;

namespace PractiseTests.Data.Entities
{
    public class Career 
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string ResumeUpload { get; set; }

        public string DocUpload { get; set; }

        //private readonly IStorageService _storageService;

        //public void FileUpload()
        //{
        //    _storageService.Upload(ResumeUpload);
        //}

    }
}
