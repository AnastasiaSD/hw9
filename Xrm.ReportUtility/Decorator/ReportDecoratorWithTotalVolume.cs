namespace Xrm.ReportUtility
{
    public class ReportDecoratorWithTotalVolume : ReportDecoratorBase \\ конкретный декоратор 
    {
        public ReportDecoratorWithTotalVolume(IReportCreator report) : base(report)
        { }

        public override ITable GetTable() \\ вызывают обёрнутый объект (таблицу) и добавляет столбец «Суммарный объём» в отчёт
        {
            var table = base.GetTable();
            table.HeaderRow += "\tСуммарный объём";
            table.RowTemplate += "\t{6,15}";
            return table;
        }
    }
}
