using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tyuiu.SavenkovaME.Sprint7.V10
{
    public partial class FormRegister : Form
    {
        public FormRegister(string fio, string address, string num, string pay)
        {
            InitializeComponent();
            textBoxResult_SME.Text = fio;
            textBoxAddress_SME.Text = address;
            textBoxNumber_SME.Text = num;
            textBoxSum_SME.Text = pay;
            labelTime_SME.Text = Convert.ToString(DateTime.Now);
        }

        private void buttonOK_SME_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
