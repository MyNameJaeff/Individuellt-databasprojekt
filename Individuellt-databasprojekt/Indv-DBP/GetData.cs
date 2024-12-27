using Indv_DBP.Data;
using Microsoft.EntityFrameworkCore;

namespace Indv_DBP
{
    internal class GetData
    {
        public void GetTeachersByDepartment()
        {
            using (var context = new SchoolContext())
            {
                // Get the count of teachers by department
                var teacherCountByDepartment = context.Teachers
                    .GroupBy(t => t.Department)
                    .Select(g => new
                    {
                        DepartmentName = g.Key,
                        TeacherCount = g.Count()
                    })
                    .ToList();

                // Display the results
                foreach (var department in teacherCountByDepartment)
                {
                    Console.WriteLine($"Department: {department.DepartmentName}, Teacher Count: {department.TeacherCount}");
                }
            }
        }

        public void GetStudentsInfo()
        {
            using (var context = new SchoolContext())
            {
                // Show info for all students
                var students = context.Students
                    .Include(s => s.Person)  // Assuming there is a Person entity for student details
                    .Include(s => s.Class)   // Assuming there is a Class entity for student class details
                    .ToList();

                // Display the results
                Console.WriteLine($"Totalt antal studenter: {students.Count()}");
                foreach (var student in students)
                {
                    Console.WriteLine($"Name: {student.Person.FirstName} {student.Person.LastName}, Klass: {student.Class.ClassName}");
                }
            }
        }

        public void GetActiveCourses()
        {
            using (var context = new SchoolContext())
            {
                // Get active courses
                var activeCourses = context.Courses
                    .Where(c => c.IsActive)
                    .ToList();
                // Display the results
                Console.WriteLine($"Active Courses:");
                foreach (var course in activeCourses)
                {
                    Console.WriteLine($"Course Name: {course.CourseName}");
                }
            }
        }
    }
}
