using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BookingRestaurant
{
    public partial class Dang_Nhap : Form
    {
        public Dang_Nhap()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        Modify modify = new Modify();
        Account tk = new Account(); 
        private void button1_Click(object sender, EventArgs e)
        {
            string strConnectstring = System.Configuration.ConfigurationSettings.AppSettings["MyConnectString"].ToString();
            string tentk = textBox1.Text;
            string matkhau = textBox2.Text;
            if(tentk.Trim() == "") { MessageBox.Show("Vui long nhap vao tai khoan"); }
            else if(matkhau.Trim() == "") { MessageBox.Show("Vui long nhap vao mat khau"); }
            else
            {

                string strCommand = " Select * from Account where taikhoan = '" + tentk + "' and matkhau = '" + matkhau + "'";
                SqlConnection conn = new SqlConnection(Connection.stringConnection);
                SqlCommand  cmd = new SqlCommand(strCommand, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);// lay thong tin tu sql ra tu dong chay lay data
                DataSet ds = new DataSet();//class trung gian hien tai dang trong'
                da.Fill(ds);
                
                if(modify.accounts(strCommand).Count !=0 ) 
                {
                    DSBan dSBan = new DSBan();
                    dSBan.FormClosed += delegate { this.Show(); };// formclosed khi dsBan bị đóng thì tất cả các hàm sau += delegate (dc đăng ký để chạy) sẽ chạy lại form ở đây là form đăng nhập
                    MessageBox.Show("Dang nhap thanh cong", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    tk.tenTaiKhoan = ds.Tables[0].Rows[0]["Taikhoan"].ToString();//cell tentaikhoan thuoc row 1 thuoc dong 1
                    tk.email = ds.Tables[0].Rows[0]["Email"].ToString();//code lay thong tin sql = c#
                    tk.sdt = ds.Tables[0].Rows[0]["SDT"].ToString();
                    dSBan.tk = this.tk;// lu tru = 1 ban tk khac y het
                    if (tentk.Equals("admin"))
                    {
                        FrmAdmin admin = new FrmAdmin();
                        admin.tk = this.tk;
                        admin.FormClosed += delegate { this.Show(); };
                        admin.ShowDialog();
                    }
                    else {
                        dSBan.ShowDialog();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Ten tai khoan hoac mat khau khong chinh xac");
                }
             

            }
          
        }

        private void Dang_Nhap_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;

            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dang_Ky dang_Ky = new Dang_Ky();
            this.Hide();

            dang_Ky.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
    

