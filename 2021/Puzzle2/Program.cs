using System;
using System.IO;
using System.Text;

namespace Puzzle2
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

            int hor_pos = 0;
            int vert_pos = 0;

            for (int i = 0; i < strings.Length; i++)
            {
                string direction = strings[i].Split(' ')[0];
                int value = Int32.Parse(strings[i].Split(' ')[1]);
                if (direction.Equals("forward"))
                {
                    hor_pos += value;
                }
                else if (direction.Equals("down"))
                {
                    vert_pos += value;
                }
                else if (direction.Equals("up"))
                {
                    vert_pos -= value;
                }
            }

            Console.WriteLine("Part 1 - {0}", hor_pos * vert_pos);

            hor_pos = 0;
            vert_pos = 0;
            int aim = 0;

            for (int i = 0; i < strings.Length; i++)
            {
                string direction = strings[i].Split(' ')[0];
                int value = Int32.Parse(strings[i].Split(' ')[1]);
                if (direction.Equals("forward"))
                {
                    vert_pos += value * aim;
                    hor_pos += value;
                }
                else if (direction.Equals("down"))
                {
                    aim += value;
                }
                else if (direction.Equals("up"))
                {
                    aim -= value;
                }
            }

            Console.WriteLine("Part 2 - {0}", hor_pos * vert_pos);
            Console.WriteLine("End of Program.");
        }
    }
}
