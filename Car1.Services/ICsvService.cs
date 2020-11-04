using System;
using System.Threading.Tasks;

namespace Car1.Services
{
    public interface ICsvService
    {
        public void ProcessCsv(string csvText);
    }
}