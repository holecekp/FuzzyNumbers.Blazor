using System.Globalization;
using Holecek.FuzzyMath.FuzzyNumbers;
using FuzzyNumbers.Blazor.Interfaces;

namespace FuzzyNumbers.Blazor.Services;

public class FuzzyNumberParser : IFuzzyNumberParser
{
    public char BreakPointsSeparators { get; set; } = ',';

    public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

    public bool TryPare(string input, out FuzzyNumber? fuzzyNumber)
    {
        fuzzyNumber = null;

        if (string.IsNullOrEmpty(input))
        {
            return false;
        }

        try
        {
            List<double> breakPoints = input
                .Split(BreakPointsSeparators, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => double.Parse(s.Trim(), Culture))
                .ToList();

            var alphaCuts = BreakPointsConverter.ConvertToAlphaCuts(breakPoints);
            fuzzyNumber = new FuzzyNumber(alphaCuts);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
