using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public  class StringCalculatorKata
    {
        const int MaxNumber = 1000;
        string StartMarker = "//";
        string EndMarker = "\n";
        string OpeningBracket = "[";
        string EndBracket = "[";
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers)||string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }
            var delimiters = listDelimiters(numbers);
            if (numbers.Contains('-'))
                throw new Exception("The negative sign is not allowed");

           numbers = RemoveDelimiterEnd(numbers);
            
            var integerNumbers
                   = numbers
                    .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                    .Where(Stringnumber => Convert.ToInt32(Stringnumber) < MaxNumber)
                    .Select(Stringnumber => Convert.ToInt32(Stringnumber));

            return integerNumbers.Sum();
        }

        private string[] listDelimiters(string numbers)
        {
            string[] defaultDelimiters = new string[] { ",", "\n" };
            int DefaultDelimiterLength = 1;
            if (!numbers.StartsWith(StartMarker))
                return defaultDelimiters;
            
            int DelimiterDataStartPosition = 2;

            int DelDataLength= numbers.IndexOf(EndMarker) - DelimiterDataStartPosition;

            var delimiterData = numbers.Substring(DelimiterDataStartPosition, DelDataLength);
            string DelimiterListSeperator = "][";
            int DelimiterListStart = 1;
            int DelimiterListEnd = 2;
            if (delimiterData.Contains(OpeningBracket) ||
               delimiterData.Contains(EndBracket))
            {

                delimiterData = delimiterData.Substring(DelimiterListStart, delimiterData.Length - DelimiterListEnd);

                return delimiterData.Split(new string[] { DelimiterListSeperator },StringSplitOptions.RemoveEmptyEntries);
            }

            
            var delimiterString = numbers.Substring(DelimiterDataStartPosition, DefaultDelimiterLength);

            return new string[] { delimiterString };
        }

        private string RemoveDelimiterEnd(string numbers)
        {
            if (numbers.StartsWith(StartMarker))
            {
             return numbers.Substring((numbers.IndexOf(EndMarker) + 1));
            }

            return numbers;
        }
    }
}