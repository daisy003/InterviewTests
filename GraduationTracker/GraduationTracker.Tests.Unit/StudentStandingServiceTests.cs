using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class StudentStandingServiceTests
    {
        private StudentStandingService standingService;

        [TestInitialize]
        public void Init()
        {
            //depends on Poor man's DI
            standingService = new StudentStandingService();
        }

        [TestMethod]
        public void TestStudentStandingByAverage()
        {
            Assert.AreEqual(STANDING.Remedial,standingService.GetStudentStandingByAverage(49.6).Item2);
            Assert.AreEqual(STANDING.Remedial, standingService.GetStudentStandingByAverage(0).Item2);
            Assert.AreEqual(STANDING.Average, standingService.GetStudentStandingByAverage(50.1).Item2);
            Assert.AreEqual(STANDING.MagnaCumLaude, standingService.GetStudentStandingByAverage(94).Item2);
            Assert.AreEqual(STANDING.SumaCumLaude, standingService.GetStudentStandingByAverage(96).Item2);
        }

        public void TestCalculateStudentAverageCredits()
        {
            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            var student = new Student
            {
                Id = 1,
                Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                   }

            };

            //expected
            var average = 95;
            var credit = 4;

            standingService.CalculateStudentGrade(diploma, student);

            Assert.AreEqual(student.TotalAverage, average);
            Assert.AreEqual(student.CompletedCredits, credit);


        }

        [TestMethod]
        public void TestCalculateStudentAverageOneFailingMark()
        {
            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            var student = new Student
            {
                Id = 1,
                Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=40 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                   }

            };

            //expected
            var average = 81.25;
            var credit = 3;

            standingService.CalculateStudentGrade(diploma, student);

            Assert.AreEqual(student.TotalAverage, average);
            Assert.AreEqual(student.CompletedCredits, credit);


        }

        [TestMethod]
        public void TestCalculateStudentAverageCreditsEmptyDimplomaRequirement()
        {
            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { }
            };

            var student = new Student
            {
                Id = 1,
                Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=40 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                   }

            };

            //expected
            var average = 0;
            var credit = 0;

            standingService.CalculateStudentGrade(diploma, student);

            Assert.AreEqual(student.TotalAverage, average);
            Assert.AreEqual(student.CompletedCredits, credit);

        }

        [TestMethod]
        public void TestCalculateStudentAverageIncompleteCourse()
        {
            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            var student = new Student
            {
                Id = 1,
                Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                   }

            };

            //expected
            var average = 95;
            var credit = 3;

            standingService.CalculateStudentGrade(diploma, student);

            Assert.AreEqual(student.TotalAverage, average);
            Assert.AreEqual(student.CompletedCredits, credit);

        }

        [TestMethod]
        public void TestCalculateStudentCreditCourseNotInDiploma()
        {
            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 105 }
            };

            var student = new Student
            {
                Id = 1,
                Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=40 },
                   }

            };

            var average = 76.67;
            var credit = 2;

            standingService.CalculateStudentGrade(diploma, student);
            Assert.AreEqual(student.TotalAverage, average);
            Assert.AreEqual(student.CompletedCredits, credit);
        }



    }
}
