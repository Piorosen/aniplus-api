using System;
using aniplus_api;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAniplusApi
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SearchTest3DGirl()
        {
            var api = new aniplus_api.AniPlusApi();
            var a = api.Search("3D 그녀 리얼걸");
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
            var api = new aniplus_api.AniPlusApi();
            var a = api.Search("asdf");
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
            var api = new aniplus_api.AniPlusApi();
            var a = api.Search("아이돌 마스터");
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
            var p = new aniplus_api.AniPlusApi().GetAnimeInformation(2006);

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
            var p = new aniplus_api.AniPlusApi().GetAnimeInformation(2006);

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
        public void VideoResultCheck()
        {
            var api = new aniplus_api.AniPlusApi();
            var p = api.GetVideoInformation(0);
            if (p[0].listData != null)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void StillVideo()
        {
            var api = new aniplus_api.AniPlusApi();
            var p = api.GetStillCutImage(1414);
            if (p[0].listData != null)
            {
                Assert.Fail();
            }
        }
    }
}
