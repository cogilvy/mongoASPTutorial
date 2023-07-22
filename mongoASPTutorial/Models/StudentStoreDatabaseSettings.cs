namespace mongoASPTutorial.Models
{
    public class StudentStoreDatabaseSettings : IStudentStoreDatabaseSettings
    {
        public string DatabaseName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string StudentCoursesCollectionName { get; set; } = String.Empty;
    }
}
