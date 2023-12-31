﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Is_Takip_Proje.Entity;

namespace Is_Takip_Proje.Forms
{
    public partial class FormYeniGorev : Form
    {
        public FormYeniGorev()
        {
            InitializeComponent();
        }
        DbIsTakiipEntities db = new DbIsTakiipEntities();
        private void FormYeniGorev_Load(object sender, EventArgs e)
        {
            var gorevAlan = (from x in db.TblPersonel select new { x.ID, AdSoyad =  x.Ad + " " +  x.Soyad}).ToList();
            lookGorevAlan.Properties.ValueMember = "ID";
            lookGorevAlan.Properties.DisplayMember = "AdSoyad";
            lookGorevAlan.Properties.DataSource = gorevAlan;
            //yeni görev formu
        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TblGorevler t = new TblGorevler();

            t.GorevVeren = 1;
            t.GorevAlan = int.Parse(lookGorevAlan.EditValue.ToString());
            t.Aciklama = txtAciklama.Text;

            if (checkAktifGorev.Checked == true) {
                t.Durum = true;
            }
            else { t.Durum = false; };
            t.Tarih = DateTime.Parse(txtTarih.Text);

            db.TblGorevler.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Kayıt başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
