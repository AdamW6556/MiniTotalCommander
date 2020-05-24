using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace miniTC.Controls
{

    using miniTC.Model;
    /// <summary>
    /// Logika interakcji dla klasy TCPanel.xaml
    /// </summary>
    public partial class TCPanel : UserControl
    {
        public TCPanel()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty wlasciwoscsciezki = DependencyProperty.Register("Sciezkaaktualna",
            typeof(string), typeof(TCPanel), new PropertyMetadata(""));

        public string Sciezkaaktualna
        {
            get
            {
                return (string)GetValue(wlasciwoscsciezki);
            }
            set
            {
                SetValue(wlasciwoscsciezki, value);
            }
        }

        public static readonly DependencyProperty wlasnosclistycombobox = DependencyProperty.Register("Comboboxlista",
    typeof(string[]), typeof(TCPanel), new PropertyMetadata(null));

        public string[] Comboboxlista
        {
            get
            {
                return (string[])GetValue(wlasnosclistycombobox);
            }
            set
            {
                SetValue(wlasnosclistycombobox, value);
            }
        }



        public static readonly DependencyProperty wlasnoscwybranegoitemucombobox = DependencyProperty.Register("Comboboxwybranyitem",
          typeof(string), typeof(TCPanel), new PropertyMetadata(""));
        public string Comboboxwybranyitem
        {
            get
            {
                return (string)GetValue(wlasnoscwybranegoitemucombobox);
            }
            set
            {
                SetValue(wlasnoscwybranegoitemucombobox, value);
            }
        }

      

        public static readonly DependencyProperty comboboxwlasnoscoznaczona = DependencyProperty.Register("Comboboxwybrany2",
           typeof(ICommand), typeof(TCPanel), new PropertyMetadata(null));
        public ICommand Comboboxwybrany2
        {
            get
            {
                return (ICommand)GetValue(comboboxwlasnoscoznaczona);
            }
            set
            {
                SetValue(comboboxwlasnoscoznaczona, value);
            }
        }
       

        public static readonly DependencyProperty comboboxopcjewlasnosci = DependencyProperty.Register("Combobozmianaopcji",
        typeof(ICommand), typeof(TCPanel), new PropertyMetadata(null));
        public ICommand Combobozmianaopcji
        {
            get
            {
                return (ICommand)GetValue(comboboxopcjewlasnosci);
            }
            set
            {
                SetValue(comboboxopcjewlasnosci, value);
            }
        }

    


        public static readonly DependencyProperty wlasnosczawartoscisciezki = DependencyProperty.Register("Zawartoscsciezki",
            typeof(ObservableCollection<Modeldlapliku>), typeof(TCPanel), new PropertyMetadata(null));
        public ObservableCollection<Modeldlapliku> Zawartoscsciezki
        {
            get
            {
                return (ObservableCollection<Modeldlapliku>)GetValue(wlasnosczawartoscisciezki);
            }
            set
            {
                SetValue(wlasnosczawartoscisciezki, value);
            }
        }



        public static readonly DependencyProperty wlasciwoscwybrana = DependencyProperty.Register("Wlasciwoscwybrana",
            typeof(Modeldlapliku), typeof(TCPanel), new PropertyMetadata(null));
        public Modeldlapliku Wlasciwoscwybrana
        {
            get => (Modeldlapliku)GetValue(wlasciwoscwybrana);
            set
            {
                SetValue(wlasciwoscwybrana, value);
            }
        }

        

        public static readonly DependencyProperty wlasciwoscmyszki = DependencyProperty.Register("Podwojnekliknieciemyszki",
            typeof(ICommand), typeof(TCPanel), new PropertyMetadata(null));
        public ICommand Podwojnekliknieciemyszki
        {
            get
            {
                return (ICommand)GetValue(wlasciwoscmyszki);
            }
            set
            {
                SetValue(wlasciwoscmyszki, value);
            }
        }
        


    }
}
