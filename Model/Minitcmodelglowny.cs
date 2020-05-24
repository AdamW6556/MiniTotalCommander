using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace miniTC.Model
{
    using miniTC.ViewModel.BaseClass;

    class Minitcmodelglowny : ViewModelBase
    {
        
        private ObservableCollection<Modeldlapliku> listaplikow = new ObservableCollection<Modeldlapliku>();

        public ObservableCollection<Modeldlapliku> Listaplikow
        {
            get
            {
                return listaplikow;
            }
            set
            {
                listaplikow = value;

                onPropertyChanged(nameof(Listaplikow));
            }
        }

        private string[] listadyskow;

        public string[] Listadyskow
        {
            get
            {
                return listadyskow;
            }
            set
            {
                listadyskow = value;

                onPropertyChanged(nameof(Listadyskow));
            }
        }

        private string sciezka = "";
        public string Sciezka
        {
            get
            {
                return sciezka;
            }

            set
            {
                sciezka = value;

                onPropertyChanged(nameof(Sciezka));
            }
        }
          
        public void Kolejnasciezka(string sciezka1)
        {
            try
            {
                for (int i = 0; i < Directory.GetFiles(sciezka1, "*", SearchOption.TopDirectoryOnly).Length; i++)
                {
                    listaplikow.Add(new Modeldlapliku(Directory.GetFiles(sciezka1, "*", SearchOption.TopDirectoryOnly)[i], 0));
                }
                   
            }

            catch (Exception)
            {

            }

            try
            {
                for (int i = 0; i < Directory.GetDirectories(sciezka1, "*", SearchOption.TopDirectoryOnly).Length; i++)
                {
                    listaplikow.Add(new Modeldlapliku(Directory.GetDirectories(sciezka1, "*", SearchOption.TopDirectoryOnly)[i], 0));
                }
                    
            }
            catch (Exception)
            {


            }
        }
    }
}
