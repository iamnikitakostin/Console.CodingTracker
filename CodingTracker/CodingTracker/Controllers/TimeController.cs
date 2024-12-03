using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker.Controllers
{
    internal class TimeController
    {
        static internal string ConvertFromSeconds(int seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            string answer = time.ToString(@"hh\:mm\:ss");
            return answer;
        }
    }
}
