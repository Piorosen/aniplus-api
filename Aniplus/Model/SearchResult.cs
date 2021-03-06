﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Aniplus_Api.Model
{
    public class SearchListData
    {
        public string segNo{ get; set; }
        public int contentSerial{ get; set; }
        public string title{ get; set; }
        public string genreName{ get; set; }
        public string img{ get; set; }
        public string overImg{ get; set; }
        public string restrictionCode{ get; set; }
        public string opening{ get; set; }
        public string director{ get; set; }
        public string contentSysnopsis{ get; set; }
        public int wishFlag{ get; set; }
        public int? contentPartSerial{ get; set; }
        public string subTitle{ get; set; }

        public SearchListData() { }

        public SearchListData(AnimeListData anime)
        {
            segNo = "0";
            contentSerial = anime.contentSerial;
            title = anime.title;
            genreName = anime.genreName;
            img = anime.imageL;
            overImg = anime.thumbImg;
            restrictionCode = anime.restrictionCode;
            opening = anime.opening;
            director = anime.director;
            contentSysnopsis = anime.synopsis;
            wishFlag = 0;
            contentPartSerial = anime.contentPartSerial;
            subTitle = anime.subTitle;
        }
    }

    public class SearchResult
    {
        public int intReturn { get; set; }
        public int? con{ get; set; }
        public int? pageCount{ get; set; }
        public SearchListData[] listData { get; set; }
    }
}
