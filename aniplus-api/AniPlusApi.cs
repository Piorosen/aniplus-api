using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace aniplus_api
{
    public class AniPlusApi
    {
        public AniPlusApi()
        {

        }

        private HttpWebRequest CreateWeb(string url)
        {
            var d = HttpWebRequest.CreateHttp(url);
            d.Method = "POST";
            d.Headers.Add("Connection", "keep-alive");
            d.Headers.Add("sec-ch-ua", "\"Google Chrome\"; v = \"87\", \" Not;A Brand\"; v = \"99\", \"Chromium\"; v = \"87\"");
            d.Headers.Add("Accept", "application/json, text/plain, */*'");
            d.Headers.Add("sec-ch-ua-mobile", "?0");
            d.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.141 Safari/537.36");
            d.Headers.Add("Content-Type", "application/json;charset=UTF-8");
            d.Headers.Add("Origin", "https://www.aniplustv.com");
            d.Headers.Add("Sec-Fetch-Site", "same-site");
            d.Headers.Add("Sec-Fetch-Mode", "cors");
            d.Headers.Add("Sec-Fetch-Dest", "empty");
            d.Headers.Add("Referer", "https://www.aniplustv.com/");
            d.Headers.Add("Accept-Language", "ko,ko-KR;q=0.9,en-US;q=0.8,en;q=0.7,ja;q=0.6");
            return d;
        }

        private bool WriteData(HttpWebRequest hwr, string data)
        {
            var en = Encoding.UTF8.GetBytes(data);
            using var stream = hwr.GetRequestStream();
            stream.Write(en, 0, en.Length);

            return true;
        }

        private string ReadData(HttpWebRequest hwr)
        {
            using var stream = hwr.GetResponse().GetResponseStream();
            using var reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }

        public SearchResult[] Search(string query, int page = 1, string userId = "")
        {
            var hwr = CreateWeb("https://api.aniplustv.com:3100/search");
            var str = "{\"params\":{\"userid\":\"" + userId + "\",\"strFind\":\"" + query + "\",\"gotoPage\":" + page.ToString() + "}}";

            WriteData(hwr, str);
            var result = ReadData(hwr);
            var data = JsonSerializer.Deserialize<SearchResult[]>(result);
            return data;
        }

        public StarRateResult[] GetStarRateInformation(int contentSerial)
        {
            var hwr = CreateWeb("https://api.aniplustv.com:3100/starRating");
            var str = "{params: {contentSerial: " + contentSerial + "}}";
            WriteData(hwr, str);
            var result = ReadData(hwr);
            var data = JsonSerializer.Deserialize<StarRateResult[]>(result);
            return data;
        }



        public AnimeResult[] GetAnimeInformation(int contentSerial)
        {
            WebClient wc = new WebClient();
            var result = wc.DownloadString($"https://api.aniplustv.com:3100/itemInfo?contentSerial={contentSerial}");

            var data = JsonSerializer.Deserialize<AnimeResult[]>(result);
            return data;
        }

        public VideoResult[] GetVideoInformation(int contentSerial, string userId = "")
        {
            WebClient wc = new WebClient();
            var result = wc.DownloadString($"https://api.aniplustv.com:3100/itemPart?contentSerial={contentSerial}&userid={userId}");
            var data = JsonSerializer.Deserialize<VideoResult[]>(result);
            return data;
        }

        public CharactersResult[] GetCharactersInformation(int contentSerial, string userId = "")
        {
            WebClient wc = new WebClient();
            var result = wc.DownloadString($"https://api.aniplustv.com:3100/stepList?contentSerial={contentSerial}&userid={userId}");
            var data = JsonSerializer.Deserialize<CharactersResult[]>(result);
            return data;
        }

        public StillCutResult[] GetStillCutImage(int contentSerial, string userId = "")
        {
            WebClient wc = new WebClient();
            var result = wc.DownloadString($"https://api.aniplustv.com:3100/stillcut?contentSerial={contentSerial}");
            var data = JsonSerializer.Deserialize<StillCutResult[]>(result);
            return data;
        }

        public SexRateResult[] GetSexRateInformation(int contentSerial)
        {
            WebClient wc = new WebClient();
            var result = wc.DownloadString($"https://api.aniplustv.com:3100/stillcut?contentSerial={contentSerial}");
            var data = JsonSerializer.Deserialize<SexRateResult[]>(result);
            return data;
        }

        public AgeRateResult[] GetAgeRateInformation(int contentSerial)
        {
            WebClient wc = new WebClient();
            var result = wc.DownloadString($"https://api.aniplustv.com:3100/stillcut?contentSerial={contentSerial}");
            var data = JsonSerializer.Deserialize<AgeRateResult[]>(result);
            return data;
        }



    }
}
