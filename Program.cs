using System;

namespace SolidRefactoringLab
{
    public interface IReportFormatter
    {
        void FormatReport();
    }

    public class PdfReportFormatter : IReportFormatter
    {
        public void FormatReport()
        {
            Console.WriteLine("Formatting report as a PDF...");
        }
    }

    public class WordReportFormatter : IReportFormatter
    {
        public void FormatReport()
        {
            Console.WriteLine("Formatting report as a Word Document...");
        }
    }

    public class PlainTextReportFormatter : IReportFormatter
    {
        public void FormatReport()
        {
            Console.WriteLine("Formatting report as plain text...");
        }
    }

    public class ReportSaver
    {
        public void SaveToFile(string filename)
        {
            Console.WriteLine($"Saving report data to {filename}...");
        }
    }

    // THIS CLASS VIOLATES SRP AND OCP
    public class ReportManager
    {
        private readonly IReportFormatter _formatter;
        public string ReportData { get; set; }

        public ReportManager(IReportFormatter formatter)
        {
            _formatter = formatter;
        }

        public void GeneralReport()
        {
            _formatter.FormatReport();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            IReportFormatter formatter = new PdfReportFormatter();
            ReportManager manager = new ReportManager(formatter);
            manager.GeneralReport();

            ReportSaver saver = new ReportSaver();
            saver.SaveToFile("Q1_Report.pdf");
        }
    }
}