namespace quanlyphongkhamnhi.Forms
{
    partial class PhongKhoa
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
            dataGridView = new DataGridView();
            dataGridView1 = new DataGridView();
            materialTextBox1 = new MaterialSkin.Controls.MaterialTextBox();
            materialTextBox2 = new MaterialSkin.Controls.MaterialTextBox();
            label1 = new Label();
            materialTextBox3 = new MaterialSkin.Controls.MaterialTextBox();
            button2 = new Button();
            button1 = new Button();
            buttonSua = new Button();
            buttonXoa = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            label2 = new Label();
            button8 = new Button();
            textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(422, 12);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(557, 253);
            dataGridView.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(422, 338);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(557, 231);
            dataGridView1.TabIndex = 4;
            // 
            // materialTextBox1
            // 
            materialTextBox1.AnimateReadOnly = false;
            materialTextBox1.BorderStyle = BorderStyle.None;
            materialTextBox1.Depth = 0;
            materialTextBox1.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox1.Hint = "Tên Khoa";
            materialTextBox1.LeadingIcon = null;
            materialTextBox1.Location = new Point(81, 59);
            materialTextBox1.MaxLength = 50;
            materialTextBox1.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox1.Multiline = false;
            materialTextBox1.Name = "materialTextBox1";
            materialTextBox1.Size = new Size(283, 50);
            materialTextBox1.TabIndex = 5;
            materialTextBox1.Text = "";
            materialTextBox1.TrailingIcon = null;
            // 
            // materialTextBox2
            // 
            materialTextBox2.AnimateReadOnly = false;
            materialTextBox2.BorderStyle = BorderStyle.None;
            materialTextBox2.Depth = 0;
            materialTextBox2.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox2.Hint = "Mô tả";
            materialTextBox2.LeadingIcon = null;
            materialTextBox2.Location = new Point(81, 115);
            materialTextBox2.MaxLength = 50;
            materialTextBox2.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox2.Multiline = false;
            materialTextBox2.Name = "materialTextBox2";
            materialTextBox2.Size = new Size(283, 50);
            materialTextBox2.TabIndex = 6;
            materialTextBox2.Text = "";
            materialTextBox2.TrailingIcon = null;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LightSeaGreen;
            label1.Location = new Point(153, 12);
            label1.Name = "label1";
            label1.Size = new Size(135, 32);
            label1.TabIndex = 30;
            label1.Text = "NHI KHOA";
            // 
            // materialTextBox3
            // 
            materialTextBox3.AnimateReadOnly = false;
            materialTextBox3.BorderStyle = BorderStyle.None;
            materialTextBox3.Depth = 0;
            materialTextBox3.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox3.Hint = "Tên Phòng";
            materialTextBox3.LeadingIcon = null;
            materialTextBox3.Location = new Point(81, 391);
            materialTextBox3.MaxLength = 50;
            materialTextBox3.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox3.Multiline = false;
            materialTextBox3.Name = "materialTextBox3";
            materialTextBox3.Size = new Size(283, 50);
            materialTextBox3.TabIndex = 31;
            materialTextBox3.Text = "";
            materialTextBox3.TrailingIcon = null;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 128, 255);
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(283, 178);
            button2.Name = "button2";
            button2.Padding = new Padding(20, 0, 0, 0);
            button2.Size = new Size(81, 31);
            button2.TabIndex = 35;
            button2.Text = "Lưu";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkOrchid;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(81, 234);
            button1.Name = "button1";
            button1.Padding = new Padding(20, 0, 0, 0);
            button1.Size = new Size(90, 31);
            button1.TabIndex = 34;
            button1.Text = "Thêm";
            button1.TextAlign = ContentAlignment.TopLeft;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // buttonSua
            // 
            buttonSua.BackColor = Color.Orange;
            buttonSua.Cursor = Cursors.Hand;
            buttonSua.FlatAppearance.BorderSize = 0;
            buttonSua.FlatStyle = FlatStyle.Flat;
            buttonSua.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSua.ForeColor = Color.White;
            buttonSua.Location = new Point(247, 234);
            buttonSua.Name = "buttonSua";
            buttonSua.Padding = new Padding(20, 0, 0, 0);
            buttonSua.Size = new Size(117, 31);
            buttonSua.TabIndex = 33;
            buttonSua.Text = "Cập nhật";
            buttonSua.TextAlign = ContentAlignment.TopLeft;
            buttonSua.UseVisualStyleBackColor = false;
            buttonSua.Click += buttonSua_Click;
            // 
            // buttonXoa
            // 
            buttonXoa.BackColor = Color.DodgerBlue;
            buttonXoa.Cursor = Cursors.Hand;
            buttonXoa.FlatAppearance.BorderSize = 0;
            buttonXoa.FlatStyle = FlatStyle.Flat;
            buttonXoa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonXoa.ForeColor = Color.White;
            buttonXoa.Location = new Point(177, 234);
            buttonXoa.Name = "buttonXoa";
            buttonXoa.Padding = new Padding(10, 0, 0, 0);
            buttonXoa.Size = new Size(64, 31);
            buttonXoa.TabIndex = 32;
            buttonXoa.Text = "Xóa";
            buttonXoa.TextAlign = ContentAlignment.TopLeft;
            buttonXoa.UseVisualStyleBackColor = false;
            buttonXoa.Click += buttonXoa_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 128, 255);
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(283, 447);
            button3.Name = "button3";
            button3.Padding = new Padding(20, 0, 0, 0);
            button3.Size = new Size(81, 31);
            button3.TabIndex = 39;
            button3.Text = "Lưu";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.DarkOrchid;
            button4.Cursor = Cursors.Hand;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(81, 538);
            button4.Name = "button4";
            button4.Padding = new Padding(20, 0, 0, 0);
            button4.Size = new Size(90, 31);
            button4.TabIndex = 38;
            button4.Text = "Thêm";
            button4.TextAlign = ContentAlignment.TopLeft;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.Orange;
            button5.Cursor = Cursors.Hand;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.White;
            button5.Location = new Point(247, 538);
            button5.Name = "button5";
            button5.Padding = new Padding(20, 0, 0, 0);
            button5.Size = new Size(117, 31);
            button5.TabIndex = 37;
            button5.Text = "Cập nhật";
            button5.TextAlign = ContentAlignment.TopLeft;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.DodgerBlue;
            button6.Cursor = Cursors.Hand;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.White;
            button6.Location = new Point(177, 538);
            button6.Name = "button6";
            button6.Padding = new Padding(10, 0, 0, 0);
            button6.Size = new Size(64, 31);
            button6.TabIndex = 36;
            button6.Text = "Xóa";
            button6.TextAlign = ContentAlignment.TopLeft;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.LightSeaGreen;
            label2.Location = new Point(113, 338);
            label2.Name = "label2";
            label2.Size = new Size(219, 32);
            label2.TabIndex = 40;
            label2.Text = "PHÒNG LÀM VIỆC";
            // 
            // button8
            // 
            button8.BackColor = Color.LimeGreen;
            button8.Cursor = Cursors.Hand;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.ForeColor = Color.White;
            button8.Location = new Point(722, 286);
            button8.Name = "button8";
            button8.Padding = new Padding(5, 0, 0, 0);
            button8.Size = new Size(71, 33);
            button8.TabIndex = 42;
            button8.Text = "Tìm";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.InactiveCaption;
            textBox2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(422, 286);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(294, 33);
            textBox2.TabIndex = 41;
            // 
            // PhongKhoa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(991, 581);
            Controls.Add(button8);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(button6);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(buttonSua);
            Controls.Add(buttonXoa);
            Controls.Add(materialTextBox3);
            Controls.Add(label1);
            Controls.Add(materialTextBox2);
            Controls.Add(materialTextBox1);
            Controls.Add(dataGridView1);
            Controls.Add(dataGridView);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PhongKhoa";
            Text = "PhongKhoa";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private DataGridView dataGridView1;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox1;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox2;
        private Label label1;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox3;
        private Button button2;
        private Button button1;
        private Button buttonSua;
        private Button buttonXoa;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Label label2;
        private Button button8;
        private TextBox textBox2;
    }
}