using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using T9Spelling.Business.Interfaces;
using T9Spelling.Common.Extensions;

namespace T9Spelling.Business.Implementations
{
    internal class CodesService : ICodesService
    {
        [NotNull]
        private readonly Dictionary<char, int> _codesOfLetters = new Dictionary<char, int>()
        {
            { 'a', 2 },
            { 'b', 22 },
            { 'c', 222 },
            { 'd', 3 },
            { 'e', 33 },
            { 'f', 333 },
            { 'g', 4 },
            { 'h', 44 },
            { 'i', 444 },
            { 'j', 5 },
            { 'k', 55 },
            { 'l', 555 },
            { 'm', 6 },
            { 'n', 66 },
            { 'o', 666 },
            { 'p', 7 },
            { 'q', 77 },
            { 'r', 777 },
            { 's', 7777 },
            { 't', 8 },
            { 'u', 88 },
            { 'v', 888 },
            { 'w', 9 },
            { 'x', 99 },
            { 'y', 999 },
            { 'z', 9999 },
            { ' ', 0 },
        };

        [NotNull]
        public string GetStringCode([NotNull] string s)
        {
            if (s.OnlyLowercaseLettersAndSpaceCharacters() == false)
            {
                return string.Empty;
            }

            var result = new StringBuilder();

            var lastDigit = -1;

            foreach (var c in s)
            {
                var code = GetCode(c);
                var currentLastDigit = code % 10;

                if (lastDigit == currentLastDigit)
                {
                    result.Append(' ');
                }
                else
                {
                    lastDigit = currentLastDigit;
                }

                result.Append(code);
            }

            return result.ToString();
        }

        private int GetCode(char symbol)
        {
            if (_codesOfLetters.ContainsKey(symbol))
            {
                return _codesOfLetters[symbol];
            }

            return -1;
        }
    }
}