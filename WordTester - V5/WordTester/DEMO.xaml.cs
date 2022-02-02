using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WordTester
{
    /// <summary>
    /// Interaction logic for DEMO.xaml
    /// </summary>
    public partial class DEMO : Window
    {
        Random rnd = new Random();


        private TestContainer test;

        public DEMO(TestContainer test)
        {
            this.test = test;
            InitializeComponent();

            lbLista.ItemsSource = test.WordPairs;
            lbListaFormazott.ItemsSource = test.WordPairs;

            dgLista.ItemsSource = test.WordPairs;
            dgListaFormazott.ItemsSource = test.WordPairs;
        }

        private void btnAngol_Click(object sender, RoutedEventArgs e)
        {
            test.OrderByEnglisWord();
            //Nem a legszebb megoldás, de ha azt szeretnénk hogy frissüljön, akkor újra kellépíteni!
            //A jó megoldás a ObservableCollection lenne -> using System.Collections.ObjectModel;
            //Ilyen lista esetén a tartalom változása a ráépülő vezérlőben is azonnal megjelenik.
            //Mivel a listánk a TestContainer-ben van, ott kellene a List<WordPair> wordPairs; cserélni
            //ObservableCollection<WordPair> wordPairs; -re!!!
            lbLista.ItemsSource = null;
            lbLista.ItemsSource = test.WordPairs;

            lbListaFormazott.ItemsSource = null;
            lbListaFormazott.ItemsSource = test.WordPairs;
        }

        private void btnMagyar_Click(object sender, RoutedEventArgs e)
        {
            test.OrderByHungarianWord();

            lbLista.ItemsSource = null;
            lbLista.ItemsSource = test.WordPairs;

            lbListaFormazott.ItemsSource = null;
            lbListaFormazott.ItemsSource = test.WordPairs;
        }
    }
}
