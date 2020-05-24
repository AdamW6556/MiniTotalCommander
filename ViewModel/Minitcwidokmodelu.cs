using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows;

namespace miniTC.ViewModel
{
    using miniTC.ViewModel.BaseClass;
    using miniTC.Model;
    class Minitcwidokmodelu : ViewModelBase
    {

        private Minitcmodelglowny panelprawy = new Minitcmodelglowny();
        public string Sciezkaod
        {
            get
            {
                return panellewy.Sciezka;
            }
            set
            {
                panellewy.Sciezka = value;

                onPropertyChanged(nameof(Sciezkaod));
            }
        }

        private Minitcmodelglowny panellewy = new Minitcmodelglowny();
        public string Sciezkado
        {
            get
            {
                return panelprawy.Sciezka;
            }
            set
            {
                panelprawy.Sciezka = value;

                onPropertyChanged(nameof(Sciezkado));
            }
        }
       

        private string sciezkaodprawej;

        private string sciezkaodlewej;

        private Modeldlapliku wybranawartoscprawa;

        private Modeldlapliku wybranawartosclewa;


        public string Sciezkaodprawej
        {
            get
            {
                return sciezkaodprawej;
            }
            set
            {
                sciezkaodprawej = value;

                onPropertyChanged(nameof(Sciezkaodprawej));
            }
        }

        public string Sciezkaodlewej
        {
            get
            {
                return sciezkaodlewej;
            }
            set
            {
                sciezkaodlewej = value;

                onPropertyChanged(nameof(Sciezkaodlewej));
            }
        }

        public Modeldlapliku Wybranawartoscprawa
        {
            get
            {
                return wybranawartoscprawa;
            }
            set
            {
                wybranawartoscprawa = value;

                onPropertyChanged(nameof(Wybranawartoscprawa));
            }
        }

        public Modeldlapliku Wybranawartosclewa
        {
            get
            {
                return wybranawartosclewa;
            }
            set
            {
                wybranawartosclewa = value;

                onPropertyChanged(nameof(Wybranawartosclewa));
            }
        }

        public ObservableCollection<Modeldlapliku> Listaplikowzlewej
        {
            get
            {
                return panellewy.Listaplikow;
            }
            set
            {
                panellewy.Listaplikow = value;

                onPropertyChanged(nameof(Listaplikowzlewej));
            }
        }

        public ObservableCollection<Modeldlapliku> Listaplikowzprawej
        {
            get
            {
                return panelprawy.Listaplikow;
            }
            set
            {
                panelprawy.Listaplikow = value;

                onPropertyChanged(nameof(Listaplikowzprawej));
            }
        }

        public string[] Dyskistronalewa
        {
            get
            {
                return panellewy.Listadyskow;
            }
            set
            {
                panellewy.Listadyskow = value;

                onPropertyChanged(nameof(Dyskistronalewa));
            }
        }

        public string[] Dyskistronaprawa
        {
            get
            {
                return panelprawy.Listadyskow;
            }
            set
            {
                panelprawy.Listadyskow = value;

                onPropertyChanged(nameof(Dyskistronaprawa));
            }
        }

        private ICommand nowykatalogr = null;

        private ICommand nowykatalogl = null;
        

        private ICommand prawalistadyskow = null;

        private ICommand lewalistadyskow = null;

        private ICommand zmianastronyprawej = null;
        private ICommand zmianastronylewej = null;
        private ICommand kopiujplik = null;

        public ICommand Nowykatalogr
        {
            get
            {
                if (nowykatalogr == null)
                {
                    nowykatalogr = new RelayCommand(

                        arg => {

                            if (Directory.Exists(Wybranawartoscprawa.Sciezkadopliku))
                            {
                                Sciezkado = Wybranawartoscprawa.Sciezkadopliku;

                                Listaplikowzprawej.Clear();

                                if (Directory.GetParent(Sciezkado) != null)
                                {
                                    Listaplikowzprawej.Add(new Modeldlapliku(Directory.GetParent(Sciezkado).ToString(), 1));
                                }

                                panelprawy.Kolejnasciezka(Sciezkado);
                            }
                        },


                        arg => Wybranawartoscprawa != null

                        );
                }

                return nowykatalogr;
            }
        }
        public ICommand Nowykatalogl
        {
            get
            {
                if (nowykatalogl == null)
                {
                    nowykatalogl = new RelayCommand(

                        arg => {

                            if (Directory.Exists(Wybranawartosclewa.Sciezkadopliku))
                            {
                                Sciezkaod = Wybranawartosclewa.Sciezkadopliku;

                                Listaplikowzlewej.Clear();

                                if (Directory.GetParent(Sciezkaod) != null)
                                {
                                    Listaplikowzlewej.Add(new Modeldlapliku(Directory.GetParent(Sciezkaod).ToString(), 1));
                                }

                                panellewy.Kolejnasciezka(Sciezkaod);
                            }
                        },

                        arg => Wybranawartosclewa != null

                        );
                }

                return nowykatalogl;
            }
        }

