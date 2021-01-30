using Aniplus_Api;
using System;
using System.IO;

namespace TestCuiAniplus
{
    class Program
    {
        static void Help()
        {
            Console.WriteLine("clear");
            Console.WriteLine("search \"애니메이션 제목\"");
            Console.WriteLine("download 2006");
            Console.WriteLine("download 2006 > 저장 폴더");
        }

        static void SearchHelp(string command)
        {
            Console.WriteLine("해당 검색 명령어는 잘못되었습니다.");
            Console.WriteLine("example : clear");
            Console.WriteLine("example: search \"3D\"");
            Console.WriteLine("");
            Console.WriteLine("example: download 2006");
            Console.WriteLine("example: download 2006 > 저장 폴더");
        }

        static void Download(Anime anime, string output)
        {
            if (output == null || output == string.Empty)
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
            else
            {
                using StreamWriter sw = new StreamWriter(output);

                sw.WriteLine(anime.Info.title);
                var more = anime.MoreInfo.GetType().GetProperties();
                sw.WriteLine("\tMoreInfo: -");
                foreach (var m in more)
                {
                    sw.Write("\t\t");
                    sw.WriteLine($"{m.Name} : {m.GetValue(anime.MoreInfo)}");
                }

                sw.WriteLine("\tVideoInfo: -");
                foreach (var m in anime.Videos)
                {
                    var obj = m.GetType().GetProperties();
                    foreach (var t in obj)
                    {
                        sw.Write("\t\t");
                        sw.WriteLine($"{t.Name} : {t.GetValue(m)}");
                    }
                }

                sw.WriteLine("\tCharactersInfo: -");
                foreach (var m in anime.Characters)
                {
                    var obj = m.GetType().GetProperties();
                    foreach (var t in obj)
                    {
                        sw.Write("\t\t");
                        sw.WriteLine($"{t.Name} : {t.GetValue(m)}");
                    }
                }

                sw.WriteLine("\tStillCuts: -");
                foreach (var m in anime.StillCuts)
                {
                    var obj = m.GetType().GetProperties();
                    foreach (var t in obj)
                    {
                        sw.Write("\t\t");
                        sw.WriteLine($"{t.Name} : {t.GetValue(m)}");
                    }
                }

                var ratio = anime.Ratio;
                sw.WriteLine("\tRatio: -");
                sw.WriteLine($"\t\tSexRatio: (man: {ratio.SexRatio.man}, woman: {ratio.SexRatio.woman})");


                sw.WriteLine($"\t\tStarRatio: -");
                foreach (var item in anime.Ratio.StarRatio)
                {
                    sw.WriteLine($"\t\t\t점수 : {item.star}, 인원 {item.starCount}");
                }

                sw.WriteLine($"\t\tAgeRatio: -");
                foreach (var item in anime.Ratio.AgeRatio)
                {
                    foreach (var m in item.GetType().GetProperties())
                    {
                        sw.WriteLine($"\t\t\t나이 : {m.Name}, 인원 {m.GetValue(item)}");
                    }
                }

            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("$> ");
                var command = Console.ReadLine();

                var c = command.Split(" ")[0];
                switch (c)
                {
                    case "clear":
                        Console.Clear();
                        break;
                    case "help":
                        Help();
                        break;
                    case "search":
                        if (command.IndexOf(' ') == -1)
                        {
                            SearchHelp(command);
                            break;
                        }

                        var search = command.Substring(command.IndexOf(' ')).Trim(' ', '\t', '\"', '\'', '\n', '\r');
                        var s = AniplusSeach.Search(search);
                        Array.Sort<Anime>(s, (a, b) => { return a.Info.contentSerial - b.Info.contentSerial; });
                        foreach (var item in s)
                        {
                            Console.WriteLine($"{item.Info.contentSerial} - {item.Info.title}");
                        }
                        break;

                    case "download":
                        if (command.IndexOf(' ') == -1)
                        {
                            SearchHelp(command);
                            break;
                        }
                        string output = null;
                        int firstSpace = command.IndexOf(' ');
                        int firstRight = command.IndexOf('>');
                        int length = command.Length;
                        string intRange = string.Empty;

                        if (firstRight != -1)
                        {
                            output = command.Substring(firstRight + 1).Trim();
                        }
                        if (firstRight != -1)
                        {
                            intRange = command.Substring(firstSpace, firstRight - firstSpace).Trim(' ', '\t', '\"', '\'', '\n', '\r');
                        }else
                        {
                            intRange = command.Substring(firstSpace).Trim(' ', '\t', '\"', '\'', '\n', '\r');
                        }

                        if (int.TryParse(intRange, out int result))
                        {
                            Download(AniplusSeach.Search(result), output);
                        }else
                        {
                            SearchHelp(command);
                        }
                        break;
                    default:
                        Help();
                        break;
                }
            }

        }
    }
}
