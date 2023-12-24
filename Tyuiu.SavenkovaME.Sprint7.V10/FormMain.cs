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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonCatalog_SME_Click(object sender, EventArgs e)
        {
            FormCatalog catalog = new FormCatalog();
            catalog.ShowDialog();
        }

        private void labelAboutUs_SME_Click(object sender, EventArgs e)
        {
            FormAboutUs aboutUs = new FormAboutUs();
            aboutUs.Show();
        }

        private void labelQuestions_SME_Click(object sender, EventArgs e)
        {
            FormHelp help = new FormHelp();
            help.Show();
        }

        private void labelDeliveryAndPay_SME_Click(object sender, EventArgs e)
        {
            FormDeliveryPay deliveryPay = new FormDeliveryPay();
            deliveryPay.Show();
        }
    }
}
