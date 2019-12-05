namespace Xrm.ReportUtility
{
    public class ReportDecoratorWithTotalWeight : ReportDecoratorBase \\ конкретный декоратор 
    {
        public ReportDecoratorWithTotalWeight(IReportCreator report) : base(report)
        { }

        public override ITable GetTable() \\ вызывают обёрнутый объект (таблицу) и добавляет столбец «Суммарный вес» в отчёт
        {
            var table = base.GetTable();
            table.HeaderRow += "\tСуммарный вес";
            table.RowTemplate += "\t{7,13}";
            return table;
        }
    }
}
