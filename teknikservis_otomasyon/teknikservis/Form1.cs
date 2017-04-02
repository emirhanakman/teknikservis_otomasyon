using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace teknikservis
{
    public partial class Form1 : Form
    {
        public Form2 frm2;
        public Form1()
        {
         InitializeComponent();
         frm2 = new Form2();
         frm2.frm1 = this;
        }
        
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=database.mdb");
        DataTable tablo = new DataTable();
        OleDbCommand komut = new OleDbCommand();
        public void verigetir()
        {
            tablo.Clear();
            OleDbDataAdapter adptr = new OleDbDataAdapter("Select * From Musteri", baglan);
            adptr.Fill(tablo);
            dataGridView1.DataSource = tablo;

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtAdi.Focus();
            verigetir();
            dataGridView1.Columns[0].HeaderText = "Adı";
            dataGridView1.Columns[1].HeaderText = "Soyadı";
            dataGridView1.Columns[6].HeaderText = "Arıza";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = "INSERT INTO Musteri(Adi,Soyadi,Tel,Adres,Marka,Model,Ariza,Fiyat,Tarih) VALUES('" + txtAdi.Text + "','" + txtSoyadi.Text + "','" + txtTel.Text + "','" + txtAdres.Text + "','" + txtMarka.Text + "','" + txtModel.Text + "','" + txtArıza.Text + "','" + txtFiyat.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "')";
                komut.ExecuteNonQuery();
                baglan.Close();
                verigetir();
                MessageBox.Show("Kayıt Ekleme İşlemi Tamamlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }

            catch (Exception)
            {
                MessageBox.Show("Aynı Kayıt Tekrar Eklenemez!");
                baglan.Close();
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult cevap;
                cevap = MessageBox.Show("Kaydı Silmek İstediğinizden Eminmisiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (cevap == DialogResult.Yes)
                {
                    baglan.Open();
                    komut.Connection = baglan;
                    komut.CommandText = "Delete From Musteri Where Tel='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'";
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    verigetir();
                    MessageBox.Show("Silindi", "Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hata!","Uyarı");
            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            frm2.ShowDialog();
        }
    }
}
