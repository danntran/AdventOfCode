using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

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
            string[] strings = inputstr.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            int lenBin = strings[0].Length;
            int gamma = 0;
            int epsilon = 0;

            for (int i = 0; i < lenBin; i++)
            {
                int onecount = 0;
                int zerocount = 0;
                for(int j = 0; j < strings.Length; j++)
                {
                    if (strings[j][i] == '1')
                    {
                        onecount++;
                    }
                    else 
                    {
                        zerocount++;
                    }
                }
                if (onecount >= zerocount)
                {
                    gamma = (gamma << 1) + 1;
                    epsilon = (epsilon << 1) + 0;
                }
                else
                {
                    gamma = (gamma << 1) + 0;
                    epsilon = (epsilon << 1) + 1;
                }
            }
            string bgamma = Convert.ToString(gamma, 2);
            string bepsilon = Convert.ToString(epsilon, 2);
            Console.WriteLine("Part 1 - gamma {0}, binary {1}, answer = {2}", bgamma, bepsilon, gamma*epsilon);

            List<string> gammaList = new List<string>(strings);
            for (int i = 0; i < lenBin; i++)
            {
                List<string> tempgammaList = new List<string>();
                string[] gammaArray = gammaList.ToArray();

                // Find gamma
                int onecount = 0;
                int zerocount = 0;
                for (int j = 0; j < gammaArray.Length; j++)
                {
                    if (gammaArray[j][i] == '1')
                    {
                        onecount++;
                    }
                    else
                    {
                        zerocount++;
                    }
                }
                if (onecount >= zerocount)
                {
                    gamma = '1';
                    epsilon = '0';
                }
                else
                {
                    gamma =  '0';
                    epsilon =  '1';
                }


                for (int j = 0; j < gammaArray.Length; j++)
                {
                    if (gamma == gammaArray[j][i])
                    {
                        tempgammaList.Add(gammaArray[j]);
                    }
                }
                gammaList.Clear();
                gammaList = tempgammaList;
                if (gammaList.Count == 1)
                {
                    break;
                }
            }

            List<string> epsilonList = new List<string>(strings);
            for (int i = 0; i < lenBin; i++)
            {
                List<string> tempeList = new List<string>();
                string[] eArray = epsilonList.ToArray();

                // Find gamma
                int onecount = 0;
                int zerocount = 0;
                for (int j = 0; j < eArray.Length; j++)
                {
                    if (eArray[j][i] == '1')
                    {
                        onecount++;
                    }
                    else
                    {
                        zerocount++;
                    }
                }
                if (onecount >= zerocount)
                {
                    gamma = '1';
                    epsilon = '0';
                }
                else
                {
                    gamma = '0';
                    epsilon = '1';
                }


                for (int j = 0; j < eArray.Length; j++)
                {
                    if (epsilon == eArray[j][i])
                    {
                        tempeList.Add(eArray[j]);
                    }
                }
                epsilonList.Clear();
                epsilonList = tempeList;
                if (epsilonList.Count == 1)
                {
                    break;
                }
            }



            Console.WriteLine("Part 2 - {0}, {1}, Answer={2}", gammaList[0], epsilonList[0], Convert.ToInt32(gammaList[0], 2)* Convert.ToInt32(epsilonList[0], 2));


            Console.WriteLine("End of Program .");
        }
    }
}
