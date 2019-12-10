using System;
using System.Collections;


namespace _176_2
{
    class Program
    {
        static void Main(string[] args)
        {
           // #region Start of Variables
           // // Variable declaration
           //// Data Type space Name = initilization (if any)
           // int MyIntVariable;
           // string MyString ;
           // double myDouble = 50.15;
           // float test = 50.12F;

           // Int16 test16 = 15;
           // short testagain = 15;

           // // Int32 = int
           // // int64 = long

           // bool _myName = true;

           // Console.WriteLine(test16);
           // #endregion

            //#region Start of Conditions
            //int a = 10;
            //int b = 10;
            //if (a < b)
            //{
            //    Console.WriteLine("A<b");
            //}
            //else if (a == b)
            //{
            //    Console.WriteLine("Equal");
            //}
            //else
            //{
            //    Console.WriteLine("greater");
            //}
            ////==, != , < , <= , >, >= , || , && 
            //int? abc = null;
            //float? nullfloat = null;

            //#endregion

            #region Start of Switch

            //Assignment
            //switch (Statement)
            //{
            //    case 1: 
            //        // some op
            //        break;
            //    case 2:
            //        // Some op
            //        break;
            //    default: (equals to Else of If Statment))
            //        // Some op
            //        break;
            //}
            #endregion

            //#region Start of Conversion
            //// AKA Type casting
            //object o = new object();
            //int aConvert = 10;
            //float bConvert = (float)aConvert;
           
            //string result = Convert.ToString(aConvert);
            //float newTest = 158.5F;
            //int resultant = -1;
            //if (int.TryParse(newTest.ToString(), out resultant))
            //{
            //    Console.WriteLine("Conversion possible");
            //    Console.WriteLine(resultant);
            //}
            //else
            //{
            //    Console.WriteLine("Conversion not possible");
            //    Console.WriteLine(resultant);
            //}

            //#endregion


            #region Loop
            // For loop
            for (int i = 0; i < 50; i++)
            {
                // Statment execute
                //Console.WriteLine(i);
            }
            //for (int j = 0; j < 10; j++)
            //{
            //    for (int k = 0; k < j; k++)
            //    {

            //    }
            //}
            // While Loop
            //int w = 0;
            //while (w<5)
            //{
            //    // Execute Statment
            //    Console.WriteLine("While Loop: " + w);
            //    w++;
            //}

            // Do While Loop
            //int x = 0;
            //do
            //{
            //    // Statement
            //    Console.WriteLine("Execute");
            //    x++;
            //} while (x<5);
            
            // Foreach Loop

            string TestMe = "This is Test String";
            
            for(int i = 0;i< TestMe.Length;i++)
            {
               // Console.Write(TestMe[i]);
            }
            // TestMe = Huge Paragraph
            // Ask user to find a specific character to search in this paragraph
            // Find count of that char entered by the user
            // Then ask the user to conevert that char into upper case
            // Find the total length of string (excluding space and the chater which user has entered)
            foreach (char c in TestMe)
            {
                Console.WriteLine(c);
            }
            //foreach (object c in TestMe)
            //{
            //    Console.WriteLine(c);
            //}
            // Data Type+[] VarialeName = // Initilization OR Assign data
            int[] MyIntArray = new int[5];
            for (int a=0 ; a<MyIntArray.Length;a++)
            {
                //Console.WriteLine(MyIntArray[a]);
            }
            foreach (int a in MyIntArray)
            {
               // Console.WriteLine(a);
            }


            //IEnumerator test = MyIntArray.GetEnumerator();
            //while (test.MoveNext())
            //{
            //    Console.WriteLine("Enumerator:" + test.Current.ToString());
            //}


            #endregion

            Console.WriteLine(DateTime.Now);
            Console.WriteLine(DateTime.Now.ToShortDateString());
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));

            DateTime dtCurrent = DateTime.Now;
            DateTime dtFuture = DateTime.Now.AddDays(1);

            TimeSpan dtDiff =  dtFuture - dtCurrent;

            // Ask user to enter date of any incident of history, then 
            // show different with current date in terms of Days, Hours, Second
            // MS

            Console.WriteLine(Math.Sqrt(5) * Math.Sqrt(5));

            Console.WriteLine(Math.Abs(-5));
            
            // Dynamic Array
            //Console.WriteLine("Please enter size of array");
            //int size = Convert.ToInt32(Console.ReadLine());
            //int[] TestArray = new int[size];

            //Console.WriteLine(TestArray.Length);

            string[] testarray = new string[] { "one", "Two"};

            ArrayList myObject = new ArrayList();
            Console.WriteLine(myObject.Count);
            myObject.Add('c');
            Console.WriteLine(myObject.Count);
            myObject.Add(200);
            Console.WriteLine(myObject.Count);
            myObject.RemoveAt(0);
            Console.WriteLine(myObject.Count);

            // Play with this GetEnumerator
            //myObject.GetEnumerator()

        }
    }
}
//namespace MyNameSpace
//{
//    public class Test
//    {
 
//    }
//}
