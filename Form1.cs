using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SimplePaint
{
    public partial class Form1 : Form
    {
        enum ToolType { Line, Rectangle, Circle }

        private Bitmap canvasBitmap;
        private Graphics canvasGraphics;
        private bool isDrawing = false;
        private Point startPoint;
        private Point endPoint;

        private ToolType currentTool = ToolType.Line;
        private Color currentColor = Color.Black;
        private int currentLineWidth = 2;

        public Form1()
        {
            InitializeComponent();

            canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.Clear(Color.White);
            picCanvas.Image = canvasBitmap;

            picCanvas.MouseDown += PicCanvas_MouseDown;
            picCanvas.MouseMove += PicCanvas_MouseMove;
            picCanvas.MouseUp += PicCanvas_MouseUp;
            picCanvas.Paint += PicCanvas_Paint;

            cmbColor.Items.Add("Black 검정");
            cmbColor.Items.Add("Red 빨강");
            cmbColor.Items.Add("Blue 파랑");
            cmbColor.Items.Add("Green 녹색");
            cmbColor.SelectedIndex = 0;

            trbLineWidth.Minimum = 1;
            trbLineWidth.Maximum = 10;
            trbLineWidth.Value = 2;
        }

        private void PicCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            startPoint = e.Location;
            endPoint = e.Location;
        }

        private void PicCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            endPoint = e.Location;
            picCanvas.Invalidate();
        }

        private void PicCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            isDrawing = false;
            endPoint = e.Location;

            using (Pen pen = new Pen(currentColor, currentLineWidth))
            {
                DrawShape(canvasGraphics, pen, startPoint, endPoint);
            }

            picCanvas.Invalidate();
        }

        private void PicCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (!isDrawing) return;

            using (Pen previewPen = new Pen(currentColor, currentLineWidth))
            {
                previewPen.DashStyle = DashStyle.Dash;
                DrawShape(e.Graphics, previewPen, startPoint, endPoint);
            }
        }

        private void DrawShape(Graphics g, Pen pen, Point p1, Point p2)
        {
            Rectangle rect = GetRectangle(p1, p2);

            switch (currentTool)
            {
                case ToolType.Line:
                    g.DrawLine(pen, p1, p2);
                    break;

                case ToolType.Rectangle:
                    g.DrawRectangle(pen, rect);
                    break;

                case ToolType.Circle:
                    g.DrawEllipse(pen, rect);
                    break;
            }
        }

        private Rectangle GetRectangle(Point p1, Point p2)
        {
            return new Rectangle(
                Math.Min(p1.X, p2.X),
                Math.Min(p1.Y, p2.Y),
                Math.Abs(p1.X - p2.X),
                Math.Abs(p1.Y - p2.Y)
            );
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Line;
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Rectangle;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Circle;
        }

        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbColor.SelectedIndex)
            {
                case 0:
                    currentColor = Color.Black;
                    break;
                case 1:
                    currentColor = Color.Red;
                    break;
                case 2:
                    currentColor = Color.Blue;
                    break;
                case 3:
                    currentColor = Color.Green;
                    break;
            }
        }

        private void trbLineWidth_ValueChanged(object sender, EventArgs e)
        {
            currentLineWidth = trbLineWidth.Value;
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Title = "그림 저장";
            sfd.Filter = "PNG 파일|*.png|JPG 파일|*.jpg|BMP 파일|*.bmp";
            sfd.FileName = "my_paint.png";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName).ToLower();

                if (ext == ".jpg")
                {
                    canvasBitmap.Save(sfd.FileName, ImageFormat.Jpeg);
                }
                else if (ext == ".bmp")
                {
                    canvasBitmap.Save(sfd.FileName, ImageFormat.Bmp);
                }
                else
                {
                    canvasBitmap.Save(sfd.FileName, ImageFormat.Png);
                }

                MessageBox.Show("그림 저장 완료!");
            }
        }
    }
}