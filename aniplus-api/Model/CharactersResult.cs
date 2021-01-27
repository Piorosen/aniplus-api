using System;
namespace aniplus_api.Model
{
    public class CharacterListData
    {
        public int contentSerial{ get; set; }
        public int stepIdx{ get; set; }
        public string stepName{ get; set; }
        public string stepImage{ get; set; }
        public int rank{ get; set; }
        public int stepLike{ get; set; }
        public string comment{ get; set; }
        public int cv_Idx{ get; set; }
        public string kname{ get; set; }
    }

    public class CharactersResult
    {
        public int intReturn{ get; set; }
        public CharacterListData[] listData{ get; set; }
    }
}
