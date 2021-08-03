using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExtraEdge.Repository.Interfaces;
using ExtraEdge.Models;

namespace ExtraEdge.Repository.Services
{
    public class MobileCRUDRepository : IMobileCRUDRepository<MobileShopModel>
    {


        //private readonly MobileOwnerContext _mobileOwnerContext;
        //public MobileCRUDRepository(MobileOwnerContext mobileOwnerContext)
        //{
        //    this._mobileOwnerContext = mobileOwnerContext;
        //}

        public async Task<bool> AddAsync(MobileShopModel entity)
        {
            //While using database we need to uncomment this

            //_mobileOwnerContext.Employees.Add(entity);
            //_mobileOwnerContext.SaveChanges();
            return true;
        }
        public async Task<bool> DeleteAsync(MobileShopModel entity)
        {
            //_mobileOwnerContext.MobileShop.Remove(entity);
            // _mobileOwnerContext.SaveChanges();
            return true;
        }


        public async Task<MobileShopModel> GetAsync(long id)
        {
            //await will qwork when we come to real programming
            //uncommet when we use database and get the data as we need
            //var result = await _mobileOwnerContext.MobileShop.FirstOrDefault(e => e.EmployeeId == id);
            return MockData.GetMobileShopModelData().FirstOrDefault(a => a.Id == id);
        }

        public async Task<bool> UpdateAsync(MobileShopModel dbEntity, MobileShopModel entity)
        {
            //assign each propert we need to update here
            //dbEntity = entity;
            //_mobileOwnerContext.SaveChanges();
            return true;
        }
    }
}
