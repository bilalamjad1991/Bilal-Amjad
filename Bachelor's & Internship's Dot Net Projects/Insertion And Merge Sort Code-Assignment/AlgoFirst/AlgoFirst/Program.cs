using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace AlgoFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing
            stopwatch.Start();

            System.Threading.Thread.Sleep(500);

            int Min = 0;
            int Max = 20;
            int[] intArray = new int[10];

            Random randNum = new Random();
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = randNum.Next(Min, Max);
            }

            InsertionSort(intArray);

            // Stop timing
            stopwatch.Stop();
            Console.WriteLine(""); Console.WriteLine("");
            Console.WriteLine("Time elapsed in Seconds for 10 integers: {0}", stopwatch.Elapsed.TotalSeconds);

            
            //////////////////////////////////////////////////////////////////////////////////////
            Stopwatch stopwatch2 = new Stopwatch();
            // Begin timing
            stopwatch2.Start();

            System.Threading.Thread.Sleep(500);

            int Min2 = 0;
            int Max2 = 20;
            int[] intArray2 = new int[100000];

            Random randNum2 = new Random();
            for (int i = 0; i < intArray2.Length; i++)
            {
                intArray2[i] = randNum2.Next(Min2, Max2);
            }

            InsertionSort2(intArray2);

            // Stop timing
            stopwatch2.Stop();
            Console.WriteLine("");
            Console.WriteLine("Time elapsed in Seconds for 100000 integers: {0}", stopwatch2.Elapsed.TotalSeconds);

            Console.ReadKey();

           }

        static public void InsertionSort(int[] intArray)
        {
            Console.WriteLine("==========Integer Array Input===============");
            for (int i = 0; i < intArray.Length; i++)
            {
                Console.Write(intArray[i] + " ");
            }

            int temp, j,temp2;
            for (int i = 1; i < intArray.Length; i++)
            {
                //temp = intArray[i];
                j = i;

                while (j > 0 && intArray[j - 1] > intArray[j])
                {
                    //intArray[j + 1] = intArray[j];
                    temp2 = intArray[j];
                    intArray[j] = intArray[j-1];
                    intArray[j-1] = temp2;
                    j--;
                }

                //intArray[j + 1] = temp;
            }
            Console.WriteLine("");
            Console.WriteLine("==========Integer Array OutPut===============");
            for (int i = 0; i < intArray.Length; i++)
            {
                Console.Write(intArray[i] + " ");
            }
        }
        static public void InsertionSort2(int[] intArray2)
        {
            //Console.WriteLine("==========Integer Array Input===============");
            //for (int i = 0; i < intArray.Length; i++)
            //{
            //    Console.Write(intArray[i] + " ");
            //}

            int temp, j, temp2;
            for (int i = 1; i < intArray2.Length; i++)
            {
                //temp = intArray[i];
                j = i;

                while (j > 0 && intArray2[j - 1] > intArray2[j])
                {
                    //intArray[j + 1] = intArray[j];
                    temp2 = intArray2[j];
                    intArray2[j] = intArray2[j - 1];
                    intArray2[j - 1] = temp2;
                    j--;
                }

                //intArray[j + 1] = temp;
            }
            Console.WriteLine("");
            //Console.WriteLine("==========Integer Array OutPut===============");
            //for (int i = 0; i < intArray.Length; i++)
            //{
            //    Console.Write(intArray[i] + " ");
            //}
        }
        }
        
}



