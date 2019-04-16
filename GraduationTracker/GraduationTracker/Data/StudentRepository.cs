using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduationTracker.Interface;

namespace GraduationTracker.Data
{
    public class StudentRepository : IStudentRepository
    {
        public Student GetStudent(int id)
        {

            var students = GetStudents();
            Student student = null;

            for (int i = 0; i < students.Length; i++)
            {
                if (id == students[i].Id)
                {
                    student = students[i];
                }
            }
            return student;

        }

        public Student[] GetAllStudents()
        {
            return GetStudents();
        }

        private static Student[] GetStudents()
        {
            return new[]
            {
               new Student
               {
                   Id = 1,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark= 84 },
                        new Course{Id = 3, Name = "Literature", Mark= 75 },
                        new Course{Id = 4, Name = "Physichal Education", Mark= 20 }
                   }
               },
               new Student
               {
                   Id = 2,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark= 80 },
                        new Course{Id = 2, Name = "Science", Mark= 60 },
                        new Course{Id = 3, Name = "Literature", Mark= 90 },
                        new Course{Id = 4, Name = "Physichal Education", Mark= 50 }
                   }
               },
            new Student
            {
                Id = 3,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark= 70 },
                    new Course{Id = 2, Name = "Science", Mark= 90 },
                    new Course{Id = 3, Name = "Literature", Mark= 20 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=60 }
                }
            },
            new Student
            {
                Id = 4,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark= 50 },
                    new Course{Id = 2, Name = "Science", Mark=30 },
                    new Course{Id = 3, Name = "Literature", Mark=20 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=10 }
                }
            }

            };
        }
    }
}
