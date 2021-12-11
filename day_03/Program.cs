using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_03
{
    class Program
    {
        public static void Day1(string[] lines)
        {
            var linesCount = lines.Length;
            var lineLength = lines[0].Length;
            var counter = Enumerable.Repeat(0, lineLength)
                            .ToList();

            foreach (var line in lines)
            {
                for (int i = 0; i < lineLength - 1; i++)
                {
                    if (line[i] == '1')
                        counter[i]++;
                }
            }

            var gamma = string.Join("", counter.Select(x => x >= linesCount / 2 ? "1" : "0"));
            var epsilion = string.Join("", counter.Select(x => x >= linesCount / 2 ? "0" : "1"));
            Console.WriteLine("gamma: " + gamma + " => " + Convert.ToInt32(gamma, 2));
            Console.WriteLine("epsilion: " + epsilion + " => " + Convert.ToInt32(epsilion, 2));
            Console.WriteLine("day1: " + Convert.ToInt32(epsilion, 2) * Convert.ToInt32(gamma, 2));
        }

        public static void Day2(string[] lines)
        {
            int oxygenGeneratorRating = 0;
            int co2ScrubberRating = 0;

            var binaryNumberCount = lines.Length;
            var binaryNumberLength = lines[0].Length;


            var numbersLeft = new List<string>(lines);


            //calc oxygen generator rating
            for (int i = 0; i < binaryNumberLength; i++)
            {
                var bitsInIteration = numbersLeft.Select(x => x[i]).ToList();
                var oneCount = bitsInIteration.Count(x => x == '1');
                var zeroCount = bitsInIteration.Count(x => x == '0');

                if (oneCount >= zeroCount)
                    numbersLeft = numbersLeft.Where(x => x[i] == '1').ToList();
                else
                    numbersLeft = numbersLeft.Where(x => x[i] == '0').ToList();

                if (numbersLeft.Count == 1)
                {
                    Console.WriteLine(numbersLeft[0] + " => " + Convert.ToInt32(numbersLeft[0], 2));
                    oxygenGeneratorRating = Convert.ToInt32(numbersLeft[0], 2);
                }
            }



            numbersLeft = new List<string>(lines);

            // calc CO2 scrubber rating
            for (int i = 0; i < binaryNumberLength - 1; i++)
            {
                var bitsInIteration = numbersLeft.Select(x => x[i]).ToList();
                var oneCount = bitsInIteration.Count(x => x == '1');
                var zeroCount = bitsInIteration.Count(x => x == '0');

                if (oneCount >= zeroCount)
                    numbersLeft = numbersLeft.Where(x => x[i] == '0').ToList();
                else
                    numbersLeft = numbersLeft.Where(x => x[i] == '1').ToList();


                if (numbersLeft.Count == 1)
                {
                    Console.WriteLine(numbersLeft[0] + " => " + Convert.ToInt32(numbersLeft[0], 2));
                    co2ScrubberRating = Convert.ToInt32(numbersLeft[0], 2);
                }
            }

            Console.WriteLine("day1 2: " + co2ScrubberRating * oxygenGeneratorRating);
        }



        static void Main()
        {
            var lines = File.ReadAllLines("inputs/input.txt");
            Day1(lines);
            Console.WriteLine("------------------");
            Day2(lines);
        }
    }
}
