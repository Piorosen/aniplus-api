using System;
namespace aniplus_api
{
    public class Video
    {
        public Model.VideoListData data;
        public Video(Model.VideoListData data)
        {
            this.data = data;
        }
    }
}
