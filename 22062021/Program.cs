using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _22062021
{
    class Program
    {
        const int MIN = 0;
        const int MAX = 100;
        const int RANGE = 4;
        static void Main(string[] args)
        {
            //BR1
            // Publisher publisher = new Publisher();
            // Subcriber subcriber = new Subcriber();
            // subcriber.Subcribe(publisher);
            // publisher.Run();

            //BR2
            Task.Run(() => PrintPrimaryNumber(RANGE)).Wait();
        }

        // Split list to *range element and do *range task (ex: 4 task, 4 element)
        public static async Task PrintPrimaryNumber(int range)
        {
            // the number which split the list
            int distance = (MAX - MIN) / range;

            List<int>[] result = new List<int>[RANGE+1];

            // A list of the return type of FindPrimaryNumber method
            List<Task<List<int>>> totalTask = new List<Task<List<int>>>();

            for (int i = 0; i <= range; i++)
            {
                // If the next element is over then find from this number to the maximum 
                if (distance * (i + 1) > MAX)
                {
                    totalTask.Add(FindPrimaryNumber(distance * i, MAX));
                }
                else
                {
                    // From first element to element + distance
                    totalTask.Add(FindPrimaryNumber(distance * i, distance * (i + 1) - 1));
                }
            }

            result = await Task.WhenAll(totalTask);

            for (int i = 0; i < result.Length; i++)
            {
                result[i].ForEach(x => Console.WriteLine(x));
            }
        }

        public static async Task<List<int>> FindPrimaryNumber(int start, int end)
        {
            List<int> primaryList = new List<int>();
            return await Task.Run(() =>
            {
                for (int i = start; i <= end; i++)
                {
                    if (IsPrimaryNumber(i))
                    {
                        primaryList.Add(i);
                    }
                };
                return primaryList;
            });
        }

        public static bool IsPrimaryNumber(int number)
        {
            if (number < 2) return false;
            int checkNumber = (int)Math.Round(Math.Sqrt(number));
            for (int i = 2; i <= checkNumber; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
