using System;
namespace aniplus_api
{
    public class CharacterListData
    {
        public int contentSerial;
        public int stepIdx;
        public string stepName;
        public string stepImage;
        public int rank;
        public int stepLike;
        public string comment;
        public int cv_Idx;
        public string kname;
    }

    public class CharactersResult
    {
        public int intReturn;
        public CharacterListData[] listData;
    }
}
