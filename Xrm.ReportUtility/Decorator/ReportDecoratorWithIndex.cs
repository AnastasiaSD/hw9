namespace Xrm.ReportUtility
{
    public class ReportDecoratorWithIndex : ReportDecoratorBase \\ конкретный декоратор 
    {
        public ReportDecoratorWithIndex(IReportCreator report) : base(report)
        { }

        public override ITable GetTable() \\ вызывают обёрнутый объект (таблицу) и добавляет в начало отчёта столбец «№»       
        {
            var table = base.GetTable();
            table.HeaderRow = "№\t" + table.HeaderRow;
            table.RowTemplate = "{0}\t" + table.RowTemplate;
            return table;
        }
    }
}
