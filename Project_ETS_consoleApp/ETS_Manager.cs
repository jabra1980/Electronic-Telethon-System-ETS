using Project_ETS_consoleApp.Indexer;
using Project_ETS_consoleApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;

namespace Project_ETS_consoleApp
{
    public class ETS_Manager
    {
        //Objects of Lists
        Sponsors sponsors = new Sponsors();
        Prizes prizes = new Prizes();
        Donors donors = new Donors();
        Donations donations = new Donations();

        
        //Files & locations path
        string sponsorFile = "sponsor.txt";
        string prizeFile = "prize.txt";
        string donorFile = "donor.txt";
        string donationFile = "donation.txt";
        string path = @"C:\Users\jabra\OneDrive\Desktop\Project_ETS_consoleApp\DBtxt\";

        

        // Verifier Section
        public bool sponsorVerifier(string sponsorID)
        {
            bool flag = false;

            foreach (Sponsor sponsor in sponsors)
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

            foreach (Prize prize in prizes)
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

            foreach (Donor donor in donors)
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

            foreach (Donation donation in donations)
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

            foreach (Donor donor in donors)
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
            foreach (Sponsor sponsor in sponsors)
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
            foreach (Prize prize in prizes)
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
            foreach (Donor donor in donors)
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
            foreach (Donation donation in donations)
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
            foreach (Prize prize in prizes)
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

            foreach (Sponsor sponsor in sponsors)
            {
                if (sponsor.getSponsorID() == sponsorID)
                {
                    sponsor.addTotalPrize(value, origAvilable);
                }
            }
        }

        public double listQualifiedPrizes(double donationAmount)
        {
            
            double numberOFQualifiedPrizes = 0;
            foreach (Prize prize in prizes)
            {
                if (prize.DonationLimit <= donationAmount)
                {
                    numberOFQualifiedPrizes = (int)(donationAmount / prize.DonationLimit);
                    Console.WriteLine("Prize ID: " + prize.PrizeID + " " + "Description: " + prize.Description + " " + "Number of Prize: " + numberOFQualifiedPrizes + "\n");
                }

                
            }
            return numberOFQualifiedPrizes;
        }

