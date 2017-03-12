using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace TPP.ObjectOrientation.Reflection {

    public partial class FormGenerativeProgramming : Form {
        public FormGenerativeProgramming() {
            InitializeComponent();
        }

        public FormGenerativeProgramming(MethodInfo function, double from, double to, double increment): this() {
            this.function = function;
            this.fromX = from;
            this.toX = to;
            this.incrementX = increment;
        }

        private double fromX, toX, incrementX;
        private MethodInfo function;

        private void WorkOutValues(out double[] xs, out double[] ys) {
            xs = new double[(int)((toX - fromX) / incrementX) + 1];
            ys = new double[(int)((toX - fromX) / incrementX) + 1];
            int i = 0;
            for (double x = fromX; x < toX; x = x + incrementX, i++) {
                xs[i] = x;
                ys[i] = (double)function.Invoke(null, new object[] { x });
            }
        }

        private int TranslateX(double x, double minX, double maxX, int widthPixels) {
            return (int)(widthPixels / (maxX - minX) * (x - minX));
        }

        private int TranslateY(double y, double minY, double maxY, int heightPixels) {
            return heightPixels - (int)(heightPixels / (maxY - minY) * (y - minY));
        }

        private void DrawAxes(Graphics graphics, double minX, double maxX, double minY, double maxY, int widthPixels, int heightPixels) {
            Pen pen = new Pen(Color.Black, 2.0f);
            int centerX = TranslateX(0, minX, maxX, widthPixels);
            int centerY = TranslateY(0, minY, maxY, heightPixels);
            graphics.DrawLine(pen, 0, centerY, widthPixels, centerY);
            graphics.DrawLine(pen, centerX, 0, centerX, heightPixels);
            Font font = new Font("Arial", widthPixels / 40);
            SolidBrush brush = new SolidBrush(Color.Black);
            graphics.DrawString(minX.ToString(), font, brush, new PointF(widthPixels / 2 + 2, heightPixels - 17));
            graphics.DrawString(maxX.ToString(), font, brush, new PointF(widthPixels / 2 + 2, 0));
            graphics.DrawString(minY.ToString(), font, brush, new PointF(0, heightPixels/2 +2));
            graphics.DrawString(maxY.ToString(), font, brush, new PointF(widthPixels - 12, heightPixels / 2 + 2));
            //graphics.DrawString("1", font, brush, new PointF(widthPixels - 12, heightPixels / 2 + 2));
        }

        private void FormGenerativeProgramming_Paint(object sender, PaintEventArgs e) {
            double[] xs, ys;
            WorkOutValues(out xs, out ys);
            double maxX = xs.Max(), maxY = ys.Max(),
                minX = xs.Min(), minY = ys.Min();
            int widthPixels = this.ClientRectangle.Width,
                heightPixels = this.ClientRectangle.Height;
            DrawAxes(e.Graphics, minX, maxX, minY, maxY, widthPixels, heightPixels);
            Pen pen = new Pen(Color.Blue);
            for (int i = 0; i < xs.Length - 1; i++) {
                int fromX, toX, fromY, toY;
                fromX = TranslateX(xs[i], minX, maxX, widthPixels);
                toX = TranslateX(xs[i + 1], minX, maxX, widthPixels);
                fromY = TranslateY(ys[i], minY, maxY, heightPixels);
                toY = TranslateY(ys[i + 1], minY, maxY, heightPixels);
                e.Graphics.DrawLine(pen, fromX, fromY, toX, toY);
            }
        }

    }
}
