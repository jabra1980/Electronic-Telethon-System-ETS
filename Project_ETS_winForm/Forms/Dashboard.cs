using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ETSLibraryClass;
using ComponentFactory.Krypton.Toolkit;
using System.IO;
using System.Windows.Markup;

namespace Project_ETS_winForm
{
    public partial class Dashboard : KryptonForm
    {

        ETS_Manager eTS_Manager;
        
        public Dashboard(ETS_Manager eTS_Manager)
        {
            InitializeComponent();
            this.eTS_Manager = eTS_Manager;

        }
        

        private void Dashboard_Load(object sender, EventArgs e)
        {
            labUser.Text = Login.sendtext;
            laMain.Text = laDashboard.Text;
            labCurrentDate.Text = DateTime.Now.ToLongDateString();
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tbSponsor_Click(object sender, EventArgs e)
        {
            Sponsor sponsor = new Sponsor(eTS_Manager);
            this.Hide();
            sponsor.Visible = true;
            sponsor.Activate();
        }

        private void btPrize_Click(object sender, EventArgs e)
        {
            Prize prize = new Prize(eTS_Manager);
            this.Hide();
            prize.Visible = true;
            prize.Activate();
        }

        private void btDonor_Click(object sender, EventArgs e)
        {
            Donor donor = new Donor(eTS_Manager);
            this.Hide();
            donor.Visible = true;
            donor.Activate();
        }

        private void btDonation_Click(object sender, EventArgs e)
        {
            Donation donation = new Donation(eTS_Manager);
            this.Hide();
            donation.Visible = true;
            donation.Activate();
        }

        private void btBackup_Click(object sender, EventArgs e)
        {
            eTS_Manager.backupData();
            MessageBox.Show("Success! all data backup to file", "Backup");
        }
    }
}
