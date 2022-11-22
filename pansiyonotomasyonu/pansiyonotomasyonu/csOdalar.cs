using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace pansiyonotomasyonu
{
    class csOdalar
    {
        DataBase db = new DataBase();
        public DataTable tablola()
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand veriAl = new SqlCommand("select * from odalar", db.baglanti);
                SqlDataAdapter adaptor = new SqlDataAdapter(veriAl);
                DataTable tablo = new DataTable();
                adaptor.Fill(tablo);
                return tablo;
            }
            catch { return null; }
            finally
            {
                db.baglanti.Close();
            }
        }
        public void odaGuncelle(int id,string musteri,string durum)
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand guncelle = new SqlCommand("update odalar set odayiAlan=@odayiAlan, durumu=@durumu where id=@id", db.baglanti);
                guncelle.Parameters.AddWithValue("@odayiAlan", musteri);
                guncelle.Parameters.AddWithValue("@durumu", durum);
                guncelle.Parameters.AddWithValue("@id", id);
                guncelle.ExecuteNonQuery();
            }
            catch { }
            finally
            {
                db.baglanti.Close();
            }
        }
    }
}
