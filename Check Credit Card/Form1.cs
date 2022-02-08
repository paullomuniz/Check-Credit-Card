using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Check_Credit_Card
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string strIsValid = "";

        private void btnCheck_Click(object sender, EventArgs e)
        {
            strIsValid = Func.CheckValidity(txtCardNumber.Text);

            if(strIsValid == "true")
            {
                GetCardInfos();
            }
            else if (strIsValid == "false")
            {
                MessageBox.Show("This card number is invalid!", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            

        }

        private void GetCardInfos()
        {
            string strJsonString = (new WebClient()).DownloadString("https://bin-check-dr4g.herokuapp.com/api/" + txtCardNumber.Text);

            string[] resultVendor = strJsonString.Split(new string[] { "\x22vendor\x22:\x22", "\x22,\x22type\x22:\x22" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in resultVendor)
            {
                if (s.Contains(":")) { }
                else
                {
                    txtVendor.Text = s;
                }
            }

            string[] resultType = strJsonString.Split(new string[] { "\x22,\x22type\x22:\x22", "\x22,\x22level\x22" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in resultType)
            {
                if (s.Contains(":")) { }
                else
                {
                    txtType.Text = s;
                }
            }

            string[] resultBank = strJsonString.Split(new string[] { "bank\x22:\x22", "\x22,\x22" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in resultBank)
            {
                if (s.Contains(":")) { }
                else
                {
                    txtBank.Text = s;
                }
            }

            string[] resultCountry = strJsonString.Split(new string[] { "ountry\x22:\x22", "\x22,\x22" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in resultCountry)
            {
                if (s.Contains(":")) { }
                else
                {
                    txtCountry.Text = s;
                }
            }

        }
    }
}
