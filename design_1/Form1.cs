using design_1.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using Button = System.Windows.Forms.Button;
using Control = System.Windows.Forms.Control;
using Point1 = System.Drawing.Point;

namespace design_1
{
    public partial class Form1 : Form
    {
        private Form cChildForm;
        Point1 lastpoint;
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Menumenu();

            // SetRoundedShape(panel1, 30);
        }
       /* static void SetRoundedShape(Control control, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddLine(radius, 0, control.Width - radius, 0);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddLine(control.Width, radius, control.Width, control.Height - radius);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddLine(control.Width - radius, control.Height, radius, control.Height);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.AddLine(0, control.Height - radius, 0, radius);
            path.AddArc(0, 0, radius, radius, 180, 90);
            control.Region = new Region(path);
        }*/
       /* private GraphicsPath GetRoundedPath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }*/
       /* private void FormRegionAndBorder(Form form, float radius, Graphics graph, Color borderColor, float borderSize)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                using (GraphicsPath roundPath = GetRoundedPath(form.ClientRectangle, radius))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                using (Matrix transform = new Matrix())
                {
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    form.Region = new Region(roundPath);
                    if (borderSize >= 1)
                    {
                        Rectangle rect = form.ClientRectangle;
                        float scaleX = 1.0F - ((borderSize + 1) / rect.Width);
                        float scaleY = 1.0F - ((borderSize + 1) / rect.Height);
                        transform.Scale(scaleX, scaleY);
                        transform.Translate(borderSize / 1.6F, borderSize / 1.6F);
                        graph.Transform = transform;
                        graph.DrawPath(penBorder, roundPath);
                    }
                }
            }
        }*/
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //FormRegionAndBorder(this, 30, e.Graphics, Color.White ,1);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Menumenu();
        }
        private void Menumenu()
        {
            if(this.menu.Width>100){
                menu.Width = 100;
                btnmenu.Dock = DockStyle.Top;
                foreach (Button menubtn in menu.Controls.OfType<Button>())
                {
                    menubtn.Text = "";
                    btnmenu.Text = "";
                    btnmenu.ImageAlign = ContentAlignment.MiddleCenter;
                    menubtn.ImageAlign = ContentAlignment.MiddleCenter;
                    menubtn.Padding = new Padding(0);
                    if (cChildForm != null)
                    {
                        cChildForm.Width = 922;
                    }
                }
            }
            else{
                menu.Width = 180;
                btnmenu.Dock = DockStyle.None;
                foreach (Button menubtn in menu.Controls.OfType<Button>())
                {
                    menubtn.Text = "    "+ menubtn.Tag.ToString();
                    btnmenu.Text = "MONO\nDRUG";
                    btnmenu.ImageAlign = ContentAlignment.MiddleLeft;
                    menubtn.ImageAlign = ContentAlignment.MiddleLeft;
                    menubtn.Padding = new Padding(10, 0, 0, 0);
                    if (cChildForm != null)
                    {
                        cChildForm.Width = 842;
                    }
                }
            }
        }
        private void OpenChForm(Form childForm)
        {
            if (cChildForm != null)
            {
                cChildForm.Close();
            }
            cChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            iconButton5.Visible = true;
            iconButton5.BringToFront();
            if(menu.BackColor == Color.Lime)
            {
                childForm.BackColor = Color.DarkSlateGray;
            }
        }
        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            OpenChForm(new FormGeneral());
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            OpenChForm(new FormDataBase());
        }

        private void l8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton6_Click(object sender, EventArgs e)
        {

        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            OpenChForm(new FormOrdering());
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new System.Drawing.Point(e.X, e.Y);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new System.Drawing.Point(e.X, e.Y);
        }

        private void panelDesktop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void panelDesktop_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new System.Drawing.Point(e.X, e.Y);
        }

        private void menu_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new System.Drawing.Point(e.X, e.Y);
        }

        private void menu_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            if (menu.BackColor == Color.MediumSeaGreen)
            {
                menu.BackColor = Color.Lime;
                foreach (Button menubtn in menu.Controls.OfType<Button>())
                {
                    menubtn.BackColor = Color.Lime;
                    btnmenu.BackColor = Color.Lime;
                }
                if (cChildForm != null)
                {
                    cChildForm.BackColor = Color.DarkSlateGray;
                }
                
            }
            else
            {
                menu.BackColor = Color.MediumSeaGreen;
                foreach (Button menubtn in menu.Controls.OfType<Button>())
                {
                    menubtn.BackColor = Color.MediumSeaGreen;
                    btnmenu.BackColor = Color.MediumSeaGreen;
                }
                if (cChildForm != null)
                {
                    cChildForm.BackColor = Color.White;
                }
            }
            
        }

        private void iconButton5_Click_1(object sender, EventArgs e)
        {
            if (panel2.Width == 10)
            {
                panel2.Visible = true;
                panel2.Width = 276;
                iconButton5.Location = new System.Drawing.Point(panelDesktop.Width-288, 24);
            }
            else
            {
                panel2.Visible = false;
                panel2.Width = 10;
                iconButton5.Location = new System.Drawing.Point(panelDesktop.Width - 42, 24);
            }
            
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }

}

