using System;
using System.Text.RegularExpressions;

namespace zadanie_05
{
    public class AnagramChecker
    {
        private static string RemoveNonAlphanumeric(String word)
        {
            if (string.IsNullOrEmpty(word))
                return word;

            return Regex.Replace(word, "[^a-zA-Z0-9]", "");
        }

        private static IDictionary<Char, int> GetCharCountDict(String word)
        {
            IDictionary<char, int> charCount = new Dictionary<char, int>();
            for (int i = 0; i < word.Length; i++)
            {
                char symbol = word[i];
                if (charCount.ContainsKey(word[i]))
                {
                    charCount[symbol] += 1;
                }
                else
                {
                    charCount.Add(symbol, 1);
                }
            }
            return charCount;

        }

        public static bool IsAnagram(String word1, String word2)
        {
            string temp1, temp2;
            temp1 = word1.ToLower();
            temp2 = word2.ToLower();
            temp1 = RemoveNonAlphanumeric(temp1);
            temp2 = RemoveNonAlphanumeric(temp2);
            IDictionary<char, int> temp1Dict = GetCharCountDict(temp1);
            IDictionary<char, int> temp2Dict = GetCharCountDict(temp2);
            foreach (var item in temp2Dict)
            {
                if (temp1Dict.ContainsKey(item.Key))
                {
                    if (temp1Dict[item.Key] != temp2Dict[item.Key])
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            foreach (var item in temp1Dict)
            {
                if (temp2Dict.ContainsKey(item.Key))
                {
                    if (temp2Dict[item.Key] != temp1Dict[item.Key])
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}

