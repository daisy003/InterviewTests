using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduationTracker.Interface;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {
        private readonly IStudentStandingService _studentStandingService;

        public GraduationTracker() : this(new StudentStandingService())
        { }
        public GraduationTracker(IStudentStandingService studentStandingService)
        {
           // _studentStandingCalculator = studentStandingCalculator;
            _studentStandingService = studentStandingService;
        }


        public Tuple<bool, STANDING>  HasGraduated(Diploma diploma, Student student)
        {
            if(diploma == null || student == null)
                return new Tuple<bool, STANDING>(false, STANDING.None);

            #region Separate Method To get average and completed credit

            /*
            var credits = 0;
            var average = 0;
        
            for(int i = 0; i < diploma.Requirements.Length; i++)
            {
                for(int j = 0; j < student.Courses.Length; j++)
                {
                    var requirement = Repository.GetRequirement(diploma.Requirements[i]);

                    for (int k = 0; k < requirement.Courses.Length; k++)
                    {
                        if (requirement.Courses[k] == student.Courses[j].Id)
                        {
                            average += student.Courses[j].Mark;
                            if (student.Courses[j].Mark > requirement.MinimumMark)
                            {
                                credits += requirement.Credits;
                            }
                        }
                    }
                }
            }

            average = average / student.Courses.Length;
            */


            #endregion

            _studentStandingService.CalculateStudentGrade(diploma, student);

            #region Separate Method to determine student standing
            /*
            var standing = STANDING.None;

            if (average < 50)
                standing = STANDING.Remedial;
            else if (average < 80)
                standing = STANDING.Average;
            else if (average < 95)
                standing = STANDING.MagnaCumLaude;
            else
                standing = STANDING.MagnaCumLaude;

            switch (standing)
            {
                case STANDING.Remedial:
                    return new Tuple<bool, STANDING>(false, standing);
                case STANDING.Average:
                    return new Tuple<bool, STANDING>(true, standing);
                case STANDING.SumaCumLaude:
                    return new Tuple<bool, STANDING>(true, standing);
                case STANDING.MagnaCumLaude:
                    return new Tuple<bool, STANDING>(true, standing);

                default:
                    return new Tuple<bool, STANDING>(false, standing);
            }
            */
            #endregion

            Tuple<bool, STANDING> standing = new Tuple<bool, STANDING>(false, STANDING.None);
            standing = _studentStandingService.GetStudentStandingByAverage(student.TotalAverage);

            //Assumption: if completed credits is not equal to required diploma credit
            //student will not graduate
            if (student.CompletedCredits < diploma.Credits)
                standing = new Tuple<bool, STANDING>(false, standing.Item2);

            return standing;
        }
    }
}
