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
    public partial class Prize : KryptonForm
    {

        ETS_Manager eTS_Manager;

        public Prize(ETS_Manager eTS_Manager)
        {
            InitializeComponent();
            this.eTS_Manager = eTS_Manager;

        }

        private void Prize_Load(object sender, EventArgs e)
        {
            this.ActiveControl = tbPrizeID;
            lapPrizeLoc.Text = laPrize.Text;
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            rbtConsolePrize.Clear();
            tbPrizeID.Clear();
            tbValue.Clear();
            tbQuantity.Clear();
            tbDonLimit.Clear();
            tbSponID.Clear();
            tbDescription.Clear();
            tbPrizeID.Focus();
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(eTS_Manager);
            this.Hide();
            dashboard.Visible = true;
            dashboard.Activate();
        }

        private void btAddPrize_Click(object sender, EventArgs e)
        {
            string info = eTS_Manager.addPrize(tbPrizeID.Text, tbDescription.Text, Convert.ToDouble(tbValue.Text), Convert.ToInt32(tbQuantity.Text), tbSponID.Text);

            MessageBox.Show(info, "Add Prize");
        }

        private void btListprize_Click(object sender, EventArgs e)
        {
            rbtConsolePrize.Clear();
            rbtConsolePrize.AppendText(eTS_Manager.listPrize());
        }

        private void btSearchPrize_Click(object sender, EventArgs e)
        {
            string info = eTS_Manager.searchPrize(tbPrizeID.Text);

            if (info.Contains("Error"))
            {
                MessageBox.Show(info, "Error");

            }
            else
            {
                rbtConsolePrize.Clear();
                rbtConsolePrize.AppendText(info);
                tbPrizeID.Clear();
                tbPrizeID.Focus();
            }
        }

        private void tbDonLimit_Enter(object sender, EventArgs e)
        {
            const double percentageOfDonation = 0.05;

            double result = Math.Round(Convert.ToDouble(tbValue.Text) / percentageOfDonation, 2);
            string dl = result.ToString();
            tbDonLimit.AppendText(dl);
        }
    }
}
