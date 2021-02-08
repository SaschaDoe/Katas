using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanParsing;

namespace RomanParsingTests
{
    [TestClass]
    public class RomanNumberTests
    {
        [DataTestMethod]
        [TestCategory("Unit")]
        [DynamicData(nameof(GetNumbersOneToHundred), DynamicDataSourceType.Method)]
        public void Of_Int_ShouldBeEqual(int arabicNumber, string romanNumberString)
        {
            RomanNumber.Of(arabicNumber)
                .Match(
                    error => Assert.Fail(),
                    romanNumber => Assert.AreEqual(romanNumberString,romanNumber.ToString()));
        }
        
        [DataTestMethod]
        [TestCategory("Unit")]
        [DynamicData(nameof(GetNumbersOneToHundred), DynamicDataSourceType.Method)]
        public void Of_String_ShouldBeEqual(int arabicNumber, string romanNumberString)
        {
            RomanNumber.Of(romanNumberString)
                .Match(
                    error => Assert.Fail(),
                    romanNumber => Assert.AreEqual(arabicNumber,romanNumber.ArabicValue));
        }

        static IEnumerable<object[]> GetNumbersOneToHundred()
        {
            return new[]
            {
                new object[] {1, "I"},
                new object[] {2, "II"},
                new object[] {3, "III"},
                new object[] {4, "IV"},
                new object[] {5, "V"},
                new object[] {6, "VI"},
                new object[] {7, "VII"},
                new object[] {8, "VIII"},
                new object[] {9, "IX"},
                new object[] {10, "X"},
                new object[] {11, "XI"},
                new object[] {12, "XII"},
                new object[] {13, "XIII"},
                new object[] {14, "XIV"},
                new object[] {15, "XV"},
                new object[] {16, "XVI"},
                new object[] {17, "XVII"},
                new object[] {18, "XVIII"},
                new object[] {19, "XIX"},
                new object[] {20, "XX"},
                new object[] {54, "LIV"},
                new object[] {99, "XCIX"},
                new object[] {100, "C"},
                new object[] {101, "CI"},
            }; 
        }

    }
}