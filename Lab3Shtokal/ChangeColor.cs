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
    public partial class Shape : Form
    {
        
        public Shape()
        {
            InitializeComponent();
        }

        public Color ff;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) ff = Color.Red;
            if (radioButton2.Checked) ff = Color.Green;
            if (radioButton3.Checked) ff = Color.Blue;
            this.DialogResult = DialogResult.OK;            
            this.Close();
        }

        public Color getColor()
        {
            return ff;
        }
    }
}
