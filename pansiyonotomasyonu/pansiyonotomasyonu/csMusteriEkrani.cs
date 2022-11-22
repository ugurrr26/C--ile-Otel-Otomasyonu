using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace pansiyonotomasyonu
{
    class csMusteriEkrani
    {
        DataBase db = new DataBase();
        public string guncelleDurum { get; set; }
        public string silDurum { get; set; }
        public DataTable tablola()
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand veriAl = new SqlCommand("select * from musteriler", db.baglanti);
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
        public void musteriGuncelle(int id,string adi, string soyadi, string cinsiyet, string telefonNo, string mail, string tcNo, string odaAdi, string ucret, DateTime giris, DateTime cikis)
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand guncelle = new SqlCommand("update musteriler set adi=@adi, soyadi=@soyadi, cinsiyet=@cinsiyet, telefon=@telefon, mail=@mail, tcNo=@tc, odaNo=@oda, ucret=@ucret,girisTarihi=@Tarih1 ,cikisTarihi=@Tarih2 where id=@id ", db.baglanti);
                guncelle.Parameters.AddWithValue("@adi", adi);
                guncelle.Parameters.AddWithValue("@soyadi", soyadi);
                guncelle.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                guncelle.Parameters.AddWithValue("@telefon", telefonNo);
                guncelle.Parameters.AddWithValue("@mail", mail);
                guncelle.Parameters.AddWithValue("@tc", tcNo);
                guncelle.Parameters.AddWithValue("@oda", odaAdi);
                guncelle.Parameters.AddWithValue("@ucret", ucret);
                guncelle.Parameters.AddWithValue("@Tarih1", giris);
                guncelle.Parameters.AddWithValue("@Tarih2", cikis);
                guncelle.Parameters.AddWithValue("@id", id);
                guncelle.ExecuteNonQuery();
                guncelleDurum = adi + " " + soyadi + "isimli kişinin verileri güncellenmiştir.";
            }
            catch { }
            finally
            {
                db.baglanti.Close();
            }
        }
        public void musteriSil(int id)
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand sil = new SqlCommand("delete musteriler where id=@id", db.baglanti);
                sil.Parameters.AddWithValue("@id", id);
                sil.ExecuteNonQuery();
                
                silDurum = "silme işlemi başarılı";
            }
            catch { }
            finally
            {
                db.baglanti.Close();
            }
        }
        public DataTable aramaYap(string adi)
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand veriAl = new SqlCommand("select * from musteriler where adi LIKE '%'+@adi+'%' ", db.baglanti);
                veriAl.Parameters.AddWithValue("@adi", adi);
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
    }
}
