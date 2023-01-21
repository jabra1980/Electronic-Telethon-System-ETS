using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace ETSLibraryClass
{
    class Sponsors : CollectionBase
    {
        public void add(SponsorClass sponsor)
        {
            List.Add(sponsor);
        }

        public SponsorClass this[int ind]
        {
            get
            {
                return (SponsorClass)List[ind];
            }

            set
            {
                List[ind] = value;
            }
        }
    }
}
