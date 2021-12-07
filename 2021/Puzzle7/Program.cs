using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Puzzle7
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
            foreach (string line in inputstrings)
            {
                vs.Add(Int32.Parse(line));
            }

            List<int> groups = new List<int> ( new int[vs.Max()+1] );
            foreach (int i in vs)
            {
                groups[i] += 1;
            }

            List<int[]> values = new List<int[]>();
            for(int i = 0; i < groups.Count; i++)
            {
                if(groups[i] != 0)
                {
                    int[] x = { i, groups[i] };
                    values.Add(x);
                }
            }

            List<int> result = new List<int>(new int[vs.Max()+1]);
            for (int i = 0; i <= vs.Max(); i++)
            {
                int sum = 0;
                for (int j = 0; j < values.Count(); j++)
                {
                    sum += ((Math.Abs(values[j][0] - i)) * values[j][1]);
                }
                result[i] = sum;
            }

            Console.WriteLine("Part 1 - {0}, {1}, {2}", result.Min(), true, true);

            List<int> result2 = new List<int>(new int[vs.Max() + 1]);
            for (int i = 0; i <= vs.Max(); i++)
            {
                int sum = 0;
                for (int j = 0; j < values.Count(); j++)
                {
                    int diff = Math.Abs(values[j][0] - i);
                    sum += ((diff*(diff+1))/2 * values[j][1]);
                }
                result2[i] = sum;
            }
            Console.WriteLine("Part 2 - {0}, {1}, {2}", result2.Min(), true, true);
            Console.WriteLine("End of Program .");
        }
    }
}
