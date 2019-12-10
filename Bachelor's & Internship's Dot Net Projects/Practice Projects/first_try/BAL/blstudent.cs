using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Student;
namespace BAL
{
    public class blstudent
    {
        public List<firstyear> ListStudent()
        {
            dlstudent obj = new dlstudent();
            return obj.ListStudent();
        }
    }
}
