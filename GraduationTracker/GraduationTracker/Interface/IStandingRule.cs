﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Interface
{
    public interface IStandingRule
    {
        bool Passed { get; }

        STANDING Rule { get; }

        bool IsMatch(double average);
    }
}
