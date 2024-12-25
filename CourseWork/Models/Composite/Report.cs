using CourseWork.Data.Entities;

namespace CourseWork.Models.Composite
{
    public interface IReport
    {
        public string GetReport();

        public void AddReport(IReport report);
    }
    public class Report : IReport
    {
        protected List<IReport> _reports { get; set; }

        public Report()
        {
            this._reports = new List<IReport>();
        }

        public string GetReport()
        {
            string report = "|      Звіт продуктів      |\n";

            foreach (var rItem in this._reports)
            {
                report += rItem.GetReport();
            }

            return report;
        }

        public void AddReport(IReport report)
        {
            this._reports.Add(report);
        }
    }
}
