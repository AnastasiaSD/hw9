using System;
using System.Linq;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;
using Xrm.ReportUtility.Services;

namespace Xrm.ReportUtility
{
    public static class Program
    {
        // "Files/table.txt" -data -weightSum -costSum -withIndex -withTotalVolume
        public static void Main(string[] args)
        {
            var service = GetReportService(args);

            var report = service.CreateReport();

            PrintReport(report);

            Console.WriteLine("");
            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }

        private static IReportService GetReportService(string[] args)
        {
            var filename = args[0];

            if (filename.EndsWith(".txt"))
            {
                return new TxtReportService(args);
            }

            if (filename.EndsWith(".csv"))
            {
                return new CsvReportService(args);
            }

            if (filename.EndsWith(".xlsx"))
            {
                return new XlsxReportService(args);
            }

            throw new NotSupportedException("this extension not supported");
        }

        private static void PrintReport(Report report)
        {
            if (report.Config.WithData && report.Data != null && report.Data.Any())
            { //----- далее код был переписан с использованием декоратора (реализация находится в папке "Decorator")
                var reportCreator = new ReportCreator(); // создаем основу таблицы, на которую будем навешивать декораторы
                var builder = new DecoratorBuilder(reportCreator); //конструктор, оборачивающий нашу таблицу в декораторы

                if (report.Config.WithIndex)// добавляем декораторы в зависимости от их вызова
                    builder.WithIndex();
                if (report.Config.WithTotalVolume)
                    builder.WithTotalVolume();
                if (report.Config.WithTotalWeight)
                    builder.WithTotalWeight();

                var tableWithDecoration = builder.Build(); 
                var table = tableWithDecoration.GetTable(); //получили измененную с помощью декораторов таблицу
                Console.WriteLine(table);
                //------ конец изменений
                for (var i = 0; i < report.Data.Length; i++)
                {
                    var dataRow = report.Data[i];
                    Console.WriteLine(table.RowTemplate, i + 1, dataRow.Name, dataRow.Volume, dataRow.Weight,
                        dataRow.Cost, dataRow.Count, dataRow.Volume * dataRow.Count, dataRow.Weight * dataRow.Count);
                }

                Console.WriteLine();
            }

            if (report.Rows != null && report.Rows.Any())
            {
                Console.WriteLine("Итого:");
                foreach (var reportRow in report.Rows)
                {
                    Console.WriteLine(string.Format("  {0,-20}\t{1}", reportRow.Name, reportRow.Value));
                }
            }
        }
    }
}
