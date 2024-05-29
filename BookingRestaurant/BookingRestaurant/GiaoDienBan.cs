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
    public partial class GiaoDienBan : Form
    {   /// <summary>
    /// bien bStatus co the de dc public
    /// bStatus = true  --> Bàn trống
    /// bStatus = false --> Bàn đã được đặt
    /// </summary>
        //Nhận thông tin từ form DSBan sang
        public DSBan currentDSBan;
        bool TrangThai;
        public Account tk = new Account();
        public GiaoDienBan()
        {
            InitializeComponent();
        }
  
        
        private void GiaoDienBan_Load(object sender, EventArgs e)
        {
            
            /*if (bStatus)
            {
                this.label5.Text = "Bàn trống";
            }
            else
            {
                this.label5.Text = "Bàn đã được đặt";
                if(this.currentDSBan != null)
                {
                    this.textBox2.Text = this.currentDSBan.ToString();
                }
            }*/
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            // Truyền bản ghi DSBan sang form hien tai
            ThucHienDatBan();
          
           
        }
        public DatBan DSBAN;// TAO DOI TUONG DSBAN DE LUU TRU TAM THOI CAC BIEN TU SQL
        private void ThucHienDatBan()
        {
            string strconnectstring = System.Configuration.ConfigurationSettings.AppSettings["MyConnectString"].ToString();
            string strCommand = "UPDATE DSban SET NameID = N'"+ this.tk.tenTaiKhoan.ToString() +"', TenNguoiDung = N'" + this.textBox2.Text + "', TimeBooking = '"
            + this.textBox3.Text.ToString() + "', Slot = "
            + this.textBox4.Text
            + ",Status = 1  WHERE TBID = " + DSBAN.TBID;
           
            this.Close();




            SqlConnection myConnection = new SqlConnection(strconnectstring);
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
            //thuc thi cau lenh xoa
            myCommand.ExecuteNonQuery();
            //nhan du lieu ve data set
            myConnection.Close();
        
          
           
        }

        private void GiaoDienBan_Load_1(object sender, EventArgs e)
        {
            string strconnectstring = System.Configuration.ConfigurationSettings.AppSettings["MyConnectString"].ToString();
            string strCommand = "Select * from DSban where TBID = " + DSBAN.TBID; 
           
            SqlConnection myConnection = new SqlConnection(strconnectstring);
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
            //thuc thi cau lenh xoa
            SqlDataReader dr = myCommand.ExecuteReader();
            label6.Text = tk.tenTaiKhoan;
            while (dr.Read())
            {
                TrangThai = bool.Parse(dr["Status"].ToString());
                textBox2.Text = dr["TenNguoiDung"].ToString();
                textBox3.Text = dr["TimeBooking"].ToString();
                textBox4.Text = dr["Slot"].ToString();
                
                if (dr["Status"].ToString() == "True")
                {
                    label5.Text = "Bàn đã được đặt";
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                }
             
            }


            label1.Parent = pictureBox1;
            label1.BackColor= Color.Transparent;

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;

            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;

            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;

            label5.Parent = pictureBox3;
            label5.BackColor = Color.Transparent;

            label6.Parent = pictureBox1;
            label6.BackColor = Color.Transparent;
            //nhan du lieu ve data set
            myConnection.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
