using ExtraEdge.Models;
using ExtraEdge.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExtraEdge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileShopController : ControllerBase
    {
        private readonly IMobileShopRepository<GeneratedReportModel> _mobileShopRepository;
        private readonly IProfitReportRepository<ReportForProfit> _reportRepository;
        private readonly IMobileCRUDRepository<MobileShopModel> _mobileCRUDRepository;
        //uncomment when we work wiht database to directly the log any error from use side
        //private readonly IExceptionRepository _exceptonRepository;
        public MobileShopController(IMobileShopRepository<GeneratedReportModel> mobileShopRepository, IProfitReportRepository<ReportForProfit> profitReportRepository,
            IMobileCRUDRepository<MobileShopModel> mobileCRUDRepository)
        {
            this._mobileShopRepository = mobileShopRepository;
            this._reportRepository = profitReportRepository;
            this._mobileCRUDRepository = mobileCRUDRepository;
            //uncomment when we work wiht database to directly the log any error from use side
            //this._exceptonRepository = exceptionRepository;
        }

        // GET: api/<MobileShopController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _mobileShopRepository.GetAllAsync().ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet("{month}")]
        public async Task<IActionResult> GetAsync(int month)
        {
            if (month < 1 || month > 12)
            {
                return BadRequest("Month is invalid proceed with month range from 1 to 12 only");
            }
            try
            {
                var result = await _mobileShopRepository.GetAllAsync(month).ConfigureAwait(false);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound("This Month has no data May be Entries are not there in mocking");
            }

            catch (NullReferenceException ex)
            {
                //_exceptonRepository.LogException(ex, this.ControllerContext);
                //Uncomment when we use database for logging nullrefernece error
                return NotFound(ex.Message);
            }
            catch
            {
                throw;
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DateRangeModel data)
        {
            if (data != null)
            {
                var result = await _mobileShopRepository.GetAllAsync(data.FromMonth, data.ToMonth).ConfigureAwait(false);
                return Ok(result);
            }
            return BadRequest("Information is provided by admin");
        }


        [HttpPost]
        [Route("datewise")]
        public async Task<IActionResult> GetDataDateWise([FromBody] DateTimeInput data)
        {
            if (data != null)
            {
                var f = DateTime.Parse(data.FromDate);
                var t = DateTime.Parse(data.ToDate);
                var result = await _mobileShopRepository.GetAllAsync(f, t).ConfigureAwait(false);
                return Ok(result);
            }
            return BadRequest("Information is not provided");
        }

        [HttpPost]
        [Route("brandwise")]
        public async Task<IActionResult> GetOverallReportByBrandName([FromBody] string brandName)
        {
            if (string.IsNullOrEmpty(brandName)) return BadRequest("brandname is missing");
            var result = await _mobileShopRepository.GetAllAsync(brandName).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPost]
        [Route("brand/daterange")]
        public async Task<IActionResult> GetDateWiseReportByBrandName([FromBody] BrandDateWiseModel brandDateWiseModel)
        {
            if (brandDateWiseModel != null)
            {
                var f = DateTime.Parse(brandDateWiseModel.Fromdate);
                var t = DateTime.Parse(brandDateWiseModel.Todate);
                var result = await _mobileShopRepository.GetAllAsync(brandDateWiseModel.BrandName, f, t).ConfigureAwait(false);
                return Ok(result);
            }
            return BadRequest("Information Missing");
        }


        [HttpPost]
        [Route("report")]
        public async Task<IActionResult> GetReport([FromBody] ReportInputModel reportInputModel)
        {
            if (reportInputModel != null)
            {
                var result = await _reportRepository.GenerateReport(reportInputModel.Type, reportInputModel.Month,
                  DateTime.Parse(reportInputModel.FromDate), DateTime.Parse(reportInputModel.Todate)).ConfigureAwait(false);
                return Ok(result);
            }
            //here i can not use try catch as i implemented above for demo purpose
            return BadRequest("return with invalid arguments");
        }

        //Model Price Changes So we should take the price and comparision with the unit.
        [HttpPost]
        [Route("newprice")]
        public async Task<IActionResult> GetNewReport([FromBody] string brandName)
        {
          if(string.IsNullOrEmpty(brandName)) return BadRequest("return with invalid arguments");
            var result = await _reportRepository.GetBrandPrice(brandName).ConfigureAwait(false);
                return Ok(result);
        }

        [HttpPost]
        [Route("addmobile")]
        public async Task<IActionResult> AddMobileAsync([FromBody] MobileShopModel mobileShopModel)
        {
            if (mobileShopModel == null)
            {
                return BadRequest("Information is null.");
            }
            await _mobileCRUDRepository.AddAsync(mobileShopModel);
            return Ok("inserted");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] MobileShopModel value)
        {
            if (value == null)
            {
                return BadRequest("Value is null.");
            }
            MobileShopModel dataUpdate = await _mobileCRUDRepository.GetAsync(id);
            if (dataUpdate == null)
            {
                return NotFound("The Mobile couldn't be found.");
            }
            var result = await _mobileCRUDRepository.UpdateAsync(dataUpdate, value);

            return Ok(result);
        }

        // DELETE api/<MobileShopController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            MobileShopModel dataUpdate = await _mobileCRUDRepository.GetAsync(id);
            if (dataUpdate == null)
            {
                return NotFound("The Mobile couldn't be found.");
            }
            var result = await _mobileCRUDRepository.DeleteAsync(dataUpdate);
            return Ok(result);
        }
    }
}
