using CsvHelper.Configuration;
using CsvHelper;
using Domain.Models;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine(_filePath);
            /*var employess = DbContext.ReadEmployees();
            foreach (var item in employess)
            {
                Console.WriteLine(item.Dni);
            }*/
        }
    }
}
