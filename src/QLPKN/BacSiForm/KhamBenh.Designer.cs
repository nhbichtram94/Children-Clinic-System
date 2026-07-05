namespace quanlyphongkhamnhi.Forms
{
    partial class KhamBenh
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
            materialTextBox1 = new MaterialSkin.Controls.MaterialTextBox();
            materialTextBox2 = new MaterialSkin.Controls.MaterialTextBox();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            dateTimePicker = new DateTimePicker();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            materialTextBox3 = new MaterialSkin.Controls.MaterialTextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            txtTenKhoa = new MaterialSkin.Controls.MaterialMaskedTextBox();
            txtHoTenBenhNhan = new MaterialSkin.Controls.MaterialTextBox();
            cboPhieuKham = new MaterialSkin.Controls.MaterialComboBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // materialTextBox1
            // 
            materialTextBox1.AnimateReadOnly = false;
            materialTextBox1.BorderStyle = BorderStyle.None;
            materialTextBox1.Depth = 0;
            materialTextBox1.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox1.LeadingIcon = null;
            materialTextBox1.Location = new Point(191, 244);
            materialTextBox1.Margin = new Padding(3, 2, 3, 2);
            materialTextBox1.MaxLength = 50;
            materialTextBox1.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox1.Multiline = false;
            materialTextBox1.Name = "materialTextBox1";
            materialTextBox1.Size = new Size(500, 50);
            materialTextBox1.TabIndex = 3;
            materialTextBox1.Text = "";
            materialTextBox1.TrailingIcon = null;
            // 
            // materialTextBox2
            // 
            materialTextBox2.AnimateReadOnly = false;
            materialTextBox2.BorderStyle = BorderStyle.None;
            materialTextBox2.Depth = 0;
            materialTextBox2.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox2.LeadingIcon = null;
            materialTextBox2.Location = new Point(191, 308);
            materialTextBox2.Margin = new Padding(3, 2, 3, 2);
            materialTextBox2.MaxLength = 50;
            materialTextBox2.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox2.Multiline = false;
            materialTextBox2.Name = "materialTextBox2";
            materialTextBox2.Size = new Size(500, 50);
            materialTextBox2.TabIndex = 4;
            materialTextBox2.Text = "";
            materialTextBox2.TrailingIcon = null;
            // 
            // materialButton1
            // 
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(729, 110);
            materialButton1.Margin = new Padding(4);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(95, 36);
            materialButton1.TabIndex = 5;
            materialButton1.Text = "Lập Hồ Sơ";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += materialButton1_Click;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(55, 142);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(46, 19);
            materialLabel1.TabIndex = 9;
            materialLabel1.Text = "Bác Sĩ";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(55, 197);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(79, 19);
            materialLabel2.TabIndex = 10;
            materialLabel2.Text = "Bệnh Nhân";
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(55, 260);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(80, 19);
            materialLabel3.TabIndex = 11;
            materialLabel3.Text = "Chẩn Đoán";
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(55, 324);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(108, 19);
            materialLabel4.TabIndex = 12;
            materialLabel4.Text = "Hướng Điều Trị";
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(55, 385);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(95, 19);
            materialLabel5.TabIndex = 13;
            materialLabel5.Text = "Chuyên Khoa";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker.Location = new Point(191, 428);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(500, 33);
            dateTimePicker.TabIndex = 14;
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel6.Location = new Point(26, 344);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(69, 19);
            materialLabel6.TabIndex = 15;
            materialLabel6.Text = "Ngày Lập";
            // 
            // materialTextBox3
            // 
            materialTextBox3.AnimateReadOnly = false;
            materialTextBox3.BorderStyle = BorderStyle.None;
            materialTextBox3.Depth = 0;
            materialTextBox3.Enabled = false;
            materialTextBox3.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox3.LeadingIcon = null;
            materialTextBox3.Location = new Point(191, 128);
            materialTextBox3.Margin = new Padding(3, 2, 3, 2);
            materialTextBox3.MaxLength = 50;
            materialTextBox3.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox3.Multiline = false;
            materialTextBox3.Name = "materialTextBox3";
            materialTextBox3.Size = new Size(500, 50);
            materialTextBox3.TabIndex = 16;
            materialTextBox3.Text = "";
            materialTextBox3.TrailingIcon = null;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 192, 192);
            label1.Location = new Point(29, 46);
            label1.Name = "label1";
            label1.Size = new Size(290, 37);
            label1.TabIndex = 18;
            label1.Text = "TẠO HỒ SƠ BỆNH ÁN";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtTenKhoa);
            groupBox1.Controls.Add(txtHoTenBenhNhan);
            groupBox1.Controls.Add(materialLabel6);
            groupBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(29, 97);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(693, 399);
            groupBox1.TabIndex = 19;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nhập thông tin chi tiết";
            // 
            // txtTenKhoa
            // 
            txtTenKhoa.AllowPromptAsInput = true;
            txtTenKhoa.AnimateReadOnly = false;
            txtTenKhoa.AsciiOnly = false;
            txtTenKhoa.BackgroundImageLayout = ImageLayout.None;
            txtTenKhoa.BeepOnError = false;
            txtTenKhoa.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txtTenKhoa.Depth = 0;
            txtTenKhoa.Enabled = false;
            txtTenKhoa.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTenKhoa.HidePromptOnLeave = false;
            txtTenKhoa.HideSelection = true;
            txtTenKhoa.InsertKeyMode = InsertKeyMode.Default;
            txtTenKhoa.LeadingIcon = null;
            txtTenKhoa.Location = new Point(162, 266);
            txtTenKhoa.Mask = "";
            txtTenKhoa.MaxLength = 32767;
            txtTenKhoa.MouseState = MaterialSkin.MouseState.OUT;
            txtTenKhoa.Name = "txtTenKhoa";
            txtTenKhoa.PasswordChar = '\0';
            txtTenKhoa.PrefixSuffixText = null;
            txtTenKhoa.PromptChar = '_';
            txtTenKhoa.ReadOnly = false;
            txtTenKhoa.RejectInputOnFirstFailure = false;
            txtTenKhoa.ResetOnPrompt = true;
            txtTenKhoa.ResetOnSpace = true;
            txtTenKhoa.RightToLeft = RightToLeft.No;
            txtTenKhoa.SelectedText = "";
            txtTenKhoa.SelectionLength = 0;
            txtTenKhoa.SelectionStart = 0;
            txtTenKhoa.ShortcutsEnabled = true;
            txtTenKhoa.Size = new Size(500, 48);
            txtTenKhoa.SkipLiterals = true;
            txtTenKhoa.TabIndex = 22;
            txtTenKhoa.TabStop = false;
            txtTenKhoa.TextAlign = HorizontalAlignment.Left;
            txtTenKhoa.TextMaskFormat = MaskFormat.IncludeLiterals;
            txtTenKhoa.TrailingIcon = null;
            txtTenKhoa.UseSystemPasswordChar = false;
            txtTenKhoa.ValidatingType = null;
            // 
            // txtHoTenBenhNhan
            // 
            txtHoTenBenhNhan.AnimateReadOnly = false;
            txtHoTenBenhNhan.BorderStyle = BorderStyle.None;
            txtHoTenBenhNhan.Depth = 0;
            txtHoTenBenhNhan.Enabled = false;
            txtHoTenBenhNhan.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtHoTenBenhNhan.LeadingIcon = null;
            txtHoTenBenhNhan.Location = new Point(162, 90);
            txtHoTenBenhNhan.Margin = new Padding(3, 2, 3, 2);
            txtHoTenBenhNhan.MaxLength = 50;
            txtHoTenBenhNhan.MouseState = MaterialSkin.MouseState.OUT;
            txtHoTenBenhNhan.Multiline = false;
            txtHoTenBenhNhan.Name = "txtHoTenBenhNhan";
            txtHoTenBenhNhan.Size = new Size(500, 50);
            txtHoTenBenhNhan.TabIndex = 21;
            txtHoTenBenhNhan.Text = "";
            txtHoTenBenhNhan.TrailingIcon = null;
            // 
            // cboPhieuKham
            // 
            cboPhieuKham.AutoResize = false;
            cboPhieuKham.BackColor = Color.FromArgb(255, 255, 255);
            cboPhieuKham.Depth = 0;
            cboPhieuKham.DrawMode = DrawMode.OwnerDrawVariable;
            cboPhieuKham.DropDownHeight = 174;
            cboPhieuKham.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhieuKham.DropDownWidth = 121;
            cboPhieuKham.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cboPhieuKham.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cboPhieuKham.FormattingEnabled = true;
            cboPhieuKham.Hint = "Chọn phiếu khám";
            cboPhieuKham.IntegralHeight = false;
            cboPhieuKham.ItemHeight = 43;
            cboPhieuKham.Location = new Point(543, 46);
            cboPhieuKham.Margin = new Padding(3, 2, 3, 2);
            cboPhieuKham.MaxDropDownItems = 4;
            cboPhieuKham.MouseState = MaterialSkin.MouseState.OUT;
            cboPhieuKham.Name = "cboPhieuKham";
            cboPhieuKham.Size = new Size(179, 49);
            cboPhieuKham.StartIndex = 0;
            cboPhieuKham.TabIndex = 20;
            cboPhieuKham.SelectedIndexChanged += cboPhieuKham_SelectedIndexChanged;
            // 
            // KhamBenh
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1007, 591);
            Controls.Add(cboPhieuKham);
            Controls.Add(label1);
            Controls.Add(materialTextBox3);
            Controls.Add(dateTimePicker);
            Controls.Add(materialLabel5);
            Controls.Add(materialLabel4);
            Controls.Add(materialLabel3);
            Controls.Add(materialLabel2);
            Controls.Add(materialLabel1);
            Controls.Add(materialButton1);
            Controls.Add(materialTextBox2);
            Controls.Add(materialTextBox1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "KhamBenh";
            Text = "KhamBenh";
            Load += KhamBenh_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox1;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox2;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private DateTimePicker dateTimePicker;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox3;
        private Label label1;
        internal GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialComboBox cboPhieuKham;
        private MaterialSkin.Controls.MaterialTextBox txtHoTenBenhNhan;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtTenKhoa;
    }
}