﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Test_Form
{
    public partial class Form1 : Form
    {
        TreeView tree_view = new TreeView();
        Label lbl = new Label();
        Button btn = new Button();
        CheckBox cbxb = new CheckBox();
        CheckBox cbxl = new CheckBox();
        RadioButton rbtn1 = new RadioButton();
        RadioButton rbtn2 = new RadioButton();
        TextBox txtbx = new TextBox();
        PictureBox pcrbx = new PictureBox();
        TabControl tbcntr = new TabControl();
        TabPage tp1 = new TabPage("First");
        TabPage tp2 = new TabPage("Second");
        TabPage tp3 = new TabPage("Third");
        ListBox lb = new ListBox();
        DataSet ds = new DataSet();
        DataGridView dgv = new DataGridView();
        MainMenu mm = new MainMenu();
        MenuItem mi = new MenuItem("File");

        Random rnd = new Random();
        Color[] colors_massive;

        static readonly string readable_file = @"C:\Users\opilane\source\repos\JeF11037\Test_Form\readablefile.txt";

        public Form1()
        {
            this.Height = 800;
            this.Width = 600;
            this.Text = "Test Form";
            tree_view.Dock = DockStyle.Right;
            InitializeTreeView();
            tree_view.AfterSelect += TreeViewAfterSelect;
            this.Controls.Add(tree_view);
            FileReader();
        }

        private void TreeViewAfterSelect(object s, TreeViewEventArgs e)
        {

            switch ((e.Node.Text))
            {
                case "Label":
                    lbl.Text = "I am a LABEL";
                    lbl.Width = 100;
                    lbl.Height = 50;
                    lbl.Location = new Point(250, 50);
                    this.Controls.Add(lbl);
                    break;
                case "Button":
                    btn.Text = "I am a BUTTON";
                    btn.Width = 100;
                    btn.Height = 50;
                    btn.Location = new Point(230, 100);
                    btn.Click += ChangeColor;
                    this.Controls.Add(btn);
                    break;
                case "CheckBox":
                    cbxb.Text = "Button invisibility";
                    cbxl.Text = "Label invisibility";
                    cbxb.Width = 110;
                    cbxb.Height = 50;
                    cbxb.Location = new Point(300, 150);
                    cbxl.Location = new Point(200, 150);
                    cbxl.Width = 110;
                    cbxl.Height = 50;

                    cbxb.CheckedChanged += CheckBoxChecked;
                    cbxl.CheckedChanged += CheckBoxChecked;

                    this.Controls.Add(cbxb);
                    this.Controls.Add(cbxl);
                    break;
                case "RadioButton":
                    rbtn1.Text = "Left";
                    rbtn1.Width = 100;
                    rbtn1.Height = 50;
                    rbtn1.Location = new Point(200, 200);
                    rbtn1.CheckedChanged += RadioButtonChecked;
                    this.Controls.Add(rbtn1);
                    rbtn2.Text = "Right";
                    rbtn2.Width = 100;
                    rbtn2.Height = 50;
                    rbtn2.Location = new Point(300, 200);
                    rbtn2.Checked = true;
                    rbtn2.CheckedChanged += RadioButtonChecked;
                    this.Controls.Add(rbtn2);
                    break;
                case "TextBox":
                    txtbx.Size = new Size(100, 50);
                    txtbx.Location = new Point(220, 250);
                    txtbx.TextChanged += Txtbx_TextChanged;
                    this.Controls.Add(txtbx);
                    break;
                case "PictureBox":
                    pcrbx.Size = new Size(200, 80);
                    pcrbx.SizeMode = PictureBoxSizeMode.Zoom;
                    pcrbx.Location = new Point(200, 300);
                    pcrbx.Image = (Image)new Bitmap(@"C:\Users\opilane\source\repos\JeF11037\Test_Form\Test_Form\Image1.png");
                    this.Controls.Add(pcrbx);
                    break;
                case "TabControl":
                    tbcntr.TabPages.Clear();
                    tbcntr.Location = new Point(200, 400);
                    tbcntr.Size = new Size(200, 100);
                    tp1.BackColor = Color.FromArgb(255, rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                    tp2.BackColor = Color.FromArgb(255, rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                    tp3.BackColor = Color.FromArgb(255, rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                    tbcntr.Controls.Add(tp1);
                    tbcntr.Controls.Add(tp2);
                    tbcntr.Controls.Add(tp3);
                    this.Controls.Add(tbcntr);
                    AskAboutTabs();
                    break;
                case "MessageBox":
                    MessageBox.Show("Hi, im a MESSAGEBOX", "MessageBox");
                    if (MessageBox.Show("Wanna see InputBox ?", "MessageBox", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (MessageBox.Show(Microsoft.VisualBasic.Interaction.InputBox("Put in something", "InputBox"), "Is this that you had written ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            MessageBox.Show("Sounds good", "MessageBox");
                        }
                        else
                        {
                            MessageBox.Show("Oops", "MessageBox");
                        }
                    }
                    else
                    {
                        MessageBox.Show("OK", "MessageBox", MessageBoxButtons.OK);
                    }
                    break;
                case "ListBox":
                    lb.Location = new Point(200, 500);
                    lb.SelectedIndexChanged += Lb_SelectedIndexChanged;
                    string count_of_colors;
                    try
                    {
                        count_of_colors = Microsoft.VisualBasic.Interaction.InputBox("Put digit", "InputBox");
                        colors_massive = new Color[Int32.Parse(count_of_colors)];

                        int tick = 0;
                        foreach (KnownColor el in Enum.GetValues(typeof(KnownColor)))
                        {
                            colors_massive[tick] = Color.FromKnownColor(el);
                            lb.Items.Add(Color.FromKnownColor(el).Name.ToString());
                            tick++;
                            if (tick >= Int32.Parse(count_of_colors))
                            {
                                break;
                            }
                        }
                        this.Controls.Add(lb);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Incorrect", "MessageBox");
                        break;
                    }
                    break;
                case "DataGridView":
                    ds.ReadXml("../../XMLFile1.xml");
                    dgv.Location = new Point(200, 600);
                    dgv.AutoGenerateColumns = true;
                    dgv.DataSource = ds.Tables[0];
                    this.Controls.Add(dgv);
                    break;
                case "MainMenu":
                    mi.MenuItems.Add("Exit", new EventHandler(MenuExit));
                    mi.MenuItems.Add("BG color", new EventHandler(ChangeColor));
                    mi.MenuItems.Add("Do something", new EventHandler(Okey));
                    mm.MenuItems.Add(mi);
                    this.Menu = mm;
                    break;
            }
        }

        private void Okey(object sender, EventArgs e)
        {
            MessageBox.Show("Oops", "MessageBox");
        }

        private void Lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox temp_lb = (ListBox)sender;
            this.BackColor = colors_massive[temp_lb.SelectedIndex];
        }

        private int RandomDouble(int value)
        {
            double temp = (double)value;
            int result = (int)Math.Round(temp / 10) * 10;
            return result;
        }

        private void MenuExit(object sunder, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close the menu", "MessageBox", MessageBoxButtons.OK) == DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void AskAboutTabs()
        {
            if (MessageBox.Show("Wanna see specific tab ?", "MessageBox", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                using (Form2 form = new Form2(tbcntr))
                {
                    form.ShowDialog();
                    tbcntr.SelectedIndex = form.tab_index;
                }

            }
            else
            {
                MessageBox.Show("OK", "MessageBox");
            }
        }

        public void SetTab(int index)
        {
            tbcntr.SelectedIndex = index;
        }

        private void Txtbx_TextChanged(object sender, EventArgs e)
        {
            FileWriter();
        }

        private void FileWriter()
        {
            if (File.Exists(readable_file))
            {
                File.WriteAllText(readable_file, txtbx.Text);
            }
        }

        private void FileReader()
        {
            if (File.Exists(readable_file))
            {
                string text = File.ReadAllText(readable_file);
                txtbx.Text = text;
            }
        }

        private void RadioButtonChecked(object sender, EventArgs e)
        {
            if (rbtn1.Checked)
            {
                tree_view.Dock = DockStyle.Left;
            }
            else if (rbtn2.Checked)
            {
                tree_view.Dock = DockStyle.Right;
            }
        }

        private void CheckBoxChecked(object sender, EventArgs e)
        {
            if (cbxb.Checked)
            {
                btn.Visible = false;
            }
            else
            {
                btn.Visible = true;
            }
            if (cbxl.Checked)
            {
                lbl.Visible = false;
            }
            else
            {
                lbl.Visible = true;
            }
        }

        private void ChangeColor(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
        }

        private void InitializeTreeView()
        {
            tree_view.BeginUpdate();
            tree_view.Nodes.Add("Elements");
            tree_view.Nodes[0].Nodes.Add("Label");
            tree_view.Nodes[0].Nodes.Add("Button");
            tree_view.Nodes[0].Nodes.Add("CheckBox");
            tree_view.Nodes[0].Nodes.Add("RadioButton");
            tree_view.Nodes[0].Nodes.Add("TextBox");
            tree_view.Nodes[0].Nodes.Add("PictureBox");
            tree_view.Nodes[0].Nodes.Add("TabControl");
            tree_view.Nodes[0].Nodes.Add("MessageBox");
            tree_view.Nodes[0].Nodes.Add("ListBox");
            tree_view.Nodes[0].Nodes.Add("DataGridView");
            tree_view.Nodes[0].Nodes.Add("MainMenu");
            tree_view.EndUpdate();
        }
    }
}
