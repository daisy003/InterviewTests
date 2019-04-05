using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduationTracker.Interface;

namespace GraduationTracker.Data
{
    public class DiplomaRepository : IDiplomaRepository
    {
        public Diploma GetDiploma(int id)
        {
            var diplomas = GetDiplomas();
            Diploma diploma = null;

            for (int i = 0; i < diplomas.Length; i++)
            {
                if (id == diplomas[i].Id)
                {
                    diploma = diplomas[i];
                }
            }
            return diploma;

        }

        private static Diploma[] GetDiplomas()
        {
            return new[]
            {
                new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = new int[]{100,102,103,104}
                }
            };
        }
    }
}
