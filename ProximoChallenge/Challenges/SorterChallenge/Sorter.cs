using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.SorterChallenge
{
    public static class Sorter
    {
        public static List<string> Sort(List<string> list)
        {
            List<string> returnList = new();
            List<(string, string)> tupleList = new();

            //Populating the tuple
            foreach (var word in list)
            {
                //Char sorting the words and adding to the tuple list
                var newWord = SortString(word);
                tupleList.Add((word, newWord));
            }
            //Sorting the tuple via the char sorted version of the words
            tupleList.Sort((x, y) => x.Item2.CompareTo(y.Item2));

            //Populating the new List<string> with the unsorted words
            foreach (var tuple in tupleList)
            {
                returnList.Add(tuple.Item1);
            }

            return returnList;
        }

        //Char sorting method
        private static string SortString(string word)
        {
            char[] characters = word.ToCharArray();

            //In this step Upper case should be ignored to avoid turning "aBa" into "Baa" and ruining the next sort
            Array.Sort(characters, (x, y) => char.ToLower(x).CompareTo(char.ToLower(y)));
            return new string(characters);
        }
    }
}
