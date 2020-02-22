using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
namespace DrawByMouse
{

	public partial class Form1 : Form
	{

		internal ArrayList ListOfPoint;
		internal ArrayList ListOfPoint2;

		internal bool PencilDown;
		Form2 f2;

		public Form1()
		{
			InitializeComponent();

			ListOfPoint = new ArrayList();
			ListOfPoint2 = new ArrayList();
			PencilDown = false;

			//f2.Owner = this;
			this.Width = Screen.PrimaryScreen.WorkingArea.Width / 2;
			this.Height = Screen.PrimaryScreen.WorkingArea.Height / 2;
			this.Top = (Screen.PrimaryScreen.WorkingArea.Top + Screen.PrimaryScreen.WorkingArea.Height) / 4;
			this.Left = (Screen.PrimaryScreen.WorkingArea.Left + Screen.PrimaryScreen.WorkingArea.Width) / 4;
			this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

			Form2Init();
			this.Location = new Point(0, 0);

			f2.Location = new Point(this.Width, 0);

		}
		private void Form2Init()
		{
			f2 = new Form2();
			f2.Size = this.Size;
			f2.Show();
			f2.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		}
		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			Point p = new Point(e.X, e.Y);
			Point p2 = new Point(this.Width - p.X, p.Y);
			ListOfPoint.Add(p);
			ListOfPoint2.Add(p2);
			PencilDown = true;
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			PencilDown = false;
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			if (f2.IsDisposed) return;
			Graphics g = this.CreateGraphics();
			Graphics g2 = f2.CreateGraphics();

			Point points = new Point(e.X, e.Y);
			Point points2 = new Point(this.Width - points.X, points.Y);

			Pen pencil = new Pen(Color.BlueViolet);
			if (PencilDown)
			{
				if (ListOfPoint.Count > 1)
				{
					g.DrawLine(pencil, (Point)ListOfPoint[ListOfPoint.Count - 1], points);

					g2.DrawLine(pencil, (Point)ListOfPoint2[ListOfPoint2.Count - 1], points2);
					ListOfPoint.Add(points);
					ListOfPoint2.Add(points2);

				}
			}

		}


		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			f2 = new Form2();
			Form2Init();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Invalidate();
			f2.Invalidate();
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}


		protected void clearToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Invalidate();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Invalidate();
			f2.Invalidate();
		}
	}
}
