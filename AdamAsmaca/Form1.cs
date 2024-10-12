using AdamAsmaca.Properties;
using System.ComponentModel;

namespace AdamAsmaca
{
    public partial class MainWindow : Form
    {
        // Hata sayac�, kazanma ve kaybetme de�i�kenlerinin tan�mlanmas�
        public int Hata { get; set; }
        public Boolean win = false;
        public Boolean lose = false;


        // Se�ilen �ehrin ismi ve harflerin bulunma durumunu i�eren liste
        public string Isim { get; set; }
        public List<char> sehirGizli = new List<char>();

        public MainWindow()
        {
            InitializeComponent();
            SehirOlusturma();
        }


        private void tryBtn_Click(object sender, EventArgs e)
        {
            // E�er kazanma ve kaybetme durumu 'False' ise  'Dene!' butonuna bas�ld���nda girdinin denenmesi
            if (!win && !lose)
            {
                //Girdinin bo� olma durumunun engellenmesi
                if (!textBox2.Text.Equals(""))
                {
                    TestEt();
                }
            }
        }

        private void retryButton_Click(object sender, EventArgs e)
        {
            // 'Tekrar' butonuna bas�ld���nda oyunun tekrar ba�lamas�
            Tekrar();
        }


        // Girilen de�erin test edildi�i metot
        void TestEt()
        {
            // Girdinin ilk harfinin k���k ve b�y�k harfinin al�nmas�, Kelime ise ba� harfinin b�y�t�lmesi
            string girdi = textBox2.Text;
            string kelime = girdi.ToLower();

            char ch = kelime[0];
            char ch2 = (char)(ch - 32);


            string yazi = "";


            // E�er de�er �ehrin ismiyle ayn�ysa kazanma durumu
            if (kelime.Length > 1 && kelime.Equals(Isim.ToLower()))
            {
                textBox.Text = Isim;
                pictureBox1.Image = Resources.Bildin;
                win = true;

            }

            // E�er de�er harf ise ve ismin i�inde ge�iyorsa listede yerine yaz�lmas�
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

                // E�er listede bulunmam�� harf yoksa kazanma durumu yoksa yaz�y� g�ncelleme
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

            //E�er hatal� denemeyse hata say�s�n�n artt�r�lmas�, hata say�s�na g�re resmin de�i�tirilmesi, �ok say�da hata yap�l�rsa kaybetme durumu
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

        // �ehir se�iminin yap�ld��� metot
        void SehirOlusturma()
        {
            // �ehirlerin listesi
            String[] sehirler = {"Adana","Ad�yaman","Afyonkarahisar","A�r�","Aksaray","Amasya","Ankara","Antalya","Ardahan","Artvin","Ayd�n",
                    "Bal�kesir","Bart�n","Batman","Bayburt","Bilecik","Bing�l","Bitlis","Bolu","Burdur","Bursa","�anakkale","�ank�r�","�orum","Denizli","Diyarbak�r",
                    "D�zce","Edirne","Elaz��","Erzincan","Erzurum","Eski�ehir","Gaziantep","Giresun","G�m��hane","Hakkari","Hatay","I�d�r","Isparta","Istanbul","Izmir",
                    "Kahramanmara�","Karab�k","Karaman","Kars","Kastamonu","Kayseri","K�r�kkale","K�rklareli","K�r�ehir","Kilis","Kocaeli","Konya","K�tahya","Malatya","Manisa",
                    "Mardin","Mersin","Mu�la","Mu�","Nev�ehir","Ni�de","Ordu","Osmaniye","Rize","Sakarya","Samsun","Siirt","Sinop","Sivas","�anl�urfa","��rnak","Tekirda�","Tokat",
                    "Trabzon","Tunceli","U�ak","Van","Yalova","Yozgat","Zonguldak"};

            // �ehir listesinden rastgele bir �ehir se�me ve atama
            Random random = new Random();
            int sayi = random.Next(sehirler.Length);
            Isim = sehirler[sayi];


            // Se�ilen �ehrin harflerinin de�i�tirilip listeye aktar�lmas� ve uygulamada yazd�r�lmas�
            string yazi = "";
            for (int i = 0; i < Isim.Length; i++)
            {
                char ch = Isim[i];
                sehirGizli.Add('_');

                yazi = yazi + sehirGizli[i] + " ";
            }
            textBox.Text = yazi;
        }

        //De�erlerin s�f�rlan�p tekrar �ehir se�ilen metot
        void Tekrar()
        {
            //De�erlei
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
