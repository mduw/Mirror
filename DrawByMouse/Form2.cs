using System;
using System.Windows.Forms;

namespace DrawByMouse
{

	public partial class Form2 : Form
	{


		public Form2()
		{
			InitializeComponent();


		}

		private void Form2_Load(object sender, EventArgs e)
		{

		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{

			this.Close();

		}

		private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Invalidate();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}


	}
}
