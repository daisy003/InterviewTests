using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduationTracker.Interface;

namespace GraduationTracker.StandingRuleLogic
{
    public class SumaCumLaudeRule : IStandingRule
    {
        public bool Passed { get { return true; } }

        public STANDING Rule { get { return STANDING.SumaCumLaude; } }

        public bool IsMatch(double average)
        {
            return average >= 95;
        }
    }
}
