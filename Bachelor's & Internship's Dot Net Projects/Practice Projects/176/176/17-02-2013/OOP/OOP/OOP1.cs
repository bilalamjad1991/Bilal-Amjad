using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student176
{

    sealed class Person
    {
        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }
        public virtual string Who()
        {
            return "I am Parent";
        }

        abstract public string Gender();
    }

    //class Female : Person
    //{
    //    public override string Gender()
    //    {
    //        return "Female";
    //    }
    //}
    //class Men : Person
    //{
    //    public override string Gender()
    //    {
    //        return "Male";
    //    }

    //}

    //class Student : Person // Why, find out
    //{
    //    #region Variable and Properties
    //    //string firstName;
    //    //public string FirstName
    //    //{
    //    //    set
    //    //    {
    //    //        if (value.ToString().Contains("12"))
    //    //        {
    //    //        }
    //    //        else
    //    //        {
    //    //            firstName = value;
    //    //        }
    //    //    }
    //    //    get
    //    //    {
    //    //        return firstName;
    //    //    }
    //    //}
    //    //string lastName;
    //    //public string LastName
    //    //{
    //    //    get { return lastName; }
    //    //    set { lastName = value; }
    //    //}
    //    #endregion


    //    string Grade;

    //    public string Grade1
    //    {
    //        get { return Grade; }
    //        set { Grade = value; }
    //    }
    //    // Access Modifies Data Type Name (Argument if any)
        
    //    //{
    //    //     Body
    //    //}
    //    public string GetPercentage()
    //    {
    //        if(this.Grade1 == "A")
    //        {
    //            return "80%";
    //        }
    //        else if (this.Grade1 == "B")
    //        {
    //            return "70%";
    //        }
    //        else if (this.Grade1 == "C")
    //        {
    //            return "60%";
    //        }
    //        else
    //        {
    //            return "Fail";
    //        }
    //    }

    //    public override string Who()
    //    {
    //        return "I am a student";
    //    }
    //}

    // class Teacher : Person
    //{
    //    //public override string Who()
    //    //{
    //    //    return "I am a Teacher";
    //    //}
    //}
}
