using Car1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using TinyCsvParser;

namespace Car1.Services
{
    public class CsvParser : ICsvParser
    {
        public List<CsvRecord> ParseCsvRecord(string csvContent)
        {
            TinyCsvParser.CsvParserOptions options = new TinyCsvParser.CsvParserOptions(true,',');
            TinyCsvParser.CsvReaderOptions readerOptions = new CsvReaderOptions(new[] { Environment.NewLine });
            var parser = new TinyCsvParser.CsvParser<CsvRecord>(options, new CsvRecordMapping());
            return parser.ReadFromString(readerOptions, csvContent).Select(x=>x.Result).ToList();
        }
    }
}
