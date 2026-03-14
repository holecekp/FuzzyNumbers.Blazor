using System;
using System.Drawing;
using Holecek.FuzzyMath.FuzzyNumbers;

namespace FuzzyNumbers.Blazor.Interfaces;

public interface IFuzzyNumberToGraphPointsConverter
{
    List<PointF> Convert(FuzzyNumber fuzzyNumber);
}
