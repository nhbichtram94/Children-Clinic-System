using System.Drawing.Printing;

namespace quanlyphongkhamnhi.Forms
{
    partial class PhieuKham
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
            materialComboBox = new MaterialSkin.Controls.MaterialComboBox();
            label3 = new Label();
            label1 = new Label();
            richTextBox = new RichTextBox();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            printDialog1 = new PrintDialog();
            SuspendLayout();
            // 
            // materialComboBox
            // 
            materialComboBox.AutoResize = false;
            materialComboBox.BackColor = Color.FromArgb(255, 255, 255);
            materialComboBox.Depth = 0;
            materialComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            materialComboBox.DropDownHeight = 174;
            materialComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            materialComboBox.DropDownWidth = 121;
            materialComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialComboBox.FormattingEnabled = true;
            materialComboBox.Hint = "Mã phiếu khám";
            materialComboBox.IntegralHeight = false;
            materialComboBox.ItemHeight = 43;
            materialComboBox.Location = new Point(12, 113);
            materialComboBox.MaxDropDownItems = 4;
            materialComboBox.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox.Name = "materialComboBox";
            materialComboBox.Size = new Size(380, 49);
            materialComboBox.StartIndex = 0;
            materialComboBox.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.LightSeaGreen;
            label3.Location = new Point(12, 39);
            label3.Name = "label3";
            label3.Size = new Size(166, 32);
            label3.TabIndex = 32;
            label3.Text = "PHIẾU KHÁM";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(12, 78);
            label1.Name = "label1";
            label1.Size = new Size(380, 21);
            label1.TabIndex = 33;
            label1.Text = "*Đưa phiếu khám bên cạnh cho nhân viên quầy khám";
            // 
            // richTextBox
            // 
            richTextBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox.Location = new Point(468, 28);
            richTextBox.Name = "richTextBox";
            richTextBox.Size = new Size(511, 295);
            richTextBox.TabIndex = 34;
            richTextBox.Text = "";
            // 
            // materialButton1
            // 
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(310, 171);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(82, 36);
            materialButton1.TabIndex = 35;
            materialButton1.Text = "In PHIẾU";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += materialButton1_Click;
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // PhieuKham
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(991, 620);
            Controls.Add(materialButton1);
            Controls.Add(richTextBox);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(materialComboBox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PhieuKham";
            Text = "PhieuKham";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox materialComboBox;
        private Label label3;
        private Label label1;
        private RichTextBox richTextBox;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private PrintDialog printDialog1;
    }
}