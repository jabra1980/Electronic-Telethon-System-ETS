using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace ETSLibraryClass
{
    class Prizes : CollectionBase
    {
        public void add(PrizeClass prize)
        {
            List.Add(prize);
        }

        public PrizeClass this[int ind]
        {
            get
            {
                return (PrizeClass)this[ind];
            }

            set
            {
                this[ind] = value;
            }
        }
    }
}
