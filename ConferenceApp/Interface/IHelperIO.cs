using ConferenceApp.Models;
using System.Collections.Generic;

namespace ConferenceApp.Interface
{
    interface IHelperIO
    {
        List<Talk> GetInputTalks();
        void PrintSchedule(List<Track> Tracks);
    }
}
