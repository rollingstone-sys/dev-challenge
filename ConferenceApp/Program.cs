using Microsoft.Extensions.DependencyInjection;
using ConferenceApp.Implementation;
using ConferenceApp.Interface;
using ConferenceApp.Models;
using System;
using System.Collections.Generic;

namespace ConferenceApp
{
    class Program
    {

        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            RegisterServices();
            
            var serviceIO = _serviceProvider.GetService<IHelperIO>();
            var conferenceService = _serviceProvider.GetService<IScheduler>();
            
            List<Talk> talks = serviceIO.GetInputTalks();
            List<Track> tracks = conferenceService.ScheduleTracks(talks);
            serviceIO.PrintSchedule(tracks);

            DisposeServices();
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IHelperIO, HelperIO>();
            collection.AddScoped<IScheduler, Scheduler>();
            _serviceProvider = collection.BuildServiceProvider();
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
