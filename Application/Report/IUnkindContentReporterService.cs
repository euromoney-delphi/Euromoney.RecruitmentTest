using Domain.UnkindContentReport;

namespace Application.Report
{
    public interface IUnkindContentReporterService
    {
        IUnkindContentReport ProduceReport(string content);
    }
}