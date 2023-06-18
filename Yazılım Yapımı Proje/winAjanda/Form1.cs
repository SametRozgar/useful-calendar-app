using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winAjanda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Etkinlik> Etkinlikler = new List<Etkinlik>();

        private void btnEkle_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dtpTarih.Value.ToString());

            Etkinlik etk = new Etkinlik()
            {
                Detay = txtDetay.Text,
                Tarih = dtpTarih.Value.Date,
                Tur = cmbTur.SelectedText
            };

            Etkinlikler.Add(etk);

            Listele();
            Temizle();
        }

        private void Temizle()
        {
            dtpTarih.Value = DateTime.Now;
            //dtpTarih.ResetText(); // bugün'ün tarihine çekiyor..
            txtDetay.Clear();
            cmbTur.SelectedIndex = 0;
        }

        private void Listele()
        {
            // For..
            // Foreach..

            //foreach (Etkinlik x in Etkinlikler)
            //{
            //    // Kodlar..
            //}

            lstOlaylar.Items.Clear();

            //DateTime[] tarihler = new DateTime[Etkinlikler.Count];

            // Verilen boyutta bir liste oluşturur.
            List<DateTime> tarihler = new List<DateTime>(Etkinlikler.Count);

            // Çok satırlı işlem yapacaksanız {..} gerekir.
            Etkinlikler.ForEach(x =>
            {
                // x.Tarih.ToShortDateString() : 12.02.2016
                string trh = x.Tarih.ToShortDateString();

                // Substring istenilen indexli karakterden başlayarak belli karakter 
                // uzunluğunda string kesme yapar..
                string dty =
                    (x.Detay.Length > 10) ?
                        x.Detay.Substring(0, 10) + "..." :
                        x.Detay;

                lstOlaylar.Items.Add(trh + " - " + dty);

                tarihler.Add(x.Tarih);
            });

            // MOnthCalendar,BoldedDates : takvimde koyu işaretli günler oluşturur.
            // ToArray : Verilen listeyi diziye çevirir.
            mcTakvim.BoldedDates = tarihler.ToArray();

            // Tek satırlı olarak işlem yapacaksanız {..} gerekmez..
            //Etkinlikler.ForEach(x => 
            //    lstOlaylar.Items.Add(
            //        x.Tarih.ToShortDateString() + " - " + 
            //        x.Detay.Substring(0, 10) + "..."));
        }

        private void lstOlaylar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstOlaylar.SelectedIndex;
            Etkinlik etk = Etkinlikler[index];

            txtDetay.Text = etk.Detay;
            dtpTarih.Value = etk.Tarih;
            cmbTur.SelectedText = etk.Tur;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            // Bize secili nesneyi döndüren metot "SeciliEtkinlikNesnesiGetir";
            Etkinlik etk = SeciliEtkinlikNesnesiGetir();

            // NOT : Alt tuşu ile mouse ile dikey seçim yapılabilir..

            etk.Detay = txtDetay.Text;
            etk.Tarih = dtpTarih.Value;
            etk.Tur = cmbTur.SelectedText;

            Listele();
            Temizle();
        }

        private Etkinlik SeciliEtkinlikNesnesiGetir()
        {
            int index = lstOlaylar.SelectedIndex;
            Etkinlik etk = Etkinlikler[index];

            return etk;
        }


        private void btnSil_Click(object sender, EventArgs e)
        {
            int index = lstOlaylar.SelectedIndex;
            Etkinlik etk = Etkinlikler[index];

            //Etkinlikler.RemoveAt(index);    // Index ile silme..
            Etkinlikler.Remove(etk);        // Nesne ile silme..

            Listele();
            Temizle();
        }

        private void mcTakvim_DateChanged(object sender, DateRangeEventArgs e)
        {
            // mcTakvim.SelectionStart
            // mcTakvim.SelectionRange.Start

            DateTime seciliGun = mcTakvim.SelectionStart;

            lstOlaylar.Items.Clear();

            foreach (Etkinlik etk in Etkinlikler)
            {
                if(etk.Tarih == seciliGun)
                {
                    // x.Tarih.ToShortDateString() : 12.02.2016
                    string trh = etk.Tarih.ToShortDateString();

                    // Substring istenilen indexli karakterden başlayarak belli karakter 
                    // uzunluğunda string kesme yapar..
                    string dty =
                        (etk.Detay.Length > 10) ?
                            etk.Detay.Substring(0, 10) + "..." :
                            etk.Detay;

                    lstOlaylar.Items.Add(trh + " - " + dty);
                }
            }

        }

        private void cmbTur_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
