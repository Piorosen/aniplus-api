using System;
using System.Collections.Generic;
using System.Text;

namespace aniplus_api
{
    public class StarRateListData
    {
        public int star { get; set; }
        public int starCount { get; set; }
    }
    public class StarRateResult
    {
        public int intReturn { get; set; }
        public int con { get; set; }
        public int maxCount { get; set; }
        public int avgCount { get; set; }
        public StarRateListData[] listData { get; set; }
    }
}
