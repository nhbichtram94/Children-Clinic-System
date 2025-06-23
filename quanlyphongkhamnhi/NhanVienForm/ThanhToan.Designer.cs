namespace quanlyphongkhamnhi.Forms
{
    partial class ThanhToan
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
        private void InitializeComponent()
        {
            materialComboBox1 = new MaterialSkin.Controls.MaterialComboBox();
            materialComboBox3 = new MaterialSkin.Controls.MaterialComboBox();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            label1 = new Label();
            richTextBox1 = new RichTextBox();
            materialComboBox2 = new MaterialSkin.Controls.MaterialComboBox();
            materialButton2 = new MaterialSkin.Controls.MaterialButton();
            materialTextBox1 = new MaterialSkin.Controls.MaterialTextBox();
            label2 = new Label();
            printDialog1 = new PrintDialog();
            materialButton3 = new MaterialSkin.Controls.MaterialButton();
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
            materialComboBox1.Hint = "Hồ sơ bệnh án";
            materialComboBox1.IntegralHeight = false;
            materialComboBox1.ItemHeight = 43;
            materialComboBox1.Location = new Point(12, 88);
            materialComboBox1.MaxDropDownItems = 4;
            materialComboBox1.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox1.Name = "materialComboBox1";
            materialComboBox1.Size = new Size(372, 49);
            materialComboBox1.StartIndex = 0;
            materialComboBox1.TabIndex = 0;
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
            materialComboBox3.Hint = "Phương thức thanh toán";
            materialComboBox3.IntegralHeight = false;
            materialComboBox3.ItemHeight = 43;
            materialComboBox3.Location = new Point(12, 143);
            materialComboBox3.MaxDropDownItems = 4;
            materialComboBox3.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox3.Name = "materialComboBox3";
            materialComboBox3.Size = new Size(372, 49);
            materialComboBox3.StartIndex = 0;
            materialComboBox3.TabIndex = 3;
            // 
            // materialButton1
            // 
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.BackColor = Color.FromArgb(255, 192, 128);
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(13, 201);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(127, 36);
            materialButton1.TabIndex = 6;
            materialButton1.Text = "Xuất hóa đơn";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = false;
            materialButton1.Click += materialButton1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 192, 192);
            label1.Location = new Point(13, 12);
            label1.Name = "label1";
            label1.Size = new Size(397, 37);
            label1.TabIndex = 7;
            label1.Text = "XUẤT HÓA ĐƠN KHÁM BỆNH";
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.Location = new Point(471, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(508, 548);
            richTextBox1.TabIndex = 8;
            richTextBox1.Text = "";
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
            materialComboBox2.Hint = "Chọn hóa đơn";
            materialComboBox2.IntegralHeight = false;
            materialComboBox2.ItemHeight = 43;
            materialComboBox2.Location = new Point(12, 451);
            materialComboBox2.MaxDropDownItems = 4;
            materialComboBox2.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox2.Name = "materialComboBox2";
            materialComboBox2.Size = new Size(348, 49);
            materialComboBox2.StartIndex = 0;
            materialComboBox2.TabIndex = 9;
            // 
            // materialButton2
            // 
            materialButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton2.Depth = 0;
            materialButton2.HighEmphasis = true;
            materialButton2.Icon = null;
            materialButton2.Location = new Point(367, 520);
            materialButton2.Margin = new Padding(4, 6, 4, 6);
            materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton2.Name = "materialButton2";
            materialButton2.NoAccentTextColor = Color.Empty;
            materialButton2.Size = new Size(64, 36);
            materialButton2.TabIndex = 10;
            materialButton2.Text = "Tìm";
            materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton2.UseAccentColor = false;
            materialButton2.UseVisualStyleBackColor = true;
            materialButton2.Click += materialButton2_Click;
            // 
            // materialTextBox1
            // 
            materialTextBox1.AnimateReadOnly = false;
            materialTextBox1.BorderStyle = BorderStyle.None;
            materialTextBox1.Depth = 0;
            materialTextBox1.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox1.Hint = "Tìm kiếm hóa đơn (mã hóa đơn, mã hồ sơ,...)";
            materialTextBox1.LeadingIcon = null;
            materialTextBox1.Location = new Point(12, 506);
            materialTextBox1.MaxLength = 50;
            materialTextBox1.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox1.Multiline = false;
            materialTextBox1.Name = "materialTextBox1";
            materialTextBox1.Size = new Size(348, 50);
            materialTextBox1.TabIndex = 11;
            materialTextBox1.Text = "";
            materialTextBox1.TrailingIcon = null;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.MediumSeaGreen;
            label2.Location = new Point(11, 393);
            label2.Name = "label2";
            label2.Size = new Size(303, 37);
            label2.TabIndex = 12;
            label2.Text = "TRUY XUẤT HÓA ĐƠN";
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // materialButton3
            // 
            materialButton3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton3.Depth = 0;
            materialButton3.DialogResult = DialogResult.TryAgain;
            materialButton3.HighEmphasis = true;
            materialButton3.Icon = null;
            materialButton3.Location = new Point(280, 201);
            materialButton3.Margin = new Padding(4, 6, 4, 6);
            materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton3.Name = "materialButton3";
            materialButton3.NoAccentTextColor = Color.Empty;
            materialButton3.Size = new Size(104, 36);
            materialButton3.TabIndex = 13;
            materialButton3.Text = "In hóa đơn";
            materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton3.UseAccentColor = false;
            materialButton3.UseVisualStyleBackColor = true;
            materialButton3.Click += materialButton3_Click;
            // 
            // ThanhToan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(991, 620);
            Controls.Add(materialButton3);
            Controls.Add(label2);
            Controls.Add(materialTextBox1);
            Controls.Add(materialButton2);
            Controls.Add(materialComboBox2);
            Controls.Add(richTextBox1);
            Controls.Add(label1);
            Controls.Add(materialButton1);
            Controls.Add(materialComboBox3);
            Controls.Add(materialComboBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ThanhToan";
            Text = "s";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox materialComboBox1;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox3;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private Label label1;
        private RichTextBox richTextBox1;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox2;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox1;
        private Label label2;
        private PrintDialog printDialog1;
        private MaterialSkin.Controls.MaterialButton materialButton3;
    }
}