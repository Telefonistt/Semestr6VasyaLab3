using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3Shtokal
{
    public partial class Form1 : Form
    {
        int i = 0;
        Bitmap bmp;
        Graphics graph;
        int interval=200;//в децисек
        int phasa = 0;
        Color color=Color.Blue;

        public Form1()
        {
            InitializeComponent();
            
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if(i% interval == 0)
            {
                phasa++;
                if (phasa > 2)
                    phasa = 0;
                i = 0;
            }
            
            label1.Text = i.ToString();
            label2.Text = ((Phasa)phasa).ToString();
            label3.Text = color.ToKnownColor().ToString();
            Draw();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void Draw()
        {
            switch(phasa)
            {
                case (int)Phasa.Elips:
                    pictureBox1.Image = DrawElipse();
                    break;
                case (int)Phasa.Rectangle:
                    pictureBox1.Image = DrawRectangle();
                    break;
                case (int)Phasa.Triangle:
                    pictureBox1.Image = DrawTriangle();
                    break;
                //case (int)Phasa.Elips:
                //    DrawElipse();
                //    break;
                //case (int)Phasa.Elips:
                //    DrawElipse();
                //    break;
                default:
                    MessageBox.Show("Error");
                    break;
                    
            }
            
        }

        private Bitmap DrawElipse()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Black,3);
            Brush brush = new SolidBrush(color);
            Point point1 = new Point(0, 0);
            Point point2 = new Point(200, 200);
            int phazaFigure = GetFigurePhase();

           
            float diametr = pictureBox1.Width / 3 * 2;
            float width = diametr;
            width = width / (interval / 2) * phazaFigure;
            float x = point1.X+ (diametr - width)/2;



            //graph.DrawEllipse(pen,)
            graph.FillEllipse(brush, x+2, point1.Y+2, width, diametr);
            graph.DrawEllipse(pen, x+2, point1.Y+2, width, diametr);

            //graph.Dra
            return bmp;
        }

        private Bitmap DrawRectangle()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Black, 3);
            Brush brush = new SolidBrush(color);
            Point point1 = new Point(0, 0);
            Point point2 = new Point(200, 200);
            int phazaFigure = GetFigurePhase();


            float side = pictureBox1.Width / 3 * 2;
            float width = side;
            width = width / (interval / 2) * phazaFigure;
            float x = point1.X + (side - width) / 2;



            //graph.DrawEllipse(pen,)
            graph.FillRectangle(brush, x+2, point1.Y+2, width, side);
            graph.DrawRectangle(pen, x+2, point1.Y+2, width, side);
            return bmp;
        }

        private Bitmap DrawTriangle()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Black, 3);
            Brush brush = new SolidBrush(color);
            
            int phazaFigure = GetFigurePhase();


            float side = pictureBox1.Width / 3 * 2;
            float width = side;
            width = width / (interval / 2) * phazaFigure/2+side/2;
            float x = 0 + (side - width) ;

            PointF[] points = new PointF[3];
            //points.

            points[0] = new PointF(side / 2, 0);
            //float y = Convert.ToSingle(points[0].X * Math.Sqrt(3));
            points[1] = new PointF(x, side);
            points[2] = new PointF(width, side);

            graph.DrawPolygon(pen, points);
            graph.FillPolygon(brush, points);
            //graph.DrawEllipse(pen,)
            //graph.FillRectangle(brush, x+1, point1.Y+1, width-1, side-1);
            // graph.DrawRectangle(pen, x, point1.Y, width, side);
            return bmp;
        }

        private void Draww()
        {
            pictureBox1.Image = null;
        }
        public enum Phasa
        {
            Elips, Rectangle, Triangle
        }

        private int GetFigurePhase()
        {
            int phazaFigure = i;

            if (i > interval / 2)
            {
                phazaFigure = interval - i;
            }

            return phazaFigure;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {


                Shape shape = new Shape();
                shape.ShowDialog(this);
                if (shape.DialogResult == DialogResult.OK)
                    color = shape.getColor();
            }
            else
            {
                MessageBox.Show("It's necessary to stop process!");
            }
        }
    }
}
