using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace lab_5_Csharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text , out _) ||
                !int.TryParse(textBox2.Text , out _) )
            {
                MessageBox.Show("Не верные данные!");
                return;
            }
            var graphicsForm = new GraphicsForm(int.Parse(textBox1.Text), 
                                                int.Parse(textBox2.Text),
                                                SelectedFunc(), SelectPen());
            graphicsForm.ShowDialog();
            
        }

        private Func<double,double> SelectedFunc()
        {
            var selectedItem = comboBox1.SelectedItem.ToString();
            switch (selectedItem)
            {
                case "y = x^2":
                    return x => x * x;
                case "y = sin(x)":
                    return x => Math.Sin(x);
                case  "y = 2x + 3":
                    return x => 2 * x + 3;
                default:
                    return x => 2 * x + 3;
            }
        }

        private Pen SelectPen()
        {
            var pen = new Pen(Color.White);
            
            var selectedColor = listBox1.SelectedItem.ToString();
            switch (selectedColor)
            {
                case "Красный":
                    pen.Color = Color.Red;
                    break;
                case "Желтый":
                    pen.Color = Color.Yellow;
                    break;
                case  "Синий":
                    pen.Color = Color.Blue;
                    break;
                case  "Зеленый":
                    pen.Color = Color.Green;
                    break;
            }

            if (radioButton1.Checked)
            {
                pen.DashStyle = DashStyle.Dash;
            }

            if (radioButton2.Checked)
            {
                pen.DashStyle = DashStyle.Dot;
            }

            if (radioButton3.Checked)
            {
                pen.DashStyle = DashStyle.Solid;
            }
            

            return  pen;
        }
    }
}