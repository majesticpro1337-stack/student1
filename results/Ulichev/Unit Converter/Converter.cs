using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double kmg = 0.001;
        double kg = 1.0;
        double kkg = 1000.0;
        double kc = 100000;
        double kt = 1000000;

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            double rez, isk, vk, ed;
            isk = 0;
            vk = 0;
            ed = 0;
            if (comboBox1.Text == "Міліграм (мг)") isk = kmg;
            if (comboBox1.Text == "Грам (г)") isk = kg;
            if (comboBox1.Text == "Кілограм (кг)") isk = kkg;
            if (comboBox1.Text == "Центнер (ц)") isk = kc;
            if (comboBox1.Text == "Центнер (ц)") isk = kc;
            if (comboBox1.Text == "Тонна (т)") isk = kt;
            if (comboBox2.Text == "Міліграм (мг)") vk = kmg;
            if (comboBox2.Text == "Грам (г)") vk = kg;
            if (comboBox2.Text == "Кілограм (кг)") vk = kkg;
            if (comboBox2.Text == "Центнер (ц)") vk = kc;
            if (comboBox2.Text == "Тонна (т)") vk = kt;
            if (textBox2.Text == "") ed = 0;
            else ed = Convert.ToDouble(textBox2.Text);
            rez = ( ed * isk) / vk;
            label2.Text = "Результат = ";
            label2.Text += rez;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2_TextChanged(sender, e);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            textBox2_TextChanged(sender, e);
        }
    }
}
