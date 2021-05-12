using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab_5_Csharp
{
    public partial class GraphicsForm : Form
    {
        private readonly int _upperValue;
        private readonly int _lowerValue;
        private readonly Func<double, double> _func;
        private readonly Pen _pen;
        public GraphicsForm(int upperValue, int lowerValue, Func<double, double> func, Pen pen)
        {
            InitializeComponent();
            _upperValue = upperValue;
            _lowerValue = lowerValue;
            _func = func;
            _pen = pen;

            pictureBox1.Paint += DrawGraphic;
        }

        private void DrawGraphic(object sender, PaintEventArgs e)
        {
            var w = pictureBox1.ClientSize.Width / 2;
            var h = pictureBox1.ClientSize.Height / 2;
            
            //Смещение начала координат в центр PictureBox
            e.Graphics.TranslateTransform(w, h);
            
            GraphicsOption.DrawXAxis(new Point(-w, 0), new Point(w, 0), e.Graphics);
            GraphicsOption.DrawYAxis(new Point(0, h), new Point(0, -h), e.Graphics);
            
            GraphicsOption.DrawFunc(_upperValue,_lowerValue,  e.Graphics, _func, _pen);
            
            
            
        }
    }
}
