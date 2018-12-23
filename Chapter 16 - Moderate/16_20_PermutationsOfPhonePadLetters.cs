using NUnit.Framework;
using System.Collections.Generic;

namespace Chapter_16___Moderate
{
    class _16_20_PermutationsOfPhonePadLetters
    {
        public List<string> GetAllPossibleWords(string phoneNumber)
        {
            List<string> results = new List<string>();
            Dictionary<char, List<char>> charGroupingMap = GetLetterGroupingDict();

            GetPerms(results, "", 0, phoneNumber, charGroupingMap);

            return results;
        }

        void GetPerms(List<string> results, string prefix, int index, string phoneNumber, Dictionary<char, List<char>> charGroupingMap)
        {
            if (index == phoneNumber.Length)
            {
                results.Add(prefix);
                return;
            }

            char currChar = phoneNumber[index];
            List<char> currGroupForNumber = charGroupingMap[currChar];
            foreach (char ch in currGroupForNumber)
            {
                string newPrefix = prefix + ch;
                GetPerms(results, newPrefix, index + 1, phoneNumber, charGroupingMap);
            }
        }

        Dictionary<char, List<char>> GetLetterGroupingDict()
        {
            Dictionary<char, List<char>> dict = new Dictionary<char, List<char>>();
            List<char> list2 = new List<char>() { 'a', 'b', 'c' };
            List<char> list3 = new List<char>() { 'd', 'e', 'f' };
            List<char> list4 = new List<char>() { 'g', 'h', 'i' };
            List<char> list5 = new List<char>() { 'j', 'k', 'l' };
            List<char> list6 = new List<char>() { 'm', 'n', 'o' };
            List<char> list7 = new List<char>() { 'p', 'q', 'r', 's' };
            List<char> list8 = new List<char>() { 't', 'u', 'v' };
            List<char> list9 = new List<char>() { 'w', 'x', 'y', 'z' };

            dict.Add('2', list2);
            dict.Add('3', list3);
            dict.Add('4', list4);
            dict.Add('5', list5);
            dict.Add('6', list6);
            dict.Add('7', list7);
            dict.Add('8', list8);
            dict.Add('9', list9);

            return dict;
        }
    }

    public class _16_20_PermutationsOfPhonePadLettersTests
    {
        readonly _16_20_PermutationsOfPhonePadLetters _practice = new _16_20_PermutationsOfPhonePadLetters();

        [TestCase("234", 4)]
        public void _16_20_PermutationsOfPhonePadLetters_WithTestCases_ShouldReturnExpected(string phoneNumber, int expected)
        {
            List<string> results = new List<string>();

            results = _practice.GetAllPossibleWords(phoneNumber);

            Assert.AreEqual(expected, results.Count);
        }
    }
}
