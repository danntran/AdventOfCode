using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Puzzle10
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
            char[] delims = new[] { '\r', '\n', '|' };
            List<string> il = new List<string> ((inputstr.Split(delims, StringSplitOptions.RemoveEmptyEntries)).ToList());

            string openbrackets = "([{<";
            string closebrackets = ")]}>";

            List<char> results = new List<char>();
            List<long> results2 = new List<long>();
            foreach (string line in il)
            {
                List<char> lastopenbrack = new List<char>();
                List<int> indexes = new List<int>();
                int flag = 0;
                for (int i = 0; i < line.Count(); i++)
                {
                    if (openbrackets.Contains(line[i]))
                    {
                        lastopenbrack.Add(line[i]);
                        indexes.Add(i);
                    }
                    if (closebrackets.Contains(line[i])) 
                    {
                        int idx = closebrackets.IndexOf(line[i]);
                        if (lastopenbrack.Last() == openbrackets[idx])
                        {
                            lastopenbrack.RemoveAt(lastopenbrack.Count() - 1);
                            indexes.RemoveAt(indexes.Count() - 1);
                        }
                        else
                        {
                            results.Add(line[i]);
                            flag = 1;
                        }
                    }
                }
                if (flag == 1)
                {
                    continue;
                }
                long sums = 0;
                for (int j = lastopenbrack.Count() - 1; j >= 0; j--)
                {
                    sums *= 5;
                    switch (lastopenbrack[j])
                    {
                        case '(':
                            sums += 1;
                            break;

                        case '[':
                            sums += 2;
                            break;

                        case '{':
                            sums += 3;
                            break;

                        case '<':
                            sums += 4;
                            break;
                    }
                }
                results2.Add(sums);
            }

            results2.Sort();

            int total = 0;
            foreach (char brack in results)
            {
                switch (brack)
                {
                    case ')':
                        total += 3;
                        break;

                    case ']':
                        total += 57;
                        break;

                    case '}':
                        total += 1197;
                        break;

                    case '>':
                        total += 25137;
                        break;
                }
            }

            Console.WriteLine("Part 1 - {0}, {1}, {2}", total, true, true);
            Console.WriteLine("Part 2 - {0}, {1}, {2}", results2[(results2.Count()-1)/2], true, true);

            Console.WriteLine("End of Program .");
        }
    }
}
