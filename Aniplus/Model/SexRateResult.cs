﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Aniplus_Api.Model
{
    public class SexRateListData
    {
        public int man { get; set; }
        public int woman { get; set; }
    }
    public class SexRateResult
    {
        public int intReturn { get; set; }
        public SexRateListData[] listData { get; set; }
    }
}
