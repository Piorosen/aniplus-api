using System;
using System.Linq;
using Aniplus_Api.Model;

namespace Aniplus_Api
{
    sealed public class Anime
    {
        public VideoListData[] Videos
        {
            get
            {
                if (m_Video == null)
                {
                    var result = AniPlusApi.GetVideoInformation(Info.contentSerial);
                    m_Video = result.Select((item) => item.listData)
                        .Where((item) => item != null)
                        .SelectMany((item) => item)
                        .OrderBy((item) => item.part)
                        .ToArray();
                }
                return m_Video;
            }
        }
        public CharacterListData[] Characters
        {
            get
            {
                if (m_Characters == null)
                {
                    var result = AniPlusApi.GetCharactersInformation(Info.contentSerial);
                    m_Characters = result.Select((item) => item.listData)
                        .Where((item) => item != null)
                        .SelectMany((item) => item)
                        .ToArray();
                }
                return m_Characters;
            }
        }
        public Ratio Ratio
        {
            get
            {
                if (m_Ratio == null)
                {
                    m_Ratio = new Ratio(Info.contentSerial);
                }
                return m_Ratio;
            }
        }
        public StillCutListData[] StillCuts
        {
            get
            {
                if (m_StillCuts == null)
                {
                    var result = AniPlusApi.GetStillCutImage(Info.contentSerial);
                    m_StillCuts = result.Select((item) => item.listData)
                        .Where((item) => item != null)
                        .SelectMany((item) => item)
                        .ToArray();
                }
                return m_StillCuts;
            }
        }
        public AnimeListData MoreInfo
        {
            get
            {
                if (m_StillCuts == null)
                {
                    var result = AniPlusApi.GetAnimeInformation(Info.contentSerial);
                    m_MoreInfo = result.Select((item) => item.listData)
                        .Where((item) => item != null)
                        .SelectMany((item) => item)
                        .ToArray();
                }
                return m_MoreInfo.FirstOrDefault();
            }
        }

        private VideoListData[] m_Video = null;
        private CharacterListData[] m_Characters;
        private Ratio m_Ratio = null;
        private StillCutListData[] m_StillCuts = null;
        private AnimeListData[] m_MoreInfo = null;

        public SearchListData Info { get; private set; }

        public Anime(SearchListData item)
        {
            Info = item;
        }
        public Anime(AnimeListData moreInfo)
        {
            Info = new SearchListData(moreInfo);
        }
    }
}
