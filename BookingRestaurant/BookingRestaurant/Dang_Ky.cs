using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookingRestaurant
{
    public partial class Dang_Ky : Form
    {
        public Dang_Ky()
        {
            InitializeComponent();
        }
        public bool checkAccount(string ac)//check mk va tk
        {
            return Regex.IsMatch(ac,"^[a-zA-Z0-9]{6,24}$");
        }
        public bool checkEmail (string em)
        {
            return Regex.IsMatch(em, @"^[a-zA-Z0-9_.]{3,20}@gmail.com(.vn|)$");
        }
        public bool checkSDT (string sdt)
        {
            return Regex.IsMatch(sdt, @"^[0-9_.]{3,12}$");
        }
        Modify modify= new Modify();
        private void button1_Click(object sender, EventArgs e)
        {
            string tentk = textBox1.Text;
            string matkhau = textBox2.Text;
            string xnmatkhau = textBox3.Text;
            string email  = textBox4.Text;
            string sdt = textBox5.Text;
            if(!checkAccount(tentk)) { MessageBox.Show("Vui lòng nhập tên tài khoản từ 6-24 ký tự, bao gồm chữ số và chữ in hoa"); return; }
            if(!checkAccount(matkhau)) { MessageBox.Show("Vui lòng nhập mật khẩu từ 6-24 ký tự, bao gồm chữ số và chữ in hoa"); return; }
            if(xnmatkhau != matkhau) { MessageBox.Show("Vui lòng nhập lại đúng mật khẩu đã nhập"); return; }
            if(!checkEmail(email)) { MessageBox.Show("Vui lòng nhập đúng định dạng email "); return; }
            if (!checkSDT(sdt)) { MessageBox.Show("Vui lòng nhập đúng số điện thoại"); return; }

            if (modify.accounts("Select * from Account where Email = '" + email + "'").Count != 0) { MessageBox.Show("Email này đã được dùng");}
           try
            {
                string query = "Insert into Account values ('" + tentk + "','" + matkhau + "','" + email + "','" + sdt +"')";
                modify.Command(query);
                if(MessageBox.Show("Đăng ký thành công! Bạn có muốn đăng nhập luôn không?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    
                    Dang_Nhap dang_Nhap = new Dang_Nhap();
                    this.Hide();
                    dang_Nhap.ShowDialog();
                   
                }    
            }
            catch
            {
                MessageBox.Show("Tên tài khoản đã được đăng ký! Vui lòng đăng ký tên tài khoản khác"); 
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Dang_Ky_Load(object sender, EventArgs e)
        {
            label6.Parent = pictureBox1;
            label6.BackColor = Color.Transparent;

            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;

            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;

            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;

            label5.Parent = pictureBox1;
            label5.BackColor = Color.Transparent;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
