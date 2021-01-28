using System;
namespace Aniplus_Api.Model
{
    public class AnimeListData
    {
        public int contentSerial{ get; set; }
        public string title{ get; set; }
        public string otitle{ get; set; }
        public string production{ get; set; }
        public string director{ get; set; }
        public int number{ get; set; }
        public string country{ get; set; }
        public string makeYear{ get; set; }
        public string genreCode{ get; set; }
        public string genreName{ get; set; }
        public string imageL{ get; set; }
        public string imageLO{ get; set; }
        public string thumbImg{ get; set; }
        public int gubun{ get; set; }
        public string restrictionCode{ get; set; }
        public string opening{ get; set; }
        public string ending{ get; set; }
        public string pv{ get; set; }
        public int rank{ get; set; }
        public int contentPartSerial{ get; set; }
        public int subPartSerial2{ get; set; }
        public int subPartSerial3{ get; set; }
        public int part{ get; set; }
        public string subTitle{ get; set; }
        public int init_contentPartSerial{ get; set; }
        public int init_subPartSerial2{ get; set; }
        public int init_subPartSerial3{ get; set; }
        public int init_part{ get; set; }
        public string init_subTitle{ get; set; }
        public string vodSupport{ get; set; }
        public string downSupport{ get; set; }
        public string synopsis{ get; set; }
    }

    public class AnimeResult
    {
        public int intReturn{ get; set; }
        public AnimeListData[] listData{ get; set; }
    }
}
