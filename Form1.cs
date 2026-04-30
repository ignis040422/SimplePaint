using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplePaint
{
    public partial class Form1 : Form
    {
        // 사용할 도형 타입을 정의 (직선, 사각형, 원)
        enum ToolType { Line, Rectangle, Circle }

        // 현재 선택된 도형 (기본값: 직선)
        private ToolType currentTool = ToolType.Line;

        // 현재 선택된 색상 (기본값: 검정)
        private Color currentColor = Color.Black;

        // 현재 선 두께 (기본값: 2)
        private int currentLineWidth = 2;

        public Form1()
        {
            InitializeComponent();

            // ComboBox에 색상 목록 추가
            cmbColor.Items.Add("Black 검정");
            cmbColor.Items.Add("Red 빨강");
            cmbColor.Items.Add("Blue 파랑");
            cmbColor.Items.Add("Green 녹색");

            // 기본 선택 색상 설정 (검정)
            cmbColor.SelectedIndex = 0;

            // TrackBar 최소/최대값 설정 (선 두께)
            trbLineWidth.Minimum = 1;
            trbLineWidth.Maximum = 10;

            // 기본 선 두께 설정
            trbLineWidth.Value = 2;
        }

        // 직선 버튼 클릭 시 실행되는 이벤트
        private void btnLine_Click(object sender, EventArgs e)
        {
            // 현재 도형을 직선으로 변경
            currentTool = ToolType.Line;

            // 사용자에게 선택 상태 알림
            MessageBox.Show("직선 선택");
        }

        // 사각형 버튼 클릭 시 실행되는 이벤트
        private void btnRectangle_Click(object sender, EventArgs e)
        {
            // 현재 도형을 사각형으로 변경
            currentTool = ToolType.Rectangle;

            // 사용자에게 선택 상태 알림
            MessageBox.Show("사각형 선택");
        }

        // 원 버튼 클릭 시 실행되는 이벤트
        private void btnCircle_Click(object sender, EventArgs e)
        {
            // 현재 도형을 원으로 변경
            currentTool = ToolType.Circle;

            // 사용자에게 선택 상태 알림
            MessageBox.Show("원 선택");
        }

        // ComboBox에서 색상이 변경될 때 실행되는 이벤트
        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 선택된 인덱스에 따라 색상 변경
            switch (cmbColor.SelectedIndex)
            {
                case 0:
                    currentColor = Color.Black; // 검정
                    break;

                case 1:
                    currentColor = Color.Red;   // 빨강
                    break;

                case 2:
                    currentColor = Color.Blue;  // 파랑
                    break;

                case 3:
                    currentColor = Color.Green; // 초록
                    break;
            }
        }

        // TrackBar 값이 변경될 때 실행되는 이벤트
        private void trbLineWidth_ValueChanged(object sender, EventArgs e)
        {
            // 현재 선 두께를 TrackBar 값으로 업데이트
            currentLineWidth = trbLineWidth.Value;
        }
    }
}