using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace ETSLibraryClass
{
    class Donations : CollectionBase
    {
        public void add(DonationClass donation)
        {
            List.Add(donation);
        }

        public DonationClass this[int ind]
        {
            get
            {
                return (DonationClass)this[ind];
            }

            set
            {
                this[ind] = value;
            }
        }
    }
}
