using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Data.Database_Models;

namespace ERP_Data.Interfaces
{
    public interface IERP_Setting
    {


        decimal GetQuantityoftheItem(int IDItem);

        object GetStoragePlaceData(int IDItem);

        /// <summary>
        /// Get Printing Setting
        /// </summary>
        /// <param name="IDReport">Report ID</param>
        /// <returns>object</returns>
        PrintSetting GetPrintingSetting(int IDReport);


        /// <summary>
        /// Update Printing Setting
        /// </summary>
        /// <param name="PSetting">Updated Setting</param>
        /// <returns>int</returns>
        int UpdatePrintingSetting(PrintSetting PSetting);
    }
}
