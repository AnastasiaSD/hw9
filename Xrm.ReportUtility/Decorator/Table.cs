namespace Xrm.ReportUtility
{
    public class Table : ITable
    {
        public string HeaderRow{ get; set; }
        public string RowTemplate{ get; set; }

        public override string ToString()
        {
            return HeaderRow;
        }
    }
}