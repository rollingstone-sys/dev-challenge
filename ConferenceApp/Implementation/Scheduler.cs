using ConferenceApp.Interface;
using ConferenceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConferenceApp.Implementation
{
    class Scheduler: IScheduler
    {

        public List<Track> ScheduleTracks(List<Talk> talks)
        {
            Conference c = new Conference();
            int totalDuration = talks.Sum(x => x.Duration);
            int totalTracks = (int)Math.Ceiling((double)totalDuration / TrackConstants.WorstCaseDuration);
            int requiredAfterNoonSessions = (int)Math.Ceiling((double)totalDuration / TrackConstants.BestCaseDuration) - totalTracks;

            for (int i = 0; i < totalTracks; i++)
            {
                c.Tracks.Add(new Track(180, requiredAfterNoonSessions > 0 ? 240 : 180));
                requiredAfterNoonSessions--;
            }

            talks = talks.OrderByDescending(x => x.Duration).ToList();

            foreach (var talk in talks)
            {
                Slot bestSlot = GetBestSlotForJob(c.Tracks);
                if (bestSlot.Time >= talk.Duration)
                {
                    if (bestSlot.TrackSession == "M")
                    {
                        c.Tracks[bestSlot.TrackNumber].MorningTalks.Add(talk);
                        c.Tracks[bestSlot.TrackNumber].MorningDurationLeft -= talk.Duration;
                    }
                    else if (bestSlot.TrackSession == "A")
                    {
                        c.Tracks[bestSlot.TrackNumber].AfternoonTalks.Add(talk);
                        c.Tracks[bestSlot.TrackNumber].AfterNoonDurationLeft -= talk.Duration;
                    }
                }
            }

            return c.Tracks;

        }

        private Slot GetBestSlotForJob(List<Track> Tracks)
        {
            Slot s = new Slot();
            int maxTime = 0;
            for (int i = 0; i < Tracks.Count; i++)
            {
                if (Tracks[i].MorningDurationLeft > 0 && Tracks[i].MorningDurationLeft > maxTime)
                {
                    s.TrackNumber = i;
                    s.TrackSession = "M";
                    maxTime = Tracks[i].MorningDurationLeft;
                }
                if (Tracks[i].AfterNoonDurationLeft > 0 && Tracks[i].AfterNoonDurationLeft > maxTime)
                {
                    s.TrackNumber = i;
                    s.TrackSession = "A";
                    maxTime = Tracks[i].AfterNoonDurationLeft;
                }
            }
            s.Time = maxTime;
            return s;
        }
    }
}
