using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALPersonel

    {
        public static List<EntityPersonel> PersonelListesi()
        {
            List<EntityPersonel> degerler = new List<EntityPersonel>();
            SqlCommand komut1 = new SqlCommand("Select * From Tbl_Bilgi",Baglanti.bgl);
            if (komut1.Connection.State!=ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonel ent = new EntityPersonel();
                ent.Personelid = int.Parse(dr["PersonelId"].ToString());
                ent.Personelad = dr["PersonelAd"].ToString();
                ent.Personelsoyad = dr["PersonelSoyad"].ToString() ;
                ent.Maas = int.Parse(dr["Maas"].ToString());
                ent.Gorev = dr["Gorev"].ToString();
                ent.Sehir = dr["Sehir"].ToString();
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }
    }
}
