using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduationTracker.Interface;

namespace GraduationTracker.StandingRuleLogic
{
    public class MagnaCumLaudeRule : IStandingRule
    {
        public bool Passed { get { return true; } }

        public STANDING Rule { get { return STANDING.MagnaCumLaude; } }

        public bool IsMatch(double average)
        {
            //additional condition so order is not mandatory
            return average < 95 && average >= 80;
        }
    }
}
