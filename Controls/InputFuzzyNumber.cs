using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using FuzzyNumbers.Blazor.Interfaces;
using Holecek.FuzzyMath.FuzzyNumbers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace FuzzyNumbers.Blazor.Controls;

public class InputFuzzyNumber : InputBase<FuzzyNumber>
{
   private string _parsingErrorMessage = default!;
    
    [Inject]
    public IFuzzyNumberParser FuzzyNumberParser {get; set; }

    [Inject]
    public IFuzzyNumberFormatter FuzzyNumberFormatter {get; set; }

    public string? CurrentText {get; private set;}

    /// <summary>
    /// Gets or sets the error message used when displaying an a parsing error.
    /// </summary>
    [Parameter] public string ParsingErrorMessage { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the associated <see cref="ElementReference"/>.
    /// <para>
    /// May be <see langword="null"/> if accessed before the component is rendered.
    /// </para>
    /// </summary>
    [DisallowNull] public ElementReference? Element { get; protected set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        
        _parsingErrorMessage = string.IsNullOrEmpty(ParsingErrorMessage)
            ? $"The {{0}} field is not a valid fuzzy number."
            : ParsingErrorMessage;
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "input");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "type", "text");
        if (!string.IsNullOrEmpty(NameAttributeValue))
        {
            builder.AddAttribute(3, "name", NameAttributeValue);
        }
        builder.AddAttribute(4, "class", CssClass);
        builder.AddAttribute(5, "value", CurrentValueAsString);
        builder.AddAttribute(6, "onchange", EventCallback.Factory.CreateBinder<string?>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
        builder.SetUpdatesAttributeName("value");
        builder.AddElementReferenceCapture(7, __inputReference => Element = __inputReference);
        builder.CloseElement();
    }

    protected override string? FormatValueAsString(FuzzyNumber? value)
    {
        if (value != null)
        {
            return FuzzyNumberFormatter.Format(value);
        }
        else
        {
            return string.Empty;
        }
    }

    protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out FuzzyNumber result, [NotNullWhen(false)] out string? validationErrorMessage)
    {
        if (FuzzyNumberParser.TryParse(value, out result))
        {
            Debug.Assert(result != null);
            validationErrorMessage = null;
            return true;
        }
        else
        {
            validationErrorMessage = string.Format(CultureInfo.InvariantCulture, _parsingErrorMessage, DisplayName ?? FieldIdentifier.FieldName);
            return false;
        }
    }
}
