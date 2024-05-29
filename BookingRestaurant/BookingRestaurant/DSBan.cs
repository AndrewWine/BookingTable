using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookingRestaurant
{
    public partial class DSBan : Form
    {

        public DSBan()
        {
            InitializeComponent();
        }
        public Account tk = new Account();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void NextID(int x)// ham truyen vao tham so cac ban`
        {

            GiaoDienBan Ban = new GiaoDienBan();
            Ban.DSBAN = new DatBan();
            Ban.tk = this.tk;
            Ban.DSBAN.TBID = x;

            Ban.ShowDialog();// sang form moi
        }
        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {

            NextID(1);//truyen tham so vao ham
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            NextID(2);
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            NextID(3);
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            NextID(4);
        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
            NextID(5);
        }

        private void radioButton6_Click(object sender, EventArgs e)
        {
            NextID(6);
        }

        private void tênTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strconnectstring = System.Configuration.ConfigurationSettings.AppSettings["MyConnectString"].ToString();
            string strCommand = "Select * from Account"  ;


            SqlConnection myConnection = new SqlConnection(strconnectstring);
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
            //thuc thi cau lenh xoa
            SqlDataReader dr = myCommand.ExecuteReader();

            
            //nhan du lieu ve data set
            myConnection.Close();
        }

        private void xemThôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HuyBan huyBan = new HuyBan();
            huyBan.tk = this.tk;
            
            huyBan.ShowDialog();
            
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DSBan_Load(object sender, EventArgs e)
        {

            lbDSBan.Parent = pictureBox2;
            lbDSBan.BackColor = Color.Transparent;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}