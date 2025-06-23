namespace quanlyphongkhamnhi.Forms
{
    partial class DatKham
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
            materialComboBox1 = new MaterialSkin.Controls.MaterialComboBox();
            materialComboBox2 = new MaterialSkin.Controls.MaterialComboBox();
            label1 = new Label();
            dateTimePicker = new DateTimePicker();
            label3 = new Label();
            button1 = new Button();
            groupBox1 = new GroupBox();
            materialComboBox3 = new MaterialSkin.Controls.MaterialComboBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // materialComboBox1
            // 
            materialComboBox1.AutoResize = false;
            materialComboBox1.BackColor = Color.FromArgb(255, 255, 255);
            materialComboBox1.Depth = 0;
            materialComboBox1.DrawMode = DrawMode.OwnerDrawVariable;
            materialComboBox1.DropDownHeight = 174;
            materialComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            materialComboBox1.DropDownWidth = 121;
            materialComboBox1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialComboBox1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialComboBox1.FormattingEnabled = true;
            materialComboBox1.Hint = "Bệnh Nhi";
            materialComboBox1.IntegralHeight = false;
            materialComboBox1.ItemHeight = 43;
            materialComboBox1.Location = new Point(23, 47);
            materialComboBox1.MaxDropDownItems = 4;
            materialComboBox1.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox1.Name = "materialComboBox1";
            materialComboBox1.Size = new Size(283, 49);
            materialComboBox1.StartIndex = 0;
            materialComboBox1.TabIndex = 9;
            // 
            // materialComboBox2
            // 
            materialComboBox2.AutoResize = false;
            materialComboBox2.BackColor = Color.FromArgb(255, 255, 255);
            materialComboBox2.Depth = 0;
            materialComboBox2.DrawMode = DrawMode.OwnerDrawVariable;
            materialComboBox2.DropDownHeight = 174;
            materialComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            materialComboBox2.DropDownWidth = 121;
            materialComboBox2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialComboBox2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialComboBox2.FormattingEnabled = true;
            materialComboBox2.Hint = "Nhi Khoa Khám Bệnh";
            materialComboBox2.IntegralHeight = false;
            materialComboBox2.ItemHeight = 43;
            materialComboBox2.Location = new Point(23, 102);
            materialComboBox2.MaxDropDownItems = 4;
            materialComboBox2.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox2.Name = "materialComboBox2";
            materialComboBox2.Size = new Size(283, 49);
            materialComboBox2.StartIndex = 0;
            materialComboBox2.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 158);
            label1.Name = "label1";
            label1.Size = new Size(107, 25);
            label1.TabIndex = 12;
            label1.Text = "Ngày khám";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker.Location = new Point(23, 186);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(283, 33);
            dateTimePicker.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.LightSeaGreen;
            label3.Location = new Point(270, 28);
            label3.Name = "label3";
            label3.Size = new Size(453, 45);
            label3.TabIndex = 32;
            label3.Text = "ĐẶT KHÁM NHANH CHÓNG";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 192, 192);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(104, 303);
            button1.Name = "button1";
            button1.Padding = new Padding(10, 0, 0, 0);
            button1.Size = new Size(117, 33);
            button1.TabIndex = 48;
            button1.Text = "Xác nhận";
            button1.TextAlign = ContentAlignment.TopLeft;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Gainsboro;
            groupBox1.Controls.Add(materialComboBox3);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(materialComboBox1);
            groupBox1.Controls.Add(dateTimePicker);
            groupBox1.Controls.Add(materialComboBox2);
            groupBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(334, 150);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(326, 355);
            groupBox1.TabIndex = 50;
            groupBox1.TabStop = false;
            groupBox1.Text = "ĐIỀN THÔNG TIN";
            // 
            // materialComboBox3
            // 
            materialComboBox3.AutoResize = false;
            materialComboBox3.BackColor = Color.FromArgb(255, 255, 255);
            materialComboBox3.Depth = 0;
            materialComboBox3.DrawMode = DrawMode.OwnerDrawVariable;
            materialComboBox3.DropDownHeight = 174;
            materialComboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            materialComboBox3.DropDownWidth = 121;
            materialComboBox3.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialComboBox3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialComboBox3.FormattingEnabled = true;
            materialComboBox3.Hint = "Khung Giờ Khám";
            materialComboBox3.IntegralHeight = false;
            materialComboBox3.ItemHeight = 43;
            materialComboBox3.Location = new Point(23, 225);
            materialComboBox3.MaxDropDownItems = 4;
            materialComboBox3.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox3.Name = "materialComboBox3";
            materialComboBox3.Size = new Size(283, 49);
            materialComboBox3.StartIndex = 0;
            materialComboBox3.TabIndex = 51;
            // 
            // DatKham
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(991, 620);
            Controls.Add(label3);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DatKham";
            Text = "DatKham";
//            Load += DatKham_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox materialComboBox1;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox2;
        private Label label1;
        private DateTimePicker dateTimePicker;
        private Label label3;
        private Button button1;
        private GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox3;
    }
}