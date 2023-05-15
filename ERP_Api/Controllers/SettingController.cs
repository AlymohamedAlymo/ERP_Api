using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_Data.Interfaces;
using ERP_Data.Database_Models;

namespace ERP_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private IERP_Setting Setting;
        public SettingController(IERP_Setting _Setting)
        {
            this.Setting = _Setting;


        }



        [HttpGet]
        [Route("GetQuantityoftheItem/{IDItem}")]
        public ActionResult<decimal> GetQuantityoftheItem(int IDItem)
        {
            try
            {
                var dt = Setting.GetQuantityoftheItem(IDItem);

                return dt;
            }
            catch
            {
                return 0;
            }

        }




        [HttpGet]
        [Route("GetStoragePlaceData/{IDItem}")]
        public ActionResult<object> GetStoragePlaceData(int IDItem)
        {

            try
            {
               var dt = Setting.GetStoragePlaceData(IDItem);
                return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            }
            catch
            {
                return null;
            }
        }


        [HttpGet]
        [Route("GetPrintingSetting/{IDReport}")]
        public ActionResult<PrintSetting> GetPrintingSetting(int IDReport)
        {
            try { return Setting.GetPrintingSetting(IDReport); }
            catch { return null; }
        }


        [HttpPost]
        [Route("UpdatePrintingSetting")]
        public ActionResult<int> UpdatePrintingSetting([FromBody] PrintSetting PSetting)
        {
            try
            {
                return Setting.UpdatePrintingSetting(PSetting);
            }
            catch (Exception EX) { return EX.HResult; }
        }






    }
}
