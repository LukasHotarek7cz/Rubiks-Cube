using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RubikovaKostka3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        KostkaID k1;

		Color[] barvaC = new Color[] {
                Color.Red,
                Color.Blue,
                Color.White,
                Color.Yellow,
                Color.Green,
                Color.Brown,
				Color.Black
            };

        private void Form1_Load(object sender, EventArgs e)
        {
            k1=new KostkaID();
			pictureBox1.Invalidate();
        }

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			int strana;
			{
				for (strana = 0; strana < 6; strana++)
				{
					for (int y1 = 0; y1 < 3; y1++)
					{
						for (int x1 = 0; x1 < 3; x1++)
						{
							int x = x1 * 20 + 20;
							int y = -y1 * 20 + 60;

							switch (strana)
							{
								case 0: x += 60; y += 60; break;
								case 1: x += 180; y += 60; break;
								case 2: x += 120; y += 60; break;
								case 3: x += 60; y += 0; break;
								case 4: x += 0; y += 60; break;
								case 5: x += 60; y += 120; break;
							}

							x *= 2; x += 80;
							y *= 2; y += 90;

							g.DrawRectangle(new Pen(barvaC[k1.OutIK(strana, x1, y1, 0)], 8 * 2), new Rectangle(x, y, 8 * 2, 8 * 2));

							e.Graphics.DrawString(k1.OutSK(strana, x1, y1), new Font("Arial", 4 * 2), Brushes.Black, new Point(x - 5, y - 5));
						}
					}
				}
			}

			int a1 = 20;
			int b1 = (int)(a1 * Math.Sin(0.5));
			int c1 = (int)(a1 * Math.Cos(0.5));
			//int strana;
			int x2;
			int y2;

			strana = 3;
			for (int y1 = 0; y1 < 3; y1++)
			{
				for (int x1 = 0; x1 < 3; x1++)
				{
					x2 = (int)(x1 * a1 * 1.1 + a1 * 3 * 1.1 + 20);
					y2 = (int)(-y1 * b1 * 1.1 + b1 * 3 * 1.1 + 20);
					x2 += (int)(c1 * y1);

					Point[] point = new Point[5];
					point[0] = new Point(x2, y2);
					point[1] = new Point(x2 + a1, y2);
					point[2] = new Point(x2 + a1 + c1, y2 - b1);
					point[3] = new Point(x2 + c1, y2 - b1);
					point[4] = new Point(x2, y2);

					switch (k1.OutIK(strana, x1, y1, 0))
					{
						case 0: g.FillPolygon(Brushes.Red, point); break;
						case 1: g.FillPolygon(Brushes.Blue, point); break;
						case 2: g.FillPolygon(Brushes.White, point); break;
						case 3: g.FillPolygon(Brushes.Yellow, point); break;
						case 4: g.FillPolygon(Brushes.Green, point); break;
						case 5: g.FillPolygon(Brushes.Brown, point); break;
						case 6: g.FillPolygon(Brushes.Black, point); break;
					}
				}
			}

			strana = 2;
			for (int y1 = 0; y1 < 3; y1++)
			{
				for (int x1 = 0; x1 < 3; x1++)
				{
					x2 = (int)(x1 * c1 * 1.1 + a1 * 6 * 1.1 + 20);
					y2 = (int)(-y1 * a1 * 1.1 + b1 * 3 * 1.1 + a1 * 3 * 1.1 + 20);
					y2 -= b1 * x1;

					Point[] point = new Point[5];
					point[0] = new Point(x2, y2);
					point[1] = new Point(x2 + c1, y2 - b1);
					point[2] = new Point(x2 + c1, y2 - b1 - a1);
					point[3] = new Point(x2, y2 - a1);
					point[4] = new Point(x2, y2);

					switch (k1.OutIK(strana, x1, y1, 0))
					{
						case 0: g.FillPolygon(Brushes.Red, point); break;
						case 1: g.FillPolygon(Brushes.Blue, point); break;
						case 2: g.FillPolygon(Brushes.White, point); break;
						case 3: g.FillPolygon(Brushes.Yellow, point); break;
						case 4: g.FillPolygon(Brushes.Green, point); break;
						case 5: g.FillPolygon(Brushes.Brown, point); break;
						case 6: g.FillPolygon(Brushes.Black, point); break;
					}
				}
			}

			strana = 0;
			for (int y1 = 0; y1 < 3; y1++)
			{
				for (int x1 = 0; x1 < 3; x1++)
				{
					x2 = (int)(x1 * a1 * 1.1 + a1 * 3 * 1.1 + 20);
					y2 = (int)(-y1 * a1 * 1.1 + b1 * 3 * 1.1 + a1 * 3 * 1.1 + 20);

					Point[] point = new Point[5];
					point[0] = new Point(x2, y2);
					point[1] = new Point(x2 + a1, y2);
					point[2] = new Point(x2 + a1, y2 - a1);
					point[3] = new Point(x2, y2 - a1);
					point[4] = new Point(x2, y2);

					switch (k1.OutIK(strana, x1, y1, 0))
					{
						case 0: g.FillPolygon(Brushes.Red, point); break;
						case 1: g.FillPolygon(Brushes.Blue, point); break;
						case 2: g.FillPolygon(Brushes.White, point); break;
						case 3: g.FillPolygon(Brushes.Yellow, point); break;
						case 4: g.FillPolygon(Brushes.Green, point); break;
						case 5: g.FillPolygon(Brushes.Brown, point); break;
						case 6: g.FillPolygon(Brushes.Black, point); break;
					}
				}
			}

			strana = 5;
			for (int y1 = 0; y1 < 3; y1++)
			{
				for (int x1 = 0; x1 < 3; x1++)
				{
					x2 = (int)(-x1 * a1 * 1.1 + c1 * 3 * 1.1 + 20 + 405);
					y2 = (int)(y1 * b1 * 1.1 + a1 * 3 * 1.1 + b1 * 3 * 1.1 + 2);
					x2 += (int)(c1 * y1);

					Point[] point = new Point[5];
					point[0] = new Point(x2, y2);
					point[1] = new Point(x2 + a1, y2);
					point[2] = new Point(x2 + a1 - c1, y2 - b1);
					point[3] = new Point(x2 - c1, y2 - b1);
					point[4] = new Point(x2, y2);

					switch (k1.OutIK(strana, x1, y1, 0))
					{
						case 0: g.FillPolygon(Brushes.Red, point); break;
						case 1: g.FillPolygon(Brushes.Blue, point); break;
						case 2: g.FillPolygon(Brushes.White, point); break;
						case 3: g.FillPolygon(Brushes.Yellow, point); break;
						case 4: g.FillPolygon(Brushes.Green, point); break;
						case 5: g.FillPolygon(Brushes.Brown, point); break;
						case 6: g.FillPolygon(Brushes.Black, point); break;
					}
				}
			}

			strana = 4;
			for (int y1 = 0; y1 < 3; y1++)
			{
				for (int x1 = 0; x1 < 3; x1++)
				{
					x2 = (int)(x1 * c1 * 1.1 + a1 * 3 * 1.1 + 20 + 400);
					y2 = (int)(-y1 * a1 * 1.1 + a1 * 3 * 1.1 + 20);
					y2 += b1 * x1;

					Point[] point = new Point[5];
					point[0] = new Point(x2, y2);
					point[1] = new Point(x2 + c1, y2 + b1);
					point[2] = new Point(x2 + c1, y2 + b1 - a1);
					point[3] = new Point(x2, y2 - a1);
					point[4] = new Point(x2, y2);

					switch (k1.OutIK(strana, x1, y1, 0))
					{
						case 0: g.FillPolygon(Brushes.Red, point); break;
						case 1: g.FillPolygon(Brushes.Blue, point); break;
						case 2: g.FillPolygon(Brushes.White, point); break;
						case 3: g.FillPolygon(Brushes.Yellow, point); break;
						case 4: g.FillPolygon(Brushes.Green, point); break;
						case 5: g.FillPolygon(Brushes.Brown, point); break;
						case 6: g.FillPolygon(Brushes.Black, point); break;
					}
				}
			}

			strana = 1;
			for (int y1 = 0; y1 < 3; y1++)
			{
				for (int x1 = 0; x1 < 3; x1++)
				{
					x2 = (int)(x1 * a1 * 1.1 + 20 + 400);
					y2 = (int)(-y1 * a1 * 1.1 + a1 * 3 * 1.1 + 20);

					Point[] point = new Point[5];
					point[0] = new Point(x2, y2);
					point[1] = new Point(x2 + a1, y2);
					point[2] = new Point(x2 + a1, y2 - a1);
					point[3] = new Point(x2, y2 - a1);
					point[4] = new Point(x2, y2);

					switch (k1.OutIK(strana, x1, y1, 0))
					{
						case 0: g.FillPolygon(Brushes.Red, point); break;
						case 1: g.FillPolygon(Brushes.Blue, point); break;
						case 2: g.FillPolygon(Brushes.White, point); break;
						case 3: g.FillPolygon(Brushes.Yellow, point); break;
						case 4: g.FillPolygon(Brushes.Green, point); break;
						case 5: g.FillPolygon(Brushes.Brown, point); break;
						case 6: g.FillPolygon(Brushes.Black, point); break;
					}
				}
			}
		}

		private void Btn_R_0_R_Click(object sender, EventArgs e)
		{
			k1.RotaceHranyR();
			pictureBox1.Invalidate();
		}
		
		private void Btn_R_0_L_Click(object sender, EventArgs e)
		{
			k1.RotaceHranyL();
			pictureBox1.Invalidate();
		}

		private void Btn_R_All_R_Click(object sender, EventArgs e)
		{
			k1.RotaceKostkyR();
			pictureBox1.Invalidate();
		}

		private void Btn_R_All_L_Click(object sender, EventArgs e)
		{
			k1.RotaceKostkyL();
			pictureBox1.Invalidate();
		}

		private void Btn_P_All_R_Click(object sender, EventArgs e)
		{
			k1.PosunutiKostkyR();
			pictureBox1.Invalidate();
		}

		private void Btn_P_All_L_Click(object sender, EventArgs e)
		{
			k1.PosunutiKostkyL();
			pictureBox1.Invalidate();
		}

		private void Btn_P_All_A_Click(object sender, EventArgs e)
		{
			k1.PosunutiKostkyA();
			pictureBox1.Invalidate();
		}

		private void Btn_P_All_V_Click(object sender, EventArgs e)
		{
			k1.PosunutiKostkyV();
			pictureBox1.Invalidate();
		}

		private void Btn_LVL_21_Click(object sender, EventArgs e)
		{
			k1.LVL21();
			pictureBox1.Invalidate();
		}

		private void Btn_LVL_22_Click(object sender, EventArgs e)
		{
			k1.LVL22();
			pictureBox1.Invalidate();
		}

		private void Btn_LVL_31_Click(object sender, EventArgs e)
		{
			k1.LVL31();
			pictureBox1.Invalidate();
		}

		private void Btn_LVL_32_Click(object sender, EventArgs e)
		{
			k1.LVL32();
			pictureBox1.Invalidate();
		}

		private void Btn_LVL_33_Click(object sender, EventArgs e)
		{
			k1.LVL33();
			pictureBox1.Invalidate();
		}

		private void Btn_LVL_34_Click(object sender, EventArgs e)
		{
			k1.LVL34();
			pictureBox1.Invalidate();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			k1.NewGame();
			pictureBox1.Invalidate();
		}

    }
}