using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing
            stopwatch.Start();

            System.Threading.Thread.Sleep(500);

            List<int> unsorted = new List<int>();
            List<int> sorted;

            Random random = new Random();

            Console.WriteLine("Original array elements:");
            for (int i = 0; i < 10; i++)
            {
                unsorted.Add(random.Next(0, 10));
                Console.Write(unsorted[i] + " ");
            }
            Console.WriteLine();

            sorted = MergeSort(unsorted);

            Console.WriteLine("Sorted array elements: ");
            foreach (int x in sorted)
            {
                Console.Write(x + " ");
            }
            Console.Write("\n");
            

            // Stop timing
            stopwatch.Stop();
            Console.WriteLine("");
            Console.WriteLine("Time elapsed in seconds for 10 integers: {0}", stopwatch.Elapsed.TotalSeconds);
//////////////////////////////////////////////////////////////////////////////////////////////////////
            Stopwatch stopwatch2 = new Stopwatch();

            // Begin timing
            stopwatch2.Start();

            System.Threading.Thread.Sleep(500);

            List<int> unsorted2 = new List<int>();
            List<int> sorted2;

            Random random2 = new Random();

            //Console.WriteLine("Original array elements:");
            for (int i = 0; i < 100000; i++)
            {
                unsorted2.Add(random2.Next(0, 10));
                // Console.Write(unsorted[i] + " ");
            }
            Console.WriteLine();

            sorted2 = MergeSort2(unsorted2);

            //Console.WriteLine("Sorted array elements: ");
            //foreach (int x in sorted)
            //{
            //    Console.Write(x + " ");
            //}
            //Console.Write("\n");
            //Console.ReadKey();

            // Stop timing
            stopwatch2.Stop();
            Console.WriteLine(""); 
            Console.WriteLine("Time elapsed in seconds for 100000 integers: {0}", stopwatch2.Elapsed.TotalSeconds);
            Console.ReadKey();
        }


        private static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }
            return result;
        }
        private static List<int> MergeSort2(List<int> unsorted2)
        {
            if (unsorted2.Count <= 1)
                return unsorted2;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted2.Count / 2;
            for (int i = 0; i < middle; i++)  //Dividing the unsorted list
            {
                left.Add(unsorted2[i]);
            }
            for (int i = middle; i < unsorted2.Count; i++)
            {
                right.Add(unsorted2[i]);
            }

            left = MergeSort2(left);
            right = MergeSort2(right);
            return Merge2(left, right);
        }

        private static List<int> Merge2(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }
            return result;
        }
    }
}