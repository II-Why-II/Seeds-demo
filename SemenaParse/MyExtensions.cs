using MongoDB.Driver;
using System;
using System.Linq;
using SemenaParse.Mongo;

namespace SemenaParse
{
    public static class MyExtensions
    {
        static BaseProductInfo baseProductInfo = new BaseProductInfo();
        public static string RemoveHref(this string str) => str.Replace("https://hiden-adress/", "");
        public static string CategoryToCulture(this string str) => str.Split(" ").First();
        public static string RandomValueString()
        {
            Random random = new Random();
            long idObjAttributeValue = random.Next(111111111, 987654321);
            return idObjAttributeValue.ToString();
        }
        public static string GetSeName(string name)
        {
            string result = "";
            name = name.Replace("&amp;", "-and-").Replace("/", "").Replace("шт", "pcs");
            foreach (var letter in name)
            {
                if (StringsDefault.AlphabetRuToEn.TryGetValue(letter.ToString().ToLower(), out string s))
                    result += s;
                else
                    result += letter;
            }
            return result;
        }
    }
}
