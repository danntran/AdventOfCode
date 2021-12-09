using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Puzzle8
{
    internal class Program
    {
        public static int FindDigits(string[] inputs, string[] outputs )
        {
            string[] pin = new string[10];
            pin[1] = inputs.First(val => val.Length == 2);
            pin[4] = inputs.First(val => val.Length == 4);
            pin[7] = inputs.First(val => val.Length == 3);
            pin[8] = inputs.First(val => val.Length == 7);

            List<string> group235 = new List<string>();
            List<string> group069 = new List<string>();

            foreach (string input in inputs)
            {
                if (input.Length == 5)
                {
                    group235.Add(input);
                }
                if (input.Length == 6)
                {
                    group069.Add(input);
                }
                
            }

            string one = pin[1];

            // find digit 3, from 2,3,5. only 3 contains both segment from 1
            pin[3] = group235.First(val => val.Contains(one[0]) && val.Contains(one[1]));
            group235.Remove(pin[3]);

            // find digit 6, from 0,6,9. only 6 contains only 1 segment from 1
            pin[6] = group069.First(val => val.Contains(one[0]) ^ val.Contains(one[1]));
            group069.Remove(pin[6]);

            string four = pin[4];

            // find digit 9 from 0,9. only 9 using all segments in 4
            pin[9] = group069.First(val => val.Contains(four[0]) && val.Contains(four[1]) && val.Contains(four[2]) && val.Contains(four[3]));
            group069.Remove(pin[9]);

            pin[0] = group069[0];

            //only 1 shared segment for 6 and 1
            string onesixcommon = one.Intersect(pin[6]).First().ToString();

            // find 5 from 2,5. only 5 has the common segment from one and six
            pin[5] = group235.First(val => val.Contains(onesixcommon));
            group235.Remove(pin[5]);

            pin[2] = group235[0];

            int returnval = 0;
            foreach ( string num in outputs )
            {
                for (int i = 0; i < pin.Length; i++)
                {
                    if (num == pin[i])
                    {
                        returnval = int.Parse(returnval.ToString() + i.ToString()); 
                    }
                }
                 
            }

            return returnval;
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
            string[] inputstrings = inputstr.Split(delims, StringSplitOptions.RemoveEmptyEntries);

            List<string[]> vo = new List<string[]>();
            for (int i=1; i<inputstrings.Length; i+=2)
            {
                string[] temp = (inputstrings[i].Trim()).Split(' ');
                for (int j=0; j<temp.Length; j++)
                {
                    temp[j] = String.Concat(temp[j].OrderBy(c => c));
                }
                vo.Add(temp);
            }

            List<string[]> vi = new List<string[]>();
            for (int i = 0; i < inputstrings.Length; i += 2)
            {
                string[] temp = (inputstrings[i].Trim()).Split(' ');
                for (int j = 0; j < temp.Length; j++)
                {
                    temp[j] = String.Concat(temp[j].OrderBy(c => c));
                }
                vi.Add(temp);
            }

            int count = 0;
            foreach (string[] line in vo)
            {
                foreach (string dig in line)
                {
                    if (dig.Length == 2 || dig.Length == 4 || dig.Length == 7 || dig.Length == 3)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine("Part 1 - {0}, {1}, {2}", count, true, true);

            List<int> results = new List<int>();
            for (int i = 0;i < vo.Count; i++)
            {
                results.Add(FindDigits(vi[i],vo[i]));
            }

            Console.WriteLine("Part 2 - {0}, {1}, {2}", results.Sum(), true, true);
            Console.WriteLine("End of Program .");
        }
    }
}
