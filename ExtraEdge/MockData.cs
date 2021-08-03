using ExtraEdge.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ExtraEdge
{
    [ExcludeFromCodeCoverage]
    public class MockData
    {
        public static List<MobileShopModel> GetMobileShopModelData()
        {
            return new List<MobileShopModel>
            {
                CreateMobileShopData(1001,"test",GenerateDateForReport(1,10),GenerateDateForReport(1,12),12,"vivo",12000,12600),
                CreateMobileShopData(1002,"test1",GenerateDateForReport(4,10),GenerateDateForReport(4,10),12,"samsung",12007,14580),
                CreateMobileShopData(1003,"test2",GenerateDateForReport(4,15),GenerateDateForReport(4,16),12,"Mi",12000,14600),
                CreateMobileShopData(1004,"test3",GenerateDateForReport(4,17),GenerateDateForReport(4,20),12,"samsung",11658,14600),
                CreateMobileShopData(1005,"test4",GenerateDateForReport(3,10),GenerateDateForReport(3,18),12,"vivo",13400,15000),
                CreateMobileShopData(1006,"test5",GenerateDateForReport(4,10),GenerateDateForReport(4,20),12,"vivo",12580,13000),
                CreateMobileShopData(1007,"test6",GenerateDateForReport(3,10),GenerateDateForReport(6,10),12,"samsung",12000,14600),
                CreateMobileShopData(1008,"test7",GenerateDateForReport(3,10),GenerateDateForReport(5,10),12,"samsung",12000,14600),
                CreateMobileShopData(1009,"test8",GenerateDateForReport(3,10),GenerateDateForReport(4,10),12,"mi",12000,14600),
                CreateMobileShopData(1010,"test9",GenerateDateForReport(5,10),GenerateDateForReport(4,10),12,"samsung",12000,14600),
                CreateMobileShopData(1011,"test10",GenerateDateForReport(5,10),GenerateDateForReport(3,10),12,"apple",120000,156000),
                CreateMobileShopData(1012,"test11",GenerateDateForReport(4,10),GenerateDateForReport(4,10),12,"apple",120000,147800),
                CreateMobileShopData(1013,"test12",GenerateDateForReport(6,10),GenerateDateForReport(8,10),12,"samsung",12000,14600),
            };
        }


        public static List<GeneratedReportModel> GetReportDataList()
        {
            return new List<GeneratedReportModel>
            {
                CreateMobileShopDataForReport("test",GenerateDateForReport(1,10),GenerateDateForReport(1,12),8.5M,"vivo",12000,12600),
                CreateMobileShopDataForReport("test1",GenerateDateForReport(4,10),GenerateDateForReport(4,10),12,"samsung",12007,10580),
                CreateMobileShopDataForReport("test2",GenerateDateForReport(4,15),GenerateDateForReport(4,16),5,"Mi",12000,14600),
                CreateMobileShopDataForReport("test3",GenerateDateForReport(4,17),GenerateDateForReport(4,20),5,"samsung",11658,14600),
                CreateMobileShopDataForReport("test4",GenerateDateForReport(3,10),GenerateDateForReport(3,18),2,"vivo",13400,12000),
                CreateMobileShopDataForReport("test5",GenerateDateForReport(4,10),GenerateDateForReport(4,20),3.5M,"vivo",12580,13000),
                CreateMobileShopDataForReport("test6",GenerateDateForReport(3,10),GenerateDateForReport(6,10),7,"samsung",12000,14600),
                CreateMobileShopDataForReport("test7",GenerateDateForReport(3,10),GenerateDateForReport(5,10),6,"samsung",12000,14600),
                CreateMobileShopDataForReport("test8",GenerateDateForReport(3,10),GenerateDateForReport(4,10),2,"mi",12000,14600),
                CreateMobileShopDataForReport("test9",GenerateDateForReport(5,10),GenerateDateForReport(4,10),5,"samsung",12000,14600),
                CreateMobileShopDataForReport("test10",GenerateDateForReport(5,10),GenerateDateForReport(3,10),10,"apple",120000,156000),
                CreateMobileShopDataForReport("test11",GenerateDateForReport(4,10),GenerateDateForReport(4,10),4.8M,"apple",120000,147800),
                CreateMobileShopDataForReport("test12",GenerateDateForReport(6,10),GenerateDateForReport(8,10),10,"samsung",12000,13300),
            };
        }



        public static MobileShopModel CreateMobileShopData(Int64 id, string customeName, DateTime dateofpur, DateTime dateofsell, decimal discountonsell, string brandName, decimal mobileCost, decimal mobileSellingCost)
        {
            return new MobileShopModel
            {
                CustomerName = customeName,
                DateOfPurschsed = dateofpur,
                DateOfSell = dateofsell,
                DiscountOnSell = discountonsell,
                MobileBrandName = brandName,
                MobileCost = mobileCost,
                MobileSellingCost = mobileSellingCost,
                Id = id
            };
        }
        public static GeneratedReportModel CreateMobileShopDataForReport(string customeName, DateTime dateofpur, DateTime dateofsell, decimal discountonsell, string brandName, decimal mobileCost, decimal mobileSellingCost)
        {
            return new GeneratedReportModel
            {
                CustomerName = customeName,
                DateOfPurschsed = dateofpur,
                DateOfSell = dateofsell,
                DiscountOnSell = discountonsell,
                MobileBrandName = brandName,
                MobileCost = mobileCost,
                MobileSellingCost = mobileSellingCost,
            };
        }
        public static DateTime GenerateDateForReport(int month, int day)
        {
            return new DateTime(2021, month, day);
        }
    }
}
