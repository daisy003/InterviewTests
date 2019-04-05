﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduationTracker.Data;
using GraduationTracker.Interface;
using GraduationTracker.StandingRuleLogic;

namespace GraduationTracker
{
    public class StudentStandingService : IStudentStandingService
    {
        private readonly List<IStandingRule> _standingRules;
        private readonly IRequirementRepository _requirementRepository;

        public StudentStandingService(): this(new RequirementRepository())
        { }
        public StudentStandingService(IRequirementRepository requirementRepository)
        {
            _standingRules = new List<IStandingRule>()
            {
                new RemedialRule(),
                new AverageRule(),
                new MagnaCumLaudeRule(),
                new SumaCumLaudeRule()
            };

            _requirementRepository = requirementRepository;

        }
        public Tuple<bool, STANDING> GetStudentStandingByAverage(double average)
        {
            Tuple<bool, STANDING> standing = new Tuple<bool, STANDING>(false, STANDING.None);

            IStandingRule rule = _standingRules.First(r => r.IsMatch(average));

            if (rule != null)
                standing = new Tuple<bool, STANDING>(rule.Passed, rule.Rule);

            return standing;
        }

        public void CalculateStudentGrade(Diploma diploma, Student student)
        {
            var credits = 0; //completed Credit
            double average = 0;
            var totalCredits = 0;

            if(!ValidateInput(diploma,student))
            {
                student.TotalAverage = 0;
                student.CompletedCredits = 0;
                return;
            }

            for (int i = 0; i < diploma.Requirements.Length; i++)
            {
                for (int j = 0; j < student.Courses.Length; j++)
                {
                    var requirement = _requirementRepository.GetRequirement(diploma.Requirements[i]);

                    if (requirement == null)
                        continue;

                    for (int k = 0; k < requirement.Courses.Length; k++)
                    {
                        if (requirement.Courses[k] == student.Courses[j].Id)
                        {
                            average += student.Courses[j].Mark * requirement.Credits;
                            totalCredits += requirement.Credits;
                            //corrected to consider credit  >= min mark
                            if (student.Courses[j].Mark >= requirement.MinimumMark)
                            {
                                credits += requirement.Credits;
                            }
                        }
                    }
                }
            }

            student.TotalAverage = Math.Round((average / totalCredits), 2);
            student.CompletedCredits = credits;
        }

        private bool ValidateInput(Diploma diploma, Student student)
        {
            if (diploma.Requirements.Length == 0)
                return false;

            if (diploma.Credits == 0)
                return false;

            if (student.Courses.Length == 0)
                return false;

            return true;
        }
    }
}
