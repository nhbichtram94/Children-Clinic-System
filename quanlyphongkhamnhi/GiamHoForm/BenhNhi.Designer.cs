using MaterialSkin.Controls;

namespace quanlyphongkhamnhi.Forms
{
    partial class BenhNhi
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

        #region 

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        private GroupBox groupBox1;
        private Label labelHoTen;
        private Label labelNgaySinh;
        private TextBox txtHoTen;
        private DateTimePicker dtpNgaySinh;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox2;

        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            materialComboBox4 = new MaterialComboBox();
            materialComboBox3 = new MaterialComboBox();
            labelHoTen = new Label();
            txtHoTen = new TextBox();
            labelNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            materialComboBox2 = new MaterialComboBox();
            groupBox2 = new GroupBox();
            materialComboBox1 = new MaterialComboBox();
            materialTextBox7 = new MaterialTextBox();
            materialTextBox6 = new MaterialTextBox();
            materialTextBox5 = new MaterialTextBox();
            materialTextBox4 = new MaterialTextBox();
            materialTextBox3 = new MaterialTextBox();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            materialButton1 = new MaterialButton();
            materialButton2 = new MaterialButton();
            materialButton3 = new MaterialButton();
            materialButton4 = new MaterialButton();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.InactiveCaption;
            groupBox1.Controls.Add(materialComboBox4);
            groupBox1.Controls.Add(materialComboBox3);
            groupBox1.Controls.Add(labelHoTen);
            groupBox1.Controls.Add(txtHoTen);
            groupBox1.Controls.Add(labelNgaySinh);
            groupBox1.Controls.Add(dtpNgaySinh);
            groupBox1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(24, 41);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(440, 251);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "THÔNG TIN BỆNH NHI";
            // 
            // materialComboBox4
            // 
            materialComboBox4.AutoResize = false;
            materialComboBox4.BackColor = Color.FromArgb(255, 255, 255);
            materialComboBox4.Depth = 0;
            materialComboBox4.DrawMode = DrawMode.OwnerDrawVariable;
            materialComboBox4.DropDownHeight = 174;
            materialComboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            materialComboBox4.DropDownWidth = 121;
            materialComboBox4.Enabled = true;
            materialComboBox4.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialComboBox4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialComboBox4.FormattingEnabled = true;
            materialComboBox4.Hint = "Vai trò giám hộ";
            materialComboBox4.IntegralHeight = false;
            materialComboBox4.ItemHeight = 43;
            materialComboBox4.Location = new Point(149, 180);
            materialComboBox4.MaxDropDownItems = 4;
            materialComboBox4.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox4.Name = "materialComboBox4";
            materialComboBox4.Size = new Size(250, 49);
            materialComboBox4.StartIndex = 0;
            materialComboBox4.TabIndex = 6;
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
            materialComboBox3.Enabled = false;
            materialComboBox3.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialComboBox3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialComboBox3.FormattingEnabled = true;
            materialComboBox3.Hint = "Giới tính";
            materialComboBox3.IntegralHeight = false;
            materialComboBox3.ItemHeight = 43;
            materialComboBox3.Items.AddRange(new object[] { "Nam", "Nữ" });
            materialComboBox3.Location = new Point(149, 125);
            materialComboBox3.MaxDropDownItems = 4;
            materialComboBox3.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox3.Name = "materialComboBox3";
            materialComboBox3.Size = new Size(250, 49);
            materialComboBox3.StartIndex = 0;
            materialComboBox3.TabIndex = 5;
            // 
            // labelHoTen
            // 
            labelHoTen.AutoSize = true;
            labelHoTen.Location = new Point(20, 44);
            labelHoTen.Name = "labelHoTen";
            labelHoTen.Size = new Size(75, 25);
            labelHoTen.TabIndex = 0;
            labelHoTen.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            txtHoTen.Enabled = false;
            txtHoTen.Font = new Font("Segoe UI", 15.75F);
            txtHoTen.Location = new Point(149, 34);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(250, 35);
            txtHoTen.TabIndex = 1;
            // 
            // labelNgaySinh
            // 
            labelNgaySinh.AutoSize = true;
            labelNgaySinh.Location = new Point(20, 92);
            labelNgaySinh.Name = "labelNgaySinh";
            labelNgaySinh.Size = new Size(103, 25);
            labelNgaySinh.TabIndex = 2;
            labelNgaySinh.Text = "Ngày sinh:";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Enabled = false;
            dtpNgaySinh.Font = new Font("Segoe UI", 15.75F);
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(149, 84);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(250, 35);
            dtpNgaySinh.TabIndex = 3;
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
            materialComboBox2.IntegralHeight = false;
            materialComboBox2.ItemHeight = 43;
            materialComboBox2.Location = new Point(24, 298);
            materialComboBox2.MaxDropDownItems = 4;
            materialComboBox2.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox2.Name = "materialComboBox2";
            materialComboBox2.Size = new Size(440, 49);
            materialComboBox2.StartIndex = 0;
            materialComboBox2.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Gainsboro;
            groupBox2.Controls.Add(materialComboBox1);
            groupBox2.Controls.Add(materialTextBox7);
            groupBox2.Controls.Add(materialTextBox6);
            groupBox2.Controls.Add(materialTextBox5);
            groupBox2.Controls.Add(materialTextBox4);
            groupBox2.Controls.Add(materialTextBox3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(dateTimePicker1);
            groupBox2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(503, 41);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(440, 401);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "THÔNG TIN GIÁM HỘ";
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
            materialComboBox1.Hint = "Giới tính";
            materialComboBox1.IntegralHeight = false;
            materialComboBox1.ItemHeight = 43;
            materialComboBox1.Items.AddRange(new object[] { "Nam", "Nữ" });
            materialComboBox1.Location = new Point(20, 163);
            materialComboBox1.MaxDropDownItems = 4;
            materialComboBox1.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox1.Name = "materialComboBox1";
            materialComboBox1.Size = new Size(397, 49);
            materialComboBox1.StartIndex = 0;
            materialComboBox1.TabIndex = 10;
            // 
            // materialTextBox7
            // 
            materialTextBox7.AnimateReadOnly = false;
            materialTextBox7.BorderStyle = BorderStyle.None;
            materialTextBox7.Depth = 0;
            materialTextBox7.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox7.Hint = "Mật khẩu";
            materialTextBox7.LeadingIcon = null;
            materialTextBox7.Location = new Point(215, 331);
            materialTextBox7.MaxLength = 50;
            materialTextBox7.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox7.Multiline = false;
            materialTextBox7.Name = "materialTextBox7";
            materialTextBox7.Size = new Size(202, 50);
            materialTextBox7.TabIndex = 9;
            materialTextBox7.Text = "";
            materialTextBox7.TrailingIcon = null;
            // 
            // materialTextBox6
            // 
            materialTextBox6.AnimateReadOnly = false;
            materialTextBox6.BorderStyle = BorderStyle.None;
            materialTextBox6.Depth = 0;
            materialTextBox6.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox6.Hint = "Tên tài khoản";
            materialTextBox6.LeadingIcon = null;
            materialTextBox6.Location = new Point(20, 331);
            materialTextBox6.MaxLength = 50;
            materialTextBox6.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox6.Multiline = false;
            materialTextBox6.Name = "materialTextBox6";
            materialTextBox6.Size = new Size(189, 50);
            materialTextBox6.TabIndex = 8;
            materialTextBox6.Text = "";
            materialTextBox6.TrailingIcon = null;
            // 
            // materialTextBox5
            // 
            materialTextBox5.AnimateReadOnly = false;
            materialTextBox5.BorderStyle = BorderStyle.None;
            materialTextBox5.Depth = 0;
            materialTextBox5.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox5.Hint = "Địa chỉ";
            materialTextBox5.LeadingIcon = null;
            materialTextBox5.Location = new Point(20, 275);
            materialTextBox5.MaxLength = 50;
            materialTextBox5.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox5.Multiline = false;
            materialTextBox5.Name = "materialTextBox5";
            materialTextBox5.Size = new Size(397, 50);
            materialTextBox5.TabIndex = 7;
            materialTextBox5.Text = "";
            materialTextBox5.TrailingIcon = null;
            // 
            // materialTextBox4
            // 
            materialTextBox4.AnimateReadOnly = false;
            materialTextBox4.BorderStyle = BorderStyle.None;
            materialTextBox4.Depth = 0;
            materialTextBox4.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox4.Hint = "Số điện thoại";
            materialTextBox4.LeadingIcon = null;
            materialTextBox4.Location = new Point(20, 219);
            materialTextBox4.MaxLength = 50;
            materialTextBox4.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox4.Multiline = false;
            materialTextBox4.Name = "materialTextBox4";
            materialTextBox4.Size = new Size(397, 50);
            materialTextBox4.TabIndex = 6;
            materialTextBox4.Text = "";
            materialTextBox4.TrailingIcon = null;
            // 
            // materialTextBox3
            // 
            materialTextBox3.AnimateReadOnly = false;
            materialTextBox3.BorderStyle = BorderStyle.None;
            materialTextBox3.Depth = 0;
            materialTextBox3.Enabled = false;
            materialTextBox3.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox3.Hint = "Họ và tên";
            materialTextBox3.LeadingIcon = null;
            materialTextBox3.Location = new Point(20, 39);
            materialTextBox3.MaxLength = 50;
            materialTextBox3.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox3.Multiline = false;
            materialTextBox3.Name = "materialTextBox3";
            materialTextBox3.Size = new Size(397, 50);
            materialTextBox3.TabIndex = 5;
            materialTextBox3.Text = "";
            materialTextBox3.TrailingIcon = null;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 92);
            label2.Name = "label2";
            label2.Size = new Size(103, 25);
            label2.TabIndex = 2;
            label2.Text = "Ngày sinh:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Font = new Font("Segoe UI", 15.75F);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(20, 122);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(397, 35);
            dateTimePicker1.TabIndex = 3;
            // 
            // materialButton1
            // 
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(503, 451);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(87, 36);
            materialButton1.TabIndex = 6;
            materialButton1.Text = "Thay đổi";
            materialButton1.Type = MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += materialButton1_Click;
            // 
            // materialButton2
            // 
            materialButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton2.Density = MaterialButton.MaterialButtonDensity.Default;
            materialButton2.Depth = 0;
            materialButton2.HighEmphasis = true;
            materialButton2.Icon = null;
            materialButton2.Location = new Point(879, 451);
            materialButton2.Margin = new Padding(4, 6, 4, 6);
            materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton2.Name = "materialButton2";
            materialButton2.NoAccentTextColor = Color.Empty;
            materialButton2.Size = new Size(64, 36);
            materialButton2.TabIndex = 7;
            materialButton2.Text = "Lưu";
            materialButton2.Type = MaterialButton.MaterialButtonType.Contained;
            materialButton2.UseAccentColor = false;
            materialButton2.UseVisualStyleBackColor = true;
            materialButton2.Click += materialButton2_Click;
            // 
            // materialButton3
            // 
            materialButton3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton3.Density = MaterialButton.MaterialButtonDensity.Default;
            materialButton3.Depth = 0;
            materialButton3.HighEmphasis = true;
            materialButton3.Icon = null;
            materialButton3.Location = new Point(24, 356);
            materialButton3.Margin = new Padding(4, 6, 4, 6);
            materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton3.Name = "materialButton3";
            materialButton3.NoAccentTextColor = Color.Empty;
            materialButton3.Size = new Size(120, 36);
            materialButton3.TabIndex = 8;
            materialButton3.Text = "Bệnh nhi mới";
            materialButton3.Type = MaterialButton.MaterialButtonType.Contained;
            materialButton3.UseAccentColor = false;
            materialButton3.UseVisualStyleBackColor = true;
            materialButton3.Click += materialButton3_Click;
            // 
            // materialButton4
            // 
            materialButton4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton4.Density = MaterialButton.MaterialButtonDensity.Default;
            materialButton4.Depth = 0;
            materialButton4.HighEmphasis = true;
            materialButton4.Icon = null;
            materialButton4.Location = new Point(152, 356);
            materialButton4.Margin = new Padding(4, 6, 4, 6);
            materialButton4.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton4.Name = "materialButton4";
            materialButton4.NoAccentTextColor = Color.Empty;
            materialButton4.Size = new Size(95, 36);
            materialButton4.TabIndex = 9;
            materialButton4.Text = "Xác nhận";
            materialButton4.Type = MaterialButton.MaterialButtonType.Contained;
            materialButton4.UseAccentColor = false;
            materialButton4.UseVisualStyleBackColor = true;
            materialButton4.Visible = false;
            materialButton4.Click += materialButton4_Click;
            // 
            // BenhNhi
            // 
            BackColor = Color.SeaShell;
            ClientSize = new Size(968, 593);
            Controls.Add(materialButton4);
            Controls.Add(materialButton3);
            Controls.Add(materialButton2);
            Controls.Add(materialButton1);
            Controls.Add(groupBox2);
            Controls.Add(materialComboBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "BenhNhi";
            Text = "Thêm Bệnh Nhi";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox2;
        private DateTimePicker dateTimePicker1;
        private Label label2;
        private MaterialTextBox materialTextBox3;
        private MaterialTextBox materialTextBox5;
        private MaterialTextBox materialTextBox4;
        private MaterialTextBox materialTextBox7;
        private MaterialTextBox materialTextBox6;
        private MaterialButton materialButton1;
        private MaterialButton materialButton2;
        private MaterialComboBox materialComboBox1;
        private MaterialButton materialButton3;
        private MaterialButton materialButton4;
        private MaterialComboBox materialComboBox3;
        private MaterialComboBox materialComboBox4;
    }
}