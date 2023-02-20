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

        public static int PersonelEkle(EntityPersonel p)
        {
            SqlCommand komut2 = new SqlCommand("insert into  Tbl_Bilgi (PersonelAd,PersonelSoyad,Gorev,Sehir,Maas) values (@p1,@p2,@p3,@p4,@p5) ", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@p1", p.Personelad);
            komut2.Parameters.AddWithValue("@p2", p.Personelsoyad);
            komut2.Parameters.AddWithValue("@p3", p.Gorev);
            komut2.Parameters.AddWithValue("@p4", p.Sehir);
            komut2.Parameters.AddWithValue("@p5", p.Maas);
     
            return komut2.ExecuteNonQuery();
            
        }

        public static bool PersonelSil(int p)
        {
            SqlCommand komut3 = new SqlCommand("Delete from Tbl_Bilgi where PersonelId=@p1", Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@p1", p);
            //yukarıdaki komutlar doğru bir şekilde çalışırsa
            //0 dan büyük yani 1 döndür oda true demek
            //calısmazsa 0 döndür yani false demek
            return komut3.ExecuteNonQuery()>0;

        }
    }
}
