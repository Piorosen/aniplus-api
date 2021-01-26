using System;
using System.Collections.Generic;
using System.Text;

namespace aniplus_api
{
    public class StarRateListData
    {
        public int star;
        public int starCount;
    }
    public class StarRateResult
    {
        public int intReturn;
        public int con;
        public int maxCount;
        public int avgCount;
        public StarRateListData[] listData;
    }
}
