using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vizsgaremek
{
    public partial class mennu : Form
    {
        public mennu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mennu menu = new mennu();
            Dashboard dsb = new Dashboard();
            dsb.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mennu menu = new mennu();
            felhasznalok felhasz = new felhasznalok();
            felhasz.Show();
            this.Hide();
        }
    }
}
