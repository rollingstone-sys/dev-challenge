using ConferenceApp.Interface;
using ConferenceApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConferenceApp.Implementation
{
    class HelperIO : IHelperIO
    {
        public List<Talk> GetInputTalks()
        {
            List<Talk> talks = new List<Talk>();
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Input\\conference_input.txt";
            foreach (string input in File.ReadLines(path, Encoding.UTF8))
            {
                string[] words = input.Split('-');
                words[^1] = Regex.Replace(words[^1], @"\s+", "");
                string test = words[^1].ToLower().Contains("lightning")? "5" : words[^1].ToLower().Replace("min", "");
                talks.Add(new Talk(string.Join(" ", words.Take(words.Length - 1)), Int32.Parse(test), words[^1]));
            }
            return talks;
        }

        public void PrintSchedule(List<Track> Tracks)
        {
            int time;
            for (int i = 0; i < Tracks.Count; i++)
            {
                time = 540;
                Console.WriteLine("\nTrack {0}:", i+1);
                foreach (var talk in Tracks[i].MorningTalks)
                {
                    Console.WriteLine(GetStartTime(time) + " " + talk.Name + talk.DurationType);
                    time += talk.Duration;
                }
                Console.WriteLine("12:00 PM Lunch");
                time = 780;
                foreach (var talk in Tracks[i].AfternoonTalks)
                {
                    Console.WriteLine(GetStartTime(time) + " " + talk.Name + talk.DurationType);
                    time += talk.Duration;
                }
                if (time < 960)
                    time = 960;
                Console.WriteLine(GetStartTime(time) + " Networking Event");

            }
        }

        private string GetStartTime(int minutes)
        {
            string time, format;
            int hours, min;
            if (minutes < 720)
                format = "AM";
            else
            {
                minutes %= 720;
                format = "PM";
            }
            hours = (int)Math.Floor((double)minutes / 60);
            min = minutes % 60;
            time = hours.ToString("00") + ":" + min.ToString("00") + " " + format;
            return time;
        }
    }
}
