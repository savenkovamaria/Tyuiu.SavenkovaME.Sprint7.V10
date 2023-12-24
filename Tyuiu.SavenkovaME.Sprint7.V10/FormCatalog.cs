using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tyuiu.SavenkovaME.Sprint7.V10.Lib;

namespace Tyuiu.SavenkovaME.Sprint7.V10
{
    public partial class FormCatalog : Form
    {
        static string openfile = @"C:\Users\saven\OneDrive\Рабочий стол\прога\Files\Товары.csv";
        static int rows;
        static int columns;
        public string[] basket = new string[3];
        public int total;
        public string products;
        public int countComp;
        public int countMouse;
        public int countKey;
        public FormCatalog()
        {
            InitializeComponent();
            openFileDialogProduct_SME.Filter = "Значения, разделенные запятыми(*.csv)|*.csv|Всефайлы(*.*)|*.*";
        }
        DataService ds = new DataService();
        private void buttonClose_SME_Click(object sender, EventArgs e)
        {
            richTextBoxShop_SME.Visible = false;
            labelCatalog_SME.Visible = true;
            labelNameCatalog_SME.Visible = false;
            buttonClose_SME.Visible = false;
            buttonRegisterOrder_SME.Visible = false;
            labelTotal_SME.Visible = false;
            textBoxTotal_SME.Visible = false;
            pictureBoxShop_SME.Visible = true;
            labelName_SME.Visible = false;
            labelCountProducts_SME.Visible = false;
            labelPriceProducts_SME.Visible = false;
           
        }
        private void pictureBoxShop_SME_Click(object sender, EventArgs e)
        {
            
            richTextBoxShop_SME.Visible = true;
            labelCatalog_SME.Visible = false;
            labelNameCatalog_SME.Visible = true;
            buttonClose_SME.Visible = true;
            buttonRegisterOrder_SME.Visible = true;
            labelTotal_SME.Visible = true;
            textBoxTotal_SME.Visible = true;
            pictureBoxShop_SME.Visible = false;
            labelName_SME.Visible = true;
            labelCountProducts_SME.Visible = true;
            labelPriceProducts_SME.Visible = true;
         
        }

        private void buttonRegisterOrder_SME_Click(object sender, EventArgs e)
        {
            FormOrder order = new FormOrder(total, products);
            order.Show();

            richTextBoxShop_SME.Text = "";
            textBoxTotal_SME.Text = "";
        }

