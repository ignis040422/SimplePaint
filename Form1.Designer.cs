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
            lblAppName = new System.Windows.Forms.Label();
            groupBoxShape = new System.Windows.Forms.GroupBox();
            btnLine = new System.Windows.Forms.Button();
            btnRectangle = new System.Windows.Forms.Button();
            btnCircle = new System.Windows.Forms.Button();
            groupBoxColor = new System.Windows.Forms.GroupBox();
            cmbColor = new System.Windows.Forms.ComboBox();
            groupBoxLineWidth = new System.Windows.Forms.GroupBox();
            trbLineWidth = new System.Windows.Forms.TrackBar();
            btnOpenFile = new System.Windows.Forms.Button();
            btnSaveFile = new System.Windows.Forms.Button();
            picCanvas = new System.Windows.Forms.PictureBox();

            groupBoxShape.SuspendLayout();
            groupBoxColor.SuspendLayout();
            groupBoxLineWidth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            SuspendLayout();

            lblAppName.AutoSize = true;
            lblAppName.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Bold);
            lblAppName.ForeColor = System.Drawing.Color.Blue;
            lblAppName.Location = new System.Drawing.Point(25, 25);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new System.Drawing.Size(190, 45);
            lblAppName.Text = "Simple Paint";

            groupBoxShape.Controls.Add(btnLine);
            groupBoxShape.Controls.Add(btnRectangle);
            groupBoxShape.Controls.Add(btnCircle);
            groupBoxShape.Location = new System.Drawing.Point(30, 85);
            groupBoxShape.Name = "groupBoxShape";
            groupBoxShape.Size = new System.Drawing.Size(190, 80);
            groupBoxShape.Text = "도형 선택";

            btnLine.Location = new System.Drawing.Point(10, 25);
            btnLine.Name = "btnLine";
            btnLine.Size = new System.Drawing.Size(50, 45);
            btnLine.Text = "직선";
            btnLine.UseVisualStyleBackColor = true;
            btnLine.Click += btnLine_Click;

            btnRectangle.Location = new System.Drawing.Point(70, 25);
            btnRectangle.Name = "btnRectangle";
            btnRectangle.Size = new System.Drawing.Size(50, 45);
            btnRectangle.Text = "사각형";
            btnRectangle.UseVisualStyleBackColor = true;
            btnRectangle.Click += btnRectangle_Click;

            btnCircle.Location = new System.Drawing.Point(130, 25);
            btnCircle.Name = "btnCircle";
            btnCircle.Size = new System.Drawing.Size(50, 45);
            btnCircle.Text = "원";
            btnCircle.UseVisualStyleBackColor = true;
            btnCircle.Click += btnCircle_Click;

            groupBoxColor.Controls.Add(cmbColor);
            groupBoxColor.Location = new System.Drawing.Point(230, 85);
            groupBoxColor.Name = "groupBoxColor";
            groupBoxColor.Size = new System.Drawing.Size(120, 80);
            groupBoxColor.Text = "색 선택";

            cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbColor.Location = new System.Drawing.Point(15, 35);
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new System.Drawing.Size(90, 23);
            cmbColor.SelectedIndexChanged += cmbColor_SelectedIndexChanged;

            groupBoxLineWidth.Controls.Add(trbLineWidth);
            groupBoxLineWidth.Location = new System.Drawing.Point(360, 85);
            groupBoxLineWidth.Name = "groupBoxLineWidth";
            groupBoxLineWidth.Size = new System.Drawing.Size(150, 80);
            groupBoxLineWidth.Text = "선 두께";

            trbLineWidth.Location = new System.Drawing.Point(10, 30);
            trbLineWidth.Name = "trbLineWidth";
            trbLineWidth.Size = new System.Drawing.Size(130, 45);
            trbLineWidth.ValueChanged += trbLineWidth_ValueChanged;

            btnOpenFile.BackColor = System.Drawing.Color.LightYellow;
            btnOpenFile.Enabled = false;
            btnOpenFile.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            btnOpenFile.Location = new System.Drawing.Point(530, 105);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new System.Drawing.Size(70, 55);
            btnOpenFile.Text = "열기";
            btnOpenFile.UseVisualStyleBackColor = false;

            btnSaveFile.BackColor = System.Drawing.Color.PaleTurquoise;
            btnSaveFile.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            btnSaveFile.Location = new System.Drawing.Point(610, 105);
            btnSaveFile.Name = "btnSaveFile";
            btnSaveFile.Size = new System.Drawing.Size(70, 55);
            btnSaveFile.Text = "저장";
            btnSaveFile.UseVisualStyleBackColor = false;
            btnSaveFile.Click += btnSaveFile_Click;

            picCanvas.BackColor = System.Drawing.Color.White;
            picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picCanvas.Location = new System.Drawing.Point(30, 185);
            picCanvas.Name = "picCanvas";
            picCanvas.Size = new System.Drawing.Size(650, 360);
            picCanvas.TabStop = false;

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(715, 575);
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