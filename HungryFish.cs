using System;

namespace ConsoleAppThree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            //Code start
            
            Console.WriteLine("Infected Fish Size:");
            int infectedFishSize = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Fishs in aquarium");
            int[] fishs = Array.ConvertAll(Console.ReadLine().Split(","), int.Parse);
            Console.WriteLine("Output: {0}", HungryFish(infectedFishSize, fishs));

            //Code end
            Console.WriteLine("End");
            Console.ReadKey();
        }

        public static int HungryFish(int infectedFishSize, int[] fishs)
        {
            Array.Sort(fishs);
            int moves = 0;
            for (int i = 0; i < fishs.Length; i++)
            {
                if (fishs[i] < infectedFishSize) infectedFishSize += fishs[i];
                else
                {
                    if (fishs[i] < (infectedFishSize + infectedFishSize - 1))
                    {
                        infectedFishSize += (infectedFishSize - 1);
                        moves++;
                    }
                    else
                    {
                        moves += (fishs.Length - i);
                        break;
                    }
                }
            }
            return moves;
        }
    }
}
