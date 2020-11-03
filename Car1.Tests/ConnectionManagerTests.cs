using Car1.Data;
using Car1.Domain;
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
            settingsMock.Setup(s => s.ConnectionString).Returns(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rober\source\repos\Car1\Data\Car1.mdf;Integrated Security=True;Connect Timeout=30");
            _connectionManager = new ConnectionManager(settingsMock.Object);
        }

        [Fact]
        public void GetConnectionReturnsConnection()
        {
            _connectionManager.GetConnection().Should().NotBeNull();
        }
    }
}