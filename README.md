#  Blazor WebAssembly project demonstrating the usage of FuzzyMath library
[FuzzyMath](https://github.com/holecekp/FuzzyMath) is a free open-source library for .NET. This repository contains a simple project that demonstrates its usage in practice. The site consists of a single page that let the user enter two fuzzy number in text boxes and select one of the arithmetic operations (addition, subtraction, multiplication, division).
The entered fuzzy numbers are then parsed and validated, the operations is applied on them, and the result is visualized in form of a graph The drawing itself is performed by [Chart.js](https://www.chartjs.org/) JavaScript library. However, it could be simply replaced by any other drawing library of your choice.

This sample isn't focused just on **calculations with fuzzy numbers** themselves. It focuses on **parsing the input from the user** and on the **visual presentations of the results**. Both of them are essential for using calculations with fuzzy numbers in practice.

# See it in action
You can try the application live at: [fuzzymath.holecekp.eu](https://fuzzymath.holecekp.eu)

<img width="400" alt="Screenshot of the site where this project is running" src="https://github.com/user-attachments/assets/ae44cd08-c622-4371-ab5d-bf61941da965" />

# Parsing fuzzy numbers form text, or formatting them as a text
The `Services` folder contains `FuzzyNumberParser` class that parses a fuzzy number from a string. The particular implementation expects a list of break points separated by a comma. The breakpoints uses a period
as the decimal numbers separator. A valid fuzzy number has to have at least one break point and all the break points needs to be in an ascending order.

Examples of the user input:
- 1 - a fuzzy number representing a **real number** 1.
- 1, 2 - a fuzzy number representing a **closed interval** [1, 2]
- 1, 2, 3 - a **triangular fuzzy number** (1, 2, 3)
- 1, 2, 3, 4 - a **trapezoidal fuzzy number** (1, 2, 3, 4)
- 1.4, 2.5, 3,6, 4.7 - a trapezoidal fuzzy number with decimal break points (1.4, 2.5, 3,6, 4.7)
- 1, 2, 3, 4, 5 - a **pentagonal fuzzy number**
- and so on... More break points can be used to for representing a more complex types of fuzzy numbers.

The `Services` folder contains also `FuzzyNumberFormatter` class that takes care of the opposite task - formatting a fuzzy number as a text in the form of the break points list.

Both classes implement `IFuzzyNumberParser` interface, and `IFuzzyNumberFormatter` interface respectivelly. The particular implementation of these interfaces is registered in DI in `Program.cs`:
```csharp
builder.Services.AddSingleton<IFuzzyNumberFormatter, FuzzyNumberFormatter>();
builder.Services.AddSingleton<IFuzzyNumberParser, FuzzyNumberParser>();
```

This ensures that the same textual representation is used throughout the whole site. If you prefer a different textual representation of fuzzy numbers, just modify, or create your own implementation
for these two interfaces and register them in this single point of the code.

# Blazor component for entering fuzzy numbers
There is `InputFuzzyNumber` Blazor component in the `Controls` folder. It renders as a text box for entering a fuzzy number. It takes care of the parsing and validation of the user input.
The beahvior and usage is the same as for the standard Blazor `InputNumber`, `InputDate`, and other input components.

The component uses `IFuzzyNumberParser` and `IFuzzyNumberFormatter` registered in DI. Register a different implementation if you expect the users to enter fuzzy numbers in a different format.

# Presentation of the results in the form of a graph
When the user click on a button, the result of the selected arithmetic operation is calculated, and both the inputs and the resulting fuzzy numbers are drawn in a graph.

To achieve this, `FuzzyNumberToGraphPointsConverter` class in the `Services` folder converts a fuzzy number to a list of points that needs to be drawn. This can be then easily performed
by a graph drawing library of your choice. This site uses [Chart.js](https://www.chartjs.org/) JavaScript library. However, swapping to a different library should be an easy task.

The methods for drawing itself can be found in `index.html`. The `drawGraph` JavaScript function initializes the graph and draw the fuzzy numbers in it. The `updateGraphData` JavaScript
function is then used to update the fuzzy numbers (specifically the list of points for them) that should be drawn in an already initialized graph. Modify these functions if you want
a different number of fuzzy numbers in the graph, different colors or labels.
