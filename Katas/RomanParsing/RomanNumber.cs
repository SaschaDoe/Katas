using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace RomanParsing
{
    public class RomanNumber
    {
        private static readonly Dictionary<int, string> _arabicToRoman = new Dictionary<int, string>
        {
            {5, "V"},
            {4,"IV"},
            {1, "I"}
        };

        private string _romanString = string.Empty;
        private int? _arabicValue;

        public static Either<object, RomanNumber> Create(int arabicValue)
        {
            return arabicValue >= 1
                ? new object()
                : new RomanNumber(arabicValue);
        }

        public static Either<Error, RomanNumber> Create(string? romanString)
        {
            return romanString is null
                ? new Error(nameof(romanString))
                : new RomanNumber(romanString);
        }


        /// <summary>
        /// Constructs a roman number out of an arabic value
        /// </summary>
        /// <param name="arabicValue"></param>
        /// <exception cref="ArgumentException"></exception>
        public RomanNumber(int arabicValue)
        {
            if (arabicValue < 1)
            {
                throw new ArgumentException("No zero or minus values allowed");
            }

            _arabicValue = arabicValue;
        }

        /// <summary>
        /// Constructs a roman number out of an roman number string
        /// </summary>
        /// <param name="inputString"></param>
        public RomanNumber(string inputString)
        {
            _romanString = inputString ?? throw new ArgumentNullException(nameof(inputString));
        }

        /// <summary>
        /// The roman number as arabic value
        /// </summary>
        public int ArabicValue 
        {
            get
            {
                _arabicValue ??= StringSequence.Select(x => _arabicToRoman.First(y => y.Value == x).Key).Sum();

                return (int) _arabicValue;
            } 
        }

        private IEnumerable<int> IntSequence
        {
            get
            {
                var arabicValue = ArabicValue;
                foreach(var value in _arabicToRoman.Keys)
                {
                    while (arabicValue >= value)
                    {
                        yield return value;
                        arabicValue -= value;
                    }
                }
            }
        }

        private IEnumerable<string> StringSequence
        {
            get
            {
                var romanString = _romanString;

                foreach (var key in _arabicToRoman.Values)
                {
                    var currentCharLength = key.Length;
                    if (romanString.Length >= currentCharLength && romanString.Substring(0, currentCharLength).Equals(key))
                    {
                        do
                        { 
                        
                            var currentChar = _romanString.Substring(0,currentCharLength);
                            romanString = romanString.Substring(currentCharLength);
                            yield return currentChar;
                        }while (romanString != string.Empty) ;

                        if (romanString != string.Empty)
                        {
                            break;
                        }
                    }
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