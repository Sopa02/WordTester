using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordTester
{
    public class WordPair
    {
        String englishWord;
        int englishTestNum;
        int englishSuccessfulNum;
        String hungarianWord;
        int hungarianTestNum;
        int hungarianSuccessfulNum;

        public WordPair(String inputData)
        {
            String[] temp = inputData.Split(';');
            this.englishWord = temp[0];
            this.hungarianWord = temp[1];
            //Ha már van előzmény
            if (englishWord.Contains('|'))
            {
                temp = englishWord.Split('|');
                this.englishWord = temp[0];
                temp = temp[1].Split('/');
                this.englishTestNum = int.Parse(temp[0]);
                this.englishSuccessfulNum = int.Parse(temp[1]);
            }
            if (hungarianWord.Contains('|'))
            {
                temp = hungarianWord.Split('|');
                this.hungarianWord = temp[0];
                temp = temp[1].Split('/');
                this.hungarianTestNum = int.Parse(temp[0]);
                this.hungarianSuccessfulNum = int.Parse(temp[1]);
            }
        }

        public string EnglishWord { get => englishWord; }
        public string HungarianWord { get => hungarianWord; }
        public int EnglishTestNum { get => englishTestNum; }
        public int EnglishSuccessfulNum { get => englishSuccessfulNum; }
        public int EnglishSuccessPercentage
        {
            get => englishTestNum == 0 ? 0 : (int)Math.Round(100d * englishSuccessfulNum / englishTestNum);
        }
        public int HungarianTestNum { get => hungarianTestNum; }
        public int HungarianSuccessfulNum { get => hungarianSuccessfulNum; }
        public int HungarianSuccessPercentage
        {
            get => hungarianTestNum == 0 ? 0 : (int)Math.Round(100d * hungarianSuccessfulNum / hungarianTestNum);
        }

        //Legyen normális kinézetű String reprezentációja az objektumnak!
        public override string ToString()
        {
            return $"{this.englishWord}({this.englishTestNum}->{this.englishSuccessfulNum}) - {this.hungarianWord}({this.hungarianTestNum}->{this.hungarianSuccessfulNum})";
        }
        /// <summary>
        /// Az objektum adatait a fájlban tárolt sorok formátumára alakítja. Ezek a sorok már fájlba írhatóak.
        /// </summary>
        public string LineOfFile
        {
            get =>
            this.englishWord + (this.englishTestNum > 0 ? "|" + this.englishTestNum + "/" + this.englishSuccessfulNum : "") +
                ";" +
                this.hungarianWord + (this.hungarianTestNum > 0 ? "|" + this.hungarianTestNum + "/" + this.hungarianSuccessfulNum : "");
        }
        /// <summary>
        /// Regisztrálja az angol szó legutolsó tesztjének eredményességét. ("Mi a jelentése a megadott angol szónak?" kérdésre adott válasz eredménye)
        /// </summary>
        /// <param name="Successful">true esetén sikeres volt a válaszadás, azaz jól írta be a magyar jelentést</param>
        public void SetLastTestResultUK(bool Successful)
        {
            this.englishTestNum++;
            if (Successful)
            {
                this.englishSuccessfulNum++;
            }
        }

        /// <summary>
        /// Regisztrálja a magyar szó legutolsó tesztjének eredményességét. ("Mi a jelentése a megadott magyar szónak?" kérdésre adott válasz eredménye)
        /// </summary>
        /// <param name="Successful">true esetén sikeres volt a válaszadás, azaz jól írta be az angol jelentést</param>
        public void SetLastTestResultHU(bool Successful)
        {
            this.hungarianTestNum++;
            if (Successful)
            {
                this.hungarianSuccessfulNum++;
            }
        }

        /// <summary>
        /// Frissíti a tesztelés statisztikai adatait. A tesztek száma és annak eredmémnyessége kerül felülírásra.
        /// </summary>
        /// <param name="changedWordPair">A megadott objektum adatait fogja átvenni.</param>
        public void UpdateResultFrom(WordPair changedWordPair)
        {
            this.englishTestNum = changedWordPair.englishTestNum;
            this.englishSuccessfulNum = changedWordPair.englishSuccessfulNum;
            this.hungarianTestNum = changedWordPair.hungarianTestNum;
            this.hungarianSuccessfulNum = changedWordPair.hungarianSuccessfulNum;
        }
    }


    public class TestContainer
    {
        String actFileName; //A teszt mögött álló állomány elérési útja és neve
        List<WordPair> wordPairs;  //A tesztállományban lévő összes szópáros
        List<WordPair> narrowedWordPairs; //Különféle szempontok alapján az eredetiből másolással létrehozott szűkített lista
        Random rnd = new Random();

        /// <summary>
        /// Konstruktor: betölti a szóállományban lévő adatokat.
        /// </summary>
        /// <param name="fileName">A szóállomány elérési útja és neve</param>
        public TestContainer(String fileName)
        {
            this.actFileName = fileName;
            //kivételkezelés - állomány nem létezik?
            try
            {
                wordPairs = File.ReadAllLines(fileName).Select(data => new WordPair(data)).ToList();
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException($"A kapott {fileName} teszt nem létezik!");
            }
        }

        /// <summary>
        /// A tesztállományban lévő összes szópáros
        /// </summary>
        internal List<WordPair> WordPairs { get => wordPairs; }

        /// <summary>
        /// Különféle szempontok alapján az eredetiből másolással létrehozott szűkített lista
        /// Amennyiben nem volt előzetesen leválogatás, InvalidOperationException kivételt vált ki!
        /// </summary>
        internal List<WordPair> NarrowedWordPairs
        {
            get
            {
                if (narrowedWordPairs == null)
                {
                    throw new InvalidOperationException("Még nem futtatott leválogató metódust!");
                }
                else return narrowedWordPairs;
            }
        }
        /// <summary>
        /// Hány angol szó szerepelt eddig a tesztekben? UK -> HU (angol szó magyar jelentésére kérdez)
        /// </summary>
        public int GetNumOfWordsTestedUK { get => WordPairs.Count(x => x.EnglishTestNum > 0); }
        /// <summary>
        /// Hány magyar szó szerepelt eddig a tesztekben? HU -> UK (magyar szó angol jelentésére kérdez)
        /// </summary>
        public int GetNumOfWordsTestedHU { get => WordPairs.Count(x => x.HungarianTestNum > 0); }


        /// <summary>
        /// Készít egy szűkített listát, ami a legkevesebbszer tesztelt angol szavakból épül fel.
        /// </summary>
        /// <param name="num">Megadja hány szó kerüljön az új listába. Előbb kerülnek bele a kevésbé tesztelt szavak, majd a többet teszteltek.</param>
        public void DoLeastTestedUKList(int num)
        {
            narrowedWordPairs = wordPairs.OrderBy(x => x.EnglishTestNum).Take(num).ToList();
        }

        /// <summary>
        /// Készít egy szűkített listát, ami a legkevesebbszer tesztelt magyar szavakból épül fel.
        /// </summary>
        /// <param name="num">Megadja hány szó kerüljön az új listába. Előbb kerülnek bele a kevésbé tesztelt szavak, majd a többet teszteltek.</param>
        public void DoLeastTestedHUList(int num)
        {
            narrowedWordPairs = wordPairs.OrderBy(x => x.HungarianTestNum).Take(num).ToList();
        }

        /// <summary>
        /// Készít egy szűkített listát, ami a legkevésbé tudott angol szavakból épül fel. (nem tudta a magyar jelentését)
        /// </summary>
        /// <param name="num">Megadja hány szó kerüljön az új listába. Előbb kerülnek be a rosszabb statisztikával rendelkező szópárok.</param>
        public void DoLeastKnownUKList(int num)
        {
            if (GetNumOfWordsTestedUK < num)
            {
                throw new ArgumentException("Nem volt még ennyi szó tesztelve korábban!");
            }
            narrowedWordPairs = wordPairs.Where(x => x.EnglishTestNum > 0).OrderBy(x => x.EnglishSuccessPercentage).Take(num).ToList();
        }

        /// <summary>
        /// Készít egy szűkített listát, ami a legkevésbé tudott magyar szavakból épül fel. (nem tudta az angol jelentését)
        /// </summary>
        /// <param name="num">Megadja hány szó kerüljön az új listába. Előbb kerülnek be a rosszabb statisztikával rendelkező szópárok.</param>
        public void DoLeastKnownHUList(int num)
        {
            if (GetNumOfWordsTestedHU < num)
            {
                throw new ArgumentException("Nem volt még ennyi szó tesztelve korábban!");
            }
            narrowedWordPairs = wordPairs.Where(x => x.HungarianTestNum > 0).OrderBy(x => x.HungarianSuccessPercentage).Take(num).ToList();
        }

        /// <summary>
        /// Létrehoz egy véletlenszerű szólistát a teljes listából válogatva.
        /// </summary>
        /// <param name="percent">Az eredeti lista hány %-a kerüljön bele?</param>
        public void DoRandomListPercent(double percent)
        {
            if (percent > 100 || wordPairs.Count * percent / 100d < 1)
            {
                throw new ArgumentException($"Minimum 1 szópár, de legfeljebb 100%");
            }
            DoRandomListNumber((int)(Math.Round(wordPairs.Count * percent / 100d)));
        }

        /// <summary>
        /// Létrehoz egy véletlenszerű szólistát a teljes listából válogatva.
        /// </summary>
        /// <param name="num">Hány szó kerüljön bele?</param>
        public void DoRandomListNumber(int num)
        {
            if (num > wordPairs.Count || num < 1)
            {
                throw new ArgumentException($"1..{wordPairs.Count} tartományon kivüli érték! ({num})");
            }
            narrowedWordPairs = new List<WordPair>();
            List<WordPair> temp = wordPairs.Select(s => s).ToList();

            for (int i = 0; i < num; i++)
            {
                int tempRND = rnd.Next(temp.Count);
                narrowedWordPairs.Add(temp[tempRND]);
                temp.RemoveAt(tempRND);
            }
        }
        /// <summary>
        /// Az eredeti teljes szólistát rendezi angol szavak szerint növekvően.
        /// </summary>
        public void OrderByEnglisWord()
        {
            this.wordPairs = wordPairs.OrderBy(obj => obj.EnglishWord).ToList();
        }
        /// <summary>
        /// Az eredeti teljes szólistát rendezi magyar szavak szerint növekvően.
        /// </summary>
        public void OrderByHungarianWord()
        {
            this.wordPairs = wordPairs.OrderBy(obj => obj.HungarianWord).ToList();
        }
        /// <summary>
        /// A szűkített lista szópárjain végighaldva frissíti az eredeti listában a szópárok tesztadatait.
        /// </summary>
        public void UpdateResultFromNarrowedList()
        {
            foreach (WordPair changedWordPair in narrowedWordPairs)
            {
                WordPair originWordPair =wordPairs.Find(x => x.EnglishWord == changedWordPair.EnglishWord && x.HungarianWord == changedWordPair.HungarianWord);
                originWordPair.UpdateResultFrom(changedWordPair);
            }
        }
        /// <summary>
        /// A szópárok listáját kiírja fájlba
        /// </summary>
        public void WriteContainer()
        {
            File.WriteAllLines(actFileName, wordPairs.Select(obj => obj.LineOfFile).ToList());
        }
    }
}
