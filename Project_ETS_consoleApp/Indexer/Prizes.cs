using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_ETS_consoleApp.Classes;
using System.Collections;

namespace Project_ETS_consoleApp.Indexer
{
    class Prizes : CollectionBase
    {
        public void add(Prize prize)
        {
            List.Add(prize);
        }

        public Prize this[int ind]
        {
            get
            {
                return (Prize)this[ind];
            }

            set
            {
                this[ind] = value;
            }
        }
    }
}
