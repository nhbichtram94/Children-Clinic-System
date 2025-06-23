namespace quanlyphongkhamnhi.Forms
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            materialTextBox2 = new MaterialSkin.Controls.MaterialTextBox();
            materialTextBox1 = new MaterialSkin.Controls.MaterialTextBox();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            label3 = new Label();
            materialButton2 = new MaterialSkin.Controls.MaterialButton();
            materialTextBox6 = new MaterialSkin.Controls.MaterialTextBox();
            materialTextBox3 = new MaterialSkin.Controls.MaterialTextBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            timer3 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(materialButton1);
            panel1.Controls.Add(materialTextBox2);
            panel1.Controls.Add(materialTextBox1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(647, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(360, 659);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(70, 437);
            label2.Name = "label2";
            label2.Size = new Size(224, 23);
            label2.TabIndex = 5;
            label2.Text = "Chưa có tài khoản? Đăng ký";
            label2.Click += label2_Click;
            // 
            // materialButton1
            // 
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(130, 324);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(105, 36);
            materialButton1.TabIndex = 3;
            materialButton1.Text = "Đăng nhập";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += materialButton1_Click;
            // 
            // materialTextBox2
            // 
            materialTextBox2.AnimateReadOnly = false;
            materialTextBox2.BorderStyle = BorderStyle.None;
            materialTextBox2.Depth = 0;
            materialTextBox2.Font = new Font("Microsoft Sans Serif", 12F);
            materialTextBox2.ForeColor = Color.Silver;
            materialTextBox2.LeadingIcon = null;
            materialTextBox2.Location = new Point(31, 221);
            materialTextBox2.MaxLength = 50;
            materialTextBox2.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox2.Multiline = false;
            materialTextBox2.Name = "materialTextBox2";
            materialTextBox2.Size = new Size(300, 50);
            materialTextBox2.TabIndex = 2;
            materialTextBox2.Hint = "Mật khẩu";
            materialTextBox2.TrailingIcon = null;
            // 
            // materialTextBox1
            // 
            materialTextBox1.AnimateReadOnly = false;
            materialTextBox1.BackColor = SystemColors.HotTrack;
            materialTextBox1.BorderStyle = BorderStyle.None;
            materialTextBox1.Depth = 0;
            materialTextBox1.Font = new Font("Microsoft Sans Serif", 12F);
            materialTextBox1.ForeColor = Color.Silver;
            materialTextBox1.LeadingIcon = null;
            materialTextBox1.Location = new Point(31, 165);
            materialTextBox1.MaxLength = 50;
            materialTextBox1.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox1.Multiline = false;
            materialTextBox1.Name = "materialTextBox1";
            materialTextBox1.Size = new Size(300, 50);
            materialTextBox1.TabIndex = 1;
            materialTextBox1.Hint = "Số điện thoại";
            materialTextBox1.TrailingIcon = null;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Logo;
            pictureBox1.Location = new Point(130, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(117, 113);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(materialLabel1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(materialButton2);
            panel2.Controls.Add(materialTextBox6);
            panel2.Controls.Add(materialTextBox3);
            panel2.Controls.Add(pictureBox2);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(360, 659);
            panel2.TabIndex = 1;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(30, 143);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(107, 19);
            materialLabel1.TabIndex = 9;
            materialLabel1.Text = "materialLabel1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Blue;
            label3.Location = new Point(62, 437);
            label3.Name = "label3";
            label3.Size = new Size(236, 23);
            label3.TabIndex = 8;
            label3.Text = "Chuyển đến trang đăng nhập";
            label3.Click += label3_Click;
            // 
            // materialButton2
            // 
            materialButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton2.Depth = 0;
            materialButton2.HighEmphasis = true;
            materialButton2.Icon = null;
            materialButton2.Location = new Point(140, 298);
            materialButton2.Margin = new Padding(4, 6, 4, 6);
            materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton2.Name = "materialButton2";
            materialButton2.NoAccentTextColor = Color.Empty;
            materialButton2.Size = new Size(83, 36);
            materialButton2.TabIndex = 4;
            materialButton2.Text = "Đăng ký";
            materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton2.UseAccentColor = false;
            materialButton2.UseVisualStyleBackColor = true;
            materialButton2.Click += materialButton2_Click;
            // 
            // materialTextBox6
            // 
            materialTextBox6.AnimateReadOnly = false;
            materialTextBox6.BorderStyle = BorderStyle.None;
            materialTextBox6.Depth = 0;
            materialTextBox6.Font = new Font("Microsoft Sans Serif", 12F);
            materialTextBox6.ForeColor = Color.Silver;
            materialTextBox6.LeadingIcon = null;
            materialTextBox6.Location = new Point(30, 165);
            materialTextBox6.MaxLength = 50;
            materialTextBox6.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox6.Multiline = false;
            materialTextBox6.Name = "materialTextBox6";
            materialTextBox6.Size = new Size(300, 50);
            materialTextBox6.TabIndex = 6;
            materialTextBox6.Hint = "Số điện thoại";
            materialTextBox6.TrailingIcon = null;
            // 
            // materialTextBox3
            // 
            materialTextBox3.AnimateReadOnly = false;
            materialTextBox3.BorderStyle = BorderStyle.None;
            materialTextBox3.Depth = 0;
            materialTextBox3.Font = new Font("Microsoft Sans Serif", 12F);
            materialTextBox3.ForeColor = Color.Silver;
            materialTextBox3.LeadingIcon = null;
            materialTextBox3.Location = new Point(30, 221);
            materialTextBox3.MaxLength = 50;
            materialTextBox3.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox3.Multiline = false;
            materialTextBox3.Name = "materialTextBox3";
            materialTextBox3.Size = new Size(300, 50);
            materialTextBox3.TabIndex = 4;
            materialTextBox3.Hint = "Mật khẩu";
            materialTextBox3.TrailingIcon = null;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Logo;
            pictureBox2.Location = new Point(118, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(117, 113);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.loginbanner;
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(651, 656);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // timer1
            // 
            timer1.Interval = 5;
            timer1.Tick += timer1_Tick_1;
            // 
            // timer3
            // 
            timer3.Interval = 5;
            timer3.Tick += timer3_Tick;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.wallpaperlogin;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1007, 659);
            Controls.Add(pictureBox3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox2;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox1;
        private PictureBox pictureBox2;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox6;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox3;
        private Label label2;
        private Label label1;
        private Label label3;
        private PictureBox pictureBox3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer3;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}
