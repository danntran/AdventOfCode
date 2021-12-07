using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Puzzle5
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
            char[] delims = new[] { '\r', '\n' };
            string[] inputstrings = inputstr.Split(delims, StringSplitOptions.RemoveEmptyEntries);

            List<string[]> vs = new List<string[]>();
            foreach (string inputline in inputstrings )
            {
                vs.Add((Regex.Replace(inputline.Trim(), " -> ", ",")).Split(','));
            }

            List<string[]> verthorlines = new List<string[]>();
            List<string[]> diaglines = new List<string[]>();
            foreach (string[] line in vs)
            {
                if (line[0] == line[2] || line[1] == line[3])
                {
                    verthorlines.Add(line);
                }
                else
                {
                    diaglines.Add(line);
                }
            }

            int[,] array = new int[1000,1000];
            foreach(string[] line in verthorlines)
            {
                int hhor=0;
                int lhor=0;
                if (Int32.Parse(line[0]) >= Int32.Parse(line[2]))
                {
                    hhor = Int32.Parse(line[0]);
                    lhor = Int32.Parse(line[2]);
                }
                else
                {
                    hhor = Int32.Parse(line[2]);
                    lhor = Int32.Parse(line[0]);
                }
                for (int i = lhor; i <= hhor; i++)
                {
                    int hvert = 0;
                    int lvert = 0;
                    if (Int32.Parse(line[1]) >= Int32.Parse(line[3]))
                    {
                        hvert = Int32.Parse(line[1]);
                        lvert = Int32.Parse(line[3]);
                    }
                    else
                    {
                        hvert = Int32.Parse(line[3]);
                        lvert = Int32.Parse(line[1]);
                    }
                    for (int j = lvert; j <= hvert; j++)
                    {
                        array[j,i] += 1;
                    }
                }
            }

            int total = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if(array[i,j] > 1)
                    {
                        total += 1;
                    }
                }
            }

            Console.WriteLine("Part 1 - {0}", total);

            foreach (string[] line in diaglines)
            {
                int nsteps = Math.Abs(Int32.Parse(line[0]) - Int32.Parse(line[2]));
                int hhor = 0;
                int lhor = 0;
                Boolean horincrease = false;
                if (Int32.Parse(line[0]) >= Int32.Parse(line[2]))
                {
                    hhor = Int32.Parse(line[0]);
                    lhor = Int32.Parse(line[2]);
                    horincrease = false;
                }
                else
                {
                    hhor = Int32.Parse(line[2]);
                    lhor = Int32.Parse(line[0]);
                    horincrease = true;
                }
                int hvert = 0;
                int lvert = 0;
                Boolean vertincrease = false;
                if (Int32.Parse(line[1]) >= Int32.Parse(line[3]))
                {
                    hvert = Int32.Parse(line[1]);
                    lvert = Int32.Parse(line[3]);
                    vertincrease = false;
                }
                else
                {
                    hvert = Int32.Parse(line[3]);
                    lvert = Int32.Parse(line[1]);
                    vertincrease = true;
                }
                for (int i = 0; i <= nsteps; i++)
                {
                    if (!horincrease && !vertincrease)
                    {
                        array[Int32.Parse(line[1]) - i, Int32.Parse(line[0]) - i] += 1;
                    }
                    else if (!horincrease && vertincrease)
                    {
                        array[Int32.Parse(line[1]) + i, Int32.Parse(line[0]) - i] += 1;
                    }
                    else if (horincrease && !vertincrease)
                    {
                        array[Int32.Parse(line[1]) - i, Int32.Parse(line[0]) + i] += 1;
                    }
                    else if (horincrease && vertincrease)
                    {
                        array[Int32.Parse(line[1]) + i, Int32.Parse(line[0]) + i] += 1;
                    }
                }

            }

            total = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > 1)
                    {
                        total += 1;
                    }
                }
            }

            Console.WriteLine("Part 2 - {0}, {1}, {2}", total, true, true);
            Console.WriteLine("End of Program .");
        }
    }
}
