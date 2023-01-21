using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ETS_consoleApp.Classes
{

    class Donor : Person
    {
        string donorID;
        string address;
        string phone;
        char cardType;
        string cardNumber;
        string cardExpiry;

        public Donor(string dID, string fn, string ln, string add, string ph, char ct, string cn, string ce) : base(fn, ln)
        {
            this.donorID = dID;
            this.address = add;
            this.phone = ph;
            this.cardType = ct;
            this.cardNumber = cn;
            this.cardExpiry = ce;
        }



        public override string toString()
        {
            return "\nDonor ID: " + this.donorID +
                ", " + base.toString() + 
                ", Address: " + this.address + 
                ", Phone: " + this.phone +
                "\nCard Type: " + this.cardType +
                "\nCard Number: " + this.cardNumber +
                "\nCard Expiry: " + this.cardExpiry;
        }


        public string DonorID
        {
            get { return donorID; }
            set { donorID = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public char CardType
        {
            get { return cardType; }
            set { cardType = value; }
        }
      

        public string CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; }
        }

        public string CardExpiry
        {
            get { return cardExpiry; }
            set { cardExpiry = value; }
        }
    }
}
