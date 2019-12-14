﻿using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Net;
using System.IO;
using System.Text;
using System.Linq;



namespace Wordreader
{
    class Program
    {
        static void Main(string[] args)
        {
            //Opcja zapisywania wyników z pozycji 2-5 do pliku


            var standardOutput = Console.Out;
            //streamwriter.AutoFlush = true;
            //Menu główne, działające w nieskończonej pętli


            // case 1
            void downloadFileOption()
            {
                Console.WriteLine("Pobieranie pliku.");
                WebClient DownloadFile = new WebClient();

                try
                {


                    DownloadFile.DownloadFile("https://tinyurl.com/rugx6sb", Path.Combine(Environment.CurrentDirectory, "X.txt"));

                    Console.WriteLine("Plik został pobrany pomyślnie");
                }
                catch (WebException e)
                {
                    Console.WriteLine("Błąd pobierania. Sprawdź połączenie z internetem.");
                }
            }

            // case 2

            int letterCounter()
            {
                string path = Path.Combine(Environment.CurrentDirectory, "X.txt");
                Console.WriteLine("Liczenie liter występujących w pliku tekstowym.");
                if (File.Exists(path) == true)
                {
                    string text = File.ReadAllText(path, Encoding.UTF8);
                    int count = text.Count(char.IsLetter);
                    //using (var streamwriter = new StreamWriter(filestream))
                    //{
                    //    Console.SetOut(streamwriter);
                    ////    Console.WriteLine("Ilość liter występująca w tekście: " + count);
                    //    Console.SetOut(standardOutput);
                    //}
                    Console.WriteLine("Ilość liter występująca w tekście: " + count);
                    return count;
                    //Console.WriteLine("Wprowadź dowolny klawisz, aby kontynuować.");
                    //Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                    return 0;
                }
            }

            int wordsCounter()
            {
                string words = Path.Combine(Environment.CurrentDirectory, "X.txt.");

                if (File.Exists(words) == true)
                {
                    char[] separators = { ' ', ',', '.', ':', ';', '?', '!', '-', '=', '+', '-', '*', '/' };


                    int wordsCount = words.Split(separators, StringSplitOptions.RemoveEmptyEntries).Length;
                    //using (var streamwriter = new StreamWriter(filestream))
                    //{
                    //    Console.SetOut(streamwriter);
                    //    Console.WriteLine("Liczba wyrazów występujących w tekście: " + wordsCount);
                    //   Console.SetOut(standardOutput);
                    //}
                    Console.WriteLine("Liczba wyrazów występujących w tekście: " + wordsCount);
                    return wordsCount;
                    Console.WriteLine("Wprowadź dowolny klawisz, aby kontynuować.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                    return 0;
                }
            }

            int punctuationsCounter()
            {
                string punctuation = Path.Combine(Environment.CurrentDirectory, "X.txt.");
                if (File.Exists(punctuation) == true)
                {
                    string text = File.ReadAllText(punctuation, Encoding.UTF8);
                    int punctuationCount = text.Count(predicate: char.IsPunctuation);
                    //if (menuOption == 7)
                    //   using (var streamwriter = new StreamWriter(filestream))
                    //  {
                    //      Console.SetOut(streamwriter);
                    //     Console.WriteLine("Liczba znaków interpunkcyjnych występujących w tekście: " + punctuationCount);
                    //     Console.SetOut(standardOutput);
                    //  }
                    Console.WriteLine("Liczba znaków interpunkcyjnych występujących w tekście: " + punctuationCount);
                    return punctuationCount;
                    Console.WriteLine("Wprowadź dowolny klawisz, aby kontynuować.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                    return 0;
                }
            }

            int sentecesCounter()
            {
                string sentence = Path.Combine(Environment.CurrentDirectory, "X.txt.");
                if (File.Exists(sentence) == true)
                {

                    var sentenceCount = sentence.Split(new char[] { ',', '.', '?', '!', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    var count = sentence.Length;
                    //using (var streamwriter = new StreamWriter(filestream))
                    //{
                    //    Console.SetOut(streamwriter);
                    //    Console.WriteLine("Liczba zdań występujących w tekście: " + count.ToString());
                    //    Console.SetOut(standardOutput);
                    //}
                    Console.WriteLine("Liczba zdań występujących w tekście: " + count.ToString());
                    return count;
                    Console.WriteLine("Wprowadź dowolny klawisz, aby kontynuować.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                    return 0;

                }
            }

            void raportGenerate()
            {
                string path = Path.Combine(Environment.CurrentDirectory, "X.txt");

                Console.WriteLine("Generacja raportu o występowaniu liter.");

                if (File.Exists(path) == true)
                {
                    string text = File.ReadAllText(path, Encoding.UTF8).ToString();

                    char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
                    int alphabetLength = alphabet.Length - 1;
                    int i = 0;

                    while (i <= alphabetLength)
                    {
                        int letterCount = 0;
                        foreach (char c in text)
                        {
                            if (c == alphabet[i])
                            {
                                letterCount++;
                            }
                        }
                        Console.WriteLine("W tekście litera " + alphabet[i] + " występuje " + letterCount + " razy.");
                        i++;
                    }

                    Console.WriteLine("Wprowadź dowolny klawisz, aby kontynuować.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Plik nie istnieje.");
                }
            }

            void saveAllData(int letterCount, int wordsCount, int punctuationsCount, int sentecesCount)
            {
                var filestream = new FileStream("statystyki.txt", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamWriter sw = new StreamWriter(filestream);
                sw.WriteLine("liczba liter: " + letterCount);
                sw.WriteLine("liczba slow: " + wordsCount);
                sw.WriteLine("liczba znakow interpunkcyjnych: " + punctuationsCount);
                sw.WriteLine("liczba zdan: " + sentecesCount);
                sw.Close();
            }

            int continueProgram = 1;
            int saveLetterCount = new int();
            int saveWordsCount = new int();
            int savePunctuationsCount = new int();
            int saveSentecesCount = new int();

            while (continueProgram == 1)
            {

                Console.WriteLine("1. Pobierz plik z internetu.");
                Console.WriteLine("2. Zlicz liczbę liter w pobranym pliku.");
                Console.WriteLine("3. Zlicz liczbę wyrazów w pliku.");
                Console.WriteLine("4. Zlicz liczbę znaków interpunkcyjnych w pliku.");
                Console.WriteLine("5. Zlicz liczbę zdań w pliku.");
                Console.WriteLine("6. Wygeneruj raport o użyciu liter(A - Z).");
                Console.WriteLine("7. Zapisz statystyki z punktów 2 - 5 do pliku statystyki.txt.");
                Console.WriteLine("8. Wyjście z programu.");
                int menuOption = Convert.ToInt32(Console.ReadLine());

                //Opcja wyjścia z aplikacji

                switch (menuOption)
                {
                    case 1:
                        downloadFileOption();
                        break;
                    case 2:
                        saveLetterCount = letterCounter();
                        break;
                    case 3:
                        saveWordsCount = wordsCounter();
                        break;
                    case 4:
                        savePunctuationsCount = punctuationsCounter();
                        break;
                    case 5:
                        saveSentecesCount = sentecesCounter();
                        break;
                    case 6:
                        raportGenerate();
                        break;
                    case 7:
                        saveAllData(saveLetterCount, saveWordsCount, savePunctuationsCount, saveSentecesCount);
                        break;
                    case 8:
                        continueProgram = 0;
                        break;
                    default:
                        break;
                }
            }
            //Opcja pobierania pliku

            //Opcja zliczania liter występujących w pobranym pliku

            //Opcja liczenia ilości wyrazów w pobranym pliku

            //Opcja liczenia ilości znaków interpunkcyjnych w pobranym pliku

            //Opcja liczania ilości zdań w pobranym pliku

            //Generacja raportu o występowaniu każdej z liter


        }
    }
}

