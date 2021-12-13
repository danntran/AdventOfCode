using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Puzzle13
{
    internal class Program
    {
        public static byte[] TrimEnd(byte[] array)
        {
            int lastIndex = Array.FindLastIndex(array, b => b != 0);
            Array.Resize(ref array, lastIndex + 1);
            return array;
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
            char[] delims = new[] { '\r', '\n', ',' };
            List<string> il = new List<string>((inputstr.Split(delims, StringSplitOptions.RemoveEmptyEntries)).ToList());
            List<int> iln = il.Select(s => int.Parse(s)).ToList();
            List<int[]> foldalong = new List<int[]> { new int[] { 655, 0 }, new int[] { 0, 447 }, new int[] { 327, 0 }, new int[] { 0, 223 }, new int[] { 163, 0 }, new int[] { 0, 111 }, new int[] { 81, 0 }, new int[] { 0, 55 }, new int[] { 40, 0 }, new int[] { 0, 27 }, new int[] { 0, 13 }, new int[] { 0, 6 } };

            //find maximum x and y
            int maxx = 0;
            int maxy = 0;
            for(int i = 1; i < iln.Count(); i += 2)
            {
                if (iln[i - 1]+1 > maxx) maxx = iln[i - 1]+1;
                if (iln[i]+1 > maxy) maxy = iln[i]+1;
            }

            int[,] map = new int[maxy, maxx];
            for(int i = 1; i < iln.Count; i += 2)
            {
                map[iln[i], iln[i-1]] += 1;
            }

            List<int[]> oldmap = new List<int[]>();
            for (int i = 0; i < map.GetLength(0); i++)
            {
                int[] temp = new int[map.GetLength(1)];
                for (int n = 0; n < temp.Length; n++)
                {
                    temp[n] = map[i, n];
                }

                oldmap.Add(temp);
            }

            foreach ( int[] folds in foldalong)
            {
                List<int[]> tempmap = new List<int[]>();
                if (folds[0] > 0)
                {
                    for (int i = 0; i < oldmap.Count(); i++)
                    {
                        int[] array = new int[(oldmap[0].Count() -1) / 2];
                        for (int j = 0; j < (oldmap[0].Count() - 1) / 2; j++)
                        {
                            if (oldmap[i][j] == 1 || oldmap[i][oldmap[0].Count() - 1 - j] == 1)
                            {
                                array[j] = 1;
                            }
                        }
                        tempmap.Add(array);
                    }
                }
                if (folds[1] > 0)
                {
                    for (int i = 0; i < (oldmap.Count() - 1)/2; i++)
                    {
                        int[] array = new int[oldmap[0].Count()];
                        for (int j = 0; j < oldmap[0].Count(); j++)
                        {
                            if (oldmap[i][j] == 1 || oldmap[oldmap.Count() - 1 - i][j] == 1)
                            {
                                array[j] = 1;
                            }
                        }
                        tempmap.Add(array);
                    }
                }
                oldmap.Clear();
                for (int i = 0; i < tempmap.Count(); i++)
                {
                    int[] temp = new int[tempmap[0].Count()];
                    for (int n = 0; n < temp.Length; n++)
                    {
                        temp[n] = tempmap[i][n];
                    }

                    oldmap.Add(temp);
                }
            }

            int result = 0;
            foreach (int[] array in oldmap)
            {
                foreach (int num in array)
                {
                    result += num;
                }
            }

            Console.WriteLine("Part 1 - {0}, {1}, {2}", result, true, true);
            Console.WriteLine("Part 2 - {0}, {1}, {2}", true, true, true);

            foreach (int[] array in oldmap)
            {
                foreach (int num in array)
                {
                    if(num == 1)
                    {
                        Console.Write("# ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.Write("\n");
            }

            Console.WriteLine("End of Program .");
        }
    }
}
