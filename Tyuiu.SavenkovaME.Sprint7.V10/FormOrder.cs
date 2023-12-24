using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Tyuiu.SavenkovaME.Sprint7.V10.Lib;

namespace Tyuiu.SavenkovaME.Sprint7.V10
{
    
    public partial class FormOrder : Form
    {
        DataService ds = new DataService();
        public string fio;
        public string address;
        public string pay;
        public string totalSum;
        public string num;
        public string name;
        public string surname;
        public string patronymic;
        public string productsOrder;
        public FormOrder(int total, string products)
        {
            InitializeComponent();
            textBoxResSum_SME.Text = Convert.ToString(total) + " p.";
            productsOrder = products;
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {

        }

        private void buttonRegister_SME_Click(object sender, EventArgs e)
        {
            Random rand = new Random((int)(DateTime.Now.Ticks));
            totalSum = textBoxResSum_SME.Text;

            if ((textBoxName_SME.Text != "") && (textBoxSurname_SME.Text != "") &&
                (textBoxAddress_SME.Text != "") && (textBoxPatronymic_SME.Text != "") &&
                (radioButtonCash_SME.Text != "" || radioButtonPaycard_SME.Text != ""))
            {
                name = textBoxName_SME.Text;
                surname = textBoxSurname_SME.Text;
                patronymic = textBoxPatronymic_SME.Text;

                fio = surname + "\t" + name + "\t" + patronymic;
                address = textBoxAddress_SME.Text;
                if (radioButtonCash_SME.Checked == true)
                {
                    pay = radioButtonCash_SME.Text;
                }
                else
                {
                    pay = radioButtonPaycard_SME.Text;
                }
                num = Convert.ToString(rand.Next(1000, 10000));

                FormRegister register = new FormRegister(fio, address, num, pay);
                register.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Данные введены неверно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string[] inforegister = new string[] { surname, name, patronymic, address, num, pay };
            saveFileDialog_SME.FileName = "Информация о заказах.csv";
            saveFileDialog_SME.InitialDirectory = @"C:\Users\saven\OneDrive\Рабочий стол\прога\Files";
            saveFileDialog_SME.ShowDialog();

            string path = saveFileDialog_SME.FileName;

            int columns = 6;
            string str = "";


            for (int j = 0; j < columns; j++)
            {
                if (j != columns - 1)
                {
                    str += inforegister[j] + ";";
                }
                else
                {
                    str += inforegister[j];
                }
            }
            File.AppendAllText(path, str + Environment.NewLine, Encoding.GetEncoding("Windows-1251"));
            str = "";


            saveFileDialog_SME.FileName = "Заказы.csv";
            saveFileDialog_SME.InitialDirectory = @"C:\Users\saven\OneDrive\Рабочий стол\прога\Files";
            saveFileDialog_SME.ShowDialog();

            string pathorders = saveFileDialog_SME.FileName;
            int column = 3;
            string strOrder = "";
            string[] orders = new string[] { num, totalSum, productsOrder };
            for (int c = 0; c < column; c++)
            {
                if (c != column - 1)
                {
                    strOrder += orders[c] + ";";
                }
                else
                {
                    strOrder += orders[c];
                }
            }
            File.AppendAllText(pathorders, strOrder + Environment.NewLine, Encoding.GetEncoding("Windows-1251"));
            str = "";
        }
    }
}
