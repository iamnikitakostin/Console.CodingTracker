using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal enum MenuOption
    {
        ViewSessions,
        CurrentCodingSession,
        ViewGoals,
        AddGoal,
        DeleteRecord,
        DeleteGoal,
        EditSession,
        GenerateReport,
        Quit
    }

    internal enum CurrentCodingSessionChoice
    {
        StartSession,
        EndSession,
        EditSession,
        GoBack
    }

    internal enum EditSessionChoice
    {
        StartTime,
        EndTime,
        GoBack
    }
}
