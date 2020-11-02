using Car1.Services;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Car1.Tests
{
    public class CsvServiceTests
    {
        [Fact]
        public async Task ThrowsNotImplementedException()
        {
            var service = new CsvService();
            service.Invoking(s => s.ProcessCsv("sample text"))
                .Should().Throw<NotImplementedException>();
        }

    }
}
