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

        private float zoomScale = 1.0f;

        public Form1()
        {
            InitializeComponent();

            canvasBitmap = new Bitmap(650, 360);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.Clear(Color.White);

            picCanvas.Image = canvasBitmap;
            picCanvas.SizeMode = PictureBoxSizeMode.StretchImage;

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

            trbZoom.Minimum = 50;
            trbZoom.Maximum = 200;
            trbZoom.Value = 100;

            lblZoom.Text = "확대/축소 100%";
        }

        private Point ConvertToCanvasPoint(Point picturePoint)
        {
            return new Point(
                (int)(picturePoint.X / zoomScale),
                (int)(picturePoint.Y / zoomScale)
            );
        }

        private void UpdatePictureBoxSize()
        {
            if (canvasBitmap == null) return;

            picCanvas.Width = (int)(canvasBitmap.Width * zoomScale);
            picCanvas.Height = (int)(canvasBitmap.Height * zoomScale);
            picCanvas.Invalidate();
        }

        private void PicCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            startPoint = ConvertToCanvasPoint(e.Location);
            endPoint = ConvertToCanvasPoint(e.Location);
        }

        private void PicCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            endPoint = ConvertToCanvasPoint(e.Location);
            picCanvas.Invalidate();
        }

        private void PicCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            isDrawing = false;
            endPoint = ConvertToCanvasPoint(e.Location);

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

                Point previewStart = new Point(
                    (int)(startPoint.X * zoomScale),
                    (int)(startPoint.Y * zoomScale)
                );

                Point previewEnd = new Point(
                    (int)(endPoint.X * zoomScale),
                    (int)(endPoint.Y * zoomScale)
                );

                DrawShape(e.Graphics, previewPen, previewStart, previewEnd);
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

        private void trbZoom_ValueChanged(object sender, EventArgs e)
        {
            zoomScale = trbZoom.Value / 100.0f;
            lblZoom.Text = "확대/축소 " + trbZoom.Value + "%";
            UpdatePictureBoxSize();
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
                    canvasBitmap.Save(sfd.FileName, ImageFormat.Jpeg);
                else if (ext == ".bmp")
                    canvasBitmap.Save(sfd.FileName, ImageFormat.Bmp);
                else
                    canvasBitmap.Save(sfd.FileName, ImageFormat.Png);

                MessageBox.Show("그림 저장 완료!");
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "이미지 열기";
            ofd.Filter = "이미지 파일|*.png;*.jpg;*.jpeg;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (canvasGraphics != null)
                    canvasGraphics.Dispose();

                using (Image loadImage = Image.FromFile(ofd.FileName))
                {
                    canvasBitmap = new Bitmap(loadImage);
                }

                canvasGraphics = Graphics.FromImage(canvasBitmap);
                picCanvas.Image = canvasBitmap;

                zoomScale = 1.0f;
                trbZoom.Value = 100;
                lblZoom.Text = "확대/축소 100%";

                UpdatePictureBoxSize();

                MessageBox.Show("이미지 불러오기 완료!");
            }
        }
    }
}