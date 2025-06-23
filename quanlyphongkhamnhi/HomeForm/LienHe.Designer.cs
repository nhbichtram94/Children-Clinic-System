namespace quanlyphongkhamnhi.Forms
{
    partial class LienHe
    {
        private System.ComponentModel.IContainer components = null;
        private MaterialSkin.Controls.MaterialTextBox textBoxName;
        private MaterialSkin.Controls.MaterialTextBox textBoxEmail;
        private MaterialSkin.Controls.MaterialButton buttonSend;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            textBoxName = new MaterialSkin.Controls.MaterialTextBox();
            textBoxEmail = new MaterialSkin.Controls.MaterialTextBox();
            buttonSend = new MaterialSkin.Controls.MaterialButton();
            labelClinicInfo = new MaterialSkin.Controls.MaterialLabel();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.AnimateReadOnly = false;
            textBoxName.BorderStyle = BorderStyle.None;
            textBoxName.Depth = 0;
            textBoxName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxName.Hint = "Họ và tên";
            textBoxName.LeadingIcon = null;
            textBoxName.Location = new Point(479, 148);
            textBoxName.MaxLength = 50;
            textBoxName.MouseState = MaterialSkin.MouseState.OUT;
            textBoxName.Multiline = false;
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(495, 50);
            textBoxName.TabIndex = 2;
            textBoxName.Text = "";
            textBoxName.TrailingIcon = null;
            // 
            // textBoxEmail
            // 
            textBoxEmail.AnimateReadOnly = false;
            textBoxEmail.BorderStyle = BorderStyle.None;
            textBoxEmail.Depth = 0;
            textBoxEmail.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxEmail.Hint = "Email";
            textBoxEmail.LeadingIcon = null;
            textBoxEmail.Location = new Point(479, 208);
            textBoxEmail.MaxLength = 50;
            textBoxEmail.MouseState = MaterialSkin.MouseState.OUT;
            textBoxEmail.Multiline = false;
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(495, 50);
            textBoxEmail.TabIndex = 3;
            textBoxEmail.Text = "";
            textBoxEmail.TrailingIcon = null;
            // 
            // buttonSend
            // 
            buttonSend.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonSend.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonSend.Depth = 0;
            buttonSend.HighEmphasis = true;
            buttonSend.Icon = null;
            buttonSend.Location = new Point(479, 262);
            buttonSend.Margin = new Padding(4, 6, 4, 6);
            buttonSend.MouseState = MaterialSkin.MouseState.HOVER;
            buttonSend.Name = "buttonSend";
            buttonSend.NoAccentTextColor = Color.Empty;
            buttonSend.Size = new Size(64, 36);
            buttonSend.TabIndex = 5;
            buttonSend.Text = "Gửi";
            buttonSend.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            buttonSend.UseAccentColor = true;
            // 
            // labelClinicInfo
            // 
            labelClinicInfo.Depth = 0;
            labelClinicInfo.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelClinicInfo.ForeColor = Color.DarkSlateGray;
            labelClinicInfo.Location = new Point(50, 120);
            labelClinicInfo.MouseState = MaterialSkin.MouseState.HOVER;
            labelClinicInfo.Name = "labelClinicInfo";
            labelClinicInfo.Size = new Size(400, 150);
            labelClinicInfo.TabIndex = 1;
            labelClinicInfo.Text = "Phòng Khám Nhi Đồng ABC\nĐịa chỉ: 123 Đường ABC, Quận XYZ, TP. HCM\nHotline: 1900 6767\nEmail: lienhe@phongkhamnhi.vn";
            labelClinicInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(50, 60);
            label1.Name = "label1";
            label1.Size = new Size(360, 47);
            label1.TabIndex = 6;
            label1.Text = "THÔNG TIN LIÊN HỆ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label2.ForeColor = Color.Teal;
            label2.Location = new Point(479, 75);
            label2.Name = "label2";
            label2.Size = new Size(513, 32);
            label2.TabIndex = 7;
            label2.Text = "ĐĂNG KÝ NHẬN THÔNG BÁO KHUYẾN MÃI";
            // 
            // LienHe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1007, 659);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labelClinicInfo);
            Controls.Add(textBoxName);
            Controls.Add(textBoxEmail);
            Controls.Add(buttonSend);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LienHe";
            Text = "Liên Hệ";
            ResumeLayout(false);
            PerformLayout();
        }

        private MaterialSkin.Controls.MaterialLabel labelClinicInfo;
        private Label label1;
        private Label label2;
    }
}
