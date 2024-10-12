using AdamAsmaca.Properties;
using System.ComponentModel;

namespace AdamAsmaca
{
    public partial class MainWindow : Form
    {
        // Hata sayacý, kazanma ve kaybetme deðiþkenlerinin tanýmlanmasý
        public int Hata { get; set; }
        public Boolean win = false;
        public Boolean lose = false;


        // Seçilen þehrin ismi ve harflerin bulunma durumunu içeren liste
        public string Isim { get; set; }
        public List<char> sehirGizli = new List<char>();

        public MainWindow()
        {
            InitializeComponent();
            SehirOlusturma();
        }


        private void tryBtn_Click(object sender, EventArgs e)
        {
            // Eðer kazanma ve kaybetme durumu 'False' ise  'Dene!' butonuna basýldýðýnda girdinin denenmesi
            if (!win && !lose)
            {
                //Girdinin boþ olma durumunun engellenmesi
                if (!textBox2.Text.Equals(""))
                {
                    TestEt();
                }
            }
        }

        private void retryButton_Click(object sender, EventArgs e)
        {
            // 'Tekrar' butonuna basýldýðýnda oyunun tekrar baþlamasý
            Tekrar();
        }


        // Girilen deðerin test edildiði metot
        void TestEt()
        {
            // Girdinin ilk harfinin küçük ve büyük harfinin alýnmasý, Kelime ise baþ harfinin büyütülmesi
            string girdi = textBox2.Text;
            string kelime = girdi.ToLower();

            char ch = kelime[0];
            char ch2 = (char)(ch - 32);


            string yazi = "";


            // Eðer deðer þehrin ismiyle aynýysa kazanma durumu
            if (kelime.Length > 1 && kelime.Equals(Isim.ToLower()))
            {
                textBox.Text = Isim;
                pictureBox1.Image = Resources.Bildin;
                win = true;

            }

            // Eðer deðer harf ise ve ismin içinde geçiyorsa listede yerine yazýlmasý
            else if (kelime.Length == 1 && (Isim.Contains(ch) || Isim.Contains(ch2)))
            {

                for (int i = 0; i < Isim.Length; i++)
                {
                    if (Isim[i].Equals(ch))
                    {
                        sehirGizli[i] = ch;
                    }

                    if (Isim[i].Equals(ch2))
                    {
                        sehirGizli[i] = ch2;
                    }

                    yazi = yazi + sehirGizli[i] + " ";
                }

                // Eðer listede bulunmamýþ harf yoksa kazanma durumu yoksa yazýyý güncelleme
                if (!sehirGizli.Contains('_'))
                {
                    textBox.Text = Isim;
                    pictureBox1.Image = Resources.Bildin;
                    win = true;
                }
                else
                {
                    textBox.Text = yazi;
                }
            }

            //Eðer hatalý denemeyse hata sayýsýnýn arttýrýlmasý, hata sayýsýna göre resmin deðiþtirilmesi, Çok sayýda hata yapýlýrsa kaybetme durumu
            else
            {
                Hata++;
                if (Hata == 1)
                {
                    pictureBox1.Image = Resources.Bas;
                }
                else if (Hata == 2)
                {
                    pictureBox1.Image = Resources.Govde;
                }
                else if (Hata == 3)
                {
                    pictureBox1.Image = Resources.Kol1;
                }
                else if (Hata == 4)
                {
                    pictureBox1.Image = Resources.Kol2;
                }
                else if (Hata == 5)
                {
                    pictureBox1.Image = Resources.Bacak1;
                }
                else if (Hata == 6)
                {
                    pictureBox1.Image = Resources.Bacak2;
                }
                else if (Hata == 7)
                {
                    pictureBox1.Image = Resources.Kaybettin;
                    textBox.Text = Isim;
                    lose = true;
                }

            }
            textBox2.Text = "";
        }

        // Þehir seçiminin yapýldýðý metot
        void SehirOlusturma()
        {
            // Þehirlerin listesi
            String[] sehirler = {"Adana","Adýyaman","Afyonkarahisar","Aðrý","Aksaray","Amasya","Ankara","Antalya","Ardahan","Artvin","Aydýn",
                    "Balýkesir","Bartýn","Batman","Bayburt","Bilecik","Bingöl","Bitlis","Bolu","Burdur","Bursa","Çanakkale","Çankýrý","Çorum","Denizli","Diyarbakýr",
                    "Düzce","Edirne","Elazýð","Erzincan","Erzurum","Eskiþehir","Gaziantep","Giresun","Gümüþhane","Hakkari","Hatay","Iðdýr","Isparta","Istanbul","Izmir",
                    "Kahramanmaraþ","Karabük","Karaman","Kars","Kastamonu","Kayseri","Kýrýkkale","Kýrklareli","Kýrþehir","Kilis","Kocaeli","Konya","Kütahya","Malatya","Manisa",
                    "Mardin","Mersin","Muðla","Muþ","Nevþehir","Niðde","Ordu","Osmaniye","Rize","Sakarya","Samsun","Siirt","Sinop","Sivas","Þanlýurfa","Þýrnak","Tekirdað","Tokat",
                    "Trabzon","Tunceli","Uþak","Van","Yalova","Yozgat","Zonguldak"};

            // Þehir listesinden rastgele bir þehir seçme ve atama
            Random random = new Random();
            int sayi = random.Next(sehirler.Length);
            Isim = sehirler[sayi];


            // Seçilen þehrin harflerinin deðiþtirilip listeye aktarýlmasý ve uygulamada yazdýrýlmasý
            string yazi = "";
            for (int i = 0; i < Isim.Length; i++)
            {
                char ch = Isim[i];
                sehirGizli.Add('_');

                yazi = yazi + sehirGizli[i] + " ";
            }
            textBox.Text = yazi;
        }

        //Deðerlerin sýfýrlanýp tekrar þehir seçilen metot
        void Tekrar()
        {
            //Deðerlei
            pictureBox1.Image = Resources.Bos;
            textBox.Text = "";
            Hata = 0;
            win = false;
            lose = false;
            sehirGizli.Clear();
            SehirOlusturma();
                    
        }
    }
}
