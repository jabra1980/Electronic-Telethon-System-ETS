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
    public partial class Donor : KryptonForm
    {

        ETS_Manager eTS_Manager;

        public Donor(ETS_Manager eTS_Manager)
        {
            InitializeComponent();
            this.eTS_Manager = eTS_Manager;
        }

        private char cardType()
        {
            char cardType = '\0';
            if (rbVisa.Checked)
            {
                cardType = 'V';
            }
            if (rbMC.Checked)
            {
                cardType = 'M';
            }
            if (rbAMEX.Checked)
            {
                cardType = 'A';
            }
            return cardType;
        }


        private void Donor_Load(object sender, EventArgs e)
        {
            this.ActiveControl = tbDonorID;
            lapDonorLoc.Text = laDonor.Text;
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            rbtConsoleDonor.Clear();
            tbDonorID.Clear();
            tbfName.Clear();
            tblName.Clear();
            tbAddress.Clear();
            tbPhone.Clear();
            rbVisa.Checked = false;
            rbMC.Checked = false;
            rbAMEX.Checked = false;
            tbNumber.Clear();
            tbExpiry.Clear();
            tbDonorID.Focus();
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(eTS_Manager);
            this.Hide();
            dashboard.Visible = true;
            dashboard.Activate();
        }

        private void btAddDonor_Click(object sender, EventArgs e)
        {
            string info = eTS_Manager.addDonor(tbDonorID.Text, tbfName.Text, tblName.Text, tbAddress.Text, tbPhone.Text, cardType(), tbNumber.Text, tbExpiry.Text);

            MessageBox.Show(info, "Add Donor");
            rbtConsoleDonor.Clear();
            tbDonorID.Clear();
            tbfName.Clear();
            tblName.Clear();
            tbAddress.Clear();
            tbPhone.Clear();
            rbVisa.Checked = false;
            rbMC.Checked = false;
            rbAMEX.Checked = false;
            tbNumber.Clear();
            tbExpiry.Clear();
            tbDonorID.Focus();
        }

        private void btListDonor_Click(object sender, EventArgs e)
        {
            rbtConsoleDonor.Clear();
            rbtConsoleDonor.AppendText(eTS_Manager.listDonor());
        }

        private void btSearchDonor_Click(object sender, EventArgs e)
        {
            string info = eTS_Manager.searchDonor(tbDonorID.Text);

            if (info.Contains("Error"))
            {
                MessageBox.Show(info, "Error");

            }
            else
            {
                rbtConsoleDonor.Clear();
                rbtConsoleDonor.AppendText(info);
                tbDonorID.Clear();
                tbDonorID.Focus();
            }
        }
    }
}
