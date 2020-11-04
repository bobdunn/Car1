using Car1.Domain;
using System.Collections.Generic;

namespace Car1.Services
{
    public interface ICsvParser
    {
        List<CsvRecord> ParseCsvRecord(string csvContent);
    }
}