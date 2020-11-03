using System;
using System.Threading.Tasks;

namespace Car1.Services
{
    public interface ICsvService
    {
        public Task ProcessCsv(string csvText);
    }
}