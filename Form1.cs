using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using DataAccessLayer;
using LogicLayerr;

namespace NKatmanliMimari
{
    public partial class Form1 : Form
    {
        public Form1()

        {
            InitializeComponent();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            List<EntityPersonel> PerList = LogicPersonel.LLPersonelListesi();
            dataGridView1.DataSource = PerList;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                EntityPersonel ent = new EntityPersonel();
                ent.Ad = txtAd.Text;
                ent.Soyad = txtSoyad.Text;
                ent.Sehir = txtSehir.Text;
                ent.Maas = short.Parse(txtMaas.Text);
                ent.Gorev = txtGorev.Text;
                int result = LogicPersonel.LLPersonelEkle(ent);

                if (result > 0)
                {
                    MessageBox.Show("Personel başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Personel eklenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int personelId = Convert.ToInt32(txtId.Text);
                bool result = LogicPersonel.LLPersonelSil(personelId);

                if (result)
                {
                    MessageBox.Show("Personel başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Personel silinirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            
            try
            {
                EntityPersonel ent = new EntityPersonel();
                ent.Id = Convert.ToInt32(txtId.Text);
                ent.Ad = txtAd.Text;
                ent.Soyad = txtSoyad.Text;
                ent.Sehir = txtSehir.Text;
                ent.Gorev = txtGorev.Text;
                ent.Maas = short.Parse(txtMaas.Text);
                bool result = LogicPersonel.LLPersonelGuncelle(ent);

                if (result )
                {
                    MessageBox.Show("Personel başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Personel güncellenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
     
        }

    }
}
