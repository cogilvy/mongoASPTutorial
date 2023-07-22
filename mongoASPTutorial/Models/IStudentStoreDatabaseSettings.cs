namespace mongoASPTutorial.Models
{
    public interface IStudentStoreDatabaseSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString {  get; set; }
        string StudentCoursesCollectionName { get; set; }
    }
}
