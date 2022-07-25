using System.Text.RegularExpressions;
Console.OutputEncoding = System.Text.Encoding.UTF8;


Console.WriteLine(Order("45 34 24 108 76 58 64 130 80"));


static string Order(string input) 
    => string.Join(" ", input.Split(' ').OrderBy(q => q.Sum(q => q - '0')).ThenBy(q => q)).ToString();

