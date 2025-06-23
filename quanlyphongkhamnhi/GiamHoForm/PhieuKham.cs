using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;

namespace quanlyphongkhamnhi.Forms
{
    public partial class PhieuKham : Form
    {
        private PrintDocument printDocument = new PrintDocument();
        private string connString = "Data Source=LAPTOP-U184SQRH\\HHA;Initial Catalog=QLPKND;User ID=sa;Password=123"  ;

        public PhieuKham()
        {
            InitializeComponent();
            LoadPhieuKham();
            richTextBox.ReadOnly = true;
            richTextBox.Enabled = true;
            materialComboBox.SelectedIndexChanged += materialComboBox_SelectedIndexChanged;
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
        }

        public int? GetGiamHoIDFromUserID(int userID)
        {
            int? giamHoID = null;

            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT GiamHoID FROM GIAMHO WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);

                        var result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            giamHoID = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }

            return giamHoID;
        }

        private void LoadPhieuKham()
        {
            int userID = UserSession.UserID;

            // Lấy GiamHoID từ UserID
            int? giamHoID = GetGiamHoIDFromUserID(userID);

            if (giamHoID.HasValue)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();

                        string query = @"
                SELECT pk.PhieuKhamID, bn.HoTen AS BenhNhan
                FROM PHIEUKHAM pk
                JOIN BENHNHAN bn ON pk.BenhNhanID = bn.BenhNhanID
                JOIN GIAMHO gh ON pk.GiamHoID = gh.GiamHoID
                JOIN GIAMHO_BENHNHAN gbn ON gbn.BenhNhanID = bn.BenhNhanID
                WHERE gbn.GiamHoID = @GiamHoID
                ORDER BY pk.NgayKham DESC;
                ";

                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@GiamHoID", giamHoID.Value);

                            SqlDataReader reader = command.ExecuteReader();

                            materialComboBox.Items.Clear();

                            if (!reader.HasRows)
                            {
                                MessageBox.Show("Không có phiếu khám nào được tìm thấy.");
                            }

                            var comboBoxItems = new List<object>();

                            while (reader.Read())
                            {
                                int phieuKhamID = reader.GetInt32(reader.GetOrdinal("PhieuKhamID"));
                                string benhNhan = reader.GetString(reader.GetOrdinal("BenhNhan"));

                                string displayText = $"Mã: {phieuKhamID} - {benhNhan}";

                                comboBoxItems.Add(new { PhieuKhamID = phieuKhamID, DisplayText = displayText });
                            }

                            materialComboBox.DataSource = comboBoxItems;
                            materialComboBox.DisplayMember = "DisplayText";
                            materialComboBox.ValueMember = "PhieuKhamID";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải phiếu khám: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy Giám Hộ với UserID " + userID);
            }
        }

        private void HienThiPhieuKham(int phieuKhamID)
        {
            string query = "EXEC HienThiPhieuKham @PhieuKhamID = @PhieuKhamID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PhieuKhamID", phieuKhamID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string phieuKhamText = reader["PhieuKhamText"].ToString();

                        richTextBox.Clear();
                        richTextBox.Font = new Font("Courier New", 10);

                        string[] lines = phieuKhamText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

                        foreach (string line in lines)
                        {
                            richTextBox.AppendText(line.Replace("|", "\t") + Environment.NewLine);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phiếu khám.");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hiển thị phiếu khám: " + ex.Message);
                }
            }
        }

        private void materialComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialComboBox.SelectedItem != null)
            {
                var selectedItem = (dynamic)materialComboBox.SelectedItem;
                int phieuKhamID = selectedItem.PhieuKhamID;

                MessageBox.Show("Đang chọn phiếu khám ID: " + phieuKhamID);

                HienThiPhieuKham(phieuKhamID);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu khám.");
            }
        }

        //Sự kiện in phiếu
        private void materialButton1_Click(object sender, EventArgs e)
        {
            // Thực hiện lệnh in
            printDialog1.Document = printDocument;
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument.Print(); // Gửi lệnh in
            }
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            string textToPrint = richTextBox.Text; 

            Font printFont = new Font("Arial", 12);
            Brush printBrush = Brushes.Black;

            e.Graphics.DrawString(textToPrint, printFont, printBrush, e.MarginBounds.Left, e.MarginBounds.Top);

            e.HasMorePages = false;
        }
    }
}
