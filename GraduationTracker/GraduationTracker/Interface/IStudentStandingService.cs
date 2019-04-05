using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Interface
{
    public interface IStudentStandingService
    {
        Tuple<bool, STANDING> GetStudentStandingByAverage(double average);

        void CalculateStudentGrade(Diploma diploma, Student student);
    }
}
