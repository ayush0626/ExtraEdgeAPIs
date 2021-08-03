using ExtraEdge.Models;
using System;
using System.Threading.Tasks;

namespace ExtraEdge.Repository.Interfaces
{
    public interface IProfitReportRepository<T>
    {
        Task<ReportForProfit> GenerateReport(string type, int month,DateTime fromDate,DateTime toDate);
        Task<Decimal> GetBrandPrice(string brandName);
    }
}
