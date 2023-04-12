using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTNC_1
{
    public partial class FormQLTV : Form
    {
        //kết nối
        static String connString = "Data Source=DESKTOP-07FFASP;Initial Catalog=Quanlysach;Integrated Security=True";
        //khai báo
        SqlConnection sqlconnection = new SqlConnection(connString);
        SqlCommand sqlcommand;
//Mở kết nối
        private void Openconn()
        {
            if (sqlconnection == null)
            {
                sqlconnection = new SqlConnection(connString);
            }
            if (sqlconnection.State == ConnectionState.Closed)
            {
                sqlconnection.Open();
            }
        }
//Đóng kết nối
        private void Closeconn()
        {
            if (sqlconnection.State == ConnectionState.Open && sqlconnection != null)
            {
                sqlconnection.Close();
            }
        }

        public FormQLTV()
        {
            InitializeComponent();
        }
//Đăng xuất
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn đăng xuất khỏi tài khoản này!", "Thông báo !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                MessageBox.Show("Đăng xuất thành công!");
                this.Hide();
                FormLogin logout = new FormLogin();
                logout.ShowDialog();
                this.Close();
            }
        }
        //Hiển thị ds trong listview
        private void FormQLTV_Load(object sender, EventArgs e)
        {
            HienThiDanhSach1();
            HienThiDanhSach2();
            HienThiDanhSach3();
        }

        private void HienThiDanhSach1()
        {
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();     //khởi tạo 1 cái xử lý kết nối
                sqlcommand.CommandText = "SELECT * FROM INFO";
                SqlDataReader reader = sqlcommand.ExecuteReader();  //thực thi câu truy vấn
                listView1.Items.Clear();
                while (reader.Read())
                {
                    string MaSach = reader.GetString(0);
                    string TenSach = reader.GetString(1);
                    string TacGia = reader.GetString(2);
                    string NXB = reader.GetString(3);
                    string TheLoai = reader.GetString(4);
                    int SoLuong = reader.GetInt32(5);

                    ListViewItem lvi = new ListViewItem(MaSach);
                    //listView1.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                    lvi.SubItems.Add(TenSach);
                    lvi.SubItems.Add(TacGia);
                    lvi.SubItems.Add(NXB);
                    lvi.SubItems.Add(TheLoai);
                    lvi.SubItems.Add(SoLuong.ToString());
                    listView1.Items.Add(lvi);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HienThiDanhSach2()
        {
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "SELECT * FROM DOCGIA";
                SqlDataReader reader1 = sqlcommand.ExecuteReader();
                listView2.Items.Clear();
                while (reader1.Read())
                {
                    string ma1 = reader1.GetString(0);
                    string ten1 = reader1.GetString(1);
                    string diachi = reader1.GetString(2);
                    string gioitinh = reader1.GetString(3);
                    string sdt = reader1.GetString(4);

                    ListViewItem lvi = new ListViewItem(ma1);
                    lvi.SubItems.Add(ten1);
                    lvi.SubItems.Add(diachi);
                    lvi.SubItems.Add(gioitinh);
                    lvi.SubItems.Add(sdt);

                    listView2.Items.Add(lvi);
                }
                reader1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HienThiDanhSach3()
        {
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "SELECT * FROM QuanlyMT";
                //sqlcommand.Connection = sqlconnection;
                SqlDataReader reader2 = sqlcommand.ExecuteReader();
                listView3.Items.Clear();
                while (reader2.Read())
                {
                    string madg = reader2.GetString(0);
                    string masach = reader2.GetString(1);
                    int slg = reader2.GetInt32(2);
                    DateTime ngaymuon = reader2.GetDateTime(3);
                    DateTime ngaytra = reader2.GetDateTime(4);
                    string tinhtrang = reader2.GetString(5);

                    ListViewItem lvi = new ListViewItem(madg);
                    lvi.SubItems.Add(masach);
                    lvi.SubItems.Add(slg.ToString());
                    lvi.SubItems.Add(ngaymuon.ToString("MM/dd/yyyy"));
                    lvi.SubItems.Add(ngaytra.ToString("MM/dd/yyyy"));
                    lvi.SubItems.Add(tinhtrang);
                    listView3.Items.Add(lvi);
                }
                reader2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
//lấy và hiển thị thông tin cho button
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMa.ReadOnly = true;
            if (listView1.SelectedItems.Count == 0) return;
            ListViewItem lvi = listView1.SelectedItems[0];
            txtMa.Text = lvi.SubItems[0].Text;
            txtTen.Text = lvi.SubItems[1].Text;
            txtTacgia.Text = lvi.SubItems[2].Text;
            txtNxb.Text = lvi.SubItems[3].Text;
            txtTheloai.Text = lvi.SubItems[4].Text;
            txtSoluong.Text = lvi.SubItems[5].Text;
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaDocGia.ReadOnly = true;
            if (listView2.SelectedItems.Count == 0) return;
            ListViewItem lvi = listView2.SelectedItems[0];
            txtMaDocGia.Text = lvi.SubItems[0].Text;
            txtTenDocGia.Text = lvi.SubItems[1].Text;
            txtDiaChi.Text = lvi.SubItems[2].Text;
            cbxGioiTinh.Text = lvi.SubItems[3].Text;
            txtSDT.Text = lvi.SubItems[4].Text;
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaDG_MT.ReadOnly = true;
            txtMaSach_MT.ReadOnly = true;
            if (listView3.SelectedItems.Count == 0) return;
            ListViewItem lvi = listView3.SelectedItems[0];
            txtMaDG_MT.Text = lvi.SubItems[0].Text;
            txtMaSach_MT.Text = lvi.SubItems[1].Text;
            txtSL1.Text = lvi.SubItems[2].Text;
            dtpNgayM.Text = lvi.SubItems[3].Text;
            dtpNgayHen.Text = lvi.SubItems[4].Text;
            cbxTinhTrang.Text = lvi.SubItems[5].Text;
        }

//QUANLYSACH
        private void btnAddS_Click(object sender, EventArgs e)
        {
            try
            {
                Openconn();

                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "INSERT INFO VALUES('" + txtMa.Text + "',N'" + txtTen.Text + "',N'" + txtTacgia.Text + "',N'" + txtNxb.Text + "',N'" + txtTheloai.Text + "'," + txtSoluong.Text + ")";
                sqlcommand.Connection = sqlconnection;

                int kq = sqlcommand.ExecuteNonQuery();
                    if (kq > 0)
                        {
                            MessageBox.Show("Thêm thành công!");
                            HienThiDanhSach1();
                            txtMa.Clear();
                            txtTen.Clear();  
                            txtTacgia.Clear();
                            txtNxb.Clear();
                            txtTheloai.Clear();
                            txtSoluong.Clear();
                        }
                    else
                        {
                            MessageBox.Show("Thêm thất bại !");
                        }
            }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void btnDeleteS_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Bạn chưa chọn dữ liệu !");
                    return;
                }

           DialogResult kq = MessageBox.Show("Bạn có thật sự muốn xóa !", "Thông báo !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (kq == DialogResult.Yes)
                {
                    XoaDuLieu();
                }
        }

        private void XoaDuLieu()
        {
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "DELETE FROM INFO WHERE MaSach='" + txtMa.Text + "'";
                int kq = sqlcommand.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Xóa dữ liệu thành công !");         
                    HienThiDanhSach1();
                    txtMa.Clear();
                    txtTen.Clear();
                    txtSoluong.Clear();
                    txtTheloai.Clear();
                    txtTacgia.Clear();
                    txtNxb.Clear();
                }
                else
                {
                    MessageBox.Show("Xóa dữ liệu thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditS_Click(object sender, EventArgs e)
        {
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "UPDATE INFO SET  MaSach = '" + txtMa.Text + "',TenSach = N'" + txtTen.Text + "',TacGia = N'" + txtTacgia.Text + "',NXB= N'" + txtNxb.Text + "',TheLoai = N'" + txtTheloai.Text + "',SoLuong= " + txtSoluong.Text + " WHERE MaSach='" + txtMa.Text + "'";
                int kq = sqlcommand.ExecuteNonQuery();
                if (kq > 0)
                    {
                        MessageBox.Show("Cập nhật thành công !");
                        HienThiDanhSach1();
                        txtMa.Clear();
                        txtTen.Clear();
                        txtSoluong.Clear();
                        txtTacgia.Clear();
                        txtNxb.Clear();
                    }
                else
                    {
                        MessageBox.Show("Cập nhật thất bại !");
                    }
            }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void btnFindS_Click(object sender, EventArgs e)
        {
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "SELECT * FROM INFO WHERE MaSach='" + txtMaSach_F.Text + "'";
                SqlDataReader reader3 = sqlcommand.ExecuteReader();
                listView1.Items.Clear();
                if (reader3.Read())
                {
                    string MaSach = reader3.GetString(0);
                    string TenSach = reader3.GetString(1);
                    string TacGia = reader3.GetString(2);
                    string NXB = reader3.GetString(3);
                    string TheLoai = reader3.GetString(4);
                    int SoLuong = reader3.GetInt32(5);

                    ListViewItem lvi = new ListViewItem(MaSach);
                    lvi.SubItems.Add(TenSach);
                    lvi.SubItems.Add(TacGia);
                    lvi.SubItems.Add(NXB);
                    lvi.SubItems.Add(TheLoai);
                    lvi.SubItems.Add(SoLuong.ToString());
                    listView1.Items.Add(lvi);
                }
                reader3.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
//QUANLY DOCGIA
        private void btnAddDG_Click(object sender, EventArgs e)
        {
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "INSERT INTO DocGia Values ('" + txtMaDocGia.Text + "',N'" + txtTenDocGia.Text + "',N'" + txtDiaChi.Text + "' ,N'" + cbxGioiTinh.Text + "','" + txtSDT.Text + "')";
                int kq = sqlcommand.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                    HienThiDanhSach2();
                    HienThiDanhSach2();
                    txtMaDocGia.Clear();
                    txtTenDocGia.Clear();
                    txtDiaChi.Clear();
                    txtSDT.Clear();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteDG_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu !");
                return;
            }
            DialogResult kq = MessageBox.Show("Bạn có thật sự muốn xóa !", "Thông báo !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.Yes)
            {
                XoaDuLieu1();
            }
        }

        private void XoaDuLieu1()
        {
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "DELETE FROM DocGia WHERE MaDG='" + txtMaDocGia.Text + "'";
                int kq = sqlcommand.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Xóa thành công !");
                    HienThiDanhSach2();
                    txtMaDocGia.Clear();
                    txtTenDocGia.Clear();
                    txtDiaChi.Clear();
                    txtSDT.Clear();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại !");
                }
            }catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
        }

        private void btnEditDG_Click(object sender, EventArgs e)
        {
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "UPDATE DocGia SET  MaDG='" + txtMaDocGia.Text + "', TenDG=N'" + txtTenDocGia.Text + "' , DiaChi =N'" + txtDiaChi.Text + "' , GioiTinh=N'" + cbxGioiTinh.Text + "',SDT='" + txtSDT.Text + "' WHERE MaDG='" + txtMaDocGia.Text + "'";
                int kq = sqlcommand.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật thành công !");
                    HienThiDanhSach2();
                    txtMaDocGia.Clear();
                    txtTenDocGia.Clear();
                    txtDiaChi.Clear();
                    txtSDT.Clear();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFindDG_Click(object sender, EventArgs e)
        {
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "SELECT * FROM DocGia WHERE MaDG='" + txtMaDocGia.Text.Trim() + "'";
                SqlDataReader reader4 = sqlcommand.ExecuteReader();
                listView2.Items.Clear();
                if (reader4.Read())
                {
                    string ma1 = reader4.GetString(0);
                    string ten = reader4.GetString(1);
                    string diachi = reader4.GetString(2);
                    string gioitinh = reader4.GetString(3);
                    string sdt = reader4.GetString(4);

                    ListViewItem lvi = new ListViewItem(ma1);
                    lvi.SubItems.Add(ten);
                    lvi.SubItems.Add(diachi);
                    lvi.SubItems.Add(gioitinh);
                    lvi.SubItems.Add(sdt);
                    listView2.Items.Add(lvi);
                }
                reader4.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
//QUANLY MUONTRA
        private void btnAddMT_Click(object sender, EventArgs e)
        {
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "INSERT INTO QuanLyMT VALUES ('" + txtMaDG_MT.Text + "','" + txtMaSach_MT.Text + "' ,'" + txtSL1.Text + "','" + dtpNgayM.Text + "','" + dtpNgayHen.Text + "',N'" + cbxTinhTrang.Text + "')";
                int kq = sqlcommand.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                    HienThiDanhSach3();
                    txtMaDG_MT.Clear();
                    txtMaSach_MT.Clear();
                    txtSL1.Clear();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteMT_Click(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu !");
                return;
            }
            DialogResult kq = MessageBox.Show("Bạn có thật sự muốn xóa !", "Thông báo !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.Yes)
            {
                XoaDuLieu2();
            }
        }

        private void XoaDuLieu2()
        {
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "DELETE FROM QuanlyMT WHERE MaDG='" + txtMaDG_MT.Text + "' AND MaSach='" + txtMaSach_MT.Text + "'";         
                int kq = sqlcommand.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Xóa thành công !");
                    HienThiDanhSach3();
                    txtMaDG_MT.Clear();
                    txtMaSach_MT.Clear();
                    txtSL1.Clear();              
                }
                else
                {
                    MessageBox.Show("Xóa thất bại !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditMT_Click(object sender, EventArgs e)
        {
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "UPDATE QuanlyMT SET SoLuong='" + txtSL1.Text + "',NgayMuon='" + dtpNgayM.Text + "' , NgayTra='" + dtpNgayHen.Text + "' , TinhTrang=N'" + cbxTinhTrang.Text + "' WHERE MaDG='" + txtMaDG_MT.Text + "' AND MaSach='" + txtMaSach_MT.Text + "'";
                int kq = sqlcommand.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật thành công !");
                    HienThiDanhSach3();
                    txtMaDG_MT.Clear();
                    txtMaSach_MT.Clear();
                    txtSL1.Clear();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFind_MT_Click(object sender, EventArgs e)
        {
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "SELECT * FROM QuanlyMT WHERE MaDG='" + txtMaDG_FMT.Text + "'";
                SqlDataReader reader5 = sqlcommand.ExecuteReader();
                listView3.Items.Clear();
                if (reader5.Read())
                {
                    string MaDG_MT = reader5.GetString(0);
                    string MaSach_MT = reader5.GetString(1);
                    int slg = reader5.GetInt32(3);
                    DateTime ngaymuon = reader5.GetDateTime(4);
                    DateTime ngaytra = reader5.GetDateTime(5);
                    string tinhtrang = reader5.GetString(6);

                    ListViewItem lvi = new ListViewItem(MaDG_MT);
                    lvi.SubItems.Add(MaSach_MT);
                    lvi.SubItems.Add(slg.ToString());
                    lvi.SubItems.Add(ngaymuon.ToString("MM/dd/yyyy"));
                    lvi.SubItems.Add(ngaytra.ToString("MM/dd/yyyy"));
                    lvi.SubItems.Add(tinhtrang);
                    listView3.Items.Add(lvi);
                }
                reader5.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
//btnRefresh
        private void btnRefresh_MT_Click(object sender, EventArgs e)
        {
            txtMaDG_MT.ReadOnly = false;
            txtMaSach_MT.ReadOnly = false;
            txtMaDG_MT.Text = "";
            txtMaSach_MT.Text = "";
            txtSL1.Text = "";
            dtpNgayM.Text = "";
            dtpNgayHen.Text = "";
            cbxTinhTrang.Text = "";
            txtMaDG_FMT.Text = ""; 
            HienThiDanhSach3();
        }

        private void btnRefresh_DG_Click(object sender, EventArgs e)
        {
            txtMaDocGia.ReadOnly = false;
            txtMaDocGia.Text = "";
            txtTenDocGia.Text = "";
            txtDiaChi.Text = "";
            cbxGioiTinh.Text = "";
            txtSDT.Text = "";
            txtMaDG_F.Text = "";
            HienThiDanhSach2();
        }

        private void btnRefresh_F_Click(object sender, EventArgs e)
        {
            txtMa.ReadOnly = false;
            txtMa.Text = "";
            txtTen.Text = "";
            txtTacgia.Text = "";
            txtNxb.Text = "";
            txtTheloai.Text = "";
            txtSoluong.Text = "";
            txtMaSach_F.Text = "";
            HienThiDanhSach1();
        }

    }
}
