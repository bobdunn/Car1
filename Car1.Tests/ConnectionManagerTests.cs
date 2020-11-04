using Car1.Data;
using Car1.Domain;
using Dapper;
using FluentAssertions;
using Moq;
using Xunit;

namespace Car1.Tests
{
    public class ConnectionManagerTests
    {
        IConnectionManager _connectionManager;

        public ConnectionManagerTests()
        {
            var settingsMock = new Mock<ISettings>();
            // this needs to have the file path for the solution item Car1.mdf, as does the appsettings.json in the Car1 API project.
            settingsMock.Setup(s => s.GetConnectionString()).Returns(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\dev\R1\Car1\Data\Car1.mdf;Integrated Security=True;Connect Timeout=30");
            _connectionManager = new ConnectionManager(settingsMock.Object);
        }

        [Fact]
        public void GetConnectionReturnsConnection()
        {
            using var connection = _connectionManager.GetConnection();
            System.Collections.Generic.IEnumerable<dynamic> result = connection.Query(@"
SELECT *
FROM sys.Tables
GO
");
            result.AsList<dynamic>().Count.Should().Be(4);
        }
    }
}