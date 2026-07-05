namespace quanlyphongkhamnhi.Forms
{
    partial class NhanVien : Form
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
            sidebar = new FlowLayoutPanel();
            panel2 = new Panel();
            panel4 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            menuButton = new PictureBox();
            homeContainer = new Panel();
            buttonHome = new Button();
            button1 = new Button();
            button3 = new Button();
            button5 = new Button();
            mainpanel = new Panel();
            sidebarTimer = new System.Windows.Forms.Timer(components);
            HomeTimer = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            label2 = new Label();
            button8 = new Button();
            button7 = new Button();
            closeButton = new Button();
            sidebar.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)menuButton).BeginInit();
            homeContainer.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // sidebar
            // 
            sidebar.BackColor = Color.FromArgb(74, 123, 157);
            sidebar.Controls.Add(panel2);
            sidebar.Controls.Add(homeContainer);
            sidebar.Controls.Add(button3);
            sidebar.Controls.Add(button5);
            sidebar.Location = new Point(0, 0);
            sidebar.MaximumSize = new Size(200, 698);
            sidebar.MinimumSize = new Size(77, 698);
            sidebar.Name = "sidebar";
            sidebar.Size = new Size(200, 698);
            sidebar.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(54, 103, 137);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(menuButton);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(197, 100);
            panel2.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Location = new Point(194, 42);
            panel4.Name = "panel4";
            panel4.Size = new Size(569, 324);
            panel4.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Cursor = Cursors.Hand;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(76, 40);
            label1.Name = "label1";
            label1.Size = new Size(62, 25);
            label1.TabIndex = 1;
            label1.Text = "Menu";
            // 
            // panel3
            // 
            panel3.Location = new Point(203, 40);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 100);
            panel3.TabIndex = 2;
            // 
            // menuButton
            // 
            menuButton.BackgroundImage = Properties.Resources.ham1;
            menuButton.Cursor = Cursors.Hand;
            menuButton.Location = new Point(20, 27);
            menuButton.Name = "menuButton";
            menuButton.Size = new Size(50, 49);
            menuButton.SizeMode = PictureBoxSizeMode.StretchImage;
            menuButton.TabIndex = 0;
            menuButton.TabStop = false;
            // 
            // homeContainer
            // 
            homeContainer.BackColor = Color.RoyalBlue;
            homeContainer.Controls.Add(buttonHome);
            homeContainer.Controls.Add(button1);
            homeContainer.Location = new Point(3, 109);
            homeContainer.MaximumSize = new Size(197, 89);
            homeContainer.MinimumSize = new Size(197, 48);
            homeContainer.Name = "homeContainer";
            homeContainer.Size = new Size(197, 48);
            homeContainer.TabIndex = 2;
            // 
            // buttonHome
            // 
            buttonHome.BackColor = Color.FromArgb(74, 123, 157);
            buttonHome.BackgroundImageLayout = ImageLayout.None;
            buttonHome.Cursor = Cursors.Hand;
            buttonHome.FlatAppearance.BorderSize = 0;
            buttonHome.FlatStyle = FlatStyle.Flat;
            buttonHome.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonHome.ForeColor = Color.White;
            buttonHome.Image = Properties.Resources.home3;
            buttonHome.ImageAlign = ContentAlignment.MiddleLeft;
            buttonHome.Location = new Point(0, 0);
            buttonHome.Name = "buttonHome";
            buttonHome.Padding = new Padding(20, 0, 0, 0);
            buttonHome.Size = new Size(197, 48);
            buttonHome.TabIndex = 1;
            buttonHome.Text = "            Trang Cá Nhân";
            buttonHome.TextAlign = ContentAlignment.MiddleLeft;
            buttonHome.UseVisualStyleBackColor = false;
            buttonHome.Click += buttonHome_Click_1;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(163, 200, 228);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Image = Properties.Resources.userbs1;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(0, 44);
            button1.Name = "button1";
            button1.Padding = new Padding(20, 0, 0, 0);
            button1.Size = new Size(197, 45);
            button1.TabIndex = 4;
            button1.Text = "            Hồ sơ cá nhân";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(74, 123, 157);
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Image = Properties.Resources.file;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(3, 163);
            button3.Name = "button3";
            button3.Padding = new Padding(20, 0, 0, 0);
            button3.Size = new Size(197, 48);
            button3.TabIndex = 3;
            button3.Text = "            Thành Tiền";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click_1;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(74, 123, 157);
            button5.Cursor = Cursors.Hand;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.White;
            button5.Image = Properties.Resources.out1;
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(3, 217);
            button5.Name = "button5";
            button5.Padding = new Padding(20, 0, 0, 0);
            button5.Size = new Size(197, 48);
            button5.TabIndex = 5;
            button5.Text = "            Đăng Xuất";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click_1;
            // 
            // mainpanel
            // 
            mainpanel.BackColor = Color.LightGray;
            mainpanel.Location = new Point(200, 39);
            mainpanel.Name = "mainpanel";
            mainpanel.Size = new Size(1007, 659);
            mainpanel.TabIndex = 2;
            // 
            // sidebarTimer
            // 
            sidebarTimer.Interval = 10;
            sidebarTimer.Tick += sidebarTimer_Tick;
            // 
            // HomeTimer
            // 
            HomeTimer.Interval = 10;
            HomeTimer.Tick += HomeTimer_Tick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(74, 123, 157);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(closeButton);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1207, 39);
            panel1.TabIndex = 1;
            panel1.MouseDown += Form1_MouseDown;
            panel1.MouseMove += Form1_MouseMove;
            panel1.MouseUp += Form1_MouseUp;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(74, 123, 157);
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(219, 3);
            label2.Name = "label2";
            label2.Size = new Size(72, 30);
            label2.TabIndex = 5;
            label2.Text = "label2";
            // 
            // button8
            // 
            button8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button8.BackColor = Color.White;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.Location = new Point(1072, 3);
            button8.Name = "button8";
            button8.Size = new Size(40, 30);
            button8.TabIndex = 4;
            button8.Text = "▁";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click_1;
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button7.BackColor = Color.FromArgb(255, 255, 192);
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.Location = new Point(1118, 3);
            button7.Name = "button7";
            button7.Size = new Size(40, 30);
            button7.TabIndex = 3;
            button7.Text = "▭";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click_1;
            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeButton.BackColor = Color.FromArgb(255, 192, 192);
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            closeButton.Location = new Point(1164, 3);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(40, 30);
            closeButton.TabIndex = 2;
            closeButton.Text = "X";
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += closeButton_Click_1;
            // 
            // NhanVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1207, 698);
            Controls.Add(sidebar);
            Controls.Add(panel1);
            Controls.Add(mainpanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "NhanVien";
            Text = "Phòng Khám Nhi Đồng";
            sidebar.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)menuButton).EndInit();
            homeContainer.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Panel mainpanel;
        private Button buttonHome;
        private Button button3;
        private PictureBox menuButton;
        private Label label1;
        private System.Windows.Forms.Timer sidebarTimer;
        private FlowLayoutPanel sidebar;
        private Panel homeContainer;
        private Button button1;
        private System.Windows.Forms.Timer HomeTimer;
        private Panel panel1;
        private Button closeButton;
        private Button button8;
        private Button button7;
        private Panel panel3;
        private Panel panel4;
        private Label label2;
        private Button button5;
    }
}
