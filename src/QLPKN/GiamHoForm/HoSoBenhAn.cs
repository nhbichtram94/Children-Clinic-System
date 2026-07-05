    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlyphongkhamnhi.Forms
{
    public partial class HoSoBenhAn : Form
    {
        private string connString = "Data Source=DESKTOP-35FGUEF;Initial Catalog=QLPKN;User ID=sa;Password=Tram@942004";
        private PrintDocument printDocument = new PrintDocument();

        public HoSoBenhAn()
        {
            InitializeComponent();
            LoadHoSoBenhAn();
            materialComboBox1.SelectedIndexChanged += materialComboBox1_SelectedIndexChanged;
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            string textToPrint = richTextBox1.Text;

            Font printFont = new Font("Arial", 12);
            Brush printBrush = Brushes.Black;

            e.Graphics.DrawString(textToPrint, printFont, printBrush, e.MarginBounds.Left, e.MarginBounds.Top);

            e.HasMorePages = false;
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

        private void LoadHoSoBenhAn()
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            HBA.HoSoID, 
                            BN.HoTen AS TenBenhNhan, 
                            HBA.ChuanDoan, 
                            FORMAT(HBA.NgayKham, 'dd/MM/yyyy HH:mm') AS NgayKham
                        FROM 
                            HOSOBENHAN HBA
                            JOIN BENHNHAN BN ON HBA.BenhNhanID = BN.BenhNhanID
                            JOIN GIAMHO_BENHNHAN GHB ON GHB.BenhNhanID = BN.BenhNhanID
                            JOIN GIAMHO GH ON GHB.GiamHoID = GH.GiamHoID
                        WHERE 
                            GH.UserID = @UserID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserID", UserSession.UserID);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        materialComboBox1.Items.Clear();

                        foreach (DataRow row in dataTable.Rows)
                        {
                            materialComboBox1.Items.Add(row["HoSoID"]);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hồ sơ bệnh án.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialComboBox1.SelectedItem != null)
            {
                // Lấy HoSoID từ giá trị được chọn
                int hoSoID = Convert.ToInt32(materialComboBox1.SelectedItem);
                HienThiHoSoBenhAn(hoSoID);
            }
        }

        private void HienThiHoSoBenhAn(int hoSoID)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("XemThongTinHoSo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@HoSoID", hoSoID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Lấy nội dung văn bản từ Stored Procedure
                        string hoSoText = reader["HoSoText"].ToString();

                        // Xóa nội dung cũ và thiết lập font monospace
                        richTextBox1.Clear();
                        richTextBox1.Font = new Font("Courier New", 10);

                        // Chia dòng dựa trên ký tự xuống dòng
                        string[] lines = hoSoText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                        foreach (string line in lines)
                        {
                            // Thêm từng dòng vào RichTextBox
                            richTextBox1.AppendText(line + Environment.NewLine);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin hồ sơ.");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hiển thị thông tin hồ sơ bệnh án: " + ex.Message);
                }
            }
        }

        
    }
}
