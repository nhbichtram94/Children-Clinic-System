namespace quanlyphongkhamnhi.Forms
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            sidebar = new FlowLayoutPanel();
            panel2 = new Panel();
            panel4 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            menuButton = new PictureBox();
            homeContainer = new Panel();
            button10 = new Button();
            button1 = new Button();
            buttonHome = new Button();
            button6 = new Button();
            button3 = new Button();
            button5 = new Button();
            button9 = new Button();
            button11 = new Button();
            button4 = new Button();
            button2 = new Button();
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
            sidebar.BackColor = Color.FromArgb(31, 31, 31);
            sidebar.Controls.Add(panel2);
            sidebar.Controls.Add(homeContainer);
            sidebar.Controls.Add(button3);
            sidebar.Controls.Add(button5);
            sidebar.Controls.Add(button9);
            sidebar.Controls.Add(button11);
            sidebar.Controls.Add(button4);
            sidebar.Controls.Add(button2);
            sidebar.Location = new Point(0, 0);
            sidebar.MaximumSize = new Size(200, 698);
            sidebar.MinimumSize = new Size(77, 698);
            sidebar.Name = "sidebar";
            sidebar.Size = new Size(200, 698);
            sidebar.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Indigo;
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
            menuButton.Location = new Point(9, 21);
            menuButton.Name = "menuButton";
            menuButton.Size = new Size(48, 44);
            menuButton.SizeMode = PictureBoxSizeMode.StretchImage;
            menuButton.TabIndex = 0;
            menuButton.TabStop = false;
            menuButton.Click += menuButton_Click;
            // 
            // homeContainer
            // 
            homeContainer.BackColor = Color.RoyalBlue;
            homeContainer.Controls.Add(button10);
            homeContainer.Controls.Add(button1);
            homeContainer.Controls.Add(buttonHome);
            homeContainer.Controls.Add(button6);
            homeContainer.Location = new Point(3, 109);
            homeContainer.MaximumSize = new Size(197, 176);
            homeContainer.MinimumSize = new Size(197, 48);
            homeContainer.Name = "homeContainer";
            homeContainer.Size = new Size(197, 48);
            homeContainer.TabIndex = 2;
            // 
            // button10
            // 
            button10.BackColor = Color.SlateGray;
            button10.Cursor = Cursors.Hand;
            button10.FlatAppearance.BorderSize = 0;
            button10.FlatStyle = FlatStyle.Flat;
            button10.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button10.ForeColor = Color.White;
            button10.Image = Properties.Resources.dot;
            button10.ImageAlign = ContentAlignment.MiddleLeft;
            button10.Location = new Point(0, 132);
            button10.Name = "button10";
            button10.Padding = new Padding(20, 0, 0, 0);
            button10.Size = new Size(197, 43);
            button10.TabIndex = 5;
            button10.Text = "            Nhân Viên";
            button10.TextAlign = ContentAlignment.MiddleLeft;
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.SlateGray;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Image = Properties.Resources.dot;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(0, 89);
            button1.Name = "button1";
            button1.Padding = new Padding(20, 0, 0, 0);
            button1.Size = new Size(197, 45);
            button1.TabIndex = 4;
            button1.Text = "            Bệnh Nhi";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // buttonHome
            // 
            buttonHome.BackColor = Color.FromArgb(31, 31, 31);
            buttonHome.Cursor = Cursors.Hand;
            buttonHome.FlatAppearance.BorderSize = 0;
            buttonHome.FlatStyle = FlatStyle.Flat;
            buttonHome.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonHome.ForeColor = Color.White;
            buttonHome.Image = Properties.Resources.fle_admin;
            buttonHome.ImageAlign = ContentAlignment.MiddleLeft;
            buttonHome.Location = new Point(0, 0);
            buttonHome.Name = "buttonHome";
            buttonHome.Padding = new Padding(20, 0, 0, 0);
            buttonHome.Size = new Size(197, 48);
            buttonHome.TabIndex = 1;
            buttonHome.Text = "            Quản Lý Chung";
            buttonHome.TextAlign = ContentAlignment.MiddleLeft;
            buttonHome.UseVisualStyleBackColor = false;
            buttonHome.Click += buttonHome_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.SlateGray;
            button6.Cursor = Cursors.Hand;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.White;
            button6.Image = Properties.Resources.dot;
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(0, 45);
            button6.Name = "button6";
            button6.Padding = new Padding(20, 0, 0, 0);
            button6.Size = new Size(197, 46);
            button6.TabIndex = 3;
            button6.Text = "            Bác Sĩ";
            button6.TextAlign = ContentAlignment.MiddleLeft;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(31, 31, 31);
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Image = Properties.Resources.medicine;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(3, 163);
            button3.Name = "button3";
            button3.Padding = new Padding(20, 0, 0, 0);
            button3.Size = new Size(197, 48);
            button3.TabIndex = 3;
            button3.Text = "            Quản Lý Thuốc";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(31, 31, 31);
            button5.Cursor = Cursors.Hand;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.White;
            button5.Image = Properties.Resources.usericon;
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(3, 217);
            button5.Name = "button5";
            button5.Padding = new Padding(20, 0, 0, 0);
            button5.Size = new Size(197, 48);
            button5.TabIndex = 5;
            button5.Text = "            Tài Khoản HT";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button9
            // 
            button9.BackColor = Color.FromArgb(31, 31, 31);
            button9.Cursor = Cursors.Hand;
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button9.ForeColor = Color.White;
            button9.Image = (Image)resources.GetObject("button9.Image");
            button9.ImageAlign = ContentAlignment.MiddleLeft;
            button9.Location = new Point(3, 271);
            button9.Name = "button9";
            button9.Padding = new Padding(20, 0, 0, 0);
            button9.Size = new Size(197, 48);
            button9.TabIndex = 4;
            button9.Text = "            Phòng - Khoa";
            button9.TextAlign = ContentAlignment.MiddleLeft;
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // button11
            // 
            button11.BackColor = Color.FromArgb(31, 31, 31);
            button11.Cursor = Cursors.Hand;
            button11.FlatAppearance.BorderSize = 0;
            button11.FlatStyle = FlatStyle.Flat;
            button11.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button11.ForeColor = Color.White;
            button11.Image = (Image)resources.GetObject("button11.Image");
            button11.ImageAlign = ContentAlignment.MiddleLeft;
            button11.Location = new Point(3, 325);
            button11.Name = "button11";
            button11.Padding = new Padding(20, 0, 0, 0);
            button11.Size = new Size(197, 48);
            button11.TabIndex = 5;
            button11.Text = "            Hóa Đơn";
            button11.TextAlign = ContentAlignment.MiddleLeft;
            button11.UseVisualStyleBackColor = false;
            button11.Click += button11_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(31, 31, 31);
            button4.Cursor = Cursors.Hand;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Image = Properties.Resources.chart1;
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(3, 379);
            button4.Name = "button4";
            button4.Padding = new Padding(20, 0, 0, 0);
            button4.Size = new Size(197, 48);
            button4.TabIndex = 4;
            button4.Text = "            Dữ Liệu";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(31, 31, 31);
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Image = Properties.Resources.logout;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(3, 433);
            button2.Name = "button2";
            button2.Padding = new Padding(20, 0, 0, 0);
            button2.Size = new Size(197, 48);
            button2.TabIndex = 5;
            button2.Text = "            Đăng Xuất";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
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
            panel1.BackColor = Color.FromArgb(31, 31, 31);
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
            label2.BackColor = Color.FromArgb(31, 31, 31);
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(215, 6);
            label2.Name = "label2";
            label2.Size = new Size(72, 30);
            label2.TabIndex = 6;
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
            button8.Click += button8_Click;
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
            button7.Click += button7_Click;
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
            closeButton.Click += closeButton_Click;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1207, 698);
            Controls.Add(sidebar);
            Controls.Add(panel1);
            Controls.Add(mainpanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Admin";
            Text = "Quản Trị Viên";
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
        private Button button4;
        private Button button5;
        private Label label1;
        private System.Windows.Forms.Timer sidebarTimer;
        private FlowLayoutPanel sidebar;
        private Panel homeContainer;
        private Button button6;
        private Button button1;
        private System.Windows.Forms.Timer HomeTimer;
        private Panel panel1;
        private Button closeButton;
        private Button button8;
        private Button button7;
        private Panel panel3;
        private Panel panel4;
        private PictureBox menuButton;
        private Button button2;
        private Label label2;
        private Button button9;
        private Button button10;
        private Button button11;
    }
}