using System.Globalization;
using Holecek.FuzzyMath.FuzzyNumbers;
using FuzzyNumbers.Blazor.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace FuzzyNumbers.Blazor.Services;

public class FuzzyNumberParser : IFuzzyNumberParser
{
    public char BreakPointsSeparators { get; set; } = ',';

    public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

    public bool TryParse(string input, [NotNullWhen(true)] out FuzzyNumber? fuzzyNumber)
    {
        if (string.IsNullOrEmpty(input))
        {
            fuzzyNumber = default;
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
            fuzzyNumber = default;
            return false;
        }
    }
}
