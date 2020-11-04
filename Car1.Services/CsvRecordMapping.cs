using Car1.Domain;
using TinyCsvParser.Mapping;

namespace Car1.Services
{
    public class CsvRecordMapping : CsvMapping<CsvRecord>
    {
        public CsvRecordMapping()
            : base()
        {
            MapProperty(0, x => x.Country);
            MapProperty(1, x => x.Make);
            MapProperty(2, x => x.Model);
            MapProperty(3, x => x.UnitsSold);
            MapProperty(4, x => x.AdvertisingSpend);
            MapProperty(5, x => x.YearMonth);
        }
    }
}
