using Microsoft.Extensions.DependencyInjection;
using SalesTaxApp.Implementation;
using SalesTaxApp.Interface;
using SalesTaxApp.Models;
using System;
using System.Collections.Generic;

namespace SalesTaxApp
{
    class Program
    {

        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            RegisterServices();
            
            var receiptParserverService = _serviceProvider.GetService<IProductParser>();
            var taxCalulatorServie = _serviceProvider.GetService<ITaxCalculator>();
            var receiptPrinterService = _serviceProvider.GetService<IReceiptPrinter>();

            List<Product> productList = receiptParserverService.GetProducts();
            taxCalulatorServie.CalculateTax(productList);
            receiptPrinterService.PrintReceipt(productList);

            DisposeServices();
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IProductParser, ProductParser>();
            collection.AddScoped<IReceiptPrinter, ReceiptPrinter>();
            collection.AddScoped<ITaxCalculator, TaxCalculator>();
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
