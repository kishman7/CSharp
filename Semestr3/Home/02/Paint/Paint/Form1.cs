using System;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            buttonPen.Tag = DrawType.Paint;
            buttonRectangle.Tag = DrawType.Rectangle;

            ActiveButton = buttonPen;
            label1_Click(label12, null);
           
            InitializationImage();
        }

        bool draw = false;
        public int PenSize { set; get; } = 5;
        Graphics GraphicsImage { set; get; }
        Color GetColor { get => labelColor.BackColor; }

        Button activeButton = null;
        Button ActiveButton
        {
            get { return activeButton; }
            set
            {
                if (activeButton != null)
                {
                    activeButton.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(activeButton.Name);
                }
                value.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(value.Name + "Active");
                activeButton = value;

                buttonSizePen.Enabled = value.Name == "buttonPen";
            }
        }

        void InitializationImage()
        {
            pictureBox1.Image = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            GraphicsImage = Graphics.FromImage(pictureBox1.Image);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveButton = sender as Button;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            labelColor.BackColor = (sender as Label).BackColor;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                labelColor.BackColor = colorDialog1.Color;
            }
        }

        private void buttonSizePen_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(buttonSizePen, 1, buttonSizePen.ClientSize.Height);
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            buttonSizePen.Image = e.ClickedItem.Image;
            PenSize = contextMenuStrip1.Items.IndexOf(e.ClickedItem) + 2;
        }

        Point startPoint;
        Rectangle mRect;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            draw = true;
            startPoint = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)//координати для малювання
        {
            Point p = e.Location;
            if (draw)
            {
                switch (activeButton.Tag)
                {
                    case DrawType.Paint:
                        {
                            mRect = new Rectangle(p, new Size(PenSize, PenSize));
                            break;
                        }
                    case DrawType.Rectangle:
                        {
                            int x = Math.Min(startPoint.X, p.X);
                            int y = Math.Min(startPoint.Y, p.Y);
                            int w = Math.Abs(p.X - startPoint.X);
                            int h = Math.Abs(p.Y - startPoint.Y);
                            mRect = new Rectangle(x, y, w, h);
                            break;
                        }
                }
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
            if (((DrawType)activeButton.Tag) == DrawType.Rectangle)
            {
                GraphicsImage.DrawRectangle(new Pen(GetColor), mRect);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) //малюваня і відображення екскізу
        {
            if (draw)
            {
                switch (activeButton.Tag)
                {
                    case DrawType.Paint:
                        {
                            GraphicsImage.FillEllipse(new SolidBrush(GetColor), mRect);
                            break;
                        }
                    case DrawType.Rectangle:
                        {
                            e.Graphics.DrawRectangle(new Pen(GetColor), mRect);
                            break;
                        }
                }
            }
        }

        private void CleanButton2_Click(object sender, EventArgs e)
        {
            InitializationImage();
        }

        private void SaveButton3_Click(object sender, EventArgs e)
        {
            var result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
                catch(Exception ex) 
                { 
                    MessageBox.Show(ex.Message); 
                }
            }
        }
        enum DrawType
        {
            Paint,
            Rectangle
        }

    }
}