        public ICommand Prawalistadyskow
        {
            get
            {
                if (prawalistadyskow == null)
                {
                    prawalistadyskow = new RelayCommand(
                        arg => {

                            Dyskistronaprawa = new string[Environment.GetLogicalDrives().Length];

                            Dyskistronaprawa = Environment.GetLogicalDrives();
                        },

                        arg => true
                        );
                }
                return prawalistadyskow;
            }
        }

        public ICommand Lewalistadyskow
        {
            get
            {
                if (lewalistadyskow == null)
                {
                    lewalistadyskow = new RelayCommand(
                        arg => {

                            Dyskistronalewa = new string[Environment.GetLogicalDrives().Length];

                            Dyskistronalewa = Environment.GetLogicalDrives();
                        },

                        arg => true
                        );
                }
                return lewalistadyskow;
            }
        }

        public ICommand Zmianastronyprawej
        {
            get
            {
                if (zmianastronyprawej == null)
                {
                    zmianastronyprawej = new RelayCommand(
                        arg => {

                            Sciezkado = Sciezkaodprawej;

                            Listaplikowzprawej.Clear();

                            for (int i = 0; i < Directory.GetFiles(Sciezkado).Length; i++)
                            {
                                Listaplikowzprawej.Add(new Modeldlapliku(Directory.GetFiles(Sciezkado)[i], 0));
                            }


                            for (int i = 0; i < Directory.GetDirectories(Sciezkado, "*", SearchOption.TopDirectoryOnly).Length; i++)
                            {
                                Listaplikowzprawej.Add(new Modeldlapliku(Directory.GetDirectories(Sciezkado, "*", SearchOption.TopDirectoryOnly)[i], 0));
                            }

                        },

                        arg => Sciezkaodprawej != null

                        );
                }

                return zmianastronyprawej;
            }
        }

        public ICommand Zmianastronylewej
        {
            get
            {
                if (zmianastronylewej == null)
                {
                    zmianastronylewej = new RelayCommand(
                        arg =>
                        {
                            Sciezkaod = Sciezkaodlewej;

                            Listaplikowzlewej.Clear();

                            for (int i = 0; i < Directory.GetFiles(panellewy.Sciezka).Length; i++)
                            {
                                Listaplikowzlewej.Add(new Modeldlapliku(Directory.GetFiles(Sciezkaod)[i], 0));
                            }
                                
                            for (int i = 0; i < Directory.GetDirectories(Sciezkaod, "*", SearchOption.TopDirectoryOnly).Length; i++)
                            {
                                Listaplikowzlewej.Add(new Modeldlapliku(Directory.GetDirectories(Sciezkaod, "*", SearchOption.TopDirectoryOnly)[i], 0));
                            }
                                
                        },

                        arg => Sciezkaodlewej != null

                        );
                }

                return zmianastronylewej;
            }
        }


        private static void Kopiakatalogu(string sciezkaod, string sciezkado, bool kopiowanie)
        {
            DirectoryInfo katalog = new DirectoryInfo(sciezkaod);

            if (!katalog.Exists)
            {
                throw new DirectoryNotFoundException("Blad sciezki" + sciezkaod);
            }

            DirectoryInfo[] katalogi = katalog.GetDirectories();

            string s1 = Path.Combine(sciezkado, sciezkaod.Substring(sciezkaod.LastIndexOf(@"\") + 1));

            if (Directory.Exists(s1) == false)
            {
                Directory.CreateDirectory(Path.Combine(s1));
            }


            FileInfo[] pliki = katalog.GetFiles();

            foreach (FileInfo plik in pliki)
            {
                string s2 = Path.Combine(s1, plik.Name);

                try
                {
                    plik.CopyTo(s2, false);
                }
                catch (Exception)
                {

                }
            }

            if (kopiowanie == true)
            {
                foreach (DirectoryInfo katalog2 in katalogi)
                {
                    string s2 = Path.Combine(s1, katalog2.Name);

                    Kopiakatalogu(katalog2.FullName, s2, kopiowanie);
                }
            }
        }

        public ICommand Kopiujplik
        {
            get
            {
                if(kopiujplik == null)
                {
                    kopiujplik = new RelayCommand(
                        
                        arg => {

                            string s = Path.Combine(Sciezkado, Wybranawartosclewa.Sciezkadopliku.Substring(Wybranawartosclewa.Sciezkadopliku.LastIndexOf(@"\")+1));

                            try
                            {
                                File.Copy(Wybranawartosclewa.Sciezkadopliku, s, true);
                            }
                            catch (Exception)
                            {
                                Kopiakatalogu(Wybranawartosclewa.Sciezkadopliku, Sciezkado, true);
                            }

                            Listaplikowzprawej.Clear();

                            if (Directory.GetParent(Sciezkado) != null)
                            {
                                Listaplikowzprawej.Add(new Modeldlapliku(Directory.GetParent(Sciezkado).ToString(), 1));
                            }

                            panelprawy.Kolejnasciezka(Sciezkado);

                        },

                        arg => Wybranawartosclewa != null && Sciezkado != null && Sciezkado != ""

                        );
                }

                return kopiujplik;
            }
        }

       

      
    }
}
