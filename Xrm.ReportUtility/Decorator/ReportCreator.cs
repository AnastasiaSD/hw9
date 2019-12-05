namespace Xrm.ReportUtility
{
    public class ReportCreator : IReportCreator // базовый класс (на него навешиваются декораторы)
    {
        public ITable GetTable()
        {
            return new Table()
            {
                HeaderRow = "Наименование\tОбъём упаковки\tМасса упаковки\tСтоимость\tКоличество",
                RowTemplate = "{1,12}\t{2,14}\t{3,14}\t{4,9}\t{5,10}"
            };
        }
    }
}
