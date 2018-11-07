using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;


   public class Program
    {
        public static int Main(string[] args)
        {

            if ((args.Length == 0) || (String.Compare(args[0].ToLower(), "-d") != 0 && (String.Compare(args[0].ToLower(), "-h") != 0) && (String.Compare(args[0].ToLower(), "-m") != 0)))
            {
                Console.WriteLine("Usage: -d Hex :convert a hex string to dec (max hex=7fffffffffffffff)");
                Console.WriteLine("       -h Dec :convert a dec string to hex (max dec=9223372036854775807)");
                Console.WriteLine("       -m Hex :sort a hex string from (L+H) to (H+L)");
                Console.WriteLine("\n[Ver 1.1] Copyright (c) 2017 USI Software Inc All rights reserverd ");
                //Console.ReadKey();
                return 2;
            }
            switch(args[0].ToLower()) 
            {
                case "-d":
                    if ( (args.Length != 2) || (Regex.IsMatch(args[1], "^[0-9A-Fa-f]+$")==false) )
                    {
                        Console.WriteLine("Parameter number not 2; Or parameter 2 is not a Hex string");
                        //Console.ReadKey();
                        return 2;
                    }

                    Console.WriteLine("Hex2Dec: " + Convert.ToInt64(args[1], 16));
                    break;
                case "-h":
                    if ((args.Length != 2) || (Regex.IsMatch(args[1], "^[0-9]+$") == false))
                    {
                        Console.WriteLine("Parameter number not 2; Or parameter 2 is not a Dec string");
                        //Console.ReadKey();
                        return 2;
                    }
                    Console.WriteLine("Dec2Hex: " + Convert.ToString(Convert.ToInt64(args[1]), 16));
                    break;
                case "-m":
                    if ((args.Length != 2) || (Regex.IsMatch(args[1], "^[0-9A-Fa-f]+$") == false) || (args[1].Length % 4 != 0))
                    {
                        Console.WriteLine("Parameter number not 2; Or parameter 2 is not a Hex string; Or parameter 2 length not multiples of 4");
                        //Console.ReadKey();
                        return 2;
                    }

                    Console.Write("LH2HL: ");

                    for (int i = 1; i <= args[1].Length / 2; ++i)
                    {
                        Console.Write(args[1].Substring(args[1].Length - 2 * i, 2));
                    }


                    Console.WriteLine();
                    //Console.ReadKey();
                    break;
                   
            }
            //Console.ReadKey();
            
            return 0;
        }
        
    }
