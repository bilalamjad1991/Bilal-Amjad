using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Misc
{
    
    public class MiscClass
    {

        #region Constrctors
        private int _a;

        public int A
        {
            get { return _a; }
            set { _a = value; }
        }
        private int _b;

        public int B
        {
            get { return _b; }
            set { _b = value; }
        }
        private int _c;

        public int C
        {
            get { return _c; }
            set { _c = value; }
        }
        
        // Constructor are used to initize the class
        // and any resources. Also allocat the memory
        
        // DEFAULT Constructor
        public MiscClass()
        { 
        }
        //Constuctor overloading
        public MiscClass(int a, int b)
        {
            this._a = a;
            this._b = b;
        }
        public MiscClass(int a, int b, int c) : this(a,b)
        {
            this._c = c;
        }



        #endregion
    }

    #region Interfaces and their implementation

    interface MyInterface
    {
        void CanBreath();
        void CanWalk();
    }
    interface SecondInterface
    {
        int FunctionOne();
        string FunctionTwo();
    }
    // Study Singleton Design Pattern
    public class Test : MyInterface
    {
        public void CanBreath() 
        { }
        public void CanWalk()
        { }
    }
    public class SecondClass : SecondInterface
    {

        public int FunctionOne()
        {
            return 1;
        }

        public string FunctionTwo()
        {
            return "abc";
        }
    }

    public class ThirdClass : MyInterface, SecondInterface
    {

        public void CanBreath()
        {
            
        }

        public void CanWalk()
        {
            
        }

        public int FunctionOne()
        {
            return 123;
        }

        public string FunctionTwo()
        {
            return "abc";
        }
    }



    interface Conflict
    {
         int A();
        int B();
    }
    interface Conflict1
    {
        int A();
        int C();
    }

    public class ConflictingClass : Conflict, Conflict1
    {
         int Conflict.A()
        {
            return 1;
        }

        int Conflict.B()
        {
            return 2;
        }
        int Conflict1.A()
        {
            return 3;
        }

        int Conflict1.C()
        {
            return 4;
        }
    }
#endregion


    public enum testEnum
    {
        Value1 = 1,
        Value2,
        value3,
        value4
    }
}
