using System;
using System.Drawing;

namespace lab_5_Csharp
{
    public static class GraphicsOption
    {
        //Пикселей в одном делении оси
        private const int  PixInOne  = 15;
        //Длина стрелки
        private const int ArrLen = 10;
        
        
        
        
        //Рисование оси X
        public static void DrawXAxis(Point start, Point end, Graphics g)
        {
            //Деления в положительном направлении оси
            for (int i = PixInOne; i < end.X - ArrLen; i += PixInOne)
            {
                g.DrawLine(Pens.Black, i, -5, i, 5);
                DrawText(new Point(i, 5), (i / PixInOne).ToString(), g);
            }
            //Деления в отрицательном направлении оси
            for (int i = -PixInOne; i > start.X; i -= PixInOne)
            {
                g.DrawLine(Pens.Black, i, -5, i, 5);
                DrawText(new Point(i, 5), (i / PixInOne).ToString(), g);
            }
            //Ось
            g.DrawLine(Pens.Black, start, end);
            //Стрелка
            g.DrawLines(Pens.Black, GetArrow(start.X, start.Y, end.X, end.Y, ArrLen));
        }
 
        //Рисование оси Y
        public static void DrawYAxis(Point start, Point end, Graphics g)
        {
            //Деления в отрицательном направлении оси
            for (int i = PixInOne; i < start.Y; i += PixInOne)
            {
                g.DrawLine(Pens.Black, -5, i, 5, i);
                DrawText(new Point(5, i), (-i / PixInOne).ToString(), g, true);
            }
            //Деления в положительном направлении оси
            for (int i = -PixInOne; i > end.Y + ArrLen; i -= PixInOne)
            {
                g.DrawLine(Pens.Black, -5, i, 5, i);
                DrawText(new Point(5, i), (-i / PixInOne).ToString(), g, true);
            }
            //Ось
            g.DrawLine(Pens.Black, start, end);
            //Стрелка
            g.DrawLines(Pens.Black, GetArrow(start.X, start.Y, end.X, end.Y, ArrLen));
        }
        private static PointF[] GetArrow(float x1, float y1, 
                                        float x2, float y2, 
                                        float len = 10, float width = 4)
        {
            PointF[] result = new PointF[3];
            //направляющий вектор отрезка
            var n = new PointF(x2 - x1, y2 - y1);
            //Длина отрезка
            var l = (float)Math.Sqrt(n.X * n.X + n.Y * n.Y);
            //Единичный вектор
            var v1 = new PointF(n.X / l, n.Y / l);
            //Длина стрелки
            n.X = x2 - v1.X * len;
            n.Y = y2 - v1.Y * len;
            result[0] = new PointF(n.X + v1.Y * width, n.Y - v1.X * width);
            result[1] = new PointF(x2, y2);
            result[2] = new PointF(n.X - v1.Y * width, n.Y + v1.X * width);
            return result;
        }
        
        //Рисование текста
        private static void DrawText(Point point, string text, Graphics g, bool isYAxis = false)
        {
            var f = new Font(new FontFamily("Comic Sans MS"), 6);
            var size = g.MeasureString(text, f);
            var pt = isYAxis
                ? new PointF(point.X + 1, point.Y - size.Height / 2)
                : new PointF(point.X - size.Width / 2, point.Y + 1);
            var rect = new RectangleF(pt, size);
            g.DrawString(text, f, Brushes.Black, rect);
        }

        public static void DrawFunc(int upperValue, int lowerValue,  Graphics g , Func<double,double> func, Pen pen)
        {
            int count = 0;
            float step = 0.3f;
            for (float i = upperValue; i <= lowerValue; i += step)
            {
                count++;
            }
            var points = new PointF[count];
            float x = upperValue;
            for (int i = 0; x <= lowerValue ; i++)
            {
                points[i] = new PointF(  x * PixInOne,
                    (float) func(x  * PixInOne));
                
                if (points[i].X == 0)
                {
                    g.FillRectangle(Brushes.Red,points[i].X, points[i].Y,5,5);
                }

                x += step;
            }
            g.DrawLines(pen,points);
        }
        
        
    }
}