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
    public partial class Sponsor : KryptonForm
    {

        ETS_Manager eTS_Manager;

        public Sponsor(ETS_Manager eTS_Manager)
        {
            InitializeComponent();
            this.eTS_Manager = eTS_Manager;


        }

        private void Sponsor_Load(object sender, EventArgs e)
        {
            this.ActiveControl = tbSponsorID;
            laSponsorLoc.Text = laSponsor.Text;
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            rbtConsole.Clear();
        }

        private void btAddSponsor_Click(object sender, EventArgs e)
        {
            string info = eTS_Manager.AddSponsor(tbSponsorID.Text, tbfName.Text, tblName.Text);
            MessageBox.Show(info, "Add Sponsor");
            tbSponsorID.Clear();
            tbfName.Clear();
            tblName.Clear();
            tbSponsorID.Focus();
        }

        private void btListSponsor_Click(object sender, EventArgs e)
        {
            rbtConsole.Clear();
            rbtConsole.AppendText(eTS_Manager.listSponsor());
        }

        private void btSearchSponsor_Click(object sender, EventArgs e)
        {
            string info = eTS_Manager.searchSponsor(tbSponsorID.Text);

            if (info.Contains("Error"))
            {
                MessageBox.Show(info, "Error");

            }
            else
            {
                rbtConsole.Clear();
                rbtConsole.AppendText(info);
                tbSponsorID.Clear();
                tbSponsorID.Focus();
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(eTS_Manager);
            this.Hide();
            dashboard.Visible = true;
            dashboard.Activate();
        }
    }
}
