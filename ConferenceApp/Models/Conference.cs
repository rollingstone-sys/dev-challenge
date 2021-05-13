using System.Collections.Generic;

namespace ConferenceApp.Models
{
    public class Conference
    {
        public List<Track> Tracks { get; set; }

        public Conference()
        {
            this.Tracks = new List<Track>();
        }
    }
}
