using System;
using System.Linq;
using Aniplus_Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAniplusApi
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SearchTest3DGirl()
        {
            var a = AniPlusApi.Search("3D 그녀 리얼걸");
            if (a.Length == 1)
            {
                if (a[0].pageCount == 1 && a[0].listData[0].contentSerial == 2006)
                {
                    return;
                }
            }
            Assert.Fail();
        }

        [TestMethod]
        public void SearchTestFailTest()
        {
            var api = new Aniplus_Api.AniPlusApi();
            var a = AniPlusApi.Search("asdf");
            if (a.Length == 1)
            {
                if (a[0].pageCount == null && a[0].listData.Length == 0)
                {
                    return;
                }
            }
            Assert.Fail();
        }

        [TestMethod]
        public void SearchTestIdolMaster()
        {
            var a = AniPlusApi.Search("아이돌 마스터");
            if (a.Length == 1)
            {
                if (a[0].listData.Length == 10)
                {
                    return;
                }
            }
            Assert.Fail();
        }

        [TestMethod]
        public void AnimeResultCheck()
        {
            var p = AniPlusApi.GetAnimeInformation(2006);

            if (p.Length == 1)
            {
                if (p[0].listData.Length == 1)
                {
                    if (p[0].listData[0].contentSerial == 2006 && p[0].listData[0].director == "나오야 타카시")
                    {
                        return;
                    }
                }
            }
            Assert.Fail();
        }

        [TestMethod]
        public void AnimeResultCheckFail()
        {
            var p = AniPlusApi.GetAnimeInformation(2006);

            if (p.Length == 1)
            {
                if (p[0].listData.Length == 1)
                {
                    if (p[0].listData[0].contentSerial == 2006 && p[0].listData[0].director == "나오야 타카시")
                    {
                        return;
                    }
                }
            }
            Assert.Fail();
        }
        //1414
        [TestMethod]
        public void ssss()
        {
            var p = AniPlusApi.GetCharactersInformation(1414);

        }


        [TestMethod]
        public void VideoResultCheck()
        {
            var p = AniPlusApi.GetVideoInformation(0);
            if (p[0].listData != null)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void StillVideo()
        {
            var p = AniPlusApi.GetStillCutImage(1414);
            if (p[0].listData != null)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void aaa()
        {
            var list = AniplusSeach.Search("아이돌 마스터");
            foreach (var anime in list)
            {
                Console.WriteLine(anime.Info.title);
                foreach (var video in anime.Videos.Reverse())
                {
                    Console.Write("\t");
                    Console.WriteLine(video.subTitle);
                }
            }
        }

        [TestMethod]
        public void AllTest()
        {
            var anilist = AniplusSeach.Search("소드 아트 온라인");
            foreach (var anime in anilist)
            {
                Console.WriteLine(anime.Info.title);
                var more = anime.MoreInfo.GetType().GetProperties();
                Console.WriteLine("\tMoreInfo: -");
                foreach (var m in more)
                {
                    Console.Write("\t\t");
                    Console.WriteLine($"{m.Name} : {m.GetValue(anime.MoreInfo)}");
                }

                Console.WriteLine("\tVideoInfo: -");
                foreach (var m in anime.Videos)
                {
                    var obj = m.GetType().GetProperties();
                    foreach (var t in obj)
                    {
                        Console.Write("\t\t");
                        Console.WriteLine($"{t.Name} : {t.GetValue(m)}");
                    }
                }

                Console.WriteLine("\tCharactersInfo: -");
                foreach (var m in anime.Characters)
                {
                    var obj = m.GetType().GetProperties();
                    foreach (var t in obj)
                    {
                        Console.Write("\t\t");
                        Console.WriteLine($"{t.Name} : {t.GetValue(m)}");
                    }
                }

                Console.WriteLine("\tStillCuts: -");
                foreach (var m in anime.StillCuts)
                {
                    var obj = m.GetType().GetProperties();
                    foreach (var t in obj)
                    {
                        Console.Write("\t\t");
                        Console.WriteLine($"{t.Name} : {t.GetValue(m)}");
                    }
                }

                var ratio = anime.Ratio;
                Console.WriteLine("\tRatio: -");
                Console.WriteLine($"\t\tSexRatio: (man: {ratio.SexRatio.man}, woman: {ratio.SexRatio.woman})");


                Console.WriteLine($"\t\tStarRatio: -");
                foreach (var item in anime.Ratio.StarRatio)
                {
                    Console.WriteLine($"\t\t\t점수 : {item.star}, 인원 {item.starCount}");
                }

                Console.WriteLine($"\t\tAgeRatio: -");
                foreach (var item in anime.Ratio.AgeRatio)
                {
                    foreach (var m in item.GetType().GetProperties())
                    {
                        Console.WriteLine($"\t\t\t나이 : {m.Name}, 인원 {m.GetValue(item)}");
                    }
                }
            }
        }

    }
}
