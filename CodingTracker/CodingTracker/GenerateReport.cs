using CodingTracker.Data;
using CodingTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class GenerateReport
    {
        static internal void ByWeeks()
        {
            DbConnection.GetSessionsByPeriod("week");
        }

        static internal void ByMonths()
        {
            DbConnection.GetSessionsByPeriod("month");
        }

        static internal void ByYears() {
            DbConnection.GetSessionsByPeriod("year");

            Console.ReadKey();
        }
    }
}
