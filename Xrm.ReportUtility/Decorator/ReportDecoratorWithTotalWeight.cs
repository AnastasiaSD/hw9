namespace Xrm.ReportUtility
{
    public class ReportDecoratorWithTotalWeight : ReportDecoratorBase
    {
        public ReportDecoratorWithTotalWeight(IReportCreator report) : base(report)
        { }

        public override ITable GetTable()
        {
            var table = base.GetTable();
            table.HeaderRow += "\tСуммарный вес";
            table.RowTemplate += "\t{7,13}";
            return table;
        }
    }
}