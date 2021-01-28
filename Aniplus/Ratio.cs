using System;
using System.Linq;
using Aniplus_Api.Model;

namespace Aniplus_Api
{
    public class Ratio
    {
        protected AgeRateListData[] m_AgeRatio = null;
        protected SexRateListData[] m_SexRatio = null;
        protected StarRateListData[] m_StarRatio = null;

        public AgeRateListData[] AgeRatio
        {
            get
            {
                if (m_AgeRatio == null)
                {
                    var result = AniPlusApi.GetAgeRateInformation(ContentSerial);
                    m_AgeRatio = result.Where((item) => item.listData != null)
                        .SelectMany((item) => item.listData)
                        .ToArray();
                }
                return m_AgeRatio;
            }
        }
        public SexRateListData SexRatio
        {
            get
            {
                if (m_SexRatio == null)
                {
                    var result = AniPlusApi.GetSexRateInformation(ContentSerial);
                    m_SexRatio = result.Where((item) => item.listData != null)
                        .SelectMany((item) => item.listData)
                        .ToArray();
                }

                return m_SexRatio.FirstOrDefault();
            }
        }
        public StarRateListData[] StarRatio
        {
            get
            {
                if (m_StarRatio == null)
                {
                    var result = AniPlusApi.GetStarRateInformation(ContentSerial);
                    m_StarRatio = result.Where((item) => item.listData != null)
                        .SelectMany((item) => item.listData)
                        .ToArray();
                }
                return m_StarRatio;
            }
        }

        public int ContentSerial { get; private set; }

        public Ratio(int contentSerial)
        {
            this.ContentSerial = contentSerial;
        }
    }
}
