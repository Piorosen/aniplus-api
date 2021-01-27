using System;
using System.Linq;
using aniplus_api.Model;

namespace aniplus_api
{
    sealed public class Anime
    {
        public Video[] Videos
        {
            get
            {
                if (m_Video == null)
                {
                    var result = AniPlusApi.GetVideoInformation(Info.contentSerial);
                    m_Video = result.Select((item) => item.listData)
                        .Where((item) => item != null)
                        .SelectMany((item) => item)
                        .Select((item) => new Video(item))
                        .ToArray();
                }
                return m_Video;
            }
        }
        public Character[] Characters
        {
            get
            {
                if (m_Characters == null)
                {
                    var result = AniPlusApi.GetCharactersInformation(Info.contentSerial);
                    m_Characters = result.Select((item) => item.listData)
                        .Where((item) => item != null)
                        .SelectMany((item) => item)
                        .Select((item) => new Character())
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
        public StillCut[] StillCuts
        {
            get
            {
                if (m_StillCuts == null)
                {
                    var result = AniPlusApi.GetStillCutImage(Info.contentSerial);
                    m_StillCuts = result.Select((item) => item.listData)
                        .Where((item) => item != null)
                        .SelectMany((item) => item)
                        .Select((item) => new StillCut())
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

        private Video[] m_Video = null;
        private Character[] m_Characters;
        private Ratio m_Ratio = null;
        private StillCut[] m_StillCuts = null;
        private AnimeListData[] m_MoreInfo = null;

        public SearchListData Info { get; private set; }

        public Anime(SearchListData item)
        {
            Info = item;
        }
    }
}
