# FuzzyStringComparison

FuzzyStringComparison is a .NET library that provides comparison metrics for fuzzy string matching. It contains the following features:

- `GetJaccardDistance` and `CalculateJaccardIndex` methods to calculate the Jaccard distance and Jaccard index between two strings, respectively.
- A `tolerance` parameter for the `GetJaccardDistance` method, allowing the user to specify the maximum acceptable distance before considering the strings a match.
- A `Normalize` method that can be used to normalize a string for fuzzy matching by converting it to lowercase, removing whitespace and punctuation, and removing diacritics (accents).
- An `EqualsNormalized` method that checks if two strings are equal after normalizing them.

## Usage

To use the FuzzyStringComparison library, simply include it in your .NET project and import the `FuzzyStringComparison` namespace. You can then use any of the comparison metrics by calling the appropriate method on a string.

For example, to calculate the Jaccard distance between two strings, you could use the following code:

```csharp
using FuzzyStringComparison;

string sourceStr = "hello world";
string targetStr = "hola mundo";

double jaccardDistance = sourceStr.GetJaccardDistance(targetStr, 0.3);
```

This would calculate the Jaccard distance between the sourceStr and targetStr strings, with a tolerance of 0.3. If the distance is less than or equal to 0.3, the method will return the distance; otherwise, it will return 1 to indicate a non-match.

Similarly, you can use the Normalize method to normalize a string for fuzzy matching:

```csharp
using FuzzyStringComparison;

string str = "Héllo, wörld!";

string normalizedStr = str.Normalize();
```

This would normalize the str string by converting it to lowercase, removing whitespace and punctuation, and removing diacritics (accents), resulting in the string "helloworld".

### License

FuzzyStringComparison is licensed under the [MIT License](LICENSE.md). Feel free to use, modify, and distribute the library for any purpose.
