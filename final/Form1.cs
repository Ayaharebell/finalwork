using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace final
{
    public partial class Form1 : Form
    {

        private static string dockpanelConfigFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockManager.config");
        private Form_solve form_solve = new Form_solve();
        private Form_main form_main;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            form_solve.Show(dockPanel1, DockState.DockRight);
            form_main = new Form_main();
            form_main.Show(dockPanel1);
        }
    }
}
