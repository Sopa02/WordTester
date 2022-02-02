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
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        int currentQuestionNumber;
        int numOfCorrectQuestion;
        List<WordPair> testList;
        bool ISfromUKtoHU, IShelpForEveryWord;

        List<WordPair> badList = new List<WordPair>();

        //List<WordPair> wrongAnswers = new List<WordPair>();

        public TestWindow(List<WordPair> par, bool ISfromUKtoHU, bool IShelpForEveryWord)
        {
            InitializeComponent();
            this.ISfromUKtoHU = ISfromUKtoHU;
            this.Title = "Szóteszt : " + (ISfromUKtoHU ? "UK->HU (angolról magyarra)" : "HU->UK (magyarról angolra)");
            this.IShelpForEveryWord = IShelpForEveryWord;
            this.testList = par;
            currentQuestionNumber = 0;
            numOfCorrectQuestion = 0;
            pbProcesss.Minimum = 0;
            pbProcesss.Maximum = testList.Count;
            NextQuestion();

        }

        private void NextQuestion()
        {
            if (currentQuestionNumber == testList.Count)
            {
                ListOfWords result = new ListOfWords(badList,"A teszt alatt elrontott szavak listája");
                result.ShowDialog();
                this.Close();
                return;
            }
            lblQuestion.Content = ISfromUKtoHU ? testList[currentQuestionNumber].EnglishWord : testList[currentQuestionNumber].HungarianWord;

            currentQuestionNumber++;
            lbCurrent.Content = currentQuestionNumber + "/" + testList.Count;
            txtAnswer.Focus();
        }

        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            AnswerCheck();
        }

        private void AnswerCheck()
        {
            pbProcesss.Value++;
            bool goodAnswer;
            WordPair actWordPair = testList[currentQuestionNumber - 1];
            if (ISfromUKtoHU)
            {
                goodAnswer = actWordPair.HungarianWord == txtAnswer.Text;
                actWordPair.SetLastTestResultUK(true);
            }
            else
            {
                goodAnswer = actWordPair.EnglishWord == txtAnswer.Text;
                actWordPair.SetLastTestResultHU(true);
            }
            if (goodAnswer)
            {
                numOfCorrectQuestion++;
            }
            else
            {
                if (ISfromUKtoHU)
                {
                    actWordPair.SetLastTestResultUK(false);
                }
                else
                {
                    actWordPair.SetLastTestResultHU(false);
                }
                badList.Add(testList[currentQuestionNumber - 1]);

                if (IShelpForEveryWord)
                {
                    MessageBox.Show($"Téves! A helyes válasz: {(ISfromUKtoHU ? actWordPair.HungarianWord : actWordPair.EnglishWord)}");
                }
            }
            lblActResult.Content = Math.Round(100d * numOfCorrectQuestion / currentQuestionNumber) + "%";

            txtAnswer.Text = "";
            NextQuestion();
        }

        private void txtAnswer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AnswerCheck();
            }
        }
    }
}
