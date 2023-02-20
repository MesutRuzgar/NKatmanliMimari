using EntityLayer;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            dataGridView1.DataSource= PerList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Personelad = tbxAd.Text;
            ent.Personelsoyad = tbxSoyad.Text;
            ent.Sehir=tbxSehir.Text;
            ent.Maas =int.Parse(tbxMaas.Text);
            ent.Gorev = tbxGorev.Text;
            LogicPersonel.LLPersonelEkle(ent);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Personelid = Convert.ToInt32(tbxId.Text);
            LogicPersonel.LLPersonelSil(ent.Personelid);
        }
    }
}
