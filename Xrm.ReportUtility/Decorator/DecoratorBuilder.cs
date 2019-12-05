namespace Xrm.ReportUtility
{
    public class DecoratorBuilder // конструктор декораторов (навешивает тот декоратор, который мы вызовим, зависит от порядка вызова)
    {
        private IReportCreator _reportCreator;

        public DecoratorBuilder(IReportCreator reportCreator)
        {
            _reportCreator = reportCreator;
        }

        public DecoratorBuilder WithIndex()
        {
            _reportCreator = new ReportDecoratorWithIndex(_reportCreator);
            return this;
        }

        public DecoratorBuilder WithTotalVolume()
        {
            _reportCreator = new ReportDecoratorWithTotalVolume(_reportCreator);
            return this;
        }
        
        public DecoratorBuilder WithTotalWeight()
        {
            _reportCreator = new ReportDecoratorWithTotalWeight(_reportCreator);
            return this;
        }

        public IReportCreator Build()
        {
            return _reportCreator;
        }
    }
}
