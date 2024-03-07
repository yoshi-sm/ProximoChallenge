using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
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
                //Char sorting the words
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
            char[] characters = word.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}
