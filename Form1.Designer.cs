namespace cam_rewrite
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            old_display = new PictureBox();
            new_display = new PictureBox();
            selectcam = new ComboBox();
            label1 = new Label();
            start_btn = new Button();
            speedLB = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            ConsoleTB = new TextBox();
            totalLB = new Label();
            speedYLB = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)old_display).BeginInit();
            ((System.ComponentModel.ISupportInitialize)new_display).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 62);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // old_display
            // 
            old_display.BackColor = SystemColors.ActiveCaptionText;
            old_display.Location = new Point(78, 92);
            old_display.Name = "old_display";
            old_display.Size = new Size(312, 307);
            old_display.SizeMode = PictureBoxSizeMode.StretchImage;
            old_display.TabIndex = 1;
            old_display.TabStop = false;
            // 
            // new_display
            // 
            new_display.BackColor = SystemColors.ActiveCaptionText;
            new_display.Location = new Point(441, 92);
            new_display.Name = "new_display";
            new_display.Size = new Size(329, 307);
            new_display.SizeMode = PictureBoxSizeMode.StretchImage;
            new_display.TabIndex = 2;
            new_display.TabStop = false;
            // 
            // selectcam
            // 
            selectcam.FormattingEnabled = true;
            selectcam.Location = new Point(240, 34);
            selectcam.Name = "selectcam";
            selectcam.Size = new Size(250, 28);
            selectcam.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Location = new Point(315, 11);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 4;
            label1.Text = "Select Camera";
            // 
            // start_btn
            // 
            start_btn.Location = new Point(521, 33);
            start_btn.Name = "start_btn";
            start_btn.Size = new Size(94, 29);
            start_btn.TabIndex = 5;
            start_btn.Text = "Start";
            start_btn.UseVisualStyleBackColor = true;
            start_btn.Click += start_btn_Click;
            // 
            // speedLB
            // 
            speedLB.AutoSize = true;
            speedLB.BackColor = SystemColors.Control;
            speedLB.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            speedLB.Location = new Point(441, 421);
            speedLB.Name = "speedLB";
            speedLB.Size = new Size(122, 35);
            speedLB.TabIndex = 6;
            speedLB.Text = "speedtext";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // ConsoleTB
            // 
            ConsoleTB.Location = new Point(89, 484);
            ConsoleTB.Name = "ConsoleTB";
            ConsoleTB.Size = new Size(125, 27);
            ConsoleTB.TabIndex = 8;
            ConsoleTB.TextChanged += ConsoleTB_TextChanged;
            // 
            // totalLB
            // 
            totalLB.AutoSize = true;
            totalLB.BackColor = SystemColors.Control;
            totalLB.Location = new Point(441, 491);
            totalLB.Name = "totalLB";
            totalLB.Size = new Size(40, 20);
            totalLB.TabIndex = 9;
            totalLB.Text = "total";
            totalLB.Click += totalLB_Click;
            // 
            // speedYLB
            // 
            speedYLB.AutoSize = true;
            speedYLB.BackColor = SystemColors.Control;
            speedYLB.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            speedYLB.Location = new Point(441, 456);
            speedYLB.Name = "speedYLB";
            speedYLB.Size = new Size(136, 35);
            speedYLB.TabIndex = 10;
            speedYLB.Text = "speedYtext";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlLightLight;
            label2.Location = new Point(121, 456);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 11;
            label2.Text = "Console";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(832, 578);
            Controls.Add(label2);
            Controls.Add(speedYLB);
            Controls.Add(totalLB);
            Controls.Add(ConsoleTB);
            Controls.Add(speedLB);
            Controls.Add(start_btn);
            Controls.Add(label1);
            Controls.Add(selectcam);
            Controls.Add(new_display);
            Controls.Add(old_display);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)old_display).EndInit();
            ((System.ComponentModel.ISupportInitialize)new_display).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox old_display;
        private PictureBox new_display;
        private ComboBox selectcam;
        private Label label1;
        private Button start_btn;
        private Label speedLB;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox ConsoleTB;
        private Label totalLB;
        private Label speedYLB;
        private Label label2;
    }
}