using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DALPersonel
    {
        public static List<EntityPersonel> PersonelListesi()
        { 
            List<EntityPersonel> degerler = new List<EntityPersonel>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Personeller", Baglanti.bgl);
            
            //Bağlantı açık değilse bağlantı aç
            if (cmd.Connection.State != System.Data.ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonel ent = new EntityPersonel();
                ent.Id = int.Parse(dr["ID"].ToString());
                ent.Ad = dr["Ad"].ToString();
                ent.Soyad = dr["Soyad"].ToString();
                ent.Sehir = dr["Sehir"].ToString();
                ent.Gorev = dr["Gorev"].ToString();
                ent.Maas = short.Parse(dr["Maas"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }

        public static int PersonelEkle(EntityPersonel p)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Personeller (Ad,Soyad,Gorev,Sehir,Maas)" +
                                            "VALUES(@p1,@p2,@p3,@p4,@p5)",Baglanti.bgl);
            if (cmd.Connection.State != System.Data.ConnectionState.Open)
            { cmd.Connection.Open(); }

            cmd.Parameters.AddWithValue("@p1",p.Ad);
            cmd.Parameters.AddWithValue("@p2", p.Soyad);
            cmd.Parameters.AddWithValue("@p3", p.Gorev);
            cmd.Parameters.AddWithValue("@p4", p.Sehir);
            cmd.Parameters.AddWithValue("@p5", p.Maas);
            return cmd.ExecuteNonQuery();
        }

        public static bool PersonelSil(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Personeller WHERE ID=@p1",Baglanti.bgl);
            if (cmd.Connection.State != System.Data.ConnectionState.Open)
            { cmd.Connection.Open(); }
            cmd.Parameters.AddWithValue("@p1", id);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool PersonelGuncelle(EntityPersonel ent)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Personeller SET Ad=@p1,Soyad=@p2,Sehir=@p3,Gorev=@p4,Maas=@p5 WHERE ID=@p6", Baglanti.bgl);
            if (cmd.Connection.State != System.Data.ConnectionState.Open)
            { cmd.Connection.Open(); }
            cmd.Parameters.AddWithValue("@p1",ent.Ad);
            cmd.Parameters.AddWithValue("@p2", ent.Soyad);
            cmd.Parameters.AddWithValue("@p3", ent.Sehir);
            cmd.Parameters.AddWithValue("@p4", ent.Gorev);
            cmd.Parameters.AddWithValue("@p5", ent.Maas);
            cmd.Parameters.AddWithValue("@p6", ent.Id);
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
