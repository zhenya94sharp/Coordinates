using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoordApp.Controllers;

namespace CoordApp
{
    public partial class FormMain : Form
    {
        private ControllerFormMain controller;
        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            controller = new ControllerFormMain();
        }

        private void buttonLoadPoints_Click(object sender, EventArgs e)
        {
            controller.Blabla(this);
        }

    }
}
