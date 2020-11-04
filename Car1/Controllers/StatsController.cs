using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car1.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly ISalesAndSpendDao _salesAndSpendDao;

        public StatsController(ISalesAndSpendDao salesAndSpendDao)
        {
            _salesAndSpendDao = salesAndSpendDao;
        }
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(new { result=_salesAndSpendDao.GetAllSalesAndSpendData()});
        }
    }
}
