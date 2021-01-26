using System;
namespace aniplus_api
{
    public class VideoListData
    {
        int contentSerial;
        int contentPartSerial;
        string title;
        int part;
        string subTitle;
        int subPartSerial;
        int subPartSerial3;
        string img;
        string overImg;
        bool active;
        string activeFlag;
        bool aniplusFree;
        bool pointActive;
        int chkFree;
        int chk1080p;
        bool downActive;
        int pos;
        string mediaTime;
        string opening;
        string contentEpisode;
        string updateDate;
        int wishFlag;
        string vodSupport;
        string downSupport;
        int vodPrice;
        int downPrice;
        int downExist;
    }

    public class VideoResult
    {
        int intReturn;
        VideoListData[] listData;
    }
}
