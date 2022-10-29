using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class Parkinglot
    {
        public IList<string> Ticket { get; set; }

        public bool Remove(Car car)
        {
            throw new NotImplementedException();
        }

        public bool Add(Car car)
        {
            throw new NotImplementedException();
        }
    }
}

public class CourseClass
{
    public string ClassName { get; }
    private Teacher classTeacher;
    private IList<Student> classStudents;

    public CourseClass(string className)
    {
        ClassName = className;
        classStudents = new List<Student>();
    }

    public bool AddTeacher(Teacher teacher)
    {
        if (classTeacher != null)
        {
            return false;
        }

        classTeacher = teacher;
        teacher.CourseClass = this;
        return true;
    }

    public ClassWelcome AddStudent(Student student)
    {
        if (classStudents.Any(_ => _.Id == student.Id))
        {
            return new ClassWelcome();
        }

        student.CourseClass = this;
        var welcome = new ClassWelcome
        {
            TeacherWelcome = classTeacher?.Welcome(student) ?? string.Empty,
            StudentsWelcome = classStudents.Select(classStudent => classStudent.Welcome(student)).ToList(),
        };
        classStudents.Add(student);
        return welcome;
    }
}
