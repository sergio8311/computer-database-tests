using System;
using System.Linq;

namespace ComputerDatabase.Qa.Core.Helpers
{
    //Helper methods to get random string or int values
    public static class CommonFunctions
    {
        private static Random random = new Random();

        public static string GetRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static int GetRandomInt(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
