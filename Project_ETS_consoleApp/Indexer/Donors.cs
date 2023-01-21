using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Project_ETS_consoleApp.Classes;

namespace Project_ETS_consoleApp.Indexer
{
    class Donors : CollectionBase
    {
        public void add(Donor donor)
        {
            List.Add(donor);
        }

        public void remove(Donor don)
        {
            List.Remove(don);
        }

        public Donor this[int ind]
        {
            get
            {
                return (Donor)this[ind];
            }

            set
            {
                this[ind] = value;
            }
        }
    }
}
