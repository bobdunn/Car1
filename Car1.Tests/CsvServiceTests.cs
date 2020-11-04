using Car1.Data;
using Car1.Domain;
using Car1.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Car1.Tests
{
    public class CsvServiceTests
    {
        ICsvService _csvService;
        Mock<ICsvParser> _mockCsvParser;
        Mock<ISalesAndSpendDao> _mockSalesAndSpendDao;

        public CsvServiceTests()
        {
            _mockCsvParser = new Mock<ICsvParser>();
            _mockSalesAndSpendDao = new Mock<ISalesAndSpendDao>();
            _csvService = new CsvService(_mockCsvParser.Object,_mockSalesAndSpendDao.Object);
        }

        [Fact]
        public void ProcessCsvParsesInputFile()
        {
            string content = "";
            
            var records = new List<CsvRecord> { new CsvRecord
            {
                AdvertisingSpend = 7,
                Country = "Country1",
                Make = "Make",
                Model = "Model",
                UnitsSold = 1,
                YearMonth = "200812"
            } };
            _mockCsvParser.Setup(x => x.ParseCsvRecord(content)).Returns(records);
            _mockSalesAndSpendDao.Setup(x => x.InsertFromCsvRecords(records));

            _csvService.ProcessCsv(content);

            _mockCsvParser.VerifyAll();
            _mockSalesAndSpendDao.VerifyAll();

        }
    }

    public class CsvParserTests
    {
        ICsvParser _csvParser;
        string _csvContent = @"Country,Make,Model,UnitsSold,AdvertisingSpend,YearMonth
Brazil,Ford,Focus,1121,1000000,201901
Brazil,Ford,Explorer,703,2000000,201901";

        public CsvParserTests()
        {
            _csvParser = new CsvParser();
        }
        [Fact]
        public void ParseGeneratesSalesAndSpendRecords()
        {
            var result = _csvParser.ParseCsvRecord(_csvContent);
            result.Count.Should().Be(2);
            // Spot check third party library
            result[0].Country.Should().Be("Brazil");
            result[1].UnitsSold.Should().Be(703);
        }
    }
}