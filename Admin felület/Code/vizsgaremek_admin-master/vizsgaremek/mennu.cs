﻿using System;
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
            Rendelések dsb = new Rendelések();
            dsb.ShowDialog();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mennu menu = new mennu();
            felhasznalok felhasz = new felhasznalok();
            felhasz.ShowDialog();
            this.Hide();
        }
    }
}
