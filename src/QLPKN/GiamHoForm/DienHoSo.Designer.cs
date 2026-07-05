namespace quanlyphongkhamnhi.Forms
{
    partial class DienHoSo
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
            tabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            tabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            materialComboBox1 = new MaterialSkin.Controls.MaterialComboBox();
            diachiGH = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            textBoxGiamHoPhone = new MaterialSkin.Controls.MaterialTextBox();
            tbGiamHo = new MaterialSkin.Controls.MaterialTextBox();
            ngaysinhGH = new DateTimePicker();
            tabPage2 = new TabPage();
            materialComboBox3 = new MaterialSkin.Controls.MaterialComboBox();
            tbBenhNhan = new MaterialSkin.Controls.MaterialTextBox();
            dateTimePickerBenhNhan = new DateTimePicker();
            cbGioiTinh = new MaterialSkin.Controls.MaterialComboBox();
            buttonLuuBenhNhan = new MaterialSkin.Controls.MaterialButton();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabSelector1
            // 
            tabSelector1.BaseTabControl = tabControl1;
            tabSelector1.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            tabSelector1.Depth = 0;
            tabSelector1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            tabSelector1.Location = new Point(0, 0);
            tabSelector1.Margin = new Padding(0);
            tabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            tabSelector1.Name = "tabSelector1";
            tabSelector1.Size = new Size(991, 50);
            tabSelector1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Depth = 0;
            tabControl1.Location = new Point(0, 50);
            tabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(991, 570);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.WhiteSmoke;
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(materialComboBox1);
            tabPage1.Controls.Add(diachiGH);
            tabPage1.Controls.Add(textBoxGiamHoPhone);
            tabPage1.Controls.Add(tbGiamHo);
            tabPage1.Controls.Add(ngaysinhGH);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(983, 542);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Thông Tin Giám Hộ";
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
            materialComboBox1.Location = new Point(26, 145);
            materialComboBox1.MaxDropDownItems = 4;
            materialComboBox1.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox1.Name = "materialComboBox1";
            materialComboBox1.Size = new Size(350, 49);
            materialComboBox1.StartIndex = 0;
            materialComboBox1.TabIndex = 7;
            // 
            // diachiGH
            // 
            diachiGH.AnimateReadOnly = false;
            diachiGH.BackgroundImageLayout = ImageLayout.None;
            diachiGH.CharacterCasing = CharacterCasing.Normal;
            diachiGH.Depth = 0;
            diachiGH.HideSelection = true;
            diachiGH.Hint = "Địa chỉ";
            diachiGH.Location = new Point(26, 256);
            diachiGH.MaxLength = 32767;
            diachiGH.MouseState = MaterialSkin.MouseState.OUT;
            diachiGH.Name = "diachiGH";
            diachiGH.PasswordChar = '\0';
            diachiGH.ReadOnly = false;
            diachiGH.ScrollBars = ScrollBars.None;
            diachiGH.SelectedText = "";
            diachiGH.SelectionLength = 0;
            diachiGH.SelectionStart = 0;
            diachiGH.ShortcutsEnabled = true;
            diachiGH.Size = new Size(350, 100);
            diachiGH.TabIndex = 6;
            diachiGH.TabStop = false;
            diachiGH.TextAlign = HorizontalAlignment.Left;
            diachiGH.UseSystemPasswordChar = false;
            // 
            // textBoxGiamHoPhone
            // 
            textBoxGiamHoPhone.AnimateReadOnly = false;
            textBoxGiamHoPhone.BackColor = Color.FromArgb(255, 192, 192);
            textBoxGiamHoPhone.BorderStyle = BorderStyle.None;
            textBoxGiamHoPhone.Depth = 0;
            textBoxGiamHoPhone.Enabled = false;
            textBoxGiamHoPhone.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxGiamHoPhone.Hint = "Số điện thoại";
            textBoxGiamHoPhone.LeadingIcon = null;
            textBoxGiamHoPhone.Location = new Point(26, 200);
            textBoxGiamHoPhone.MaxLength = 50;
            textBoxGiamHoPhone.MouseState = MaterialSkin.MouseState.OUT;
            textBoxGiamHoPhone.Multiline = false;
            textBoxGiamHoPhone.Name = "textBoxGiamHoPhone";
            textBoxGiamHoPhone.Size = new Size(350, 50);
            textBoxGiamHoPhone.TabIndex = 0;
            textBoxGiamHoPhone.Text = "";
            textBoxGiamHoPhone.TrailingIcon = null;
            // 
            // tbGiamHo
            // 
            tbGiamHo.AnimateReadOnly = false;
            tbGiamHo.BackColor = Color.FromArgb(255, 192, 192);
            tbGiamHo.BorderStyle = BorderStyle.None;
            tbGiamHo.Depth = 0;
            tbGiamHo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbGiamHo.Hint = "Họ và Tên Giám Hộ";
            tbGiamHo.LeadingIcon = null;
            tbGiamHo.Location = new Point(26, 28);
            tbGiamHo.MaxLength = 100;
            tbGiamHo.MouseState = MaterialSkin.MouseState.OUT;
            tbGiamHo.Multiline = false;
            tbGiamHo.Name = "tbGiamHo";
            tbGiamHo.Size = new Size(350, 50);
            tbGiamHo.TabIndex = 1;
            tbGiamHo.Text = "";
            tbGiamHo.TrailingIcon = null;
            // 
            // ngaysinhGH
            // 
            ngaysinhGH.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ngaysinhGH.Location = new Point(26, 96);
            ngaysinhGH.Name = "ngaysinhGH";
            ngaysinhGH.Size = new Size(350, 33);
            ngaysinhGH.TabIndex = 2;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.WhiteSmoke;
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(materialComboBox3);
            tabPage2.Controls.Add(tbBenhNhan);
            tabPage2.Controls.Add(dateTimePickerBenhNhan);
            tabPage2.Controls.Add(cbGioiTinh);
            tabPage2.Controls.Add(buttonLuuBenhNhan);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(983, 542);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Thông Tin Bệnh Nhân";
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
            materialComboBox3.Hint = "Vai trò giám hộ";
            materialComboBox3.IntegralHeight = false;
            materialComboBox3.ItemHeight = 43;
            materialComboBox3.Items.AddRange(new object[] { "Cha", "Mẹ", "Người giám hộ" });
            materialComboBox3.Location = new Point(22, 196);
            materialComboBox3.MaxDropDownItems = 4;
            materialComboBox3.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox3.Name = "materialComboBox3";
            materialComboBox3.Size = new Size(350, 49);
            materialComboBox3.StartIndex = 0;
            materialComboBox3.TabIndex = 9;
            // 
            // tbBenhNhan
            // 
            tbBenhNhan.AnimateReadOnly = false;
            tbBenhNhan.BorderStyle = BorderStyle.None;
            tbBenhNhan.Depth = 0;
            tbBenhNhan.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbBenhNhan.Hint = "Họ và Tên Bệnh Nhân";
            tbBenhNhan.LeadingIcon = null;
            tbBenhNhan.Location = new Point(22, 20);
            tbBenhNhan.MaxLength = 100;
            tbBenhNhan.MouseState = MaterialSkin.MouseState.OUT;
            tbBenhNhan.Multiline = false;
            tbBenhNhan.Name = "tbBenhNhan";
            tbBenhNhan.Size = new Size(350, 50);
            tbBenhNhan.TabIndex = 0;
            tbBenhNhan.Text = "";
            tbBenhNhan.TrailingIcon = null;
            // 
            // dateTimePickerBenhNhan
            // 
            dateTimePickerBenhNhan.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerBenhNhan.Location = new Point(22, 89);
            dateTimePickerBenhNhan.Name = "dateTimePickerBenhNhan";
            dateTimePickerBenhNhan.Size = new Size(350, 33);
            dateTimePickerBenhNhan.TabIndex = 1;
            // 
            // cbGioiTinh
            // 
            cbGioiTinh.AutoResize = false;
            cbGioiTinh.BackColor = Color.FromArgb(255, 255, 255);
            cbGioiTinh.Depth = 0;
            cbGioiTinh.DrawMode = DrawMode.OwnerDrawVariable;
            cbGioiTinh.DropDownHeight = 174;
            cbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGioiTinh.DropDownWidth = 121;
            cbGioiTinh.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbGioiTinh.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbGioiTinh.FormattingEnabled = true;
            cbGioiTinh.Hint = "Giới tính";
            cbGioiTinh.IntegralHeight = false;
            cbGioiTinh.ItemHeight = 43;
            cbGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            cbGioiTinh.Location = new Point(22, 141);
            cbGioiTinh.MaxDropDownItems = 4;
            cbGioiTinh.MouseState = MaterialSkin.MouseState.OUT;
            cbGioiTinh.Name = "cbGioiTinh";
            cbGioiTinh.Size = new Size(350, 49);
            cbGioiTinh.StartIndex = 0;
            cbGioiTinh.TabIndex = 2;
            // 
            // buttonLuuBenhNhan
            // 
            buttonLuuBenhNhan.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonLuuBenhNhan.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonLuuBenhNhan.Depth = 0;
            buttonLuuBenhNhan.HighEmphasis = true;
            buttonLuuBenhNhan.Icon = null;
            buttonLuuBenhNhan.Location = new Point(22, 274);
            buttonLuuBenhNhan.Margin = new Padding(4, 6, 4, 6);
            buttonLuuBenhNhan.MouseState = MaterialSkin.MouseState.HOVER;
            buttonLuuBenhNhan.Name = "buttonLuuBenhNhan";
            buttonLuuBenhNhan.NoAccentTextColor = Color.Empty;
            buttonLuuBenhNhan.Size = new Size(95, 36);
            buttonLuuBenhNhan.TabIndex = 4;
            buttonLuuBenhNhan.Text = "Xác nhận";
            buttonLuuBenhNhan.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            buttonLuuBenhNhan.UseAccentColor = false;
            buttonLuuBenhNhan.Click += buttonLuuBenhNhan_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 359);
            label1.Name = "label1";
            label1.Size = new Size(655, 20);
            label1.TabIndex = 8;
            label1.Text = "(*) Chuyển đến trang thông tin 'Thông tin bệnh nhân' bên cạnh để tiếp tục điền thông tin bệnh nhi.\r\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(26, 379);
            label2.Name = "label2";
            label2.Size = new Size(452, 20);
            label2.TabIndex = 9;
            label2.Text = "(*) Hãy hoàn tất thông tin cá nhân để có thể đặt khám tại hệ thống.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(22, 248);
            label3.Name = "label3";
            label3.Size = new Size(380, 20);
            label3.TabIndex = 10;
            label3.Text = "(*) Nhấn xác nhận để hoàn tất. Có thể bắt đầu đặt khám.";
            // 
            // DienHoSo
            // 
            ClientSize = new Size(991, 620);
            Controls.Add(tabControl1);
            Controls.Add(tabSelector1);
            Name = "DienHoSo";
            Text = "Điền Hồ Sơ";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabSelector tabSelector1;
        private MaterialSkin.Controls.MaterialTabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MaterialSkin.Controls.MaterialTextBox textBoxGiamHoPhone;
        private MaterialSkin.Controls.MaterialTextBox tbGiamHo;
        private System.Windows.Forms.DateTimePicker ngaysinhGH;  // Sử dụng DateTimePicker cho Giám Hộ
        private MaterialSkin.Controls.MaterialTextBox tbBenhNhan;
        private System.Windows.Forms.DateTimePicker dateTimePickerBenhNhan;  // DateTimePicker cho Bệnh Nhân
        private MaterialSkin.Controls.MaterialComboBox cbGioiTinh;
        private MaterialSkin.Controls.MaterialButton buttonLuuBenhNhan;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox1;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 diachiGH;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox3;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}