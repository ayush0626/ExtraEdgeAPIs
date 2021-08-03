using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExtraEdge.Repository.Interfaces;
using ExtraEdge.Models;

namespace ExtraEdge.Repository.Services
{
    public class ProfitReportRepository : IProfitReportRepository<ReportForProfit>
    {
        public async Task<ReportForProfit> GenerateReport(string type, int month, DateTime fromDate, DateTime toDate)
        {

            //Firstly we need to capture all data which we have in our database
            //this collection will be used for getting analysis and reduce database hit
            var collection = MockData.GetReportDataList().Select(a => new GeneratedReportModel { DateOfSell = a.DateOfSell, MobileCost = a.MobileCost, MobileSellingCost = a.MobileSellingCost, DiscountOnSell = a.DiscountOnSell });

            if (type == "monthwise" && (month > 0 || month <= 12))
            {

                //montly is for per month detail
                //comparsion should be done between all previous months

                //Getting total Collection Till Month Not include any future month for analysis
                var totalCollectionTillInputMonth = collection.Where(a => a.DateOfSell.Month == month).Sum(a => a.MobileCost);
                var ProfitCollectionForInputMonth = collection.Where(a => a.MobileCost < a.MobileSellingCost && a.DateOfSell.Month == month).Sum(s => s.MobileSellingCost);
                var lossCollectionForInputMonth = collection.Where(a => a.MobileCost > a.MobileSellingCost && a.DateOfSell.Month == month).Sum(s => s.MobileSellingCost);

                var profitAfterAllInThisMonth = ProfitCollectionForInputMonth - totalCollectionTillInputMonth - lossCollectionForInputMonth;

                //inintlize the variable for comapre inf in case of no sell was in previos month or handling the null exception at run time;
                decimal profitCollectionForPreviousMonth = 0.0M;
                decimal lossCollectionForPreviousMonth = 0.0M;
                decimal totalCollectionPreviousMonth = 0.0M;

                //if month has 1 value then we need to decearse year by 1 and set month to 12 so that we can easily comapre the months.
                if (month > 1)
                {
                    totalCollectionPreviousMonth = collection.Where(a => a.DateOfSell.Month == month - 1).Sum(a => a.MobileCost);
                    profitCollectionForPreviousMonth = collection.Where(a => a.MobileCost < a.MobileSellingCost && a.DateOfSell.Month == month - 1).Sum(s => s.MobileSellingCost);
                    lossCollectionForPreviousMonth = collection.Where(a => a.MobileCost > a.MobileSellingCost && a.DateOfSell.Month == month - 1).Sum(s => s.MobileSellingCost);
                }
                else
                {
                    const int previousMonth = 12;
                    totalCollectionPreviousMonth = collection.Where(a => a.DateOfSell.Year == a.DateOfSell.Year - 1 && a.DateOfSell.Month < month).Sum(a => a.MobileSellingCost);
                    profitCollectionForPreviousMonth = collection.Where(a => a.MobileCost < a.MobileSellingCost && a.DateOfSell.Year == a.DateOfSell.Year - 1 && a.DateOfSell.Month == previousMonth).Sum(s => s.MobileSellingCost);
                    lossCollectionForPreviousMonth = collection.Where(a => a.MobileCost > a.MobileSellingCost && a.DateOfSell.Year == a.DateOfSell.Year - 1 && a.DateOfSell.Month == previousMonth).Sum(s => s.MobileSellingCost);
                }
                var profitAfterAllForPreviousMonth = profitCollectionForPreviousMonth - totalCollectionPreviousMonth - lossCollectionForPreviousMonth;

                string comparePercent = string.Empty;
                decimal profitAfterCompare = profitAfterAllInThisMonth - profitAfterAllForPreviousMonth;
                if (profitAfterCompare > 0)
                {
                    comparePercent = "Profit is more from last month" + String.Format("{0:0.00}", profitAfterCompare);
                }
                else
                {
                    comparePercent = "Profit is less from last month " + String.Format("{0:0.00}", Math.Abs(profitAfterCompare));
                }
                //i have include the percent in dev envoirment but we can remove this in production
                //as we do not need to include this from backedn it should always include in ui side
                return new ReportForProfit
                {
                    ProfitForNow = String.Format("{0:0.00}", profitAfterAllInThisMonth),
                    CompareProfit = comparePercent
                };
            }
            else if (type == "daywise")
            {
                var totalCollectionTillInputMonth = collection.Where(a => a.DateOfSell >= fromDate && a.DateOfSell <= toDate).Sum(a => a.MobileCost);
                var ProfitCollectionForInputMonth = collection.Where(a => a.MobileCost < a.MobileSellingCost && a.DateOfSell >= fromDate && a.DateOfSell <= toDate).Sum(s => s.MobileSellingCost);
                var lossCollectionForInputMonth = collection.Where(a => a.MobileCost > a.MobileSellingCost && a.DateOfSell >= fromDate && a.DateOfSell <= toDate).Sum(s => s.MobileSellingCost);
                var profitAfterAll = ProfitCollectionForInputMonth - totalCollectionTillInputMonth - lossCollectionForInputMonth;
                return new ReportForProfit
                {
                    ProfitForNow = String.Format("{0:0.00}", profitAfterAll),
                    CompareProfit = "N/A"
                };

            }
            else
            {
                return new ReportForProfit { };
            }
        }
        //best price apis but data unavaiable as i am using the mock data
        public async Task<decimal> GetBrandPrice(string brandName)
        {
            var collection = MockData.GetReportDataList().FindAll(a=>a.MobileBrandName.Equals(brandName)).Select(a=>new GeneratedReportModel { MobileSellingCost=a.MobileSellingCost});
            decimal total = collection.Sum(s => s.MobileSellingCost);
            return total;
        }
    }
}
