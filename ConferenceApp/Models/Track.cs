using System.Collections.Generic;

namespace ConferenceApp.Models
{
    public class Track
    {
        public List<Talk> MorningTalks { get; set; }
        public List<Talk> AfternoonTalks { get; set; }
        public int AfterNoonDurationLeft { get; set; }
        public int MorningDurationLeft { get; set; }

        public Track(int MorningDurationLeft, int AfterNoonDurationLeft)
        {
            this.MorningDurationLeft = MorningDurationLeft;
            this.AfterNoonDurationLeft = AfterNoonDurationLeft;
            this.MorningTalks = new List<Talk>();
            this.AfternoonTalks = new List<Talk>();
        }
    }

    public static class TrackConstants
    {
        public const int WorstCaseDuration = 420;
        public const int BestCaseDuration = 360;

    }
}
