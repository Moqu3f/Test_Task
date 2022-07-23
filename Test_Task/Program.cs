using System.Text.RegularExpressions;
Console.OutputEncoding = System.Text.Encoding.UTF8;



Console.WriteLine("% = початок/кінець рядку");
Console.WriteLine($"Тест 1\n" +
    $"Вхідні данні : %111   22 32 99 30%\n" +
    $"Очікуваний результат : %111 30 22 32 99%");
Console.WriteLine("Результат");
Console.WriteLine(Order("111 30 22 32 99"));
Console.WriteLine("============");
Console.WriteLine($"Тест 2\n" +
    $"Вхідні данні : %     111   22 32 99 30       %\n" +
    $"Очікуваний результат : %111 30 22 32 99%");
Console.WriteLine("Результат");
Console.WriteLine(Order("111 30 22 32 99"));
Console.WriteLine("============");





static string Order(string input)
{
    //Видалення зайвих пробілів
    var TextNoSpace = Regex.Replace(input, " {2,}", " ");
    List<string> ListNumber = TextNoSpace.Split(' ').ToList();
    
    int[][] WeightNumberArray = new int[ListNumber.Count][];
    for (int i = 0; i < ListNumber.Count(); i++)
        WeightNumberArray[i] = new int[] {WeightNumber(Convert.ToInt32(ListNumber[i])) , Convert.ToInt32(ListNumber[i]) };
    Array.Sort(WeightNumberArray, (a, b) => a[0].CompareTo(b[0]));
    string result = String.Empty;
    foreach (int[] row in WeightNumberArray)
    {
        result += row[1] + " ";
    }
    return result;
}

static int WeightNumber(int n)
{
    var sum = 0;
    while (n > 0)
    {
        sum += n % 10;
        n /= 10;
    }
    return sum;
}