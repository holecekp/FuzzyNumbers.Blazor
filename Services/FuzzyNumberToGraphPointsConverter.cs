using System;
using System.Drawing;
using FuzzyNumbers.Blazor.Interfaces;
using Holecek.FuzzyMath.FuzzyNumbers;

namespace FuzzyNumbers.Blazor.Services;

public class FuzzyNumberToGraphPointsConverter : IFuzzyNumberToGraphPointsConverter
{
    public List<PointF> Convert(FuzzyNumber fuzzyNumber)
    {
        int alphaCutsCount = fuzzyNumber.AlphaCuts.Count;
        var lowerEndpoints = fuzzyNumber.AlphaCuts
            .Select((alphaCut, index) => new PointF
            {
                X = (float)alphaCut.Min,
                Y = GetAlphaForAlphaCutIndex(index, alphaCutsCount),
            });

        var upperEndpoints = fuzzyNumber.AlphaCuts
            .Select((alphaCut, index) => new PointF
            {
                X = (float)alphaCut.Max,
                Y = GetAlphaForAlphaCutIndex(index, alphaCutsCount),
            })
            .Reverse();

        return lowerEndpoints.Concat(upperEndpoints).ToList();
    }

    private static float GetAlphaForAlphaCutIndex(int index, int alphaCutsCount)
    {
        float alphaCutsStep = 1.0f / (float)(alphaCutsCount - 1);
        return index * alphaCutsStep;
    }
}
