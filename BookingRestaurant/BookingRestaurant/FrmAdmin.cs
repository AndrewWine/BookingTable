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

namespace BookingRestaurant
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }
        public Account tk = new Account();
        int TBID;
        public void change_button(int x)
        {
            try
            {
                string strConnectstring = System.Configuration.
                    ConfigurationSettings.
                    AppSettings["MyConnectString"].ToString();

                string strCommand = "Select * from DSban where TBID = N'" + x + "'";
                SqlConnection myConnection = new SqlConnection(strConnectstring);
                myConnection.Open();
                //MessageBox.Show("Ket noi co so du lieu thanh cong");
                SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
                SqlDataAdapter da = new SqlDataAdapter(myCommand);
                //Nhan du lieu ve data set
                DataSet ds = new DataSet();
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
        private void label1_Click(object sender, EventArgs e)
        {

        }

      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string strConnectstring = System.Configuration.ConfigurationSettings.AppSettings["MyConnectString"].ToString();

                string strCommand = "UPDATE DSban SET NameID = '', Timebooking = '', Slot = '', Status = 0, TenNguoiDung = '' where TBID = " + TBID;
                SqlConnection myConnection = new SqlConnection(strConnectstring);
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(strCommand, myConnection);
                cmd.ExecuteNonQuery();
                FrmAdmin_Load(sender, e);


                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Co loi" + ex.Message.ToString(), "Co loi");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                string strConnectstring = System.Configuration.
                    ConfigurationSettings.
                    AppSettings["MyConnectString"].ToString();

                string strCommand = "Select * from DSban ";
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

            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.Rows[e.RowIndex];
            if (dr != null)
            {
                this.TBID = int.Parse(dr.Cells[0].Value.ToString());
               
            }
        }
        private void button2_Click(object sender, EventArgs e)//ban 1
        {
            change_button(1);
        }
        private void button3_Click(object sender, EventArgs e)//ban2
        {
            change_button(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            change_button(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            change_button(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            change_button(5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            change_button(6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string strConnectstring = System.Configuration.
                    ConfigurationSettings.
                    AppSettings["MyConnectString"].ToString();

                string strCommand = "Select * from DSban ";
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

        private void button9_Click(object sender, EventArgs e)
        {
            GiaoDienBan Ban = new GiaoDienBan();
            Ban.DSBAN = new DatBan();
            Ban.tk = this.tk;
            Ban.DSBAN.TBID = TBID;
            Ban.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
    }
}
