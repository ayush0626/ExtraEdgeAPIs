using ExtraEdge.Models;
using ExtraEdge.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtraEdge.Repository.Services
{
    public class MobileRepository : IMobileShopRepository<GeneratedReportModel>
    {
        //private readonly MobileOwnerContext _mobileOwnerContext;
        //public MobileRepository(MobileOwnerContext mobileOwnerContext)
        //{
        //    this._mobileOwnerContext = mobileOwnerContext;
        //}
        public void Add(GeneratedReportModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(GeneratedReportModel entity)
        {
            throw new NotImplementedException();
        }

        public GeneratedReportModel Get(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GeneratedReportModel>> GetAllAsync()
        {
            //line changes while we have db connection right now return the data with mocking 
            //return _mobileOwnerContext.GeneratedReportModels.ToList();

            //right getting list of all records avaiable
            return MockData.GetReportDataList();
        }

        public void Update(GeneratedReportModel dbEntity, GeneratedReportModel entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GeneratedReportModel>> GetAllAsync(int month)
        {
            //using mockta leads to be sync first so
            //no use of await will be possible here but when this comes with database then
            //we can easily migrate the await to attach the Getawaiter function

            var monthList = MockData.GetReportDataList().FindAll(a => a.DateOfSell.Month == month);
            return monthList;
        }

        public async Task<IEnumerable<GeneratedReportModel>> GetAllAsync(int fromMonth, int toMonth)
        {
            var result = MockData.GetReportDataList().FindAll(a => a.DateOfSell.Month >= fromMonth && a.DateOfSell.Month <= toMonth).ToList();
            return result;
        }

        public async Task<IEnumerable<GeneratedReportModel>> GetAllAsync(DateTime fromMonth, DateTime toMonth)
        {
            var result = MockData.GetReportDataList().FindAll(a => a.DateOfSell >= fromMonth && a.DateOfSell <= toMonth).Select(p => new GeneratedReportModel
            {
                CustomerName = p.CustomerName,
                DateOfPurschsed = p.DateOfPurschsed,
                DateOfSell = p.DateOfSell,
                DiscountOnSell = p.DiscountOnSell,
                MobileBrandName = p.MobileBrandName,
                MobileCost = p.MobileCost,
                MobileSellingCost = p.MobileSellingCost
            }).ToList();
            return result;
        }

        public async Task<IEnumerable<GeneratedReportModel>> GetAllAsync(string brandName)
        {
            var result = MockData.GetReportDataList().FindAll(a => a.MobileBrandName.Equals(brandName)).Select(p => new GeneratedReportModel
            {
                CustomerName = p.CustomerName,
                DateOfPurschsed = p.DateOfPurschsed,
                DateOfSell = p.DateOfSell,
                DiscountOnSell = p.DiscountOnSell,
                MobileBrandName = p.MobileBrandName,
                MobileCost = p.MobileCost,
                MobileSellingCost = p.MobileSellingCost
            }).ToList();

            return result;
        }

        public async Task<IEnumerable<GeneratedReportModel>> GetAllAsync(string brandName, DateTime fromDate, DateTime toDate)
        {
            var result = MockData.GetReportDataList().FindAll(a => a.MobileBrandName.Equals(brandName) && a.DateOfSell >= fromDate && a.DateOfSell <= toDate).Select(p => new GeneratedReportModel
            {
                CustomerName = p.CustomerName,
                DateOfPurschsed = p.DateOfPurschsed,
                DateOfSell = p.DateOfSell,
                DiscountOnSell = p.DiscountOnSell,
                MobileBrandName = p.MobileBrandName,
                MobileCost = p.MobileCost,
                MobileSellingCost = p.MobileSellingCost
            }).ToList();
            return result;
        }
    }
}
