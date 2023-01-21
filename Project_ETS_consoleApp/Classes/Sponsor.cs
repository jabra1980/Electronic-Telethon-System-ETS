using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ETS_consoleApp.Classes
{
    class Sponsor : Person
    {
        string sponsorID;
        double totalPrizeValue;

        public Sponsor(string sID, string fn, string ln) : base(fn, ln)
        {
            this.sponsorID = sID;
        }

        public override string toString()
        {
            return "Sponsor ID: " + this.sponsorID +
                ", " + base.toString() +
                ", Total Prize Value: " + this.totalPrizeValue;
            
        }

        public string SponsorID
        {
            get { return this.sponsorID; }
            set { this.sponsorID = value; }
        }

        public double TotalPrizeValue
        {
            get { return this.totalPrizeValue; }
            set { this.totalPrizeValue = value; }
        }

        public string getSponsorID()
        {
            return this.sponsorID;
        }

        public void addTotalPrize(double aValue, int origAvilable)
        {
            this.totalPrizeValue += (aValue * origAvilable);

        }
    }
}
