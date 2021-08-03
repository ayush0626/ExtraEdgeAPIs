using ExtraEdge.Models;
using ExtraEdge.Repository.Interfaces;
using ExtraEdge.Repository.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class MobileShopTest
    {
        private readonly IMobileShopRepository<GeneratedReportModel> _mobileShopRepository;
        public MobileShopTest()
        {
            this._mobileShopRepository = new MobileRepository();
        }
        //dummy test for getting data
        [TestMethod]
        [DataRow("vivo")]
        [DataRow("apple")]
        [DataRow("not")]
        public async Task TestBrandWiseDetails(string brandName)
        {
            IEnumerable<GeneratedReportModel> result = await _mobileShopRepository.GetAllAsync(brandName).ConfigureAwait(false);
            Assert.IsNotNull(result);
        }
    }
}
