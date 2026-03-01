using FuzzyNumbers.Blazor.Interfaces;
using Holecek.FuzzyMath.FuzzyNumbers;
using System.Globalization;

namespace FuzzyNumbers.Blazor.Services;

public class FuzzyNumberFormatter : IFuzzyNumberFormatter
{
    public char BreakPointsSeparators { get; set; } = ',';
    public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

    public string Format(FuzzyNumber? fuzzyNumber)
    {
        if (fuzzyNumber is null)
        {
            return string.Empty;
        }
        else
        {
            var alphaCuts = fuzzyNumber.AlphaCuts;
            List<string> breakpoints = BreakPointsConverter.ConvertFromAlphaCuts(alphaCuts.ToList())
                .Select(breakpoint => breakpoint.ToString(Culture))
                .ToList();

            return string.Join($"{BreakPointsSeparators} ", breakpoints);
        }
    }
}
