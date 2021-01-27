using System;
using System.Collections.Generic;
using System.Linq;

namespace aniplus_api
{
    public class AniplusSeach
    {

        public AniplusSeach()
        {
        }

        public Anime[] Search(string query, int page = 1, string userId = "")
        {
            var searchResults = AniPlusApi.Search(query, page, userId);;

            if (searchResults.Length == 0)
            {
                return new Anime[0];
            }

            return searchResults.Where((item) => item.listData != null)
                .SelectMany((item) => item.listData)
                .Select((item) => new Anime(item))
                .ToArray();
        }
    }
}
