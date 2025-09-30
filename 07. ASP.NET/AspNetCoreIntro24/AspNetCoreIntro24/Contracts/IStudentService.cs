using AspNetCoreIntro24.Models;

namespace AspNetCoreIntro24.Contracts;

public interface IStudentService
{
    Student GetStudent(int id);
    bool UpdateStudent(Student student);
}