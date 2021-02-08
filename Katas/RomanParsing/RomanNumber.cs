using System.Collections.Generic;
using System.Linq;

namespace RomanParsing
{
    public class RomanNumber
    {
        private static readonly Dictionary<int, string> _arabicToRoman = new()
        {
            {100, "C"},
            {90, "XC"},
            {50, "L"},
            {40, "XL"},
            {10, "X"},
            {9, "IX"},
            {5, "V"},
            {4, "IV"},
            {1, "I"}
        };

        private string _romanString = string.Empty;
        private int? _arabicValue;

        /// <summary>
        ///     Creates a roman number of an arabic value or creates an error if arabic value smaller one
        /// </summary>
        /// <param name="arabicValue"></param>
        /// <returns></returns>
        public static Either<Error, RomanNumber> Of(int arabicValue)
        {
            return arabicValue < 1
                ? new Error(nameof(arabicValue))
                : new RomanNumber(arabicValue);
        }

        /// <summary>
        ///     Creates a roman number of a string or creates an error if the string is not an roman number
        /// </summary>
        /// <param name="romanString"></param>
        /// <returns></returns>
        public static Either<Error, RomanNumber> Of(string? romanString)
        {
            return romanString is null
                ? new Error(nameof(romanString))
                : new RomanNumber(romanString);
        }
        
        // <summary>
        ///     The roman number as arabic value
        /// </summary>
        public int ArabicValue
        {
            get
            {
                var list = ParseStringToRomanStringSequence.ToList();
                _arabicValue ??= ParseStringToRomanStringSequence.Select(x => _arabicToRoman.First(y => y.Value == x).Key).Sum();

                return (int) _arabicValue;
            }
        }

        private RomanNumber(int arabicValue)
        {
            _arabicValue = arabicValue;
        }

        private RomanNumber(string inputString)
        {
            _romanString = inputString;
        }

        private IEnumerable<int> IntSequence
        {
            get
            {
                var arabicValue = ArabicValue;
                foreach (var value in _arabicToRoman.Keys)
                {
                    while (arabicValue >= value)
                    {
                        yield return value;
                        arabicValue -= value;
                    }
                }
            }
        }

        private IEnumerable<string> ParseStringToRomanStringSequence()
        {
            var romanString = _romanString;

            foreach (var key in _arabicToRoman.Values)
            {
                var currentCharLength = key.Length;
                if (romanString.Length >= currentCharLength && romanString.Substring(0, currentCharLength).Equals(key))
                {
                    var charIndex = 0;
                    var lastCharIndex = 0;
                    do
                    {

                        var currentChar = romanString.Substring(charIndex, currentCharLength);
                        charIndex += currentCharLength;
                        if (currentChar.Equals(key))
                        {
                            lastCharIndex = charIndex;
                            yield return currentChar;
                        }
                    } while (charIndex < romanString.Length);

                    romanString = romanString.Substring(lastCharIndex);
                }
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            if (_romanString == string.Empty)
            {
                _romanString = IntSequence.Select(x => _arabicToRoman[x]).Aggregate((concat, str) => $"{concat}{str}");
            }

            return _romanString;
        }
    }
}