using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_ETS_consoleApp.Classes;
using System.Collections;

namespace Project_ETS_consoleApp.Indexer
{
    class Donations : CollectionBase
    {
        public void add(Donation donation)
        {
            List.Add(donation);
        }

        public Donation this[int ind]
        {
            get
            {
                return (Donation)this[ind];
            }

            set
            {
                this[ind] = value;
            }
        }
    }
}
