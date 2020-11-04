using Car1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyCsvParser;

namespace Car1.Services
{
    public class CsvService : ICsvService
    {
        private readonly ICsvParser _csvParser;
        private readonly ISalesAndSpendDao _salesAndSpendDao;

        public CsvService(ICsvParser csvParser, ISalesAndSpendDao salesAndSpendDao)
        {
            _csvParser = csvParser;
            _salesAndSpendDao = salesAndSpendDao;
        }

        public void ProcessCsv(string csvText)
        {
            var records = _csvParser.ParseCsvRecord(csvText);
            _salesAndSpendDao.InsertFromCsvRecords(records);

        }
    }
}
