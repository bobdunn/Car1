using Car1.Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace Car1.Data
{
    public class SalesAndSpendDao : ISalesAndSpendDao
    {
        private readonly IConnectionManager _connectionManager;

        public SalesAndSpendDao(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public dynamic GetAllSalesAndSpendData()
        {
            using(var connection = _connectionManager.GetConnection())
            {
               return connection.Query(@"
select 
	Country.[Name] Country,
	Model.[Name] Model, 
	Make.[Name] Make,
	[Year],
	[Month],
	UnitsSold,
	AdvertisingSpend
from SalesAndSpend
	join Model   on SalesAndSpend.ModelId   = Model.ModelId
	join Make    on SalesAndSpend.MakeId    = Make.MakeId
	join Country on SalesAndSpend.CountryId = Country.CountryId");
            }
        }

        public void InsertFromCsvRecords(List<CsvRecord> records)
        {
            using (var connection = _connectionManager.GetConnection())
                records.ForEach(x =>
                {
                    var year = int.Parse(x.YearMonth.Substring(0, 4));
                    var month = int.Parse(x.YearMonth.Substring(4, 2));
                    var parameters = new { 
                        country = x.Country, 
                        make = x.Make,
                        model=x.Model,
                        unitsSold=x.UnitsSold,
                        advertisingSpend=x.AdvertisingSpend,
                        year=year,
                        month=month
                    };

                    connection.Query("usp_InsertSalesAndSpend", parameters, commandType: CommandType.StoredProcedure);

                });
        }
    }

    public interface ISalesAndSpendDao
    {
        void InsertFromCsvRecords(List<CsvRecord> records);
        dynamic GetAllSalesAndSpendData();
    }
}