        public bool recordDonation(string prizeID, int number, double donationAmount)
        {

            foreach (Prize prize in prizes)
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

        public double getDontiionLimit()
        {
            double donLimit = 0.0;
            foreach (Prize prize in prizes)
            {
                donLimit = prize.DonationLimit;
            }
            return donLimit;
        }



        //adding Section
        public void addSponsor()
        {
            Console.WriteLine("Please, enter Sponsor ID? ");
            string sponsorID = Console.ReadLine();

            while (sponsorID.Length != 4)
            {
                Console.WriteLine("Error..! the Sponsor ID should be 4 character");

                Console.WriteLine("Please, enter Sponsor ID? ");
                sponsorID = Console.ReadLine();
            }
            while (sponsorVerifier(sponsorID) == true)
            {
                Console.WriteLine("Error! This Id already exists!");

                Console.WriteLine("Please, enter Sponsor ID? ");
                sponsorID = Console.ReadLine();
            }

            
            Console.WriteLine("Please, enter Sponsor first name? ");
            string firstname = Console.ReadLine();

            while (firstname.Length > 15)
            {
                Console.WriteLine("Error! Name should be 15 chars");

                Console.WriteLine("Please, enter Sponsor first name? ");
                firstname = Console.ReadLine();
            }

            
            Console.WriteLine("Please, enter Sponsor last name? ");
            string lastname = Console.ReadLine();

            while (lastname.Length > 15)
            {
                Console.WriteLine("Error! Name should be 15 chars");

                Console.WriteLine("Please, enter Sponsor last name? ");
                lastname = Console.ReadLine();
            }

            
            Sponsor sponsor = new Sponsor(sponsorID, firstname, lastname);
            sponsors.add(sponsor);

            Console.WriteLine("Success! The Sponsor added to the list");
            
        }

        public void addPrize()
        {
            Console.WriteLine("Please, enter Prize ID? ");
            string prizeID = Console.ReadLine();

            while (prizeID.Length != 4)
            {
                Console.WriteLine("Error..! the Prize ID should be 4 character");
                
                Console.WriteLine("Please, enter Prize ID? ");
                prizeID = Console.ReadLine();
            }
            while (prizeVerifier(prizeID) == true)
            {
                Console.WriteLine("Error! This Id already exists!");

                Console.WriteLine("Please, enter Prize ID? ");
                prizeID = Console.ReadLine();
            }

            Console.WriteLine("Please, enter Prize Description? ");
            string description = Console.ReadLine();

            Console.WriteLine("Please, enter Prize Value? ");
            double value = Convert.ToDouble(Console.ReadLine());

            while (value > 299.99)
            {
                Console.WriteLine("Error! Value Prize !");

                Console.WriteLine("Please, enter Prize Value? ");
                value = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine("How many quantity would you like to give? ");
            int originalAvailable = Convert.ToInt32(Console.ReadLine());

            while (originalAvailable > 999)
            {
                Console.WriteLine("Error! the capacity of the store is 999 items !");

                Console.WriteLine("How many quantity would you like to give? ");
                originalAvailable = Convert.ToInt32(Console.ReadLine());
            }

            

            Console.WriteLine("Please, Enter Sponsor ID? ");
            string sponsorId = Console.ReadLine();

            while (sponsorVerifier(sponsorId) == false)
            {
                Console.WriteLine("Error! Sponsor Id is incorrect!");

                Console.WriteLine("Please, Enter Sponsor ID? ");
                sponsorId = Console.ReadLine();
            }

            addValue(value, originalAvailable, sponsorId);
            
            Prize prize = new Prize(prizeID, description, value, originalAvailable, sponsorId);
            prizes.add(prize);
            
            Console.WriteLine($"donoation Limit: {getDontiionLimit()}");
            Console.WriteLine("Prize has been successfully added to the list.");
        }

        public void addDonor()
        {
            Console.WriteLine("Please, enter Donor ID? ");
            string donorID = Console.ReadLine();

            while (donorID.Length != 4)
            {
                Console.WriteLine("Error..! the Donor ID should be 4 character");
                
                Console.WriteLine("Please, enter Donor ID? ");
                donorID = Console.ReadLine();
            }
            while (donorVerifier(donorID) == true)
            {
                Console.WriteLine("Error! This Id already exists!");
                
                Console.WriteLine("Please, enter Donor ID? ");
                donorID = Console.ReadLine();
            }

            
            Console.WriteLine("Please, enter Donor first name? ");
            string firstname = Console.ReadLine();
            
            while (firstname.Length > 15)
            {
                Console.WriteLine("Error! Name should be 15 chars");
                
                Console.WriteLine("Please, enter Donor first name? ");
                firstname = Console.ReadLine();
            }

            
            Console.WriteLine("Please, enter Donor last name? ");
            string lastname = Console.ReadLine();

            while (lastname.Length > 15)
            {
                Console.WriteLine("Error! Name should be 15 chars");

                Console.WriteLine("Please, enter Donor last name? ");
                lastname = Console.ReadLine();
            }

            
            Console.WriteLine("Please, enter Donor Address: ");
            string address = Console.ReadLine();

            while (address.Length > 40)
            {
                Console.WriteLine("Error! Address should be 40 chars");
                
                Console.WriteLine("Please, enter Donor Address: ");
                address = Console.ReadLine();
            }

            
            Console.WriteLine("Please, enter Donor Phone number? ");
            string phoneNumber = Console.ReadLine();

            while (phoneNumberRegex(phoneNumber) == false)
            {
                Console.WriteLine("Error! Phone number should as pattern 514-200-0000");

                Console.WriteLine("Please, enter Donor Phone number? ");
                phoneNumber = Console.ReadLine();
            }

            
            Console.WriteLine("Please, enter Donor Credit Card Type? ");
            char creditCardType = Convert.ToChar(Console.ReadLine());

            while (creditCardTypeRegex(creditCardType) == false)
            {
                Console.WriteLine("Error! Phone number should as pattern V M A or v m a");

                Console.WriteLine("Please, enter Donor Credit Card Type? ");
                creditCardType = Convert.ToChar(Console.ReadLine());
            }

            
            Console.WriteLine("Please, enter Donor Credit Card Number? ");
            string creditCardNumber = Console.ReadLine();

            while (creditCardNumberVerfier(creditCardNumber) == true)
            {
                Console.WriteLine("Error! This Number already exists!");

                Console.WriteLine("Please, enter Donor Credit Card Number? ");
                creditCardNumber = Console.ReadLine();
            }
            while (creditCardNumberRegex(creditCardNumber) == false)
            {
                Console.WriteLine("Error! Credit Card number should as pattern 2000-0000-0000-0000 and 16 digits ");
                Console.WriteLine("Please, enter Donor Credit Card Number? ");
                creditCardNumber = Console.ReadLine();
            }

            
            Console.WriteLine("Please, enter Donor Credit Card Expiry Date? ");
            string creditCardExpiryDate = Console.ReadLine();

            while (creditCardExpiryDateRegex(creditCardExpiryDate) == false)
            {
                Console.WriteLine("Error! Credit Card Expiry Date should as pattern (mm/yyyy)");

                Console.WriteLine("Please, enter Donor Credit Card Expiry Date? ");
                creditCardExpiryDate = Console.ReadLine();
            }

            
            Donor donor = new Donor(donorID, firstname, lastname, address, phoneNumber, creditCardType, creditCardNumber, creditCardExpiryDate);
            donors.add(donor);

            Console.WriteLine("Donor has been successfully added to the list.");
            
        }

        public void addDonation()
        {
            Console.WriteLine("Please, enter Donation ID? ");
            string donationID = Console.ReadLine();

            while (donationID.Length != 4)
            {
                Console.WriteLine("Error..! the Donation ID should be 4 character");

                Console.WriteLine("Please, enter Donation ID? ");
                donationID = Console.ReadLine();
            }

            while (donationVerifier(donationID) == true)
            {
                Console.WriteLine("Error! This Id already exists!");

                Console.WriteLine("Please, enter Donation ID? ");
                donationID = Console.ReadLine();
            }

            Console.WriteLine("Please, enter Donor ID? ");
            string donorID = Console.ReadLine();

            while (donorVerifier(donorID) == false)
            {
                Console.WriteLine("Error! Donor ID is incorrect.!");

                Console.WriteLine("Please, enter Donor ID? ");
                donorID = Console.ReadLine();
            }

            Console.WriteLine("Please, enter Donation Amount? ");
            double donationAmount = Convert.ToDouble(Console.ReadLine());

            while (donationAmount < 5 || donationAmount > 99999999)
            {
                Console.WriteLine("Error! Donation Amount !");

                Console.WriteLine("Please, enter Donation Amount? ");
                donationAmount = Convert.ToDouble(Console.ReadLine());
            }

            listQualifiedPrizes(donationAmount);

            Console.WriteLine("Please, enter Prize ID? ");
            string prizeID = Console.ReadLine();

            while (prizeVerifier(prizeID) == false)
            {
                Console.WriteLine("Error! Prize ID is incorrect.!");

                Console.WriteLine("Please, enter Prize ID? ");
                prizeID = Console.ReadLine();
            }

            Console.WriteLine("Enter number of prize? ");
            int numberOFQualifiedPrizes = Convert.ToInt32(Console.ReadLine());

            while (recordDonation(prizeID, numberOFQualifiedPrizes, donationAmount) == false)
            {
                Console.WriteLine("Error..! Select another Prize...");

                Console.WriteLine("Enter number of prize? ");
                numberOFQualifiedPrizes = Convert.ToInt32(Console.ReadLine());
            }

            Donation donation = new Donation(donationID, donorID, donationAmount, prizeID);
            donations.add(donation);

            Console.WriteLine("Donation has been successfully added to the list.");

        }



        //search Section
        public void searchSponsor()
        {
            Console.WriteLine("Please, enter Sponsor ID? ");
            string sponsorID = Console.ReadLine();

            while (sponsorID.Length != 4)
            {
                Console.WriteLine("Error..! the Sponsor ID should be 4 character");

                Console.WriteLine("Please, enter Sponsor ID? ");
                sponsorID = Console.ReadLine();
            }
            
            while (sponsorVerifier(sponsorID) == false)
            {
                Console.WriteLine("Error! This Id doest not exists!");

                Console.WriteLine("Please, enter Sponsor ID? ");
                sponsorID = Console.ReadLine();
            }

            Console.WriteLine(sponsorOneDisplay(sponsorID));
        }

        public void searchPrize()
        {
            Console.WriteLine("Please, enter Prize ID? ");
            string prizeID = Console.ReadLine();

            while (prizeID.Length != 4)
            {
                Console.WriteLine("Error..! the Prize ID should be 4 character");

                Console.WriteLine("Please, enter Prize ID? ");
                prizeID = Console.ReadLine();
            }
            
            while (prizeVerifier(prizeID) == false)
            {
                Console.WriteLine("Error! This Id doest not exists!");

                Console.WriteLine("Please, enter Prize ID? ");
                prizeID = Console.ReadLine();
            }
            Console.WriteLine(prizeOneDisplay(prizeID));
        }

        public void searchDonor()
        {
            Console.WriteLine("Please, enter Donor ID? ");
            string donorID = Console.ReadLine();

            if (donorID.Length != 4)
            {
                Console.WriteLine("Error..! the Donor ID should be 4 character");

                Console.WriteLine("Please, enter Donor ID? ");
                donorID = Console.ReadLine();
            }

            while (donorVerifier(donorID) == false)
            {
                Console.WriteLine("Error! This Id doest not exists!");

                Console.WriteLine("Please, enter Donor ID? ");
                donorID = Console.ReadLine();
            }

            Console.WriteLine(donorOneDisplay(donorID));
        }

        public void searchDonation()
        {
            Console.WriteLine("Please, enter Donation ID? ");
            string donationID = Console.ReadLine();

            while (donationID.Length != 4)
            {
                Console.WriteLine("Error..! the Donation ID should be 4 character");

                Console.WriteLine("Please, enter Donation ID? ");
                donationID = Console.ReadLine();
            }
            
            while (donationVerifier(donationID) == false)
            {
                Console.WriteLine("Error! This Id doest not exists!");

                Console.WriteLine("Please, enter Donation ID? ");
                donationID = Console.ReadLine();
            }
            Console.WriteLine(donationOneDisplay(donationID));
        }




        //Listing Section
        public void listSponsor()
        {
            foreach (Sponsor sponsor in sponsors)
            {
                Console.Write(sponsor.toString());
                Console.WriteLine();

            }

        }

        public void listPrize()
        {
            foreach (Prize prize in prizes)
            {
                Console.Write(prize.toString());
                Console.WriteLine();

            }
        }

        public void listDonor()
        {
            foreach (Donor donor in donors)
            {
                Console.Write(donor.toString());
                Console.WriteLine();
            }
        }

        public void listDonation()
        {
            foreach (Donation donation in donations)
            {
                Console.Write(donation.toString());
                Console.WriteLine();
            }
        }

        
       // Write to File
        public void backupData()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(path, sponsorFile)))
                {
                    foreach (Sponsor sponsor in sponsors)
                    {
                        sw.WriteLine(sponsor.toString());
                    }
                    sw.Close();
                }

                using (StreamWriter sw = new StreamWriter(Path.Combine(path, prizeFile)))
                {
                    foreach (Prize prize in prizes)
                    {
                        sw.WriteLine(prize.toString());
                    }
                    sw.Close();
                }

                using (StreamWriter sw = new StreamWriter(Path.Combine(path, donorFile)))
                {
                    foreach (Donor donor in donors)
                    {
                        sw.WriteLine(donor.toString());
                    }
                    sw.Close();
                }

                using (StreamWriter sw = new StreamWriter(Path.Combine(path, donationFile)))
                {
                    foreach (Donation donation in donations)
                    {
                        sw.WriteLine(donation.toString());
                    }
                    sw.Close();
                }

                Console.WriteLine("Success! all data Backup to file");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                
            }
        }

    }//End class ETS_Manager

}//End nameSpace
