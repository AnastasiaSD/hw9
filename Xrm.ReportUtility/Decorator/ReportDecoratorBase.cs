namespace Xrm.ReportUtility
{
    public class ReportDecoratorBase: IReportCreator
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