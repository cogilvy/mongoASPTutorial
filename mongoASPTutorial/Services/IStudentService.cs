using mongoASPTutorial.Models;

namespace mongoASPTutorial.Services
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Student GetStudent(string id);
        Student Create(Student student);
        void Update(string id,Student student);
        void Delete(string id);
    }
}
