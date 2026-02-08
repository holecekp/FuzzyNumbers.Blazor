using System.Globalization;
using Holecek.FuzzyMath.FuzzyNumbers;

namespace FuzzyNumbers.Blazor.Interfaces;

public interface IFuzzyNumberFormatter
{
    char BreakPointsSeparators { get; set; }
    CultureInfo Culture { get; set; }

    string Format(FuzzyNumber? fuzzyNumber);
}
