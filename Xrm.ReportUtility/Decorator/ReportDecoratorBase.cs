namespace Xrm.ReportUtility
{
    public class ReportDecoratorBase: IReportCreator // базовый класс декоратора - определяет интерфейс обёртки для
    // всех конкретных декораторов
    {
        protected readonly IReportCreator Decoratee;

        protected ReportDecoratorBase(IReportCreator report)
        {
            Decoratee = report;
        }

        public virtual ITable GetTable()
        {
            return Decoratee.GetTable();
        }
    }
}
