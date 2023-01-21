using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ETSLibraryClass
{
    class DonationClass
    {
        DateTime today = DateTime.Now;
        string donationID;
        string donationDate;
        string donorID;
        double donationAmount;
        string prizeID;
        int numberOFQualifiedPrizes;

        public DonationClass(string donationID, string donorID, double donationAmount, string prizeID, int numberOFQualifiedPrizes)
        {
            this.donationID = donationID;
            this.donationDate = today.ToString("dd/MM/yyyy");
            this.donorID = donorID;
            this.donationAmount = donationAmount;
            this.prizeID = prizeID;
            this.numberOFQualifiedPrizes = numberOFQualifiedPrizes;
        }

        public string toString()
        {
            
            return "ID: " + this.donationID + ", "+
                "Donation Date: " + this.donationDate + ", " + 
                "Donor ID: " + this.donorID + ", " + 
                "Donation Amount: " + this.donationAmount + "$" + ", " +
                "Prize ID: " + this.prizeID;
        }

        public string DonationID
        {
            get { return this.donationID; }
            set { this.donationID = value; }
        }

        public string DonationDate
        {
            get { return this.donationDate; }
            set { this.donationDate = value; }
        }

        public string DonorID
        {
            get { return this.donorID; }
            set { donorID = value; }
        }

        public double DonationAmount
        {
            get { return this.donationAmount; }
            set { this.donationAmount = value; }
        }

        public string PrizeID
        {
            get { return this.prizeID; }
            set { this.prizeID = value; }
        }

        public int NumberOFQualifiedPrizes
        {
            get { return this.numberOFQualifiedPrizes; }
            set { this.numberOFQualifiedPrizes = value; }
        }

    }
}
