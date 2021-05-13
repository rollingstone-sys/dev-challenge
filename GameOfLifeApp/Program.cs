using Microsoft.Extensions.DependencyInjection;
using GameOfLifeApp.Implementation;
using GameOfLifeApp.Interface;
using GameOfLifeApp.Models;
using System;

namespace GameOfLifeApp
{
    class Program
    {

        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            RegisterServices();

            var ioHelperService = _serviceProvider.GetService<IHelperIO>();
            var gridHelperService = _serviceProvider.GetService<IGridHelper>();

            Grid gObj = gridHelperService.CreateGridForInitialSeed(ioHelperService.ProcessInput());
            gridHelperService.UpdateGridOneGeneration(gObj);
            ioHelperService.DisplayGrid(gObj);

            DisposeServices();
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IHelperIO, HelperIO>();
            collection.AddScoped<IGridHelper, GridHelper>();
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
