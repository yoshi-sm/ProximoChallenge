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
        public void Sort_DifferentAlphabets_ReturnAnswer()
        {
            var list = new List<string>() { "ϡ", "б", "þ", "α" };
            var answer = new List<string>() { "þ", "α", "ϡ", "б" };

            var result = Sorter.Sort(list);

            Assert.That(result, Is.EqualTo(answer));
        }
    }
}
