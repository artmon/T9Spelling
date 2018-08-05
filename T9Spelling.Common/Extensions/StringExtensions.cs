using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace T9Spelling.Common.Extensions
{
    public static class StringExtensions
    {
        [NotNull]
        private static readonly Regex OnlyLowercaseLettersAndSpaceCharactersRegex = new Regex(@"^[a-z\s]+$");

        public static bool OnlyLowercaseLettersAndSpaceCharacters([NotNull] this string s)
        {
            return OnlyLowercaseLettersAndSpaceCharactersRegex.IsMatch(s);
        }
    }
}