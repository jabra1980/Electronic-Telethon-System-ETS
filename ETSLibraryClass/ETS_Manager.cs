using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;
using System.Net;
using System.Runtime.Remoting.Lifetime;


namespace ETSLibraryClass
{
    public class ETS_Manager
    {
        

        string sponsorFile = "sponsor.txt";
        string prizeFile = "prize.txt";
        string donorFile = "donor.txt";
        string donationFile = "donation.txt";
        string path = @"C:\Users\jabra\OneDrive\Desktop\Project_ETS_winForm\DB_txt\";
        
        
        

        Sponsors sponsors = new Sponsors();
        Prizes prizes = new Prizes();
        Donors donors = new Donors();
        Donations donations = new Donations();



        // Verifier Section
        public bool sponsorVerifier(string sponsorID)
        {
            bool flag = false;

            foreach (SponsorClass sponsor in sponsors)
            {
                if (sponsor.getSponsorID() == sponsorID)
                {
                    flag = true;
                }
            }
            return flag;
        }
        
        public bool prizeVerifier(string prizeID)
        {
            bool flag = false;

            foreach (PrizeClass prize in prizes)
            {
                if (prize.getPrizeID() == prizeID)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public bool donorVerifier(string donorID)
        {
            bool flag = false;

            foreach (DonorClass donor in donors)
            {
                if (donor.DonorID == donorID)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public bool donationVerifier(string donationID)
        {
            bool flag = false;

            foreach (DonationClass donation in donations)
            {
                if (donation.DonationID == donationID)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public bool creditCardNumberVerfier(string creditCardNumber)
        {
            bool flag = false;

            foreach (DonorClass donor in donors)
            {
                if (donor.CardNumber == creditCardNumber)
                {
                    flag = true;
                }
            }
            return flag;
        }


        // RegexVerifier
        public bool phoneNumberRegex(string phone)
        {
            bool flag = false;
            string pattern = @"^[2-9]\d{2}[-][2-9]\d{2}[-]\d{4}$";
            foreach (Match m in Regex.Matches(phone, pattern))
            {
                if (m.Success)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public bool creditCardNumberRegex(string creditCardNumber)
        {
            bool flag = false;
            string pattern = @"^[2-9]\d{3}[-]\d{4}[-]\d{4}[-]\d{4}$";
            foreach (Match m in Regex.Matches(creditCardNumber, pattern))
            {
                if (m.Success)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public bool creditCardExpiryDateRegex(string creditCardExpiryDate)
        {
            bool flag = false;
            string pattern = @"^(1[0-2]|0[1-9])[\/](20[2-9]\d)$";
            foreach (Match m in Regex.Matches(creditCardExpiryDate, pattern))
            {
                if (m.Success)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public bool creditCardTypeRegex(char creditCardType)
        {
            bool flag = false;
            string pattern = @"\b([VMAvma]{1})";
            foreach (Match m in Regex.Matches(char.ToString(creditCardType), pattern))
            {
                if (m.Success)
                {
                    flag = true;
                }
            }
            return flag;
        }



        // Methods
        public string sponsorOneDisplay(string sponsorId)
        {
            string strID = "";

            foreach (SponsorClass sponsor in sponsors)
            {
                if (sponsor.getSponsorID() == sponsorId)
                {
                    strID = sponsor.toString();
                }
            }
            
            return strID;
        }
        
        public string prizeOneDisplay(string prizeId)
        {
            string strID = "";
            foreach (PrizeClass prize in prizes)
            {
                if (prize.getPrizeID() == prizeId)
                {
                    strID = prize.toString();
                }
            }
            return strID;
        }

        public string donorOneDisplay(string donorId)
        {
            string strID = "";
            foreach (DonorClass donor in donors)
            {
                if (donor.DonorID == donorId)
                {
                    strID = donor.toString();
                }
            }
            return strID;
        }

        public string donationOneDisplay(string donationId)
        {
            string strID = "";
            foreach (DonationClass donation in donations)
            {
                if (donation.DonationID == donationId)
                {
                    strID = donation.toString();
                }
            }
            return strID;
        }

        public string getSponserIdFromPrizeID(string prizeID)
        {
            string sponsorID = "";
            foreach (PrizeClass prize in prizes)
            {
                if (prize.getPrizeID() == prizeID)
                {
                    sponsorID = prize.SponsorID;
                }
            }
            return sponsorID;
        }
        
        public void addValue(double value, int origAvilable, string sponsorID)
        {

            foreach (SponsorClass sponsor in sponsors)
            {
                if (sponsor.getSponsorID() == sponsorID)
                {
                    sponsor.addTotalPrize(value, origAvilable);
                }
            }
        }

        public string listQualifiedPrizes(double donationAmount)
        {
            string info = "";
            int numberOFQualifiedPrizes = 0;
            foreach (PrizeClass prize in prizes)
            {
                if (prize.DonationLimit <= donationAmount)
                {
                    numberOFQualifiedPrizes = (int)(donationAmount / prize.DonationLimit);
                }

                info += "Prize ID: " + prize.PrizeID + ", " + "Description: " + prize.Description + ", " + "Number of Prize: " + numberOFQualifiedPrizes + "\n";
            }
            return info;
        }

        public bool recordDonation(string prizeID, int number, double donationAmount)
        {

            foreach (PrizeClass prize in prizes)
            {
                int numberOFQualifiedPrizes = (int)(donationAmount / prize.DonationLimit);
                if (prize.getPrizeID() == prizeID && number <= numberOFQualifiedPrizes && number <= prize.CurrentAvailable)
                {
                    prize.decrease(number);
                    return true;
                }
            }
            return false;
        }


        //adding Section
        public string AddSponsor(string sponsorID, string firstname, string lastname )
        {
            string info = "";
            if (sponsorID.Length != 4)
            {
                info = "Error..! the Sponsor ID should be 4 character";
                return info;
            }
            if (sponsorVerifier(sponsorID) == true)
            {
                info = "Error! This Id already exists!";
                return info;
            }
            if (firstname.Length > 15)
            {
                info = "Error! Name should be 15 chars";
                return info;
            }
            if (lastname.Length > 15)
            {
                info = "Error! Name should be 15 chars";
                return info;
            }

            SponsorClass sponsor = new SponsorClass(sponsorID, firstname, lastname);
            sponsors.add(sponsor);

            info = "Success! The Sponsor added to the list";

            return info;
        }

        public string addPrize(string prizeID, string description, double value, int originalAvailable, string sponsorId)
        {
            string info = "";
            if (prizeID.Length != 4)
            {
                info = "Error..! the Prize ID should be 4 character";
                return info;
            }
            if (prizeVerifier(prizeID) == true)
            {
                info = "Error! This Id already exists!";
                return info;
            }
            if (value > 299.99)
            {
                info = "Error! Value Prize !";
                return info;
            }
            if (originalAvailable > 999)
            {
                info = "Error! the capacity of the store is 999 items !";
                return info;
            }
            if (sponsorVerifier(sponsorId) == false)
            {
                info = "Error! Sponsor Id is incorrect!";
                return info;
            }
            addValue(value, originalAvailable, sponsorId);

            PrizeClass prize = new PrizeClass(prizeID, description, value, originalAvailable, sponsorId);
            prizes.add(prize);

            info = "Prize has been successfully added to the list.";

            return info;
        }

        public string addDonor(string donorID, string firstname, string lastname, string address, string phoneNumber, char creditCardType, string creditCardNumber, string creditCardExpiryDate)
        {
            string info = "";
            
            if (donorID.Length != 4)
            {
                info = "Error..! the Donor ID should be 4 character";
                return info;
            }
            
            if (donorVerifier(donorID) == true)
            {
                info = "Error! This Id already exists!";
                return info;
            }

            if (firstname.Length > 15)
            {
                info = "Error! Name should be 15 chars";
                return info;
            }

            if (lastname.Length > 15)
            {
                info = "Error! Name should be 15 chars";
                return info;
            }

            if (address.Length > 40)
            {
                info = "Error! Address should be 40 chars";
                return info;
            }

            if (phoneNumberRegex(phoneNumber) == false)
            {
                info = "Error! Phone number should as pattern 514-200-0000";
                return info;
            }

            if (creditCardTypeRegex(creditCardType) == false)
            {
                info = "Error! Phone number should as pattern V M A or v m a";
                return info;
            }

            if (creditCardNumberVerfier(creditCardNumber) == true)
            {
                info = "Error! This Number already exists!";
                return info;
            }

            if (creditCardNumberRegex(creditCardNumber) == false)
            {
                info = "Error! Credit Card number should as pattern 2000-0000-0000-0000 and 16 digits ";
                return info;
            }

            if (creditCardExpiryDateRegex(creditCardExpiryDate) == false)
            {
                info = "Error! Credit Card Expiry Date should as pattern (mm/yyyy)";
                return info;
            }


            DonorClass donor = new DonorClass(donorID, firstname, lastname, address, phoneNumber, creditCardType, creditCardNumber, creditCardExpiryDate);
            donors.add(donor);

            info = "Donor has been successfully added to the list.";
            return info;

        }

        public string addDonation(string donationID, string donorID, double donationAmount, string prizeID, int numberOFQualifiedPrizes)
        {
            string info = "";

            if (donationID.Length != 4)
            {
                info = "Error..! the Donation ID should be 4 character";
                return info;
            }

            if (donationVerifier(donationID) == true)
            {
                info = "Error! This Id already exists!";
                return info;
            }

            if (donorVerifier(donorID) == false)
            {
                info = "Error! Donor ID is incorrect.!";
                return info;
            }

            if (donationAmount < 5 || donationAmount > 99999999)
            {
                info = "Error! Donation Amount !";
                return info;
            }

            if (prizeVerifier(prizeID) == false)
            {
                info = "Error! Prize ID is incorrect.!";
                return info;
            }

            if (recordDonation(prizeID, numberOFQualifiedPrizes, donationAmount) == false)
            {
                info = "Error..! Select another Prize...";
                return info;
            }

            DonationClass donation = new DonationClass(donationID, donorID, donationAmount, prizeID, numberOFQualifiedPrizes);
            donations.add(donation);

            info = "Donation has been successfully added to the list.";

            return info;

        }




        //search Section
        public string searchSponsor(string sponsorID)
        {
            string info = "";
            if (sponsorID.Length != 4)
            {
                info = "Error..! the Sponsor ID should be 4 character";
                return info;
            }
            if (sponsorVerifier(sponsorID) == false)
            {
                info = "Error..! This Id doest not exists!";
                return info;
            }

            info = sponsorOneDisplay(sponsorID);

            return info;
        }
        
        public string searchPrize(string prizeID)
        {
            string info = "";
            if (prizeID.Length != 4)
            {
                info = "Error..! the prize ID should be 4 character";
                return info;
            }
            if (prizeVerifier(prizeID) == false)
            {
                info = "Error..! This Id doest not exists!";
                return info;
            }

            info = prizeOneDisplay(prizeID);

            return info;
        }

        public string searchDonor(string donorID)
        {
            string info = "";
            if (donorID.Length != 4)
            {
                info = "Error..! the prize ID should be 4 character";
                return info;
            }
            if (donorVerifier(donorID) == false)
            {
                info = "Error..! This Id doest not exists!";
                return info;
            }

            info = donorOneDisplay(donorID);

            return info;
        }

        public string searchDonation(string donationID)
        {
            string info = "";
            if (donationID.Length != 4)
            {
                info = "Error..! the prize ID should be 4 character";
                return info;
            }
            if (donationVerifier(donationID) == false)
            {
                info = "Error..! This Id doest not exists!";
                return info;
            }

            info = donationOneDisplay(donationID);

            return info;
        }

        
        
        //List Section
        public string listSponsor()
        {
            string msg = "";

            foreach (SponsorClass sponsor in sponsors)
            {
                msg += sponsor.toString();
            }
            return msg;
        }
        
        public string listPrize()
        {
            string msg = "";
            foreach (PrizeClass prize in prizes)
            {
                msg += prize.toString();
            }
            return msg;
        }

        public string listDonor()
        {
            string msg = "";
            foreach (DonorClass donor in donors)
            {
                msg += donor.toString();
            }
            return msg;
        }

        public string listDonation()
        {
            string msg = "";
            foreach (DonationClass donation in donations)
            {
                msg += donation.toString();
            }
            return msg;
        }


        //write Data to file
        public void backupData()
        {
            
            try
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(path, sponsorFile)))
                {
                    foreach (SponsorClass sponsor in sponsors)
                    {
                        sw.WriteLine(sponsor.toString());
                    }
                    sw.Close();
                    
                }

                using (StreamWriter sw = new StreamWriter(Path.Combine(path, prizeFile)))
                {
                    foreach (PrizeClass prize in prizes)
                    {
                        sw.WriteLine(prize.toString());
                    }
                    sw.Close();
                }

                using (StreamWriter sw = new StreamWriter(Path.Combine(path, donorFile)))
                {
                    foreach (DonorClass donor in donors)
                    {
                        sw.WriteLine(donor.toString());
                    }
                    sw.Close();
                }

                using (StreamWriter sw = new StreamWriter(Path.Combine(path, donationFile)))
                {
                    foreach (DonationClass donation in donations)
                    {
                        sw.WriteLine(donation.toString());
                    }
                    sw.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

            }
        }

    }//End class ETS_winForm
}
