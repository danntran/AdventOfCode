using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Puzzle9
{
    internal class Program
    {
        public static class Globals
        {
            public const Int32 BUFFER_SIZE = 512; // Unmodifiable
            public static String FILE_NAME = "Output.txt"; // Modifiable
        }
        public static byte[] TrimEnd(byte[] array)
        {
            int lastIndex = Array.FindLastIndex(array, b => b != 0);
            Array.Resize(ref array, lastIndex + 1);
            return array;
        }
        public static int FindSmallestNumber(List<string> map, int xpos, int ypos)
        {
            List<int> adjac = new List<int> ();
            int xl = xpos;
            int yl = ypos;
            int curnum = Int32.Parse(map[ypos][xpos].ToString());
            for (int i = (xpos - 1 < 0 ? 0 : xpos - 1); i <= (xpos + 1 > map[0].Count() - 1 ? map[0].Count() - 1 : xpos + 1); i++)
            {
                for (int j = (ypos - 1 < 0 ? 0 : ypos - 1); j <= (ypos + 1 > map.Count() - 1 ? map.Count() - 1 : ypos + 1); j++)
                {
                    if (Int32.Parse(map[ypos][xpos].ToString()) > Int32.Parse(map[j][i].ToString()))
                    {
                        return -1;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return curnum;
        }

        public static int findbasin(List<string> map, List<int[]> flagmap, int ypos, int xpos)
        {
            int total = 0;
            if (flagmap[ypos][xpos] == 0 && Int32.Parse(map[ypos][xpos].ToString()) != 9)
            {
                flagmap[ypos][xpos] = 1;
                total += 1;
            }

            Boolean checkup = false;
            Boolean checkdown = false;
            Boolean checkleft = false;
            Boolean checkright = false;

            int ydel = 0;
            int xdel = 0;
            // check up
            ydel = -1;
            xdel = 0;
            if ( (ypos + ydel) >= 0 && flagmap[ypos+ydel][xpos+xdel] == 0 && Int32.Parse(map[ypos+ydel][xpos+xdel].ToString()) != 9)
            {
                flagmap[ypos+ydel][xpos+xdel] = 1;
                total += 1;
                checkup = true;
            }
            // checkdown
            ydel = 1;
            xdel = 0;
            if ((ypos + ydel) < map.Count() && flagmap[ypos + ydel][xpos + xdel] == 0 && Int32.Parse(map[ypos + ydel][xpos + xdel].ToString()) != 9)
            {
                flagmap[ypos + ydel][xpos + xdel] = 1;
                total += 1;
                checkdown = true;
            }
            // checkleft
            ydel = 0;
            xdel = -1;
            if ((xpos + xdel) >= 0 && flagmap[ypos + ydel][xpos + xdel] == 0 && Int32.Parse(map[ypos + ydel][xpos + xdel].ToString()) != 9)
            {
                flagmap[ypos + ydel][xpos + xdel] = 1;
                total += 1;
                checkleft = true;
            }
            // checkright
            ydel = 0;
            xdel = 1;
            if ((xpos + xdel) < map[0].Count() && flagmap[ypos + ydel][xpos + xdel] == 0 && Int32.Parse(map[ypos + ydel][xpos + xdel].ToString()) != 9)
            {
                flagmap[ypos + ydel][xpos + xdel] = 1;
                total += 1;
                checkright = true;
            }

            if (checkup)
            {
                total += findbasin(map, flagmap, ypos - 1, xpos);
            }
            if (checkdown)
            {
                total += findbasin(map, flagmap, ypos + 1, xpos);
            }
            if (checkleft)
            {
                total += findbasin(map, flagmap, ypos, xpos - 1);
            }
            if (checkright)
            {
                total += findbasin(map, flagmap, ypos, xpos + 1);
            }
            return total;
        }

        static void Main(string[] args)
        {
            string path = @"..\..\..\input.txt";
            FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            byte[] b = new byte[1000000];
            UTF8Encoding data = new UTF8Encoding(true);
            while (fs.Read(b, 0, b.Length) > 0)
            {
                Console.WriteLine(data.GetString(TrimEnd(b)));
            }
            // put input data into a character string
            string inputstr = data.GetString(TrimEnd(b));
            // Characters to dlimit and split string by dlimtr
            char[] delims = new[] { '\r', '\n', '|' };
            List<string> vs = new List<string> (inputstr.Split(delims, StringSplitOptions.RemoveEmptyEntries).ToList());

            List<int> results = new List<int>();
            for(int i = 0; i< vs.Count(); i++)
            {
                for(int j =0; j < vs[0].Count(); j++)
                {
                    int v = FindSmallestNumber(vs, j, i);
                    if (!(v < 0))
                    {
                        results.Add(v+1);
                    }
                }
            }

            Console.WriteLine("Part 1 - {0}, {1}, {2}", results.Sum(), true, true);

            List<int[]> flagmap = new List<int[]>();
            for (int i = 0; i < vs.Count(); i++)
            {
                flagmap.Add(new int[vs[0].Count()]);
            }

            results.Clear();
            for (int i = 0; i < vs.Count(); i++)
            {
                for (int j =0; j<vs[0].Count(); j++)
                {
                    results.Add(findbasin(vs,flagmap,i,j));
                }
            }
            results.Sort();
            results.Reverse();
            Console.WriteLine("Part 2 - {0}, {1}, {2}", results[0] * results[1]* results[2], true, true);
            Console.WriteLine("End of Program .");
        }
    }
}
