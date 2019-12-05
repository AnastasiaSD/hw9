namespace Xrm.ReportUtility
{
    public interface IReportCreator // Базовый интерфейс - определяет поведение, которое изменяется
    // декораторами.
    {
        ITable GetTable();
    }
}
