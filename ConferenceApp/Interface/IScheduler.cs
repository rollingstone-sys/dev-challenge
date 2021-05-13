using ConferenceApp.Models;
using System.Collections.Generic;

namespace ConferenceApp.Interface
{
    interface IScheduler
    {
        List<Track> ScheduleTracks(List<Talk> talks);
    }
}
