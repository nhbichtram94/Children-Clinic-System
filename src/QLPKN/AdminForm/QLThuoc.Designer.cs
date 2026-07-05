namespace quanlyphongkhamnhi.Forms
{
    partial class QLThuoc
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
            materialTextBox1 = new MaterialSkin.Controls.MaterialTextBox();
            materialTextBox2 = new MaterialSkin.Controls.MaterialTextBox();
            materialTextBox3 = new MaterialSkin.Controls.MaterialTextBox();
            numericUpDown = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            button8 = new Button();
            textBox2 = new TextBox();
            button2 = new Button();
            button1 = new Button();
            buttonSua = new Button();
            buttonXoa = new Button();
            materialTextBox4 = new MaterialSkin.Controls.MaterialTextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 284);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(660, 324);
            dataGridView.TabIndex = 4;
            // 
            // materialTextBox1
            // 
            materialTextBox1.AnimateReadOnly = false;
            materialTextBox1.BorderStyle = BorderStyle.None;
            materialTextBox1.Depth = 0;
            materialTextBox1.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox1.Hint = "Tên thuốc";
            materialTextBox1.LeadingIcon = null;
            materialTextBox1.Location = new Point(12, 62);
            materialTextBox1.MaxLength = 50;
            materialTextBox1.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox1.Multiline = false;
            materialTextBox1.Name = "materialTextBox1";
            materialTextBox1.Size = new Size(336, 50);
            materialTextBox1.TabIndex = 7;
            materialTextBox1.Text = "";
            materialTextBox1.TrailingIcon = null;
            // 
            // materialTextBox2
            // 
            materialTextBox2.AnimateReadOnly = false;
            materialTextBox2.BorderStyle = BorderStyle.None;
            materialTextBox2.Depth = 0;
            materialTextBox2.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox2.Hint = "Cách dùng";
            materialTextBox2.LeadingIcon = null;
            materialTextBox2.Location = new Point(12, 118);
            materialTextBox2.MaxLength = 50;
            materialTextBox2.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox2.Multiline = false;
            materialTextBox2.Name = "materialTextBox2";
            materialTextBox2.Size = new Size(502, 50);
            materialTextBox2.TabIndex = 10;
            materialTextBox2.Text = "";
            materialTextBox2.TrailingIcon = null;
            // 
            // materialTextBox3
            // 
            materialTextBox3.AnimateReadOnly = false;
            materialTextBox3.BorderStyle = BorderStyle.None;
            materialTextBox3.Depth = 0;
            materialTextBox3.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox3.Hint = "Giá bán";
            materialTextBox3.LeadingIcon = null;
            materialTextBox3.Location = new Point(354, 62);
            materialTextBox3.MaxLength = 50;
            materialTextBox3.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox3.Multiline = false;
            materialTextBox3.Name = "materialTextBox3";
            materialTextBox3.Size = new Size(160, 50);
            materialTextBox3.TabIndex = 11;
            materialTextBox3.Text = "";
            materialTextBox3.TrailingIcon = null;
            // 
            // numericUpDown
            // 
            numericUpDown.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDown.Location = new Point(248, 189);
            numericUpDown.Name = "numericUpDown";
            numericUpDown.Size = new Size(100, 35);
            numericUpDown.TabIndex = 12;
            numericUpDown.Minimum = 0;
            numericUpDown.Maximum = 1000;

            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(188, 194);
            label2.Name = "label2";
            label2.Size = new Size(54, 30);
            label2.TabIndex = 13;
            label2.Text = "Kho:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.LightSeaGreen;
            label3.Location = new Point(12, 12);
            label3.Name = "label3";
            label3.Size = new Size(207, 32);
            label3.TabIndex = 31;
            label3.Text = "QUẢN LÝ THUỐC";
            // 
            // button8
            // 
            button8.BackColor = Color.LimeGreen;
            button8.Cursor = Cursors.Hand;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.ForeColor = Color.White;
            button8.Location = new Point(601, 245);
            button8.Name = "button8";
            button8.Padding = new Padding(5, 0, 0, 0);
            button8.Size = new Size(71, 33);
            button8.TabIndex = 44;
            button8.Text = "Tìm";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.InactiveCaption;
            textBox2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(301, 245);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(294, 33);
            textBox2.TabIndex = 43;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 128, 255);
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(433, 196);
            button2.Name = "button2";
            button2.Padding = new Padding(20, 0, 0, 0);
            button2.Size = new Size(81, 31);
            button2.TabIndex = 48;
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
            button1.Location = new Point(12, 245);
            button1.Name = "button1";
            button1.Padding = new Padding(20, 0, 0, 0);
            button1.Size = new Size(90, 31);
            button1.TabIndex = 47;
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
            buttonSua.Location = new Point(178, 245);
            buttonSua.Name = "buttonSua";
            buttonSua.Padding = new Padding(20, 0, 0, 0);
            buttonSua.Size = new Size(117, 31);
            buttonSua.TabIndex = 46;
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
            buttonXoa.Location = new Point(108, 245);
            buttonXoa.Name = "buttonXoa";
            buttonXoa.Padding = new Padding(10, 0, 0, 0);
            buttonXoa.Size = new Size(64, 31);
            buttonXoa.TabIndex = 45;
            buttonXoa.Text = "Xóa";
            buttonXoa.TextAlign = ContentAlignment.TopLeft;
            buttonXoa.UseVisualStyleBackColor = false;
            buttonXoa.Click += buttonXoa_Click;
            // 
            // materialTextBox4
            // 
            materialTextBox4.AnimateReadOnly = false;
            materialTextBox4.BorderStyle = BorderStyle.None;
            materialTextBox4.Depth = 0;
            materialTextBox4.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox4.Hint = "Hàm lượng";
            materialTextBox4.LeadingIcon = null;
            materialTextBox4.Location = new Point(12, 174);
            materialTextBox4.MaxLength = 50;
            materialTextBox4.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox4.Multiline = false;
            materialTextBox4.Name = "materialTextBox4";
            materialTextBox4.Size = new Size(160, 50);
            materialTextBox4.TabIndex = 49;
            materialTextBox4.Text = "";
            materialTextBox4.TrailingIcon = null;
            // 
            // QLThuoc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(683, 620);
            Controls.Add(materialTextBox4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(buttonSua);
            Controls.Add(buttonXoa);
            Controls.Add(button8);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(numericUpDown);
            Controls.Add(materialTextBox3);
            Controls.Add(materialTextBox2);
            Controls.Add(materialTextBox1);
            Controls.Add(dataGridView);
            FormBorderStyle = FormBorderStyle.None;
            Name = "QLThuoc";
            Text = "QLThuoc";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox1;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox2;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox3;
        private NumericUpDown numericUpDown;
        private Label label2;
        private Label label3;
        private Button button8;
        private TextBox textBox2;
        private Button button2;
        private Button button1;
        private Button buttonSua;
        private Button buttonXoa;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox4;
    }
}