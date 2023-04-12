using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTNC_1
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            txtAcc.ForeColor = Color.LightGray; //set thuộc tính
            txtAcc.Text = "Tài khoản";
            this.txtAcc.Leave += new System.EventHandler(this.txtAcc_Leave);
            this.txtAcc.Enter += new System.EventHandler(this.txtAcc_Enter);

            txtPass.ForeColor = Color.LightGray;
            txtPass.Text = "Mật khẩu";
            this.txtPass.Leave += new System.EventHandler(this.txtPass_Leave);
            this.txtPass.Enter += new System.EventHandler(this.txtPass_Enter);
        }

//TK & PASS
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtAcc.Text == "thuvien" && txtPass.Text == "123456")
            {
                MessageBox.Show("Đăng nhập thành công!");
                this.Hide();
                FormQLTV qltv = new FormQLTV();
                qltv.ShowDialog();
                this.Close();
            }
            else if (txtAcc.Text == "Tài khoản" && txtPass.Text == "Mật khẩu")
            {
                MessageBox.Show("Hãy nhập thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

//QUENPASS
        private void btnForgot_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hãy liên hệ quản trị viên của bạn để lấy lại mật khẩu!", "NOTICE!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

//Thoát khỏi ứng dụng
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult y = MessageBox.Show("Bạn muốn thoát ứng dụng?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (y == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(50, 0, 0, 0);
        }


        private void txtAcc_Enter(object sender, EventArgs e)
        {
            if (txtAcc.Text == "Tài khoản")
            {
                txtAcc.Clear();
                txtAcc.ForeColor = Color.Black;
            }
        }

        private void txtAcc_Leave(object sender, EventArgs e)
        {
            if (txtAcc.Text == "")
            {
                txtAcc.Text = "Tài khoản";
                txtAcc.ForeColor = Color.LightGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Mật khẩu")
            {
                txtPass.Clear();
                txtPass.ForeColor = Color.Black;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Mật khẩu";
                txtPass.ForeColor = Color.LightGray;
            }
        }

        private void cbPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPass.Checked || txtPass.Text == "Mật khẩu")
                txtPass.PasswordChar = '\0';
            else
                txtPass.PasswordChar = '*';
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
            if (txtPass.Text == "Mật khẩu" || txtPass.Text == "")
            {
                txtPass.PasswordChar = '\0';
            }
        }
 //lỗi nhỏ - nhấn chọn trước thì không hiện mật khẩu!
    }
}