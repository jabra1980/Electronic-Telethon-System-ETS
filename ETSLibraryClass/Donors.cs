using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace ETSLibraryClass
{
    class Donors : CollectionBase
    {
        public void add(DonorClass donor)
        {
            List.Add(donor);
        }

        public DonorClass this[int ind]
        {
            get
            {
                return (DonorClass)this[ind];
            }

            set
            {
                this[ind] = value;
            }
        }
    }
}
