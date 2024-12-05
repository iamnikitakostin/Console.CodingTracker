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
