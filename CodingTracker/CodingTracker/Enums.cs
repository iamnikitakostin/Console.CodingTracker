using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReviews.Console.CodingTracker
{
    internal enum MenuOption
    {
        ViewSessions,
        CurrentCodingSession,
        DeleteRecord,
        GenerateReport
    }

    internal enum CurrentCodingSessionChoice { 
        StartCurrentSession,
        EndCurrentSession,
        EditCurrentSessionTime
    }
}
