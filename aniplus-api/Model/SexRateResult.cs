using System;
using System.Collections.Generic;
using System.Text;

namespace aniplus_api
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
