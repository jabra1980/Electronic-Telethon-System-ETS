using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ETS_consoleApp.Classes
{
    abstract class Person
    {
        string firstName;
        string lastName;

        public Person(string fn, string ln)
        {
            this.firstName = fn;
            this.lastName = fn;
        }

        public virtual string toString()
        {
            return "First Name: " + this.firstName + ", " + "Last Name: " + this.lastName;
        }
    }
}
