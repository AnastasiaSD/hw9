namespace Xrm.ReportUtility
{
    public class Table : ITable // таблица, шапку которой собираем
    {
        public string HeaderRow{ get; set; }
        public string RowTemplate{ get; set; }

        public override string ToString() // выводим полученную шапку
        {
            return HeaderRow;
        }
    }
}
