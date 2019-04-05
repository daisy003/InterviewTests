using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduationTracker.Interface;

namespace GraduationTracker.StandingRuleLogic
{
    public class RemedialRule : IStandingRule
    {
        public bool Passed { get { return false; } }

        public STANDING Rule { get { return STANDING.Remedial; } }

        public bool IsMatch(double average)
        {
            return average < 50;
        }
    }
}
