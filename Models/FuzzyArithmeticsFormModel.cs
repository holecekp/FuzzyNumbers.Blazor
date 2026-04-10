using System.ComponentModel.DataAnnotations;
using Holecek.FuzzyMath.FuzzyNumbers;

namespace FuzzyNumbers.Blazor.Models;

public enum ArithmeticOperation
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

public class FuzzyArithmeticsFormModel
{
    [Required]
    public FuzzyNumber FirstFuzzyNumber { get; set; } = new FuzzyNumber(1, 2, 3);

    [Required]
    public FuzzyNumber SecondFuzzyNumber { get; set; } = new FuzzyNumber(2, 3, 4, 5);

    public ArithmeticOperation ArithmeticOperation { get; set; } = ArithmeticOperation.Addition;

    public string ArithmeticOperationSign => ArithmeticOperation switch
    {
        ArithmeticOperation.Addition => "+",
        ArithmeticOperation.Subtraction => "-",
        ArithmeticOperation.Multiplication => "⋅",
        ArithmeticOperation.Division => "/",
        _ => throw new ArgumentOutOfRangeException()
    };

    public string ArithmeticOperationFormula => $"A{ArithmeticOperationSign}B";
}