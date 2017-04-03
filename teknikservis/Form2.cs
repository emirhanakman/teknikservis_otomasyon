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
    public partial class Form2 : Form
    {
        public Form1 frm1;
        public Form2()
        {
            InitializeComponent();
        }
        
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=database.mdb");
        OleDbCommand komut = new OleDbCommand();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = "update Musteri set Adi='" + txtAdi.Text + "',Soyadi='" + txtSoyadi.Text + "',Tel='" + txtTel.Text + "',Adres='" + txtAdres.Text + "',Marka='" + txtMarka.Text + "',Model='" + txtModel.Text + "',Ariza='" + txtArıza.Text + "',Fiyat='" + txtFiyat.Text + "',Tarih='" + dateTimePicker1.Value + "' WHERE Tel='" + frm1.dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'";
                komut.ExecuteNonQuery();
                baglan.Close();
                frm1.verigetir();
                MessageBox.Show("Güncelleme İşlemi Tamamlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Güncelleme Yapılamadı","Uyarı");
            }
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                txtAdi.Text = frm1.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtSoyadi.Text = frm1.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtTel.Text = frm1.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtAdres.Text = frm1.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtMarka.Text = frm1.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtModel.Text = frm1.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtArıza.Text = frm1.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtFiyat.Text = frm1.dataGridView1.CurrentRow.Cells[7].Value.ToString();
                dateTimePicker1.Text = frm1.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Boş Kayıt Güncellenemez!","Uyarı");
            }
         
            
        }
    }
}
