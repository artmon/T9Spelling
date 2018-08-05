using System;
using Autofac;
using T9Spelling.Business.Interfaces;
using T9Spelling.Common.Extensions;

namespace T9Spelling
{
    internal class Program
    {
        private static ICodesService _codesService;

        private static void Main(string[] args)
        {
            var container = Initializer.Initialize();
            _codesService = container.Resolve<ICodesService>();

            var numberOsCases = GetNumberOfCases();
            var inputs = new string[numberOsCases];

            for (var i = 0; i < numberOsCases; i++)
            {
                inputs[i] = GetInputString();
            }

            for (var i = 0; i < numberOsCases; i++)
            {
                var result = ProcessString(inputs[i], i + 1);
                Console.WriteLine(result);
            }

            Console.ReadLine();
        }

        private static string ProcessString(string s, int number)
        {
            var code = _codesService.GetStringCode(s);

            return $"Case #{number}: {code}";
        }

        private static int GetNumberOfCases()
        {
            int result;

            do
            {
                // Commented it for check system
                // Console.WriteLine("Please enter a number of cases (1 ≤ N ≤ 100): ");
                var inputStr = Console.ReadLine();

                if (int.TryParse(inputStr,  out result) == false)
                {
                    Console.WriteLine("Please enter a correct number. 1 ≤ N ≤ 100.");
                }
            }
            while (result == 0 || result > 100);

            return result;
        }

        private static string GetInputString()
        {
            do
            {
                var result = Console.ReadLine();

                if (result != null && result.OnlyLowercaseLettersAndSpaceCharacters())
                {
                    return result;
                }

                Console.WriteLine(@"Please enter a correct string. It can consist of only lowercase characters a-z and space characters ' '");
            }
            while (true);
        }
    }
}