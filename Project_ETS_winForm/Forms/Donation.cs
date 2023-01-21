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

namespace Project_ETS_winForm
{
    public partial class Donation : KryptonForm
    {

        ETS_Manager eTS_Manager;

        public Donation(ETS_Manager eTS_Manager)
        {
            InitializeComponent();
            this.eTS_Manager = eTS_Manager;
        }

        private void Donation_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            this.ActiveControl = tbDonationID;
            lapDonationLoc.Text = laDonation.Text;
            string date = today.ToString("dd/MM/yyyy");
            tbDonationDate.Text = date;
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(eTS_Manager);
            this.Hide();
            dashboard.Visible = true;
            dashboard.Activate();
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            rbtConsoleDonation.Clear();
            tbDonationID.Clear();
            tbDonorID.Clear();
            tbAmount.Clear();
            tbPrizeID.Clear();
            tbNumber.Clear();
            tbDonationID.Focus();
        }

        private void btAddDonor_Click(object sender, EventArgs e)
        {
            string info = eTS_Manager.addDonation(tbDonationID.Text, tbDonorID.Text, Convert.ToDouble(tbAmount.Text), tbPrizeID.Text, Convert.ToInt32(tbNumber.Text));

            MessageBox.Show(info, "Add Donation");
        }

        private void btListDonor_Click(object sender, EventArgs e)
        {
            rbtConsoleDonation.Clear();
            rbtConsoleDonation.AppendText(eTS_Manager.listDonation());
        }

        private void btSearchDonor_Click(object sender, EventArgs e)
        {
            string info = eTS_Manager.searchDonation(tbDonationID.Text);

            if (info.Contains("Error"))
            {
                MessageBox.Show(info, "Error");

            }
            else
            {
                rbtConsoleDonation.Clear();
                rbtConsoleDonation.AppendText(info);
                tbDonationID.Clear();
                tbDonationID.Focus();
            }
        }

        private void btShowPrize_Click(object sender, EventArgs e)
        {
            string info = eTS_Manager.listQualifiedPrizes(Convert.ToDouble(tbAmount.Text));
            rbtConsoleDonation.AppendText(info);
        }
    }
}
