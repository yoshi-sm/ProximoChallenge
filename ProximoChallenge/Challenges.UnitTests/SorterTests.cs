using System;
using Challenges.SorterChallenge;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.UnitTests
{
    internal class SorterTests
    {
        [Test]
        public void Sort_DefaultScenario_ReturnAnswer()
        {
            var list = new List<string>() { "fox", "dog", "snake" };
            var answer = new List<string>() { "snake", "dog", "fox" };

            var result = Sorter.Sort(list);

            Assert.That(result, Is.EqualTo(answer));
        }

        [Test]
        public void Sort_EmptyList_ReturnEmptyList()
        {
            var list = new List<string>();

            var result = Sorter.Sort(list);

            Assert.That(result, Is.EqualTo(new List<string>()));
        }

        [Test]
        public void Sort_OneWord_ReturnAnswer()
        {
            var list = new List<string>() { "fox" };

            var result = Sorter.Sort(list);

            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void Sort_SimilarLongWords_ReturnAnswer()
        {
            var list = new List<string>() { "fox", "dog", "snake", "pneumonoultramicroscopicsilicovolcanoconiosis", 
                "pneumonoultramicroscopicsilicovolcanoconiosi" };
            var answer = new List<string>() { "pneumonoultramicroscopicsilicovolcanoconiosis", "pneumonoultramicroscopicsilicovolcanoconiosi",
                "snake", "dog", "fox"};

            var result = Sorter.Sort(list);

            Assert.That(result, Is.EqualTo(answer));
        }

        [Test]
        public void Sort_WhiteSpaces_ReturnAnswer()
        {
            var list = new List<string>() { "fox", "dog", "snake", " ", "" };
            var answer = new List<string>() { "", " ", "snake", "dog", "fox"};

            var result = Sorter.Sort(list);

            Assert.That(result, Is.EqualTo(answer));
        }

        [Test]
        public void Sort_UpperCase_ReturnAnswer()
        {
            var list = new List<string>() { "ab", "Baa"};
            var answer = new List<string>() { "Baa", "ab" };

            var result = Sorter.Sort(list);

            Assert.That(result, Is.EqualTo(answer));
        }


        [Test]
        public void Sort_EorLevelOneDifferentAlphabets_ReturnAnswer()
        {
            var list = new List<string>() { "ϡ", "б", "þ", "α", "d", "ð", "e", "z" };
            var answer = new List<string>() { "d", "ð", "e", "z", "þ", "α", "ϡ", "б" };

            var result = Sorter.Sort(list);

            Assert.That(result, Is.EqualTo(answer));
        }

        [Test]
        public void Sort_EorLevelTwoDiacriticsOrder_ReturnAnswer()
        {
            var list = new List<string>() { "bàa", "báa", "bãa", "bab", "baa", "báá"  };
            var answer = new List<string>() { "baa", "báa", "bàa", "bãa", "báá", "bab" };

            var result = Sorter.Sort(list);

            Assert.That(result, Is.EqualTo(answer));
        }

        [Test]
        public void Sort_EorLevelThreeUpperCaseDistinction_ReturnAnswer()
        {
            var list = new List<string>() { "PPP", "pPP", "pPp",  "ppp" };
            var answer = new List<string>() { "ppp", "pPp", "pPP", "PPP" };

            var result = Sorter.Sort(list);

            Assert.That(result, Is.EqualTo(answer));
        }

        [Test]
        public void Sort_EorLevelFourWhiteSpaceAndPunctuation_ReturnAnswer()
        {
            var list = new List<string>() { " a" , "  a", "its", "it's" };
            var answer = new List<string>() { "  a", " a", "it's", "its" };

            var result = Sorter.Sort(list);

            Assert.That(result, Is.EqualTo(answer));
        }
    }
}
