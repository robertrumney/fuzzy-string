using System;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FuzzyStringComparison
{
    // Static class containing comparison metrics for fuzzy string matching
    public static partial class ComparisonMetrics
    {
        // Method to calculate the Jaccard distance between two strings with an optional tolerance parameter
        public static double GetJaccardDistance(this string sourceStr, string targetStr, double tolerance = 0.1)
        {
            // Call CalculateJaccardIndex method and subtract its result from 1
            double jaccardIndex = CalculateJaccardIndex(sourceStr, targetStr);
            double distance = 1 - jaccardIndex;

            // Return the distance if it is less than or equal to the tolerance, otherwise return 1 to indicate a non-match
            if (distance <= tolerance)
            {
                return distance;
            }
            else
            {
                return 1;
            }
        }

        // Method to calculate the Jaccard index between two strings
        public static double CalculateJaccardIndex(this string sourceStr, string targetStr)
        {
            // Get distinct characters in source and target strings
            IEnumerable<char> sourceChars = sourceStr.Distinct();
            IEnumerable<char> targetChars = targetStr.Distinct();

            // Calculate count of characters in the intersection of the two strings
            int intersectionCount = sourceChars.Intersect(targetChars).Count();
            // Calculate count of characters in the union of the two strings
            int unionCount = sourceChars.Union(targetChars).Count();

            // Convert the count of characters in the intersection of the two strings to double and divide it by the count of characters in the union of the two strings.
            double jaccardIndex = (double) intersectionCount / unionCount;
            return jaccardIndex;
        }

        // Method to normalize a string for fuzzy matching
        public static string Normalize(this string str)
        {
            // Convert string to lowercase
            string normalizedStr = str.ToLower();
            // Remove whitespace
            normalizedStr = Regex.Replace(normalizedStr, @"\s+", "");
            // Remove punctuation
            normalizedStr = Regex.Replace(normalizedStr, @"\p{P}", "");
            // Normalize string by decomposing diacritics
            normalizedStr = normalizedStr.Normalize(NormalizationForm.FormD);
            // Remove diacritics (accents)
            normalizedStr = Regex.Replace(normalizedStr, @"\p{M}", "");

            return normalizedStr;
        }

        // Method to check if two strings are equal after normalizing them for fuzzy matching
        public static bool EqualsNormalized(this string sourceStr, string targetStr)
        {
            // Normalize source and target strings
            string normalizedSource = sourceStr.Normalize();
            string normalizedTarget = targetStr.Normalize();

            // Compare normalized strings for equality
            return normalizedSource.Equals(normalizedTarget);
        }
    }
}
