using System.ComponentModel.DataAnnotations;
using Holecek.FuzzyMath.FuzzyNumbers;

namespace FuzzyNumbers.Blazor.Models;

public class FuzzyArithmeticsFormModel
{
    [Required]
    public FuzzyNumber FirstFuzzyNumber { get; set; } = new FuzzyNumber(1, 2, 3);

    [Required]
    public FuzzyNumber SecondFuzzyNumber { get; set; } = new FuzzyNumber(2, 3, 4, 5);
}