using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SimplePaint
{
    public partial class Form1 : Form
    {
        // 사용할 도형 타입 정의
        enum ToolType { Line, Rectangle, Circle }

        // 실제 그림이 저장되는 캔버스
        private Bitmap canvasBitmap;

        // Bitmap 위에 그림을 그리기 위한 도구
        private Graphics canvasGraphics;

        // 현재 마우스 드래그 중인지 확인하는 변수
        private bool isDrawing = false;

        // 마우스를 처음 누른 위치
        private Point startPoint;

        // 마우스를 움직이거나 뗀 위치
        private Point endPoint;

        // 현재 선택된 도형
        private ToolType currentTool = ToolType.Line;

        // 현재 선택된 색상
        private Color currentColor = Color.Black;

        // 현재 선택된 선 두께
        private int currentLineWidth = 2;

        public Form1()
        {
            InitializeComponent();

            // 캔버스 생성
            canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.Clear(Color.White);
            picCanvas.Image = canvasBitmap;

            // 마우스 이벤트 연결
            picCanvas.MouseDown += PicCanvas_MouseDown;
            picCanvas.MouseMove += PicCanvas_MouseMove;
            picCanvas.MouseUp += PicCanvas_MouseUp;

            // Paint 이벤트 연결
            picCanvas.Paint += PicCanvas_Paint;

            // 색상 목록 추가
            cmbColor.Items.Add("Black 검정");
            cmbColor.Items.Add("Red 빨강");
            cmbColor.Items.Add("Blue 파랑");
            cmbColor.Items.Add("Green 녹색");
            cmbColor.SelectedIndex = 0;

            // 선 두께 설정
            trbLineWidth.Minimum = 1;
            trbLineWidth.Maximum = 10;
            trbLineWidth.Value = 2;
        }

        // 마우스를 눌렀을 때 실행
        private void PicCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            startPoint = e.Location;
            endPoint = e.Location;
        }

        // 마우스를 누른 상태로 움직일 때 실행
        private void PicCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            endPoint = e.Location;

            // 미리보기 도형을 다시 그리기 위해 화면 갱신
            picCanvas.Invalidate();
        }

        // 마우스에서 손을 뗐을 때 실행
        private void PicCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            isDrawing = false;
            endPoint = e.Location;

            // 최종 도형을 실제 Bitmap에 저장
            using (Pen pen = new Pen(currentColor, currentLineWidth))
            {
                DrawShape(canvasGraphics, pen, startPoint, endPoint);
            }

            picCanvas.Invalidate();
        }

        // 드래그 중일 때 점선 미리보기 표시
        private void PicCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (!isDrawing) return;

            using (Pen previewPen = new Pen(currentColor, currentLineWidth))
            {
                previewPen.DashStyle = DashStyle.Dash;
                DrawShape(e.Graphics, previewPen, startPoint, endPoint);
            }
        }

        // 선택된 도형에 따라 그림 그리기
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

        // 두 점을 기준으로 사각형 영역 만들기
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
    }
}