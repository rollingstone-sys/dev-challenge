
namespace ConferenceApp.Models
{
    public class Talk
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public string DurationType { get; set; }

        public Talk(string Name, int Duration, string DurationType)
        {
            this.Name = Name;
            this.Duration = Duration;
            this.DurationType = DurationType;
        }

    }

    public class Slot
    {
        public int TrackNumber { get; set; }
        public string TrackSession { get; set; }
        public int Time { get; set; }
    }
}
