﻿using System;
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



    }
}