using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookingRestaurant
{
    public partial class HuyBan : Form
    {
        public HuyBan()
        {
            InitializeComponent();
        }
        public Account tk  = new Account();
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void HuyBan_Load(object sender, EventArgs e)
        {
            label4.Text = tk.tenTaiKhoan;
            label5.Text = tk.email;
            label7.Text = tk.sdt;

            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;

            label5.Parent = pictureBox1;
            label5.BackColor = Color.Transparent;

            label7.Parent = pictureBox1;
            label7.BackColor = Color.Transparent;

            label8.Parent = pictureBox1;
            label8.BackColor = Color.Transparent;


            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;


            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;


            label6.Parent = pictureBox1;
            label6.BackColor = Color.Transparent;


            label3.Parent = pictureBox2;
            label3.BackColor = Color.Transparent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        int TBID;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string strConnectstring = System.Configuration.
                    ConfigurationSettings.
                    AppSettings["MyConnectString"].ToString();

                string strCommand = "UPDATE DSban SET NameID = '', Timebooking = '', Slot = 0, Status = 0, TenNguoiDung = '' where TBID = " + TBID ;
                SqlConnection myConnection = new SqlConnection(strConnectstring);
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(strCommand,myConnection);
                cmd.ExecuteNonQuery();
                button3_Click(sender, e);
            
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Co loi" + ex.Message.ToString(), "Co loi");
            }
        }
     

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string strConnectstring = System.Configuration.
                    ConfigurationSettings.
                    AppSettings["MyConnectString"].ToString(); 

                string strCommand = "Select * from DSban where NameID = N'" + tk.tenTaiKhoan +"'" ;
                SqlConnection myConnection = new SqlConnection(strConnectstring);
                myConnection.Open();
                //MessageBox.Show("Ket noi co so du lieu thanh cong");
                SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
                SqlDataAdapter da = new SqlDataAdapter(myCommand);
                //Nhan du lieu ve data set
                DataSet ds = new DataSet();
            
                //Dataset ds chỉ khai báo biến ds, biến này mặc định là null
                //gọi hàm tạo của class dataset xong gán nó vào ds
               
                da.Fill(ds, "Account");
                //dua du lieu vao dataview
                this.dataGridView1.DataSource = ds;
                this.dataGridView1.DataMember = "Account";
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Co loi" + ex.Message.ToString(), "Co loi");
            }
        }
       private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.Rows[e.RowIndex];
            if(dr != null)
            {
                this.TBID = int.Parse(dr.Cells[0].Value.ToString());
                
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
