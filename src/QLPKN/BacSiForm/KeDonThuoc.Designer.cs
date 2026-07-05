namespace quanlyphongkhamnhi.Forms
{
    partial class KeDonThuoc
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
            cboHoSo = new MaterialSkin.Controls.MaterialComboBox();
            cboThuoc = new MaterialSkin.Controls.MaterialComboBox();
            txtName = new MaterialSkin.Controls.MaterialTextBox();
            txtSoLuong = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            txtThemThuoc = new MaterialSkin.Controls.MaterialButton();
            txtTaoDonKhac = new MaterialSkin.Controls.MaterialButton();
            groupBox1 = new GroupBox();
            txtCachDung = new MaterialSkin.Controls.MaterialTextBox();
            lstView1 = new MaterialSkin.Controls.MaterialListView();
            txtTonKho = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // cboHoSo
            // 
            cboHoSo.AutoResize = false;
            cboHoSo.BackColor = Color.FromArgb(255, 255, 255);
            cboHoSo.Depth = 0;
            cboHoSo.DrawMode = DrawMode.OwnerDrawVariable;
            cboHoSo.DropDownHeight = 174;
            cboHoSo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHoSo.DropDownWidth = 121;
            cboHoSo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cboHoSo.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cboHoSo.FormattingEnabled = true;
            cboHoSo.IntegralHeight = false;
            cboHoSo.ItemHeight = 43;
            cboHoSo.Location = new Point(245, 77);
            cboHoSo.MaxDropDownItems = 4;
            cboHoSo.MouseState = MaterialSkin.MouseState.OUT;
            cboHoSo.Name = "cboHoSo";
            cboHoSo.Size = new Size(507, 49);
            cboHoSo.StartIndex = 0;
            cboHoSo.TabIndex = 0;
            cboHoSo.SelectedIndexChanged += cboHoSo_SelectedIndexChanged;
            // 
            // cboThuoc
            // 
            cboThuoc.AutoResize = false;
            cboThuoc.BackColor = Color.FromArgb(255, 255, 255);
            cboThuoc.Depth = 0;
            cboThuoc.DrawMode = DrawMode.OwnerDrawVariable;
            cboThuoc.DropDownHeight = 174;
            cboThuoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboThuoc.DropDownWidth = 121;
            cboThuoc.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cboThuoc.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cboThuoc.FormattingEnabled = true;
            cboThuoc.IntegralHeight = false;
            cboThuoc.ItemHeight = 43;
            cboThuoc.Location = new Point(245, 220);
            cboThuoc.MaxDropDownItems = 4;
            cboThuoc.MouseState = MaterialSkin.MouseState.OUT;
            cboThuoc.Name = "cboThuoc";
            cboThuoc.Size = new Size(507, 49);
            cboThuoc.StartIndex = 0;
            cboThuoc.TabIndex = 1;
            cboThuoc.SelectedIndexChanged += cboThuoc_SelectedIndexChanged;
            // 
            // txtName
            // 
            txtName.AnimateReadOnly = false;
            txtName.BorderStyle = BorderStyle.None;
            txtName.Depth = 0;
            txtName.Enabled = false;
            txtName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtName.LeadingIcon = null;
            txtName.Location = new Point(245, 147);
            txtName.MaxLength = 50;
            txtName.MouseState = MaterialSkin.MouseState.OUT;
            txtName.Multiline = false;
            txtName.Name = "txtName";
            txtName.Size = new Size(507, 50);
            txtName.TabIndex = 2;
            txtName.Text = "";
            txtName.TrailingIcon = null;
            // 
            // txtSoLuong
            // 
            txtSoLuong.AnimateReadOnly = false;
            txtSoLuong.BorderStyle = BorderStyle.None;
            txtSoLuong.Depth = 0;
            txtSoLuong.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSoLuong.LeadingIcon = null;
            txtSoLuong.Location = new Point(520, 267);
            txtSoLuong.MaxLength = 50;
            txtSoLuong.MouseState = MaterialSkin.MouseState.OUT;
            txtSoLuong.Multiline = false;
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(194, 50);
            txtSoLuong.TabIndex = 3;
            txtSoLuong.Text = "";
            txtSoLuong.TrailingIcon = null;
            txtSoLuong.TextChanged += txtSoLuong_TextChanged;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(53, 92);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(44, 19);
            materialLabel1.TabIndex = 16;
            materialLabel1.Text = "Hồ Sơ";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(53, 150);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(101, 19);
            materialLabel2.TabIndex = 17;
            materialLabel2.Text = "Họ Tên Bác Sĩ";
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(91, 241);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(81, 19);
            materialLabel3.TabIndex = 18;
            materialLabel3.Text = "Loại Thuốc";
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(415, 287);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(70, 19);
            materialLabel4.TabIndex = 19;
            materialLabel4.Text = "Số Lượng";
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(55, 360);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(79, 19);
            materialLabel5.TabIndex = 20;
            materialLabel5.Text = "Cách Dùng";
            // 
            // txtThemThuoc
            // 
            txtThemThuoc.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            txtThemThuoc.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            txtThemThuoc.Depth = 0;
            txtThemThuoc.HighEmphasis = true;
            txtThemThuoc.Icon = null;
            txtThemThuoc.Location = new Point(599, 415);
            txtThemThuoc.Margin = new Padding(5);
            txtThemThuoc.MouseState = MaterialSkin.MouseState.HOVER;
            txtThemThuoc.Name = "txtThemThuoc";
            txtThemThuoc.NoAccentTextColor = Color.Empty;
            txtThemThuoc.Size = new Size(115, 36);
            txtThemThuoc.TabIndex = 22;
            txtThemThuoc.Text = "Thêm Thuốc";
            txtThemThuoc.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            txtThemThuoc.UseAccentColor = false;
            txtThemThuoc.UseVisualStyleBackColor = true;
            txtThemThuoc.Click += txtThemThuoc_Click;
            // 
            // txtTaoDonKhac
            // 
            txtTaoDonKhac.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            txtTaoDonKhac.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            txtTaoDonKhac.Depth = 0;
            txtTaoDonKhac.HighEmphasis = true;
            txtTaoDonKhac.Icon = null;
            txtTaoDonKhac.Location = new Point(399, 415);
            txtTaoDonKhac.Margin = new Padding(5);
            txtTaoDonKhac.MouseState = MaterialSkin.MouseState.HOVER;
            txtTaoDonKhac.Name = "txtTaoDonKhac";
            txtTaoDonKhac.NoAccentTextColor = Color.Empty;
            txtTaoDonKhac.Size = new Size(180, 36);
            txtTaoDonKhac.TabIndex = 23;
            txtTaoDonKhac.Text = "Tạo Đơn Thuốc Khác";
            txtTaoDonKhac.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            txtTaoDonKhac.UseAccentColor = false;
            txtTaoDonKhac.UseVisualStyleBackColor = true;
            txtTaoDonKhac.Click += txtTaoDonKhac_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(materialLabel6);
            groupBox1.Controls.Add(txtTonKho);
            groupBox1.Controls.Add(materialLabel5);
            groupBox1.Controls.Add(txtCachDung);
            groupBox1.Controls.Add(txtTaoDonKhac);
            groupBox1.Controls.Add(materialLabel2);
            groupBox1.Controls.Add(txtThemThuoc);
            groupBox1.Controls.Add(materialLabel1);
            groupBox1.Controls.Add(materialLabel4);
            groupBox1.Controls.Add(txtSoLuong);
            groupBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(38, 28);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(758, 517);
            groupBox1.TabIndex = 26;
            groupBox1.TabStop = false;
            groupBox1.Text = "Điền thông tin đơn thuốc";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // txtCachDung
            // 
            txtCachDung.AnimateReadOnly = false;
            txtCachDung.BorderStyle = BorderStyle.None;
            txtCachDung.Depth = 0;
            txtCachDung.Enabled = false;
            txtCachDung.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCachDung.LeadingIcon = null;
            txtCachDung.Location = new Point(207, 341);
            txtCachDung.MaxLength = 50;
            txtCachDung.MouseState = MaterialSkin.MouseState.OUT;
            txtCachDung.Multiline = false;
            txtCachDung.Name = "txtCachDung";
            txtCachDung.Size = new Size(507, 50);
            txtCachDung.TabIndex = 27;
            txtCachDung.Text = "";
            txtCachDung.TrailingIcon = null;
            // 
            // lstView1
            // 
            lstView1.AutoSizeTable = false;
            lstView1.BackColor = Color.FromArgb(255, 255, 255);
            lstView1.BorderStyle = BorderStyle.None;
            lstView1.Depth = 0;
            lstView1.FullRowSelect = true;
            lstView1.Location = new Point(838, 46);
            lstView1.MinimumSize = new Size(200, 100);
            lstView1.MouseLocation = new Point(-1, -1);
            lstView1.MouseState = MaterialSkin.MouseState.OUT;
            lstView1.Name = "lstView1";
            lstView1.OwnerDraw = true;
            lstView1.Size = new Size(250, 232);
            lstView1.TabIndex = 27;
            lstView1.UseCompatibleStateImageBehavior = false;
            lstView1.View = View.Details;
            // 
            // txtTonKho
            // 
            txtTonKho.AnimateReadOnly = false;
            txtTonKho.BorderStyle = BorderStyle.None;
            txtTonKho.Depth = 0;
            txtTonKho.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTonKho.LeadingIcon = null;
            txtTonKho.Location = new Point(207, 267);
            txtTonKho.MaxLength = 50;
            txtTonKho.MouseState = MaterialSkin.MouseState.OUT;
            txtTonKho.Multiline = false;
            txtTonKho.Name = "txtTonKho";
            txtTonKho.Size = new Size(157, 50);
            txtTonKho.TabIndex = 28;
            txtTonKho.Text = "";
            txtTonKho.TrailingIcon = null;
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel6.Location = new Point(55, 287);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(61, 19);
            materialLabel6.TabIndex = 29;
            materialLabel6.Text = "Tồn Kho";
            materialLabel6.Click += materialLabel6_Click;
            // 
            // KeDonThuoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1133, 788);
            Controls.Add(lstView1);
            Controls.Add(materialLabel3);
            Controls.Add(txtName);
            Controls.Add(cboThuoc);
            Controls.Add(cboHoSo);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "KeDonThuoc";
            Text = "KeDonThuoc";
            Load += KeDonThuoc_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox cboHoSo;
        private MaterialSkin.Controls.MaterialComboBox cboThuoc;
        private MaterialSkin.Controls.MaterialTextBox txtName;
        private MaterialSkin.Controls.MaterialTextBox txtSoLuong;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialButton txtThemThuoc;
        private MaterialSkin.Controls.MaterialButton txtTaoDonKhac;
        private GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialTextBox txtCachDung;
        private MaterialSkin.Controls.MaterialListView lstView1;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialTextBox txtTonKho;
    }
}