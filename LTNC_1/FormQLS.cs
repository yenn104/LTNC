using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LTNC_1
{
    public partial class FormQLS : Form
    {
        //kết nối
        static String connString = "Data Source=DESKTOP-07FFASP;Initial Catalog=Quanlysach;Integrated Security=True";
        //khai báo
        SqlConnection sqlconnection = new SqlConnection(connString);
        SqlCommand sqlcommand;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable datatable = new DataTable();

        // SqlConnection conn = new SqlConnection(connString);


        void loaddata()
        {
            sqlcommand = sqlconnection.CreateCommand();        //khởi tạo một cái xử lý kết nối 
            sqlcommand.CommandText = "SELECT * FROM INFO";        //lệnh thực thi câu truy vấn
                                                //  sqlcommand.ExecuteNonQuery(); //thực thi câu truy vấn
            adapter.SelectCommand = sqlcommand;
            datatable.Clear();
            adapter.Fill(datatable);
            dgvSach.DataSource = datatable;

        }



        public FormQLS()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*                        try
                                        {
                                            if (sqlconnection.State == ConnectionState.Closed)
                                                sqlconnection.Open();
                                            sqlcommand.CommandText = ("SELECT * FROM INFO"); //select database

                                            SqlDataReader reader = sqlcommand.ExecuteReader();
                                            DataTable dt = new DataTable();
                                            dt.Load(reader);
                                            dgvSach.DataSource = dt; 

                                            if (sqlconnection.State == ConnectionState.Open)
                                                sqlconnection.Close();
                                        }
                                    catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                        }   

                       


//            sqlconnection.ConnectionString = "Data Source=DESKTOP-07FFASP;Initial Catalog=Quanlysach;Integrated Security=True";
            sqlconnection.Open();
            String sql = "SELECT * FROM INFO";
            DataSet dataset = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlconnection);
            adapter.Fill(dataset);
            dgvSach.DataSource = dataset.Tables[0];
            dgvSach.Refresh();
        //  dgvSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSach.AutoResizeColumns();
            dgvSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvSach.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;*/
            sqlconnection = new SqlConnection(connString);
            sqlconnection.Open();
            loaddata();

            dgvSach.Refresh();
            //  dgvSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSach.AutoResizeColumns();
            dgvSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvSach.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }




        private void dgvSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          //  if (e.RowIndex == -1) return;
            int a = dgvSach.CurrentCell.RowIndex;
            txtMa.ReadOnly = true;
            txtMa.Text = dgvSach.Rows[a].Cells[0].Value.ToString();
            txtTen.Text = dgvSach.Rows[a].Cells[1].Value.ToString();
            txtTacgia.Text = dgvSach.Rows[a].Cells[2].Value.ToString();
            txtNxb.Text = dgvSach.Rows[a].Cells[3].Value.ToString();
            txtTheloai.Text = dgvSach.Rows[a].Cells[4].Value.ToString();
            txtSoluong.Text = dgvSach.Rows[a].Cells[5].Value.ToString();

            a = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {    
            try {  
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "INSERT INFO VALUES('"+txtMa.Text+"',N'"+txtTen.Text+"',N'"+txtTacgia.Text+"',N'"+txtNxb.Text+"',N'"+txtTheloai.Text+"',"+txtSoluong.Text+")";
                sqlcommand.ExecuteNonQuery();
                loaddata();

                //có thể tự tăng mã sách  mỗi khi tạo mới
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            sqlcommand = sqlconnection.CreateCommand();
            sqlcommand.CommandText = "DELETE FROM INFO WHERE MaSach = '"+txtMa.Text+"'";
            sqlcommand.ExecuteNonQuery();
            loaddata();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {   
            try
            {
            //thêm nếu mã = null thì hiện message.box " hãy chọn sách cần sửa" -- thêm trên xóa nữa
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "UPDATE INFO SET TenSach = N'"+txtTen.Text+"', TacGia = N'"+txtTacgia.Text+"', NXB = N'"+txtNxb.Text+"', TheLoai = N'"+txtTheloai.Text+"', SoLuong = "+txtSoluong.Text+" WHERE MaSach = '"+txtMa.Text+"';";
                sqlcommand.ExecuteNonQuery();
                loaddata();
            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn sách cần sửa!","ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //không thể sửa mã or mã đã có thì hiện là không thể sửa mã đã có
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            //có thể dùng test changed để không cần bấm tìm
            sqlcommand = sqlconnection.CreateCommand();            
            sqlcommand.CommandText = "SELECT * FROM INFO WHERE MaSach='" + txtSearch_Ma.Text + "' OR TenSach=N'" + txtSearch_Ten.Text + "'";
            adapter.SelectCommand = sqlcommand;
            datatable.Clear();
            adapter.Fill(datatable);
            dgvSach.DataSource = datatable;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMa.ReadOnly = false;
            txtMa.Text = "";
            txtTen.Text = "";
            txtTacgia.Text = "";
            txtNxb.Text = "";
            txtTheloai.Text = "";
            txtSoluong.Text = "";
        }

        private void txtSearch_Ten_TextChanged(object sender, EventArgs e)
        {
            sqlcommand = sqlconnection.CreateCommand();
            sqlcommand.CommandText = "SELECT* FROM INFO WHERE MaSach = '" + txtSearch_Ma.Text + "' OR TenSach Like N'%" + txtSearch_Ten.Text + "%'";
            adapter.SelectCommand = sqlcommand;
            datatable.Clear();
            adapter.Fill(datatable);
            dgvSach.DataSource = datatable;
        }

    }
}