namespace Xrm.ReportUtility
{
    public class ReportDecoratorWithTotalVolume : ReportDecoratorBase
    {
        public ReportDecoratorWithTotalVolume(IReportCreator report) : base(report)
        { }

        public override ITable GetTable()
        {
            var table = base.GetTable();
            table.HeaderRow += "\tСуммарный объём";
            table.RowTemplate += "\t{6,15}";
            return table;
        }
    }
}