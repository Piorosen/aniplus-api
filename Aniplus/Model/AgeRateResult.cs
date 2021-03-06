﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Aniplus_Api.Model
{
    public class AgeRateListData
    {
        public int age10 { get; set; }
        public int age20 { get; set; }
        public int age30 { get; set; }
        public int age40 { get; set; }
        public int age50 { get; set; }
    }
    public class AgeRateResult
    {
        public int intReturn{ get; set; }
        public int maxSum{ get; set; }
        public AgeRateListData[] listData{ get; set; }
    }
}
