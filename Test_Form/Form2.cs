using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Form
{
    public partial class Form2 : Form
    {
        ComboBox cbx = new ComboBox();
        TabControl tbcntr;
        public int tab_index { get; set; }
        public Form2(TabControl tbcntr_)
        {
            tbcntr = tbcntr_;

            this.Height = 150;
            this.Width = 250;
            this.Text = "Tab asker";

            cbx.Items.Clear();
            cbx.Text = "Choose your tab";
            cbx.Size = new Size(100, 150);
            foreach (var el in tbcntr.TabPages)
            {
                cbx.Items.Add(el.ToString());
            }
            cbx.SelectedIndexChanged += Cbx_SelectedIndexChanged;
            this.Controls.Add(cbx);
        }

        private void Cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            tab_index = cbx.SelectedIndex;
            this.Close();
        }
    }
}
