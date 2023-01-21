using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETSLibraryClass
{
    abstract class PersonClass
    {
        string firstName;
        string lastName;

        public PersonClass(string fn, string ln)
        {
            this.firstName = fn;
            this.lastName = fn;
        }

        public virtual string toString()
        {
            return $"First Name: {this.firstName}, Last Name: {this.lastName}";
        }

        public string getName()
        {
            return firstName;
        }
    }
}
