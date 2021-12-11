using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Puzzle11
{
    internal class Program
    {
        public static int incrementaround(List<int[]> iln, List<int[]> flagmap, int i, int j)
        {
            int count = 0;
            if (iln[i][j] > 9 && flagmap[i][j] == 0)
            {
                flagmap[i][j] = 1;
                count += 1;
                Boolean checktl = true;
                Boolean checktm = true;
                Boolean checktr = true;
                Boolean checkl = true;
                Boolean checkr = true;
                Boolean checkbl = true;
                Boolean checkbm = true;
                Boolean checkbr = true;

                if (i == 0)
                {
                    checktl = false;
                    checktm = false;
                    checktr = false;
                }
                if (i == iln.Count() -1)
                {
                    checkbl = false;
                    checkbm = false;
                    checkbr = false;
                }
                if (j == 0)
                {
                    checktl = false;
                    checkl = false;
                    checkbl = false;
                }
                if (j == iln[0].Count() - 1)
                {
                    checktr = false;
                    checkr = false;
                    checkbr = false;
                }

                if (checktl)
                {
                    int drow = -1;
                    int dcol = -1;
                    iln[i + drow][j + dcol] += 1;
                    if (iln[i + drow][j + dcol] > 9)
                    {
                        count += incrementaround(iln,flagmap,i+drow,j+dcol);   
                    }
                }
                if (checktm)
                {
                    int drow = -1;
                    int dcol = 0;
                    iln[i + drow][j + dcol] += 1;
                    if (iln[i + drow][j + dcol] > 9)
                    {
                        count += incrementaround(iln, flagmap, i + drow, j + dcol);
                    }
                }
                if (checktr)
                {
                    int drow = -1;
                    int dcol = +1;
                    iln[i + drow][j + dcol] += 1;
                    if (iln[i + drow][j + dcol] > 9)
                    {
                        count += incrementaround(iln, flagmap, i + drow, j + dcol);
                    }
                }
                if (checkl)
                {
                    int drow = 0;
                    int dcol = -1;
                    iln[i + drow][j + dcol] += 1;
                    if (iln[i + drow][j + dcol] > 9)
                    {
                        count += incrementaround(iln, flagmap, i + drow, j + dcol);
                    }
                }
                if (checkr)
                {
                    int drow = 0;
                    int dcol = +1;
                    iln[i + drow][j + dcol] += 1;
                    if (iln[i + drow][j + dcol] > 9)
                    {
                        count += incrementaround(iln, flagmap, i + drow, j + dcol);
                    }
                }
                if (checkbl)
                {
                    int drow = +1;
                    int dcol = -1;
                    iln[i + drow][j + dcol] += 1;
                    if (iln[i + drow][j + dcol] > 9)
                    {
                        count += incrementaround(iln, flagmap, i + drow, j + dcol);
                    }
                }
                if (checkbm)
                {
                    int drow = +1;
                    int dcol = 0;
                    iln[i + drow][j + dcol] += 1;
                    if (iln[i + drow][j + dcol] > 9)
                    {
                        count += incrementaround(iln, flagmap, i + drow, j + dcol);
                    }
                }
                if (checkbr)
                {
                    int drow = +1;
                    int dcol = +1;
                    iln[i + drow][j + dcol] += 1;
                    if (iln[i + drow][j + dcol] > 9)
                    {
                        count += incrementaround(iln, flagmap, i + drow, j + dcol);
                    }
                }
            }

            return count;
        }
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
            char[] delims = new[] { '\r', '\n', '|' };
            List<string> il = new List<string>((inputstr.Split(delims, StringSplitOptions.RemoveEmptyEntries)).ToList());

            List<int[]> iln = new List<int[]>();
            for (int i = 0; i < il.Count(); i++)
            {
                int[] nums = new int[il[0].Count()];
                for (int j = 0; j < il[0].Count(); j++)
                {
                    nums[j] = Int32.Parse(il[i][j].ToString());
                }
                iln.Add(nums);
            }

            int count = 0;
            List<int> solpar2 = new List<int>();
            for (int x = 0; x < 1000; x++)
            {
                for (int i = 0; i < iln.Count(); i++)
                {
                    for (int j = 0; j < iln[0].Count(); j++)
                    {
                        iln[i][j] += 1;
                    }
                }
                List<int[]> flagmap = new List<int[]>();
                for (int i = 0; i < iln.Count(); i++)
                {
                    flagmap.Add(new int[iln[0].Count()]);
                }

                for (int i = 0; i < iln.Count(); i++)
                {
                    for (int j = 0; j < iln[0].Count(); j++)
                    {
                        count += incrementaround(iln, flagmap, i, j);
                    }
                }
                int count2 = 0;
                for (int i = 0; i < iln.Count(); i++)
                {
                    for (int j = 0; j < iln[0].Count(); j++)
                    {
                        if(iln[i][j] > 9)
                        {
                            iln[i][j] = 0;
                            count2 += 1;
                        }
                    }
                }
                if (count2 == 100)
                {
                    solpar2.Add(x);
                }

            }
            solpar2.Sort();
            Console.WriteLine("Part 1 - {0}, {1}, {2}", count, true, true);
            Console.WriteLine("Part 2 - {0}, {1}, {2}", solpar2[0]+1, true, true);
            Console.WriteLine("End of Program .");
        }
    }
}
