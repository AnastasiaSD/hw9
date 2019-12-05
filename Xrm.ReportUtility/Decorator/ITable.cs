namespace Xrm.ReportUtility
{
    public interface ITable
    {
        string HeaderRow { get; set; }
        string RowTemplate { get; set; }
    }
}