﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void MaxHeapBtn_Click(object sender, EventArgs e)
        {
            new Form1().ShowDialog();
        }

        private void MinHeapBtn_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }
    }
}
