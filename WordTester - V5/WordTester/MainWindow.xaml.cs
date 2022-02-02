using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WordTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TestContainer test = null;

        public MainWindow()
        {
            InitializeComponent();
            brdVezerlo.IsEnabled = false;
        }

        private void btnLoadTest_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            try
            {
                test = new TestContainer(ofd.FileName);
            }
            catch (Exception hiba)
            {
                MessageBox.Show($"A program nem tudta a tesztet betölteni! {hiba.Message}");
                return;
            }

            

            lblFileName.Content = ofd.FileName.ToString();
            lblWordsNum.Content = test.WordPairs.Count.ToString();
            lblTestNumUK.Content = test.GetNumOfWordsTestedUK;
            lblTestNumHU.Content = test.GetNumOfWordsTestedHU;
           

            //Minimum 3, maximum az összes szópárral tesztelés.
            sliTestWordsNum.Minimum = 3;
            sliTestWordsNum.Maximum = test.WordPairs.Count;
            
            //Amíg nincs betöltés, addig legyen csak inaktív
            brdVezerlo.IsEnabled = true;
            btnStartTest.IsEnabled = true;
            btnDEMO.IsEnabled = true;
            btnListOfWords.IsEnabled = true;
            rbHUUK.IsEnabled = true;
            rbUKHU.IsEnabled = true;
            rbRandom.IsEnabled = true;
            rbLeastTested.IsEnabled = true;
            rbLeastKnown.IsEnabled = true;
        }

        private void sliTestWordsNum_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblChoisedNum.Content = Math.Round(sliTestWordsNum.Value) + " db";
           
        }

        private void btnStartTest_Click(object sender, RoutedEventArgs e)
        {

            //UK->HU vagy HU->UK teszt ?
            bool UK_HU = rbUKHU.IsChecked.Value;
            int num = (int)sliTestWordsNum.Value;

            //Tesztlista elkészítése, a csúszkán megadott darab szóval.
            try
            {
                if (UK_HU)
                {
                    if (rbLeastTested.IsChecked == true)
                    {
                        test.DoLeastTestedHUList(num);
                    }
                    else
                    if (rbLeastKnown.IsChecked == true)
                    {
                        test.DoLeastKnownHUList(num);
                    }
                    else
                    {
                        test.DoRandomListNumber(num);
                    }
                }
                else
                {
                    if (rbLeastTested.IsChecked == true)
                    {
                        test.DoLeastTestedHUList(num);
                    }
                    else
                    if (rbLeastKnown.IsChecked == true)
                    {
                        test.DoLeastKnownHUList(num);
                    }
                    else
                    {
                        test.DoRandomListNumber(num);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            



            TestWindow twin = new TestWindow(test.NarrowedWordPairs, UK_HU, chkIsCheckEveryWord.IsChecked == true);
            twin.ShowDialog();
            test.UpdateResultFromNarrowedList();
            test.WriteContainer();
            lblTestNumUK.Content = test.GetNumOfWordsTestedUK;
            lblTestNumHU.Content = test.GetNumOfWordsTestedHU;
        }


        private void btnListOfWords_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num = (int)sliTestWordsNum.Value;
                if (rbRandom.IsChecked.Value)
                {
                    test.DoRandomListNumber(num);
                }
                else if (rbLeastTested.IsChecked.Value)
                {
                    if (rbHUUK.IsChecked.Value)
                    {
                        test.DoLeastTestedHUList(num);
                    }
                    else
                        test.DoLeastTestedUKList(num);
                }
                else
                {
                    if (rbHUUK.IsChecked.Value)
                    {
                        test.DoLeastKnownHUList(num);
                    }
                    else
                        test.DoLeastKnownUKList(num);
                }
                ListOfWords szoLista = new ListOfWords(test.NarrowedWordPairs, "Szavak listája");
                szoLista.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnDEMO_Click(object sender, RoutedEventArgs e)
        {
            DEMO listak = new DEMO(test);
            listak.ShowDialog();
        }

        private void rbRandom_Checked(object sender, RoutedEventArgs e)
        {
            sliTestWordsNum.Maximum = test.WordPairs.Count;
        }

        private void rbLeastTested_Checked(object sender, RoutedEventArgs e)
        {
            if (rbUKHU.IsChecked == true)
            {
                sliTestWordsNum.Maximum = test.GetNumOfWordsTestedUK;
            }
            if (rbHUUK.IsChecked == true)
            {
                sliTestWordsNum.Maximum = test.GetNumOfWordsTestedHU;
            }
        }

        private void rbLestKnown_Checked(object sender, RoutedEventArgs e)
        {
            if (rbUKHU.IsChecked == true)
            {
                sliTestWordsNum.Maximum = test.GetNumOfWordsTestedUK;
            }
            if(rbHUUK.IsChecked==true)
            {
                sliTestWordsNum.Maximum = test.GetNumOfWordsTestedHU;
            }
        }

        private void rbHUUK_Checked(object sender, RoutedEventArgs e)
        {
            if (rbLeastKnown.IsChecked == true)
            {
                sliTestWordsNum.Maximum = test.GetNumOfWordsTestedHU;
            }
            if (rbLeastTested.IsChecked == true)
            {
                sliTestWordsNum.Maximum = test.GetNumOfWordsTestedHU;
            }
        }

        private void rbUKHU_Checked(object sender, RoutedEventArgs e)
        {
            if (rbLeastKnown.IsChecked == true)
            {
                sliTestWordsNum.Maximum = test.GetNumOfWordsTestedUK;
            }
            if (rbLeastTested.IsChecked == true)
            {
                sliTestWordsNum.Maximum = test.GetNumOfWordsTestedUK;
            }
        }
    }
}
