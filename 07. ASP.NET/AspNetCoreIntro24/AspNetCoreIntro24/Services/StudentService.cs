using AspNetCoreIntro24.Contracts;
using AspNetCoreIntro24.Models;

namespace AspNetCoreIntro24.Services;

public class StudentService : IStudentService
{
    public Student GetStudent(int id)
    {
        return Database.GetStudent(id);
    }

    public bool UpdateStudent(Student student)
    {
        return Database.UpdateStudent(student);
    }
}