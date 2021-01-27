using System;
using aniplus_api.Model;

namespace aniplus_api
{
    public class Ratio
    {
        protected AgeRateResult[] m_AgeRatio = null;
        protected SexRateResult[] m_SexRatio = null;
        protected StarRateResult[] m_StarRatio = null;

        public AgeRateResult[] AgeRatio
        {
            get
            {
                if (m_AgeRatio == null)
                {
                    m_AgeRatio = new AniPlusApi().GetAgeRateInformation(ContentSerial);
                }
                return m_AgeRatio;
            }
        }
        public SexRateResult[] SexRatio
        {
            get
            {
                if (m_SexRatio == null)
                {
                    m_SexRatio = new AniPlusApi().GetSexRateInformation(ContentSerial);
                }
                return m_SexRatio;
            }
        }
        public StarRateResult[] StarRatio
        {
            get
            {
                if (m_StarRatio == null)
                {
                    m_StarRatio = new AniPlusApi().GetStarRateInformation(ContentSerial);
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
