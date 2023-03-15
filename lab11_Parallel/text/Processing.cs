using System;
using System.IO;
using System.Threading;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TPP.Laboratory.Concurrency.Lab11 {

    public static class Processing {

        public static String ReadTextFile(string fileName) {
            using (StreamReader stream = File.OpenText(fileName)) {
                StringBuilder text = new StringBuilder();
                string line;
                while ((line = stream.ReadLine()) != null) {
                    text.AppendLine(line);
                }
                return text.ToString();
            }
        }

        public static String[] ReadTextFileArrayVersion(string fileName)
        {
            List<String> result = new List<String>();
            using (StreamReader stream = File.OpenText(fileName))
            {
                StringBuilder text = new StringBuilder();
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    result.Add(line);
                }
                return result.ToArray();
            }
        }

        public static string[] DivideIntoWords(String text) {
            return text.Split(new char[] { ' ', '\r', '\n', ',', '.', ';', ':', '-', '!', '¡', '¿', '?', '/', '«', 
                                            '»', '_', '(', ')', '\"', '*', '\'', 'º', '[', ']', '#' },
                StringSplitOptions.RemoveEmptyEntries);
        }

        public static string[] SequentialDivideIntoWords(String[] text)
        {
            char[] symbols = new char[] { ' ', '\r', '\n', ',', '.', ';', ':', '-', '!', '¡', '¿', '?', '/', '«',
                                            '»', '_', '(', ')', '\"', '*', '\'', 'º', '[', ']', '#' };
            List<String> result = new List<String>();
            foreach(var line in text) 
            {
                string[] newLine = line.Split(symbols, StringSplitOptions.RemoveEmptyEntries);
                foreach(string element in newLine)
                {   if (element != " ")
                    {
                        result.Add(element);
                    }
                }
            }
            return result.ToArray();
        }

        public static string[] ParallelDivideIntoWords(String[] text)
        {
            char[] symbols = new char[] { ' ', '\r', '\n', ',', '.', ';', ':', '-', '!', '¡', '¿', '?', '/', '«',
                                            '»', '_', '(', ')', '\"', '*', '\'', 'º', '[', ']', '#' };
            List<String> result = new List<String>();
            Parallel.ForEach(text, line =>
            {
                string[] newLine = line.Split(symbols, StringSplitOptions.RemoveEmptyEntries);
                Parallel.ForEach(newLine, element =>
                {
                    result.Add(element);
                });
            });
            return result.ToArray();
        }

        public static Dictionary<String, int> WordsCountParallel(string[] words)
        {
            Dictionary<String, int> result = new Dictionary<string, int>();
            var wordsAndOccurrences = words.AsParallel()
                .GroupBy(word => word.ToLower()) 
                .Select(group => new { Word = group.Key, Occurrences = group.Count() }) 
                .OrderByDescending(pair => pair.Occurrences); 
            Parallel.ForEach(wordsAndOccurrences, word =>
            {
                result.Add(word.Word, word.Occurrences);
            });
            return result;
        }

        public static Dictionary<String, int> WordsCountSequential(string[] words)
        {
            Dictionary<String, int> result = new Dictionary<string, int>();
            var wordsAndOccurrences = words
                .GroupBy(word => word.ToLower())
                .Select(group => new { Word = group.Key, Occurrences = group.Count() })
                .OrderByDescending(pair => pair.Occurrences);
            foreach( var word in wordsAndOccurrences)
            {
                result.Add(word.Word, word.Occurrences);
            }
            return result;
        }

        public static void PrintWordCounter(Dictionary<String, int> dictionary)
        {
            Parallel.ForEach(dictionary, instance =>
            {
                Console.Out.WriteLine("The word: {0} is repeated = {1} times", instance.Key, instance.Value);
            });
        }

        public static int PunctuationMarks(string text) {
            return text.Count(character => character == '.' || character == ',' || character == ';' || character == ':'); 
        }

        public static string[] LongestWords(string[] words) {
            // We use Linq higher-order functions
            return words
                .GroupBy(word => word.Length)  // words are classified in groups of words with the same length
                .OrderByDescending(group => group.Key)  // the groups are ordered by descending length
                .Select(group => group.Distinct()) // repeated words per group are erased
                .First() // we take the first group (words with the greatest length)
                .ToArray(); // and convert it to an array
        }

        public static string[] ShortestWords(string[] words) {
            return words
                .GroupBy(word => word.Length) // words are classified in groups of words with the same length
                .OrderBy(grupo => grupo.Key) // the groups are ordered by ascending length
                .Select(grupo => grupo.Distinct()) // repeated words per group are erased
                .First() // we take the first group (words with the smallest length)
                .ToArray(); // and convert it to an array

        }

        public static string[] WordsAppearFewerTimes(string[] words, out int occurrence) {
            var wordsAndOccurrences = words
                .GroupBy(word => word.ToLower()) // words are grouped by its lowercase representation
                .Select(group => new { Word = group.Key, Occurrences = group.Count() }) // we convert it in a list of pairs {Word, Occurrence}
                .OrderBy(pair => pair.Occurrences); // pairs are sorted ascending by occurrences
            // We take lowest occurrence from the first pair 
            int lowestOccurrence = occurrence = wordsAndOccurrences.First().Occurrences;
            // We return all the words whose occurrences are the same to the lowest one
            return wordsAndOccurrences
                .Where(pair => pair.Occurrences == lowestOccurrence) // pairs are filtered with the lowest number of occurrences
                .Select(pair => pair.Word)  // we take the lowercase word
                .ToArray(); // and convert it to an array
        }

        public static string[] WordsAppearMoreTimes(string[] words, out int occurrence) {
            var wordsAndOccurrences = words
                .GroupBy(word => word.ToLower()) // words are grouped by its lowercase representation
                .Select(group => new { Word = group.Key, Occurrences = group.Count() }) // we convert it in a list of pairs {Word, Occurrence}
                .OrderByDescending(pair => pair.Occurrences); // pairs are sorted descending by occurrences
            // We take greatest occurrence from the first pair 
            int greatestOccurrence = occurrence = wordsAndOccurrences.First().Occurrences;
            // We return all the words whose occurrences are the same to the greatest one
            return wordsAndOccurrences
                .Where(pair => pair.Occurrences == greatestOccurrence) // pairs are filtered with the greatest number of occurrences
                .Select(pair => pair.Word)  // we take the lowercase word
                .ToArray(); // and convert it to an array
        }

    }

}
