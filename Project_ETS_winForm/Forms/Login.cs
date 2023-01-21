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
using ETSLibraryClass;

namespace Project_ETS_winForm
{
    public partial class Login : KryptonForm
    {
        
        int attempt = 1;
        string msg = "";
        string fileName = "login.txt";
        string path = @"C:\Users\jabra\OneDrive\Desktop\Project_ETS_winForm\DB_txt\";
        public static string sendtext = "";


        ETS_Manager eTS_Manager;
        public Login()
        {
            InitializeComponent();
            this.eTS_Manager = new ETS_Manager();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tbLogin_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(Path.Combine(path, fileName)))
            {

                string line = sr.ReadLine();
                string[] lineArray = line.Split(',');

                string username = lineArray[0];
                string password = lineArray[1];

                if (tbUser.Text == username && tbPass.Text == password)
                {
                    Dashboard dashboard = new Dashboard(eTS_Manager);
                    this.Hide();
                    sendtext = tbUser.Text;
                    dashboard.Visible = true;
                    dashboard.Activate();
                }

                if (attempt < 4)
                {
                    if (tbUser.Text != username && tbPass.Text == password)
                    {
                        MessageBox.Show("Username is incorrect....!", $"attempt No. {attempt.ToString()}");
                    }
                    else if (tbUser.Text == username && tbPass.Text != password)
                    {
                        MessageBox.Show("Password is incorrect....!", $"attempt No. {attempt.ToString()}");
                    }
                    else if (tbUser.Text != username && tbPass.Text != password)
                    {
                        MessageBox.Show("Username and Password are incorrect....! ", $"attempt No. {attempt.ToString()}");
                    }
                    ++attempt;
                }
                if (attempt == 4)
                {
                    msg = "Unable to login, try later";
                    MessageBox.Show(msg, "Error...");
                    Application.Exit();
                }

            }
        }

    }
}
