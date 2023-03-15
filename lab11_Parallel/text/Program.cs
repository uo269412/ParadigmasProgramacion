﻿using System;
using System.IO;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TPP.Laboratory.Concurrency.Lab11 {

    class Program {


        static void Main(string[] args) {
            String[] text = Processing.ReadTextFileArrayVersion(@"..\..\..\clarin.txt");
            Stopwatch crono = new Stopwatch();
            //crono.Start();
            //CountWordsSequential(text);
            //crono.Stop();
            //Console.WriteLine("\nSequential Version -> Elapsed time: {0:N} milliseconds.", crono.ElapsedMilliseconds);
            crono.Start();
            CountWordsParallel(text);
            crono.Stop();
            Console.WriteLine("\nParallel Version -> Elapsed time: {0:N} milliseconds.", crono.ElapsedMilliseconds);
            //String text = Processing.ReadTextFile(@"..\..\..\clarin.txt");
            //string[] words = Processing.DivideIntoWords(text);
            //MeasureSequentialVSThreads(text, words);     //Implemented in class, transformed into a method
        }


        public static void ShowResults(int punctuationMarks, string[] shortestWords, string[] longestWords,
                                       string[] wordsAppearFewerTimes, int lowestOccurrence,
                                       string[] wordsAppearMoreTimes, int greatestOccurrence) {
            const int maxNumberOfElementsToShow = 20;

            Console.WriteLine("> There were {0} punctuation marks. ", punctuationMarks);

            Console.Write("> {0} shortest words: ", shortestWords.Count());
            Show(shortestWords, Console.Out, maxNumberOfElementsToShow);
            Console.WriteLine();

            Console.Write("> {0} longest words: ", longestWords.Count());
            Show(longestWords, Console.Out, maxNumberOfElementsToShow);
            Console.WriteLine();

            Console.Write("> {0} words appeared fewer times ({1}): ", wordsAppearFewerTimes.Count(), lowestOccurrence);
            Show(wordsAppearFewerTimes, Console.Out, maxNumberOfElementsToShow);
            Console.WriteLine();

            Console.Write("> {0} words appreared more times ({1}): ", wordsAppearMoreTimes.Count(), greatestOccurrence);
            Show(wordsAppearMoreTimes, Console.Out, maxNumberOfElementsToShow);
            Console.WriteLine();
        }

        private static void Show<T>(IEnumerable<T> collection, TextWriter stream, int maxNumberOfElements) {
            int i = 0;
            foreach (T element in collection) {
                stream.Write(element);
                i = i + 1;
                if (i == maxNumberOfElements) {
                    stream.Write("...");
                    break;
                }
                if (i < collection.Count())
                    stream.Write(", ");
            }
        }

        private static void MeasureSequentialVSThreads(String text, string[] words)
        {
            Stopwatch crono = new Stopwatch();
            crono.Start();
            int punctuationMarks = Processing.PunctuationMarks(text);
            var longestWords = Processing.LongestWords(words);
            var shortestWords = Processing.ShortestWords(words);
            int greatestOccurrence, lowestOccurrence;
            var wordsAppearMoreTimes = Processing.WordsAppearMoreTimes(words, out greatestOccurrence);
            var wordsAppearFewerTimes = Processing.WordsAppearFewerTimes(words, out lowestOccurrence);
            crono.Stop();

            ShowResults(punctuationMarks, shortestWords, longestWords, wordsAppearFewerTimes, lowestOccurrence,
                wordsAppearMoreTimes, greatestOccurrence);

            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", crono.ElapsedMilliseconds);

            //THREAD
            Stopwatch crono2 = new Stopwatch();
            crono2.Start();
            Parallel.Invoke(
            () => punctuationMarks = Processing.PunctuationMarks(text),
            () => longestWords = Processing.LongestWords(words),
            () => shortestWords = Processing.ShortestWords(words),
            () => wordsAppearMoreTimes = Processing.WordsAppearMoreTimes(words, out greatestOccurrence),
            () => wordsAppearFewerTimes = Processing.WordsAppearFewerTimes(words, out lowestOccurrence)
            );
            crono2.Stop();

            ShowResults(punctuationMarks, shortestWords, longestWords, wordsAppearFewerTimes, lowestOccurrence,
                wordsAppearMoreTimes, greatestOccurrence);

            Console.WriteLine("\nThread -> Elapsed time: {0:N} milliseconds.", crono2.ElapsedMilliseconds);
        }


        private static void CountWordsSequential(String[] text)
        {
            var lines = Processing.SequentialDivideIntoWords(text);
            var dictionary = Processing.WordsCountSequential(lines);
            Processing.PrintWordCounter(dictionary);

        }
        private static void CountWordsParallel(String[] text)
        {
            var lines = Processing.SequentialDivideIntoWords(text);
            var dictionary = Processing.WordsCountParallel(lines);
            Processing.PrintWordCounter(dictionary);
        }
    }
}
