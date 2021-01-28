using System;
namespace Aniplus_Api.Model
{
    public class VideoListData
    {
        public int contentSerial { get; set; }
        public int contentPartSerial { get; set; }
        public string title { get; set; }
        public int part { get; set; }
        public string subTitle { get; set; }
        public int subPartSerial { get; set; }
        public int subPartSerial3 { get; set; }
        public string img { get; set; }
        public string overImg { get; set; }
        public bool active { get; set; }
        public string activeFlag { get; set; }
        public bool aniplusFree { get; set; }
        public bool pointActive { get; set; }
        public int chkFree { get; set; }
        public int chk1080p { get; set; }
        public bool downActive { get; set; }
        public int pos { get; set; }
        public string mediaTime { get; set; }
        public string opening { get; set; }
        public string contentEpisode { get; set; }
        public string updateDate { get; set; }
        public int wishFlag { get; set; }
        public string vodSupport { get; set; }
        public string downSupport { get; set; }
        public int vodPrice { get; set; }
        public int downPrice { get; set; }
        public int downExist { get; set; }
    }

    public class VideoResult
    {
        public int intReturn { get; set; }
        public VideoListData[] listData { get; set; }
    }
}
