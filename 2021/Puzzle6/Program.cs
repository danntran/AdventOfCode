using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Puzzle6
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
            string[] inputstrings = inputstr.Split(delims, StringSplitOptions.RemoveEmptyEntries);


            List<int> vs = new List<int>();
            foreach (string i in inputstrings)
            {
                vs.Add(Int32.Parse(i));
            }

            
            for (int i = 0; i < 80; i++)
            {
                int add = 0;
                for (int j = 0; j < vs.Count(); j++)
                {
                    if (vs[j] != 0)
                    {
                        vs[j] -= 1;
                    }
                    else
                    {
                        vs[j] = 6;
                        add += 1;
                    }
               
                }
                for (int j = 0;j < add; j++)
                {
                    vs.Add(8);
                }
/*                vs.ForEach(p => Console.Write(p));
                Console.WriteLine();*/
            }



            Console.WriteLine("Part 1 - {0}, {1}, {2}", vs.Count(), true, true);

            // Use different method for day 2
            List<long> fishgroups = new List<long>{0,0,0,0,0,0,0,0,0};
            foreach (string i in inputstrings)
            {
                fishgroups[Int32.Parse(i)] += 1;
            }

            for (int i = 0;i < 256; i++)
            {
                long value = fishgroups[0];
                fishgroups.RemoveAt(0);
                fishgroups.Add(value);
                fishgroups[6] += value;
            }
            // group fish by number of days left e.g. 3,2,3,1,2,2; 1:1, 2:3, 3:2


            Console.WriteLine("Part 2 - {0}, {1}, {2}", fishgroups.Sum(), true, true);
            Console.WriteLine("End of Program .");
        }
    }
}