        private void buttonMinusComp_SME_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBoxCountComp_SME.Text) >= 1)
            {
                textBoxCountComp_SME.Text = Convert.ToString(Convert.ToInt32(textBoxCountComp_SME.Text) - 1);
                countComp = Convert.ToInt32(textBoxCountComp_SME.Text);
            }
        }

        private void buttonPlusComp_SME_Click(object sender, EventArgs e)
        {
            textBoxCountComp_SME.Text = Convert.ToString(Convert.ToInt32(textBoxCountComp_SME.Text) + 1);
            countComp = Convert.ToInt32(textBoxCountComp_SME.Text);
        }

        private void buttonMinusMouse_SME_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBoxCountMouse_SME.Text) >= 1)
            {
                textBoxCountMouse_SME.Text = Convert.ToString(Convert.ToInt32(textBoxCountMouse_SME.Text) - 1);
                countMouse = Convert.ToInt32(textBoxCountMouse_SME.Text);
            }
        }

        private void buttonPlusMouse_SME_Click(object sender, EventArgs e)
        {
            textBoxCountMouse_SME.Text = Convert.ToString(Convert.ToInt32(textBoxCountMouse_SME.Text) + 1);
            countMouse = Convert.ToInt32(textBoxCountMouse_SME.Text);
        }

        private void buttonMinusKey_SME_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBoxCountKey_SME.Text) >= 1)
            {
                textBoxCountKey_SME.Text = Convert.ToString(Convert.ToInt32(textBoxCountKey_SME.Text) - 1);
                countKey = Convert.ToInt32(textBoxCountKey_SME.Text);
            }
        }

        private void buttonPlusKey_SME_Click(object sender, EventArgs e)
        {
            textBoxCountKey_SME.Text = Convert.ToString(Convert.ToInt32(textBoxCountKey_SME.Text) + 1);
            countKey = Convert.ToInt32(textBoxCountKey_SME.Text);
        }
        
        private void buttonShopComp_SME_Click(object sender, EventArgs e)
        {
            rows = ds.LoadFromData(openfile).GetUpperBound(0) + 1;
            columns = ds.LoadFromData(openfile).GetUpperBound(1) + 1;
            openFileDialogProduct_SME.ShowDialog();
            openfile = openFileDialogProduct_SME.FileName;
            string[,] arrayValues = new string[rows, columns];
            arrayValues = ds.LoadFromData(openfile);
            string comp = arrayValues[1, 0] + "\t\t\t\t\t\t\t\t\t\t\t" + Convert.ToString(Convert.ToInt32(arrayValues[1, 2]) * countComp) + " p."
                + "\t\t\t\t" + Convert.ToString(countComp) + " шт.";

            richTextBoxShop_SME.Text += "\n\t" + comp + "\n";
            products += arrayValues[1, 0] + " " + Convert.ToString(countComp) + " шт.  ";
            total += Convert.ToInt32(arrayValues[1, 2]) * countComp;
            textBoxTotal_SME.Text = Convert.ToString(total) + " p.";
            buttonShopComp_SME.Text = "В корзине";
            buttonShopComp_SME.Enabled = false;
            buttonMinusComp_SME.Enabled = false;
            buttonPlusComp_SME.Enabled = false;
        }

        private void buttonShopMouse_SME_Click(object sender, EventArgs e)
        {
            rows = ds.LoadFromData(openfile).GetUpperBound(0) + 1;
            columns = ds.LoadFromData(openfile).GetUpperBound(1) + 1;
            openFileDialogProduct_SME.ShowDialog();
            openfile = openFileDialogProduct_SME.FileName;
            string[,] arrayValues = new string[rows, columns];
            arrayValues = ds.LoadFromData(openfile);
            string mouse = arrayValues[2, 0] + "\t\t\t\t\t" + Convert.ToString(Convert.ToInt32(arrayValues[2, 2]) * countMouse) + " p."
                + "  \t\t\t\t" + Convert.ToString(countMouse) + " шт.";
            richTextBoxShop_SME.Text += "\n\t" + mouse + "\n";
            products += arrayValues[2, 0] + " " + Convert.ToString(countMouse) + " шт.  ";
            total += Convert.ToInt32(arrayValues[2, 2]) * countMouse;
            textBoxTotal_SME.Text = Convert.ToString(total) + " p.";
            buttonShopMouse_SME.Text = "В корзине";
            buttonShopMouse_SME.Enabled = false;
            buttonMinusMouse_SME.Enabled = false;
            buttonPlusMouse_SME.Enabled = false;
        }

        private void buttonShopKey_SME_Click(object sender, EventArgs e)
        {
            rows = ds.LoadFromData(openfile).GetUpperBound(0) + 1;
            columns = ds.LoadFromData(openfile).GetUpperBound(1) + 1;
            openFileDialogProduct_SME.ShowDialog();
            openfile = openFileDialogProduct_SME.FileName;
            string[,] arrayValues1 = new string[rows, columns];
            arrayValues1 = ds.LoadFromData(openfile);
            string keyboard = arrayValues1[3, 0] + "\t\t\t\t " + Convert.ToString(Convert.ToInt32(arrayValues1[3, 2]) * countKey) + " p."
                + "\t\t\t\t" + Convert.ToString(countKey) + " шт."; ;

            richTextBoxShop_SME.Text += "\n\t" + keyboard + "\n";
            products += arrayValues1[3, 0] + " " + Convert.ToString(countKey) + " шт.  ";
            total += Convert.ToInt32(arrayValues1[3, 2]) * countKey;
            textBoxTotal_SME.Text = Convert.ToString(total) + " p.";
            buttonShopKey_SME.Text = "В корзине";
            buttonShopKey_SME.Enabled = false;
            buttonMinusKey_SME.Enabled = false;
            buttonPlusKey_SME.Enabled = false;

        }

        private void labelName_SME_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxComp_SME_MouseEnter(object sender, EventArgs e)
        {
           
            
        }

        private void buttonRegisterOrder_SME_MouseEnter(object sender, EventArgs e)
        {
            toolTipInfo_SME.ToolTipTitle = "Оформление заказа";
        }

        private void buttonClose_SME_MouseEnter(object sender, EventArgs e)
        {
            toolTipInfo_SME.ToolTipTitle = "Вернуться в каталог";
        }

        private void pictureBoxShop_SME_MouseEnter(object sender, EventArgs e)
        {
            toolTipInfo_SME.ToolTipTitle = "Корзина";
        }
    }
}
