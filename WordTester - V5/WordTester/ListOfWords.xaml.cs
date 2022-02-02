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
    /// Interaction logic for ListOfWords.xaml
    /// </summary>
    public partial class ListOfWords : Window
    {
        private List<WordPair> wordPairs;

        public ListOfWords(List<WordPair> displayWordPairs, String headMessage)
        {
            InitializeComponent();
            tbHeader.Text = headMessage;
            this.wordPairs = displayWordPairs;
            lbListOfWords.ItemsSource = this.wordPairs;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            lbListOfWords.ItemsSource = null;
            lbListOfWords.ItemsSource = this.wordPairs;
        }
    }
}
