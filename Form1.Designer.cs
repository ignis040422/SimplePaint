namespace SimplePaint
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.GroupBox groupBoxShape;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnRectangle;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.GroupBox groupBoxColor;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.GroupBox groupBoxLineWidth;
        private System.Windows.Forms.TrackBar trbLineWidth;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.PictureBox picCanvas;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblAppName = new Label();
            groupBoxShape = new GroupBox();
            btnLine = new Button();
            btnRectangle = new Button();
            btnCircle = new Button();
            groupBoxColor = new GroupBox();
            cmbColor = new ComboBox();
            groupBoxLineWidth = new GroupBox();
            trbLineWidth = new TrackBar();
            btnOpenFile = new Button();
            btnSaveFile = new Button();
            picCanvas = new PictureBox();
            groupBoxShape.SuspendLayout();
            groupBoxColor.SuspendLayout();
            groupBoxLineWidth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            SuspendLayout();
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("맑은 고딕", 24F, FontStyle.Bold);
            lblAppName.ForeColor = Color.Blue;
            lblAppName.Location = new Point(25, 25);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(212, 45);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "Simple Paint";
            // 
            // groupBoxShape
            // 
            groupBoxShape.Controls.Add(btnLine);
            groupBoxShape.Controls.Add(btnRectangle);
            groupBoxShape.Controls.Add(btnCircle);
            groupBoxShape.Location = new Point(30, 85);
            groupBoxShape.Name = "groupBoxShape";
            groupBoxShape.Size = new Size(190, 80);
            groupBoxShape.TabIndex = 1;
            groupBoxShape.TabStop = false;
            groupBoxShape.Text = "도형 선택";
            // 
            // btnLine
            // 
            btnLine.Location = new Point(10, 25);
            btnLine.Name = "btnLine";
            btnLine.Size = new Size(50, 45);
            btnLine.TabIndex = 0;
            btnLine.Text = "직선";
            btnLine.UseVisualStyleBackColor = true;
            btnLine.Click += btnLine_Click;
            // 
            // btnRectangle
            // 
            btnRectangle.Font = new Font("맑은 고딕", 8F);
            btnRectangle.Location = new Point(70, 25);
            btnRectangle.Name = "btnRectangle";
            btnRectangle.Size = new Size(50, 45);
            btnRectangle.TabIndex = 1;
            btnRectangle.Text = "사각형";
            btnRectangle.UseVisualStyleBackColor = true;
            btnRectangle.Click += btnRectangle_Click;
            // 
            // btnCircle
            // 
            btnCircle.Location = new Point(130, 25);
            btnCircle.Name = "btnCircle";
            btnCircle.Size = new Size(50, 45);
            btnCircle.TabIndex = 2;
            btnCircle.Text = "원";
            btnCircle.UseVisualStyleBackColor = true;
            btnCircle.Click += btnCircle_Click;
            // 
            // groupBoxColor
            // 
            groupBoxColor.Controls.Add(cmbColor);
            groupBoxColor.Location = new Point(230, 85);
            groupBoxColor.Name = "groupBoxColor";
            groupBoxColor.Size = new Size(120, 80);
            groupBoxColor.TabIndex = 2;
            groupBoxColor.TabStop = false;
            groupBoxColor.Text = "색 선택";
            // 
            // cmbColor
            // 
            cmbColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbColor.Location = new Point(15, 35);
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new Size(90, 23);
            cmbColor.TabIndex = 0;
            cmbColor.SelectedIndexChanged += cmbColor_SelectedIndexChanged;
            // 
            // groupBoxLineWidth
            // 
            groupBoxLineWidth.Controls.Add(trbLineWidth);
            groupBoxLineWidth.Location = new Point(360, 85);
            groupBoxLineWidth.Name = "groupBoxLineWidth";
            groupBoxLineWidth.Size = new Size(150, 80);
            groupBoxLineWidth.TabIndex = 3;
            groupBoxLineWidth.TabStop = false;
            groupBoxLineWidth.Text = "선 두께";
            // 
            // trbLineWidth
            // 
            trbLineWidth.Location = new Point(10, 30);
            trbLineWidth.Name = "trbLineWidth";
            trbLineWidth.Size = new Size(130, 45);
            trbLineWidth.TabIndex = 0;
            trbLineWidth.ValueChanged += trbLineWidth_ValueChanged;
            // 
            // btnOpenFile
            // 
            btnOpenFile.BackColor = Color.LightYellow;
            btnOpenFile.Font = new Font("맑은 고딕", 14F, FontStyle.Bold);
            btnOpenFile.Location = new Point(530, 105);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(70, 55);
            btnOpenFile.TabIndex = 4;
            btnOpenFile.Text = "열기";
            btnOpenFile.UseVisualStyleBackColor = false;
            // 
            // btnSaveFile
            // 
            btnSaveFile.BackColor = Color.PaleTurquoise;
            btnSaveFile.Font = new Font("맑은 고딕", 14F, FontStyle.Bold);
            btnSaveFile.Location = new Point(610, 105);
            btnSaveFile.Name = "btnSaveFile";
            btnSaveFile.Size = new Size(70, 55);
            btnSaveFile.TabIndex = 5;
            btnSaveFile.Text = "저장";
            btnSaveFile.UseVisualStyleBackColor = false;
            // 
            // picCanvas
            // 
            picCanvas.BackColor = Color.White;
            picCanvas.BorderStyle = BorderStyle.FixedSingle;
            picCanvas.Location = new Point(30, 185);
            picCanvas.Name = "picCanvas";
            picCanvas.Size = new Size(650, 360);
            picCanvas.TabIndex = 6;
            picCanvas.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(715, 575);
            Controls.Add(lblAppName);
            Controls.Add(groupBoxShape);
            Controls.Add(groupBoxColor);
            Controls.Add(groupBoxLineWidth);
            Controls.Add(btnOpenFile);
            Controls.Add(btnSaveFile);
            Controls.Add(picCanvas);
            Name = "Form1";
            Text = "Simple Paint v1.0";
            groupBoxShape.ResumeLayout(false);
            groupBoxColor.ResumeLayout(false);
            groupBoxLineWidth.ResumeLayout(false);
            groupBoxLineWidth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}