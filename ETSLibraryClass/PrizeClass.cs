using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETSLibraryClass
{
    class PrizeClass
    {
        const double percentageOfDonation = 0.05; 
        string prizeID;
        string description;
        double valueCost;
        double donationLimit;
        int originalAvailable;
        int currentAvailable;
        string sponsorID;
        

        public PrizeClass(string prizeID, string description, double value, int originalAvailable,string sponsorID)
        {
            this.prizeID = prizeID;
            this.description = description;
            this.valueCost = value;
            this.donationLimit = Math.Round(valueCost / percentageOfDonation, 2);
            this.originalAvailable = originalAvailable;
            this.currentAvailable = originalAvailable;
            this.sponsorID = sponsorID;
            
        }

        public string toString()
        {
            return "ID: " + this.prizeID + ", " + "Description: " + this.description + ", " + "Value: " + this.valueCost + "$" +
                   ", " + "Donation Limit: " + this.donationLimit + ", " + "Original Available: " + this.originalAvailable + ", " +
                "Current Available: " + this.currentAvailable + ", " + "Sponsor ID: " + this.sponsorID + "\n";
        }

        //Getter & Setter
        public string PrizeID
        {
            get { return prizeID; }
            set { prizeID = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public double Value
        {
            get { return valueCost; }
            set { valueCost = value; }
        }

        public double DonationLimit
        {
            get { return donationLimit; }
            set { donationLimit = value; }
        }

        public int OriginalAvailable
        {
            get { return originalAvailable; }
            set { originalAvailable = value; }
        }

        public int CurrentAvailable
        {
            get { return currentAvailable; }
            set { currentAvailable = value; }
        }

        public string SponsorID
        {
            get { return sponsorID; }
            set { sponsorID = value; }
        }



        public string getPrizeID()
        {
            return prizeID;
        }

        public void decrease(int noAwardPrice)
        {
            this.currentAvailable -= noAwardPrice;
        }
        
        public void clearPrize()
        {
            this.currentAvailable = 0;
        }

    }
}
