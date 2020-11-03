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

        public CsvService(ICsvParser csvParser)
        {
            _csvParser = csvParser;
        }

        public  async Task ProcessCsv(string csvText)
        {
            _csvParser.ParseCsvRecord(csvText);
        }
    }
}
