using System.Collections.Generic;
using System.Linq;

namespace MysteriousDataProduct.Architecture
{
    public class StaticFunctions
    {

            // Define characters to strip from the input and do it
            private static readonly string[] StripChars =
            {
                ";", ",", ".", "-", "_", "^", "(", ")", "[", "]", ":", "{", "}", "*", "!", "•", "—", "?", "\"", "~",
                "<", ">", "�", "'", "–", "|", "`", "/", "=", "+",
                "\n", "\t", "\r"
            };

            // Define stopwords
            private static readonly string[] Stopwords =
            {
                "about", "above", "above", "across", "after", "afterwards", "again", "against", "all", "almost",
                "alone", "along", "already", "also", "although", "always", "among", "amongst", "amoungst", "amount",
                "and", "another", "any", "anyhow", "anyone", "anything", "anyway", "anywhere", "are", "around",

                "back", "became", "because","become","becomes", "becoming", "been", "before", "beforehand", "behind",
                "being", "below", "beside", "besides", "between", "beyond", "bill", "both", "bottom", "but",

                "call", "can", "cannot", "cant", "con", "could", "couldnt", "cry",

                "describe", "detail", "done", "down", "due", "during",

                "each", "eight", "either", "eleven", "else", "elsewhere", "empty", "enough", "etc", "even", "ever",
                "every", "everyone", "everything", "everywhere", "except",

                "few", "fifteen", "fify", "fill", "find", "fire", "first", "five", "for", "former", "formerly", "forty",
                "found", "four", "from", "front", "full", "further",

                "get", "give",

                "had", "has", "hasnt", "have", "hence", "her", "here", "hereafter", "hereby", "herein", "hereupon",
                "hers", "herself", "him", "himself", "his", "how", "however", "hundred",

                "inc", "indeed", "interest", "into", "its", "itself",

                "keep",

                "last", "latter", "latterly", "least", "less", "ltd",

                "made", "many", "may", "meanwhile", "might", "mill", "mine", "more", "moreover", "most", "mostly",
                "move", "much", "must", "myself",

                "name", "namely", "neither", "never", "nevertheless", "next", "nine", "nobody", "none", "noone", "nor",
                "not", "nothing", "now", "nowhere",

                "off", "often", "once", "one", "only", "onto", "other", "others", "otherwise", "our", "ours",
                "ourselves", "out", "over", "own",

                "part", "per", "perhaps", "please", "put",

                "rather",

                "same", "see", "seem", "seemed", "seeming", "seems", "serious", "several", "she", "should", "show",
                "side", "since", "sincere", "six", "sixty", "some", "somehow", "someone", "something", "sometime",
                "sometimes", "somewhere", "still", "such", "system",

                "take", "ten", "than", "that", "the", "their", "them", "themselves", "then", "thence", "there",
                "thereafter", "thereby", "therefore", "therein", "thereupon", "these", "they", "thick", "thin", "third",
                "this", "those", "though", "three", "through", "throughout", "thru", "thus", "together", "too", "top",
                "toward", "towards", "twelve", "twenty", "two",

                "under", "until", "upon",

                "very", "via",

                "was", "well", "were", "what", "whatever", "when", "whence", "whenever", "where", "whereafter",
                "whereas", "whereby", "wherein", "whereupon", "wherever", "whether", "which", "while", "whither", "who",
                "whoever", "whole", "whom", "whose", "why", "will", "with", "within", "without", "would",

                "yet", "you", "your", "yours", "yourself", "yourselves"
            };
            

            public static Dictionary<string, int> GenerateSortedWordFrequency(string inputString)
            {
                
                // Create a new Dictionary object
                var dictionary = new Dictionary<string, int>();
                
                if (string.IsNullOrEmpty(inputString)) return dictionary;

                // Convert our input to lowercase
                inputString = inputString.ToLower();

                // Remove special characters
                // Split on spaces into array
                // Remove all words shorter than 3 characters
                // Remove all stopwords
                // Turn into a list
                var wordList =
                    (StripChars.Aggregate(inputString, (current, stripChar) => current.Replace(stripChar, " ")))
                        .Split(' ').Where(w => w.Length >= 3 && !Stopwords.Contains(w)).ToList();

                // Remove stopwords
                //foreach (var stopword in Stopwords) while (wordList.Contains(stopword)) wordList.Remove(stopword);

                // Loop over all over the words in our wordList...
                // If the length of the word is at least three letters...
                // ...check if the dictionary already has the word.
                // If we already have the word in the dictionary, increment the count of how many times it appears
                // Otherwise, if it's a new word then add it to the dictionary with an initial count of 1
                foreach (var word in wordList)
                        dictionary[word] = dictionary.ContainsKey(word) ? dictionary[word] + 1 : 1;

                // Create a dictionary sorted by value (i.e. how many times a word occurs)
                return (from entry in dictionary orderby entry.Value descending select entry)
                    .ToDictionary(pair => pair.Key, pair => pair.Value);
    
            }

    }

}