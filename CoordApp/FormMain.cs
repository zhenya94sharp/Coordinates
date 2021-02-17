using System;
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
            saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            controller = new ControllerFormMain();
        }

        private void buttonLoadPoints_Click(object sender, EventArgs e)
        {
            controller.ConvertJsonToList(this);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            controller.SaveFile(this);
        }
    }
}
