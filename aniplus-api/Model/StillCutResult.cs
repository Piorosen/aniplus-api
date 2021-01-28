using System;
namespace Aniplus_Api.Model
{
    public class StillCutListData
    {
        public int idx { get; set; }
        public int contentSerial { get; set; }
        public string thumb { get; set; }
        public string photo { get; set; }
    }
    public class StillCutResult
    {
        public int intReturn { get; set; }
        public StillCutListData[] listData { get; set; }
    }
}
