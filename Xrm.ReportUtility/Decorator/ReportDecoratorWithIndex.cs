namespace Xrm.ReportUtility
{
    public class ReportDecoratorWithIndex : ReportDecoratorBase
    {
        public ReportDecoratorWithIndex(IReportCreator report) : base(report)
        { }

        public override ITable GetTable()
        {
            var table = base.GetTable();
            table.HeaderRow = "№\t" + table.HeaderRow;
            table.RowTemplate = "{0}\t" + table.RowTemplate;
            return table;
        }
    }
}