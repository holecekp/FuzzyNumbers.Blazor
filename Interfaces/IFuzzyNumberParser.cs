using System.Globalization;
using Holecek.FuzzyMath.FuzzyNumbers;

namespace FuzzyNumbers.Blazor.Interfaces;

public interface IFuzzyNumberParser
{
    char BreakPointsSeparators { get; set; }
    CultureInfo Culture { get; set; }
    bool TryPare(string input, out FuzzyNumber? fuzzyNumber);
}
