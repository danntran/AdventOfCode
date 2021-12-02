using System;
using System.IO;
using System.Text;

namespace Puzzle1
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
            byte[] b = new byte[10000];
            UTF8Encoding data = new UTF8Encoding(true);
            while (fs.Read(b, 0, b.Length) > 0)
            {
                Console.WriteLine(data.GetString(TrimEnd(b)));
            }
            // put input data into a character string
            string inputstr = data.GetString(TrimEnd(b));
            // Characters to dlimit and split string by dlimtr
            char[] delims = new[] { '\r', '\n' };
            string[] strings = inputstr.Split(delims, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("End of Program.");

            // turn string into numbers
            int[] nums = new int[strings.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                nums[i] = int.Parse(strings[i]);
            }

            int increase_count = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i-1])
                {
                    increase_count++;
                }
            }
            Console.WriteLine("Part 1 - {0} increases", increase_count);

            increase_count = 0;
            for (int i = 3; i < nums.Length; i++)
            {
                if ((nums[i-3]+nums[i-2]+nums[i-1]) < (nums[i-2]+nums[i-1]+nums[i]))
                {
                    increase_count++;
                }
            }
            Console.WriteLine("Part 2 - {0} increases", increase_count);
            Console.WriteLine("End");

        }
    }
}
