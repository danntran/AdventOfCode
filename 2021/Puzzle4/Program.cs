using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

// Why didn't i use lists earlier? I will use lists going forward instead of arrrays.

namespace Puzzle4
{
    internal class Program
    {
        public static byte[] TrimEnd(byte[] array)
        {
            int lastIndex = Array.FindLastIndex(array, b => b != 0);
            Array.Resize(ref array, lastIndex + 1);
            return array;
        }
        public static Boolean win(List<string[]> array)
        {
            Boolean result = false;
            for (int i = 0; i < array.Count; i++)
            {
                int ycount = 0;
                int xcount = 0;
                for (int j = 0; j < array[0].Length; j++)
                {
                    if (array[i][j].Equals("100"))
                    { 
                        ycount++;    
                    }
                    if (array[j][i].Equals("100"))
                    {
                        xcount++;
                    }
                }
                if (ycount == 5 || xcount == 5)
                {
                    result = true;
                    break;
                }

            }
            return result;
        }

        static void Main(string[] args)
        {
            // ALl bingo number are less than 100

            string callnums = "76,69,38,62,33,48,81,2,64,21,80,90,29,99,37,15,93,46,75,0,89,56,58,40,92,47,8,6,54,96,12,66,83,4,70,19,17,5,50,52,45,51,18,27,49,71,28,86,74,77,11,20,84,72,23,31,16,78,91,65,87,79,73,94,24,68,63,9,88,82,30,42,60,13,67,85,44,59,7,53,22,1,26,41,61,55,43,39,3,35,25,34,57,10,14,32,97,95,36,98";
            //string callnums = "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1";
            string[] callnum = callnums.Split(",");

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

            //create multi dimensional list
            List<List<string[]>> games = new List<List<string[]>>();
            for (int i = 0; i < inputstrings.Length; i = i + 5)
            {
                List<string[]> game = new List<string[]>();
                for (int j = 0; j < 5; j++)
                {
                    string mystr = Regex.Replace(inputstrings[i + j].Trim(), @"\s+", " ");
                    game.Add(mystr.Split());
                }
                games.Add(game);
            }

 /*           List<string[]> winninggame = new List<string[]>();
            string winningnum = "";
            Boolean winflag = false;
            foreach (string num in callnum)
            {
                for(int i = 0;i < 5; i++)
                {
                    for (int j = 0;j < 5; j++)
                    {
                        foreach(List<string[]> game in games)
                        {
                            if (game[i][j].Equals(num))
                            {
                                game[i][j] = "100";
                            }
                        }
                    }
                }
                foreach (List<string[]> game in games)
                {
                    if (win(game) == true)
                    {
                        winflag = true;
                        winninggame = game;
                        winningnum = num;
                        //break;
                    }
                }
                if( winflag == true)
                {
                    //break;
                }
            }

            int total = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!(winninggame[i][j].Equals("100")))
                    {
                        total += Int32.Parse(winninggame[i][j]);
                    }
                }
            }

            Console.WriteLine("Part 1 - {0}, {1}, {2}", total, winningnum, total * Int32.Parse(winningnum));*/

            List<string[]> winninggame = new List<string[]> ();
            int[] wingameflags = new int[100];
            string winningnum = "";
            foreach (string num in callnum)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        foreach (List<string[]> game in games)
                        {
                            if (game[i][j].Equals(num))
                            {
                                game[i][j] = "100";
                            }
                        }
                    }
                }

                
                int ngames = games.Count;
                int wincount = 0;
                foreach (List<string[]> game in games)
                {
                    Boolean winflag = win(game);
                    if (winflag)
                    {
                        wingameflags[wincount] = 1;
                    }
                    else
                    {
                        winninggame.Clear();
                        for (int i = 0; i < 5; i++)
                        {
                            winninggame.Add(game[i]);
                        }
                        winningnum = num;
                    }
                    wincount++;
                }

                if (wingameflags.Sum() == ngames)
                {
                    winningnum = num;
                    break;
                }
            }

            int total = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!(winninggame[i][j].Equals("100")))
                    {
                        total += Int32.Parse(winninggame[i][j]);
                    }
                }
            }


            Console.WriteLine("Part 2 - {0}, {1}, {2}", (total), winningnum, (total) * Int32.Parse(winningnum));
            Console.WriteLine("End of Program .");
        }
    }
}
