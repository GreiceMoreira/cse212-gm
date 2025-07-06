using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Create an array of size 'length' to store the results.
        // Use a loop that runs from 1 to 'length'.
        // Start with factor 1, we don't want to multiply by 0. 
        // In each iteration, multiply the given number by the current loop index(this is the factor)
        // Store the result of the multiplication in the array; the index should be (factor - 1)
        // Return the array after the loop is done.

        var results = new double[length];
        for (var factor = 1; factor <= length; ++factor)
        {
            results[factor - 1] = number * factor;
        }

        return results;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // The function needs to receive a list and an amount.
        // Create a new empty list.
        // Create a variable to store the divisor of the list — we take data.Count minus the amount.
        // Insert at the beginning of the new list a first range taken from the data.
        // The first range will have the index as the divisor and the count as the amount.
        // Insert at the end of the new list a second range taken from the data.
        // The second range will have the index as 0 (beginning) and the count as the divisor.
        // Return the new list.
        List<int> result = new List<int>();

        int divisor = data.Count - amount;
        result.InsertRange(0, data.GetRange(divisor, amount));
        result.InsertRange(result.Count, data.GetRange(0, divisor));

        data.Clear();
        data.AddRange(result);

    }
}
