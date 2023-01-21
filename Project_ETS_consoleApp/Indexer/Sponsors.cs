using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Project_ETS_consoleApp.Classes;

namespace Project_ETS_consoleApp.Indexer
{
    class Sponsors : CollectionBase
    {
        public void add(Sponsor sponsor)
        {
            List.Add(sponsor);
        }

        public Sponsor this[int ind]
        {
            get
            {
                return (Sponsor)List[ind];
            }

            set
            {
                List[ind] = value;
            }
        }
    }
}
